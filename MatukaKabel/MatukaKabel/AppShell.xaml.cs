using MatukaKabel.Views;

namespace MatukaKabel
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ProductDetails", typeof(ProductDetails));
        }
    }
}
