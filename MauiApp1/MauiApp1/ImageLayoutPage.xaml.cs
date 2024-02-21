namespace MauiApp1;

public partial class ImageLayoutPage : ContentPage
{
    private List<string> imageSources = new List<string>
        {
            "https://static.wikia.nocookie.net/universalstudios/images/9/98/Shrek.png/revision/latest?cb=20220728141753",
            "E:\\Egyetem\\6. felev\\DOTNET\\cat.jpg",
            "donkey.jpg"
        };
    private int currentIndex = 0;

    public ImageLayoutPage()
	{
		InitializeComponent();
        UpdateImage();
    }

    private void OnBackButtonClicked(object sender, EventArgs e)
    {
        currentIndex = (currentIndex + 1) % imageSources.Count; // Cycle forward
        UpdateImage();
    }

    private void OnNextButtonClicked(object sender, EventArgs e)
    {
        //Navigation.PushAsync(new MainPage()); // go to next page
        currentIndex = (currentIndex - 1 + imageSources.Count) % imageSources.Count; // Cycle backward
        UpdateImage();
    }

    private void UpdateImage()
    {
        var currentSource = imageSources[currentIndex];
        currentImage.Source = currentSource;
    }
}