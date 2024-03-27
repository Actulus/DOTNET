using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Project.Model
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string ArticleNumber { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
