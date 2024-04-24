using MatukaKabel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatukaKabel.Services
{
    public interface IProductsRepository
    {
        Task<ObservableCollection<Product>> LoadProducts();
    }
}
