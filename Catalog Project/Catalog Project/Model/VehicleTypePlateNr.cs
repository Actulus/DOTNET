using Catalog_Project.Common.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Project.Model
{
    public class VehicleTypePlateNr : ViewModelBase
    {
        private string plateNr;

        [Key]
        public string PlateNr
        {
            get
            {
                return this.plateNr;
            }
            set
            {
                this.plateNr = value;
                this.RaisePropertyChanged();
            }
        }

        public int VehicleTypeId { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
