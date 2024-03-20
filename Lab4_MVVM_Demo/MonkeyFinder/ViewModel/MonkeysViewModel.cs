namespace MonkeyFinder.ViewModel;
using MonkeyFinder.Services;

public partial class MonkeysViewModel : BaseViewModel
{
	public ObservableCollection<Monkey> Monkeys { get; } = new();
	MonkeyService monkeyService;
	IConnectivity connectivity;
	IGeolocation geolocation;

	[ObservableProperty]
	bool isRefreshing;

	//public Command GetMonkeysCommand { get; } // we use the RelayCommand attribute instead
	public MonkeysViewModel(MonkeyService monkeyService, IConnectivity connectivity, IGeolocation geolocation)
	{
		Title = "Monkey Finder";
		this.monkeyService = monkeyService;
		this.connectivity = connectivity;
		this.geolocation = geolocation;
	}

	[RelayCommand] // creates the get-set property and the command and binds them

	async Task GetMonkeysAsync()
	{
		if (connectivity.NetworkAccess != NetworkAccess.Internet)
		{
			await Shell.Current.DisplayAlert("No connectivity!",
			$"Please check internet and try again.", "OK");
			return;
		}

		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			var monkeys = await monkeyService.GetMonkeys();
			if (Monkeys.Count != 0)
				Monkeys.Clear();
			foreach (var monkey in monkeys)
				Monkeys.Add(monkey);
		}
		catch (Exception ex)
		{
			Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
			await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	[RelayCommand]
	async Task GoToDetails(Monkey monkey)
	{
		if (monkey == null)
			return;
		await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
		{
			{"Monkey", monkey }
		});
	}

	[RelayCommand]
	async Task GetClosestMonkey()
	{
		if (IsBusy || Monkeys.Count == 0)
			return;
		try
		{
			// Get cached location, else get real location.
			var location = await geolocation.GetLastKnownLocationAsync();
			if (location == null)
			{
				location = await geolocation.GetLocationAsync(new GeolocationRequest
				{
					DesiredAccuracy = GeolocationAccuracy.Medium,
					Timeout = TimeSpan.FromSeconds(30)
				});
			}
			// Find closest monkey to us
			var first = Monkeys.OrderBy(m => location.CalculateDistance(
			new Location(m.Latitude, m.Longitude), DistanceUnits.Miles))
			.FirstOrDefault();
			await Shell.Current.DisplayAlert("", first.Name + " " +
			first.Location, "OK");
		}
		catch (Exception ex)
		{
			Debug.WriteLine($"Unable to query location: {ex.Message}");
			await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
		}
	}
}
