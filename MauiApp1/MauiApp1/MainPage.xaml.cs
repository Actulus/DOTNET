namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {

        string userName; 
        string password;

        public MainPage()
        {
            userName = "";
            password = "";
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            //DisplayAlert("title", "Szia " + msg, "cancel");
        }

         private void OnLoginClicked(object sender, EventArgs e)
        {
            DisplayAlert("title", "Login clicked", "cancel");
        }

        private void OnCloseClicked(object sender, EventArgs e)
        {
            DisplayAlert("title", "Close clicked", "cancel");
        }

        private void UserIdEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            userName = e.NewTextValue;
        }

        private void PasswordEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            password = e.NewTextValue;
        }
    }

}
