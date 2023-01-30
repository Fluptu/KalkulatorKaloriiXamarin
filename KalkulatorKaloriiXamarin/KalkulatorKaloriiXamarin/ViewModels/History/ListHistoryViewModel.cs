using KalkulatorKaloriiXamarin.Views.History;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;

namespace KalkulatorKaloriiXamarin.ViewModels.History
{
    public class ListHistoryViewModel : BaseViewModel
    {
        private DateTime _date;
        public DateTime SelectedDate
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }
        private int _userID;
        public int UserID
        {
            get => _userID;
            set => SetProperty(ref _userID, value);
        }

        private int _kcalSum;
        public int KcalSum
        {
            get => _kcalSum;
            set => SetProperty(ref _kcalSum, value);
        }

        private int _waterSum;
        public int WaterSum
        {
            get => _waterSum;
            set => SetProperty(ref _waterSum, value);
        }

        private string _water;
        public string WaterGoal
        {
            get => _water;
            set => SetProperty(ref _water, value);
        }
        private string _mealkcal;
        public string KcalGoal
        {
            get => _mealkcal;
            set => SetProperty(ref _mealkcal, value);
        }

        public Command<Models.UserHistory> ItemTapped { get; }
        public INavigation Navigation { get; set; }

        private Models.UserHistory _selectedHistory;
        public Models.UserHistory SelectedHistory
        {
            get => _selectedHistory;
            set
            {
                SetProperty(ref _selectedHistory, value);
                HistorySelected(value);
            }
        }
        public ObservableCollection<Models.UserHistory> UserHistories { get; }
        public Command LoadHistoriesCommand { get; }
        public Command AddHistoryCommand { get; }

        public ListHistoryViewModel()
        {
            SelectedDate = DateTime.Today;
            UserID = Models.SelectedUser.SelectedUserType.ID;
            UserHistories = new ObservableCollection<Models.UserHistory>();
            LoadHistoriesCommand = new Command(async () => await ExecuteLoadHistoriesCommand());
            AddHistoryCommand = new Command(HistoryAdd);
            ItemTapped = new Command<Models.UserHistory>(HistorySelected);
        }

        public async void LoadPage()
        {
            await ExecuteLoadHistoriesCommand();
        }

        private async Task ExecuteLoadHistoriesCommand()
        {
            IsBusy = true;
            string date = SelectedDate.ToString("dd/MM/yyyy");
            KcalSum = 0;
            WaterSum = 0;
            UserHistories.Clear();
            var items = await App.db.SelectHistoryForDate(UserID, date);
            foreach (var item in items)
            {
                UserHistories.Add(item);
                KcalSum += int.Parse(item.MealKcal);
                WaterSum += int.Parse(item.WaterQty);
            }
            KcalGoal = $"{KcalSum}/{Models.SelectedUser.SelectedUserType.KcalPerDay} Kcal";
            WaterGoal = $"{WaterSum}/{Models.SelectedUser.SelectedUserType.WaterPerDay} ml";
            IsBusy = false;
        }

        private async void HistoryAdd()
        {
            await Shell.Current.GoToAsync(nameof(AddHistoryPage));
        }

        private async void HistorySelected(Models.UserHistory uh)
        {
            if (uh == null)
                return;

            await Application.Current.MainPage.Navigation.PushAsync(new HistoryDetailPage(uh));
        }
    }
}
