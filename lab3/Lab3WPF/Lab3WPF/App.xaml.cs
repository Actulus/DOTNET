using Lab3WPF.Common;
using Lab3WPF.View;
using Lab3WPF.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Lab3WPF
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
            this.OpenMainWindow();
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            ViewService.AddMainWindowToOpened(mainWindowViewModel, mainWindow);
            ViewService.ShowDialog(mainWindowViewModel);
        }

        private void Initialize()
        {
            ViewService.RegisterView(typeof(MainWindowViewModel), typeof(MainWindow));
            ViewService.RegisterView(typeof(AddItemViewModel), typeof(AddItemWindow));
        }
    }

}
