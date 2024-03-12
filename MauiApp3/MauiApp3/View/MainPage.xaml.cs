using MauiApp3.ViewModel;

namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainWindowViewModel();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
           
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            Application.Current.Quit();
        }
    }

}
