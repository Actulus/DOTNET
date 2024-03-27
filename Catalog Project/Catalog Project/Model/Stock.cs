using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Project.Model
{
    public class Stock
    {
        [Key]
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
