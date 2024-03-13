namespace MonkeyFinder.ViewModel;
using MonkeyFinder.Services;

public partial class MonkeysViewModel : BaseViewModel
{
	public ObservableCollection<Monkey> Monkeys { get; } = new();
	MonkeyService monkeyService;
	//public Command GetMonkeysCommand { get; } // we use the RelayCommand attribute instead
	public MonkeysViewModel(MonkeyService monkeyService)
	{
		Title = "Monkey Finder";
		this.monkeyService = monkeyService; 
		//GetMonkeysCommand = new Command(async () => await GetMonkeysAsync()); // we use the RelayCommand attribute instead
	}

	[RelayCommand] // creates the get-set property and the command and binds them

	async Task GetMonkeysAsync()
	{
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
		}
	}


}
