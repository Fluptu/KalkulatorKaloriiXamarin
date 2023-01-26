using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KalkulatorKaloriiXamarin.ViewModels.User
{
    public class NewUserViewModel : BaseViewModel
    {
        private INavigation Navigation;
        public ICommand SaveUser { get; set; }

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


        public NewUserViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

            SaveUser = new Command(() => NewUser());
        }

        private async void NewUser()
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
            await App.db.CreateUser(new Models.User
            {
                Username = NewUsername,
                Sex = NewSex,
                Height = NewHeight,
                Weight = NewWeight,
                TargetWeight = NewTargetWeight,
                Age = NewAge,
                KcalPerDay = KcalDay.ToString(),
                WaterPerDay = WaterDay.ToString()
            });
            await Navigation.PopToRootAsync();
        }
    }
}
