using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace KalkulatorKaloriiXamarin.ViewModels.History
{
    public class HistoryDetailViewModel : BaseViewModel
    {
        private string _mealtype;
        public string MealType
        {
            get => _mealtype;
            set => SetProperty(ref _mealtype, value);
        }

        private string _mealname;
        public string MealName
        {
            get => _mealname;
            set => SetProperty(ref _mealname, value);
        }

        private string _mealweight;
        public string MealWeight
        {
            get => _mealweight;
            set => SetProperty(ref _mealweight, value);
        }

        private string _mealkcal;
        public string MealKcal
        {
            get => _mealkcal;
            set => SetProperty(ref _mealkcal, value);
        }

        private string _water;
        public string WaterQty
        {
            get => _water;
            set => SetProperty(ref _water, value);
        }

        private string _activity;
        public string Activity
        {
            get => _activity;
            set => SetProperty(ref _activity, value);
        }

        private string _activitytime;
        public string ActivityTime
        {
            get => _activitytime;
            set => SetProperty(ref _activitytime, value);
        }

        private DateTime _date;
        public DateTime Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        private Models.UserHistory _selectedHistory;
        public Models.UserHistory SelectedHistory
        {
            get => _selectedHistory;
            set => SetProperty(ref _selectedHistory, value);
        }
        public Command UpdateHistory { get; }
        public Command DeleteHistory { get; }
        public INavigation Navigation { get; }
        public HistoryDetailViewModel(Models.UserHistory uh)
        {
            SelectedHistory = uh;
            LoadDetails();
            UpdateHistory = new Command(HistoryUpdate);
            DeleteHistory = new Command(HistoryDelete);
        }


        private void LoadDetails()
        {
            DateTime selected_date;
            if (!DateTime.TryParseExact(SelectedHistory.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None,out selected_date))
            {
                selected_date = DateTime.ParseExact(SelectedHistory.Date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }

            MealType = SelectedHistory.MealType;
            MealName = SelectedHistory.MealName;
            MealWeight = SelectedHistory.MealWeight;
            MealKcal = SelectedHistory.MealKcal;
            WaterQty = SelectedHistory.WaterQty;
            Activity = SelectedHistory.Activity;
            ActivityTime = SelectedHistory.ActivityTime;
            Date = selected_date;
        }

        private async void HistoryUpdate()
        {
            SelectedHistory.MealType = MealType;
            SelectedHistory.MealName = MealName;
            SelectedHistory.MealWeight = MealWeight;
            SelectedHistory.MealKcal = MealKcal;
            SelectedHistory.WaterQty = WaterQty;
            SelectedHistory.Activity = Activity;
            SelectedHistory.ActivityTime = ActivityTime;
            SelectedHistory.Date = Date.ToString("dd/MM/yyyy");

            await App.db.UpdateHistory(SelectedHistory);
            await Application.Current.MainPage.Navigation.PopToRootAsync();
            await App.Current.MainPage.DisplayAlert("Sukces", "Pozycja zaaktulizowana", "Ok");
        }

        private async void HistoryDelete()
        {
            var res = await App.Current.MainPage.DisplayAlert("Uwaga", "Czy na pewno chcesz usunąć tę pozycję?", "Tak", "Nie");
            if (res)
            {
                await App.db.DeleteHistory(SelectedHistory);
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
        }
    }
}
