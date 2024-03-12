using MauiApp3.Common.MVVM;
using MauiApp3.View;
using MauiApp3.ViewModel;

namespace MauiApp3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Initialize();
            OpenMainPage();
        }

        public void OpenMainPage()
        {
            MainPage mainPage = new MainPage();
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            ViewService.AddMainWindowToOpened(mainWindowViewModel, mainPage);
            ViewService.ShowDialog(mainWindowViewModel);
        }

        public void Initialize()
        {
            ViewService.RegisterView(typeof(MainWindowViewModel), typeof(MainPage));
            ViewService.RegisterView(typeof(AddItemViewModel), typeof(AddItemWindow));
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            return new Window(new MainPage());
        }
    }
}
