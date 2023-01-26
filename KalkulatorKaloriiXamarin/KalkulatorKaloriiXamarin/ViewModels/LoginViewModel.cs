using KalkulatorKaloriiXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using KalkulatorKaloriiXamarin.DB;
using System.Collections.ObjectModel;
using KalkulatorKaloriiXamarin.Models;
using KalkulatorKaloriiXamarin.Views.User;
using System.IO;
using SQLite;
using KalkulatorKaloriiXamarin.Views.History;

namespace KalkulatorKaloriiXamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private Models.User _user;
        public Models.User SelectedUser
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        private ObservableCollection<Models.User> _users;
        public ObservableCollection<Models.User> Users
        {
            get { return _users; }
            set
            {
                if (Equals(value, _users)) return;
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
        public INavigation Navigation { get; set; }
        public Command LoginCommand { get; }
        public Command NewUserCommand { get; }
        public Command EditUserCommand { get; }
        public Command DeleteUserCommand { get; }

        public LoginViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            LoginCommand = new Command(OnLoginClicked);
            NewUserCommand = new Command(NewUser);
            EditUserCommand = new Command(EditUser);
            DeleteUserCommand = new Command(DeleteUser);
            Users = new ObservableCollection<Models.User>();
            //DisplayUsers();
        }

        public async void DisplayUsers()
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "User.db3");
            var db = new SQLiteAsyncConnection(dbpath);

            var connection = new SQLiteAsyncConnection(dbpath);
            await connection.CreateTableAsync<Models.User>();

            // in case of empty table
            try
            {
                
                Users.Clear();
                var u = await App.db.SelectUsers();
                foreach(var x in u)
                {
                    if (x.Username == null)
                        continue;
                    Users.Add(x);
                }
            }
            catch { }
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            if(SelectedUser != null)
            {
                Models.SelectedUser.SelectedUserID = SelectedUser.ID;
                await Shell.Current.GoToAsync($"//HistoryMainPage");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Uwaga", "Nie możesz przejść dalej nie wybierając użytkownika, jeżeli go nie posiadasz możesz stworzyć nowego", "OK");
            }
        }

        private async void NewUser()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new NewUserPage());
        }

        private async void EditUser()
        {
            if (SelectedUser != null)
            {
                await Navigation.PushAsync(new EditUserPage(SelectedUser));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Uwaga", "Wybierz użytkownika do edycji!", "OK");
            }
            
        }
        private async void DeleteUser()
        {
            if (SelectedUser != null)
            {
                await Navigation.PushAsync(new DeleteUserPage(SelectedUser));
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Uwaga", "Wybierz użytkownika do usunięcia!", "OK");
            }
            //await App.db.DeleteUser(SelectedUser);
            //await Navigation.PopToRootAsync();
            
        }
    }
}
