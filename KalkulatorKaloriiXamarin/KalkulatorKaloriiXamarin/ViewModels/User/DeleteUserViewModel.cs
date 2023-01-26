using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KalkulatorKaloriiXamarin.ViewModels.User
{
    public class DeleteUserViewModel : BaseViewModel
    {
        private Models.User _user;
        public Models.User SelectedUser
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
        private INavigation Navigation;
        public DeleteUserViewModel(INavigation n)
        {
            Navigation = n;
        }

        public async void DeleteUser(Models.User u)
        {
            await App.db.DeleteUser(u);
            await Navigation.PopToRootAsync();
        }
    }
}
