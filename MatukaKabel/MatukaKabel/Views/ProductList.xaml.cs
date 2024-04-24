using MatukaKabel.Models;
using System.Reflection;

namespace MatukaKabel.Views;

public partial class ProductList : ContentPage
{
    public ProductList()
    {
        InitializeComponent();
        BindingContext = new Models.AllProducts();
    }

    async void productsCollection_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            Product product = e.CurrentSelection.FirstOrDefault() as Product;
            var navigationParams = new Dictionary<string, object>
                {
                    { "product", product }
                };
            await Shell.Current.GoToAsync("ProductDetails", navigationParams);
            productsCollection.SelectedItem = null;
        }
    }
}