namespace MonkeyFinder.ViewModel;

//Add QueryProperty
[QueryProperty(nameof(Monkey), "Monkey")]
public partial class MonkeyDetailsViewModel : BaseViewModel
{

	[ObservableProperty]
	Monkey monkey;

	IMap map;
	public MonkeyDetailsViewModel(IMap map)
	{
		this.map = map;
	}

	[RelayCommand]
	async Task OpenMap()
	{
		try
		{
			await map.OpenAsync(Monkey.Latitude, Monkey.Longitude, new MapLaunchOptions
			{
				Name = Monkey.Name,
				NavigationMode = NavigationMode.None
			});
		}
		catch (Exception ex)
		{
			Debug.WriteLine($"Unable to launch maps: {ex.Message}");
			await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
		}
	}

}