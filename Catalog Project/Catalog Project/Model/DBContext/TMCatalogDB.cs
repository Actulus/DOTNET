using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Catalog_Project.Model.DBContext
{
    public class TMCatalogDB : DbContext
    {
        public TMCatalogDB()
        {
        }

        public virtual DbSet<Article> Articles { get; set; }

        public virtual DbSet<FuelType> FuelTypes { get; set; }

        public virtual DbSet<Manufacturer> Manufacturer { get; set; }

        public virtual DbSet<Model> Models { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductGroup> ProductGroups { get; set; }

        public virtual DbSet<Stock> Stocks { get; set; }

        public virtual DbSet<VehicleType> VehicleTypes { get; set; }

        public virtual DbSet<VehicleTypeArticles> VehicleTypeArticles { get; set; }

        public virtual DbSet<VehicleTypePlateNr> VehicleTypePlateNrs { get; set; }

        public virtual DbSet<VehicleTypeProducts> VehicleTypeProducts { get; set; }

        public virtual DbSet<VehicleTypeVin> VehicleTypeVin { get; set; }

    }
}
