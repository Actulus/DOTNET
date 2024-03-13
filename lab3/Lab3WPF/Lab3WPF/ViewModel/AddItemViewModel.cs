using Lab3WPF.Common;
using Lab3WPF.Model;
using Lab3WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab3WPF.ViewModel
{
    public class AddItemViewModel: ViewModelBase
    {
        private User newUser;
        public RelayCommand SaveDataCommand { get; set; }

		public AddItemViewModel()
		{
			this.NewUser = new User();
            this.SaveDataCommand = new RelayCommand(this.SaveDataCommandExecute);
		}

		private void SaveDataCommandExecute()
		{
            // check if the user is already in the list and if the new user's data is valid
            if (MainWindowViewModel.Instance.UserList.Contains(this.NewUser))
            {
                // alert the user that the user is already in the list
                MessageBox.Show("User is already in the list");
				return;
			}
            if (this.NewUser.FirstName == null || this.NewUser.LastName == null || this.NewUser.City == null || this.NewUser.State == null || this.NewUser.Country == null)
            {
                // alert the user that the user's data is invalid
				MessageBox.Show("Invalid data");
                return;
            }
			Instance.UserList.Add(this.NewUser);
            ViewService.CloseDialog(this);
		}

		public User NewUser
        {
            get { return newUser; }
            set { newUser = value;
                this.RaisePropertyChanged();
            }
        }
    }
}
