using Catalog_Project.Common.MVVM;
using Catalog_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Project.ViewModel
{
    public class VehicleTypeViewModelt : ViewModelBase
    {
        private VehicleType selectedVehicleType;
        private List<ProductGroup> vehicleTypeProductList;

        public List<ProductGroup> VehicleTypeProductList
        {
            get { return vehicleTypeProductList; }
            set
            {
                vehicleTypeProductList = value; this.RaisePropertyChanged();
            }
        }


        public VehicleType SelectedVehicleType
        {
            get { return selectedVehicleType; }
            set
            {
                selectedVehicleType = value;
                this.RaisePropertyChanged();
            }
        }


        public VehicleTypeViewModelt(VehicleType selectedVehicleType)
        {
            this.selectedVehicleType = selectedVehicleType;
            this.GetProductGroups();
        }

        private void GetProductGroups()
        {
            VehicleTypeProductList = MainWindowViewModel.CatalogController.GetProductGroups(this.selectedVehicleType);
        }
    }
}
