using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyModel;
using Snake.API.Data.Abstraction;
using System.Reflection;

internal class Program
{
    private static Assembly[] assemblies;
    private static void Main(string[] args)
    {
        assemblies = LoadAppDependencies();
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddFluentValidation(options =>
        {
            options.RegisterValidatorsFromAssemblies(assemblies);
        });

        builder.Services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblies(assemblies);
        });

        builder.Services.Scan(scan => scan.FromAssemblies(assemblies)
        .AddClasses(type =>
            type.AssignableTo(typeof(IRepository<>)))
            .AsImplementedInterfaces().WithScopedLifetime() /*ha valamit ugy hozunk letre mint singleton, hogy ne ugyanaz a repository eljen vegig?*/
        );

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    private static Assembly[] LoadAppDependencies()
    {
        var context = DependencyContext.Default;

        return context.RuntimeLibraries.SelectMany(library => library.GetDefaultAssemblyNames(context))
            .Where(assembly => assembly.FullName.Contains("Snake.API"))
            .Select(Assembly.Load)
            .ToArray();
    }
}