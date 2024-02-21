namespace MauiApp1;

public partial class ImageLayoutPage : ContentPage
{
	public ImageLayoutPage()
	{
		InitializeComponent();
	}

    private void OnBackButtonClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void OnNextButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}