using Catalog_Project.Model;
using Catalog_Project.Model.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Project.Logic
{
    public class CatalogController
    {
        private TMCatalogDB catalogDatabase;

        public CatalogController()
        {
            this.catalogDatabase = new TMCatalogDB();
        }

        public List<Manufacturer> GetManufacturers()
        {
            return this.catalogDatabase.Manufacturer.ToList();
        }

        public List<Model.Model> GetModels(int manufacturerId)
        {
            return catalogDatabase.Models
                .Where(model => model.ManufacturerId == manufacturerId)
                .ToList();
        }

        public List<VehicleType> GetVehicleTypes(int modelId)
        {
            return catalogDatabase.VehicleTypes
                .Include("Model")
                .Include("Model.Manufacturer")
                .Include("FuelType")
                .Where(vehicle => vehicle.ModelId == modelId)
                .ToList();
        }

        public List<ProductGroup> GetProductGroups(VehicleType vehicleType)
        {
            List<ProductGroup> productGroups = new List<ProductGroup>();
            List<VehicleTypeProducts> vehicleTypeProducts = this.catalogDatabase.VehicleTypeProducts
                .Include("Product")
                .Include("Product.ProductGroup")
                .Where(v => v.VehicleTypeId == vehicleType.Id)
                .ToList();

            if (vehicleTypeProducts?.Count > 0)
            {
                ProductGroup productGroupLocal = null;
                foreach (VehicleTypeProducts vehicleTypeProduct in vehicleTypeProducts)
                {
                    productGroupLocal = vehicleTypeProduct.Product.ProductGroup;
                    if (productGroups.FirstOrDefault(p => p.Id == productGroupLocal.Id) == null)
                    {
                        productGroupLocal.ProductList = new List<Product>();
                        productGroupLocal.ProductList.Add(vehicleTypeProduct.Product);
                        productGroups.Add(productGroupLocal);
                    }
                    else
                    {
                        productGroups.FirstOrDefault(p => p.Id == productGroupLocal.Id).ProductList.Add(vehicleTypeProduct.Product);
                    }
                }
            }

            return productGroups;

        }
    }
}
