using Catalog_Project.Common.MVVM;
using Catalog_Project.Model;
using Catalog_Project.Model.DBContext;
using Catalog_Project.View;
using Catalog_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Catalog_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.Initialize();
            this.InitializeData();
            this.OpenMainWindow();
        }

        private void Initialize()
        {
            ViewService.RegisterView(typeof(MainWindowViewModel), typeof(MainWindow));
            ViewService.RegisterView(typeof(VehicleTypeViewModelt), typeof(VehicleTypeWindow));
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();

            ViewService.AddMainWindowToOpened(mainWindowViewModel, mainWindow);
            ViewService.ShowDialog(mainWindowViewModel);

        }

        private void InitializeData()
        {
            try
            {
                DBInitializer dbinit = new DBInitializer();
                dbinit.InitializeDatabase(new TMCatalogDB());

                //Configuration configuration = new Configuration();
                //DbMigrator migrator = new DbMigrator(configuration);

                //migrator.Update("M1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
