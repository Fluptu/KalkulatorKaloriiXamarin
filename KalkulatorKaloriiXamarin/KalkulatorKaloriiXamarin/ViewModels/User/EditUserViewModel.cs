using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KalkulatorKaloriiXamarin.ViewModels.User
{
    public class EditUserViewModel : BaseViewModel
    {
        private Models.User _user;
        public Models.User SelectedUser
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        private string _username;
        public string NewUsername
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _sex;
        public string NewSex
        {
            get => _sex;
            set => SetProperty(ref _sex, value);
        }

        private string _height;
        public string NewHeight
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        private string _weight;
        public string NewWeight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }


        private string _targetw;
        public string NewTargetWeight
        {
            get => _targetw;
            set => SetProperty(ref _targetw, value);
        }


        private string _age;
        public string NewAge
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }
        public ICommand SaveUser { get; set; }
        private INavigation Navigation;
        public EditUserViewModel(Models.User u,INavigation n)
        {
            Navigation = n;
            SelectedUser = u;
            PopulateEntries();
            SaveUser = new Command(() => UpdateUser());
        }
        private async void UpdateUser()
        {
            decimal KcalDay = 0;
            int WaterDay = 0;
            if (NewSex == "kobieta")
            {
                KcalDay = 655 + (9.6m * Convert.ToDecimal(NewWeight)) + (1.85m * Convert.ToDecimal(NewHeight)) - (4.7m * Convert.ToDecimal(NewAge));
                WaterDay = 2000;
            }
            else
            {
                KcalDay = 66.5m + (13.7m * Convert.ToDecimal(NewWeight)) + (5m * Convert.ToDecimal(NewHeight)) - (6.8m * Convert.ToDecimal(NewAge));
                WaterDay = 2500;
            }

            if (Convert.ToDecimal(NewWeight) > Convert.ToDecimal(NewTargetWeight))
            {
                KcalDay *= 0.8m;
            }
            if (Convert.ToDecimal(NewWeight) < Convert.ToDecimal(NewTargetWeight))
            {
                KcalDay *= 1.3m;
            }
            SelectedUser.Username = NewUsername;
            SelectedUser.Sex = NewSex;
            SelectedUser.Height = NewHeight;
            SelectedUser.Weight = NewWeight;
            SelectedUser.TargetWeight = NewTargetWeight;
            SelectedUser.Age = NewAge;
            SelectedUser.KcalPerDay = KcalDay.ToString();
            SelectedUser.WaterPerDay = WaterDay.ToString();

            await App.db.UpdateUser(SelectedUser);
            await Navigation.PopToRootAsync();
        }

        private void PopulateEntries()
        {
            NewUsername = SelectedUser.Username;
            NewSex = SelectedUser.Sex;
            NewHeight = SelectedUser.Height;
            NewWeight = SelectedUser.Weight;
            NewTargetWeight = SelectedUser.TargetWeight;
            NewAge = SelectedUser.Age;
        }
    }
}
