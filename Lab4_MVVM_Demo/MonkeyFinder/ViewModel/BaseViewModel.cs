namespace MonkeyFinder.ViewModel;

// With CommunityToolkit.Mvvm Toolkit
public partial class BaseViewModel : ObservableObject
{
	// without keyword is private by default
	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(IsNotBusy))]
	bool isBusy;
	[ObservableProperty]
	string title;
	public bool IsNotBusy => !IsBusy;
}

// Without CommunityToolkit.Mvvm Toolkit
/*public class BaseViewModel : INotifyPropertyChanged
{
	bool isBusy;
	string title;

	public event PropertyChangedEventHandler PropertyChanged;

	public void OnPropertyChanged([CallerMemberName] string
		name = null) => PropertyChanged?.Invoke(this, new
		PropertyChangedEventArgs(name));

	public bool IsBusy
	{
		get => isBusy;
		set
		{
			if (isBusy == value)
				return;
			isBusy = value;
			OnPropertyChanged();
			// Also raise the IsNotBusy property changed
			OnPropertyChanged(nameof(IsNotBusy));
		}
	}
	public bool IsNotBusy => !IsBusy;
	public string Title
	{
		get => title;
		set
		{
			if (title == value)
				return;
			title = value;
			OnPropertyChanged();
		}
	}
}
*/