using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Project.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public int ProductGroupId { get; set; }

        public ProductGroup ProductGroup { get; set; }
    }
}
