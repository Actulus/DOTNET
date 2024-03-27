using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Project.Model
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public int ModelId { get; set; }

        public Model Model { get; set; }

        public int TecDocID { get; set; }

        public int ProductionYearFrom { get; set; }

        public int ProductionYearTo { get; set; }

        public int FuelTypeId { get; set; }

        public FuelType FuelType { get; set; }
    }
}
