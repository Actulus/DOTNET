using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Project.Model
{
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public List<Product> ProductList { get; set; }
    }
}
