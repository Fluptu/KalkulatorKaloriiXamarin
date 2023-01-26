using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace KalkulatorKaloriiXamarin.ViewModels.History
{
    public class AddHistoryViewModel : BaseViewModel
    {
        public ICommand SaveHistory { get; set; }

        private int _userID;
        public int UserID
        {
            get => _userID;
            set => SetProperty(ref _userID, value);
        }

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

        public AddHistoryViewModel()
        {
            UserID = Models.SelectedUser.SelectedUserID;
            Date = DateTime.Today;
            SaveHistory = new Command(() => NewHistory());
        }

        private async void NewHistory()
        {
            await App.db.AddToHistory(new Models.UserHistory
            {
                UserID = UserID,
                MealType = MealType,
                MealName = MealName,
                MealWeight = MealWeight,
                MealKcal = MealKcal,
                WaterQty = WaterQty,
                Activity = Activity,
                ActivityTime = ActivityTime,
                Date = Date.ToString("dd/MM/yyyy")
            });
            await Shell.Current.GoToAsync("..");
        }

    }
}
