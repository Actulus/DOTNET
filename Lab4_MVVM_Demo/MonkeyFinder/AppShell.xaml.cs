using MonkeyFinder.Pages;

namespace MonkeyFinder;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
		Routing.RegisterRoute(nameof(RotatePage), typeof(RotatePage));
		Routing.RegisterRoute(nameof(ScalePage), typeof(ScalePage));
	}
}