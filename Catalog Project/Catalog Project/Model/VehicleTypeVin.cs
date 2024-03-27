using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Project.Model
{
    public class VehicleTypeVin
    {
        [Key]
        public string VIN { get; set; }

        public int VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
