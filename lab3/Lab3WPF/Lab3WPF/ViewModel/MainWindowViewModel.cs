using Lab3WPF.Common;
using Lab3WPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Lab3WPF.ViewModel
{
	public class MainWindowViewModel : ViewModelBase
	{
		private ObservableCollection<User> userList;
		private User selectedUser;
		private AddItemViewModel addItemViewModel = new AddItemViewModel();
		public RelayCommand LoadDataCommand { get; set; }
		public RelayCommand ClearListCommand { get; set; }
		public RelayCommand DeleteItemCommand { get; set; }
		public RelayCommand AddItemCommand { get; set; }
		public RelayCommand UpdateCommand { get; set; }

		public MainWindowViewModel()
		{
			Instance = this;
			this.UserList = new ObservableCollection<User>();
			this.LoadDataCommand = new RelayCommand(this.LoadDataCommandExecute);
			this.ClearListCommand = new RelayCommand(this.ClearListCommandExecute);
			this.DeleteItemCommand = new RelayCommand(this.DeleteItemCommandExecute);
			this.AddItemCommand = new RelayCommand(this.AddItemCommandExecute);
			this.UpdateCommand = new RelayCommand(this.UpdateCommandExecute);
			this.addItemViewModel = new AddItemViewModel();
		}

		private void UpdateCommandExecute()
		{
			using (StreamWriter writer = new StreamWriter(@"E:\Egyetem\6. felev\DOTNET\lab3\User Data.txt"))
			{
				foreach (User user in this.UserList)
				{
					
					// if data is not valid, do not save it
					if (user.FirstName == null || user.LastName == null || user.City == null || user.State == null || user.Country == null)
					{
						MessageBox.Show("Invalid data");
						continue;

					}

					writer.WriteLine(user.ToString());
				}
			}
		}

		private void AddItemCommandExecute()
		{
			addItemViewModel.NewUser.UserId = this.UserList.Count + 1;
			ViewService.ShowDialog(addItemViewModel);
		}

		private void DeleteItemCommandExecute()
		{
			if (this.SelectedUser != null)
			{
				this.userList.Remove(this.SelectedUser);
			}
		}

		private void ClearListCommandExecute()
		{
			this.userList.Clear();
		}

		private void LoadDataCommandExecute()
		{
			if (this.userList.Count > 0)
			{
				return;
			}

			foreach (string line in System.IO.File.ReadLines(@"E:\Egyetem\6. felev\DOTNET\lab3\User Data.txt"))
			{
				string[] words = line.Split(',');

				User user = new User();
				user.UserId = Int32.Parse(words[0]);
				user.FirstName = words[1];
				user.LastName = words[2];
				user.City = words[3];
				user.State = words[4];
				user.Country = words[5];

				this.userList.Add(user);
			}
		}

		public ObservableCollection<User> UserList
		{
			get { return userList; }
			set
			{
				userList = value;
				this.RaisePropertyChanged();
			}
		}

		public User SelectedUser
		{
			get { return selectedUser; }
			set
			{
				selectedUser = value;
				this.RaisePropertyChanged();
			}
		}
	}
}
