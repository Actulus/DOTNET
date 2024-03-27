using Catalog_Project.Common.MVVM;
using Catalog_Project.Logic;
using Catalog_Project.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Catalog_Project.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public static CatalogController CatalogController;
        public static MainWindowViewModel Instance;
        private List<Manufacturer> manufacturerList;
        private int manufacturerId;
        private List<Model.Model> modelList;
        private int modelId;
        private List<VehicleType> vehicleTypeList;
        private VehicleType selectedVehicleType;

        public VehicleType SelectedVehicleType
        {
            get { return selectedVehicleType; }
            set
            {
                selectedVehicleType = value;
                this.RaisePropertyChanged();
            }
        }


        public List<VehicleType> VehicleTypeList
        {
            get { return vehicleTypeList; }
            set
            {
                vehicleTypeList = value;
                this.RaisePropertyChanged();
            }
        }


        public int ModelId
        {
            get { return modelId; }
            set
            {
                modelId = value;
                this.GetVehicleTypes(modelId);
                this.RaisePropertyChanged();
            }
        }

        private void GetVehicleTypes(int modelId)
        {
            this.vehicleTypeList?.Clear();
            this.VehicleTypeList = MainWindowViewModel.CatalogController.GetVehicleTypes(modelId);
        }

        public List<Model.Model> ModelList
        {
            get { return modelList; }
            set
            {
                modelList = value;
                this.RaisePropertyChanged();
            }
        }


        public int ManufacturerId
        {
            get { return manufacturerId; }
            set
            {
                manufacturerId = value;
                this.GetModels(manufacturerId);
                this.RaisePropertyChanged();
            }
        }

        private void GetModels(int manufacturerId)
        {
            this.ModelList?.Clear();
            this.ModelList = MainWindowViewModel.CatalogController.GetModels(manufacturerId);

        }

        public List<Manufacturer> ManufacturerList
        {
            get { return manufacturerList; }
            set
            {
                manufacturerList = value;
                this.RaisePropertyChanged();
            }
        }

        public RelayCommand OpenVehicleCommand { get; set; }

        public MainWindowViewModel()
        {
            CatalogController = new CatalogController();
            MainWindowViewModel.Instance = this;
            GetManufacturers();
            this.OpenVehicleCommand = new RelayCommand(this.OpenVehicleCommandExecute);
        }

        private void OpenVehicleCommandExecute()
        {
            if (this.SelectedVehicleType != null)
            {
                VehicleTypeViewModelt vehicleTypeViewModelt = new VehicleTypeViewModelt(this.SelectedVehicleType);
                ViewService.ShowDialog(vehicleTypeViewModelt); // opens the VehicleTypeWindow
            }

        }

        private void GetManufacturers()
        {
            ManufacturerList = MainWindowViewModel.CatalogController.GetManufacturers();
        }
    }
}
