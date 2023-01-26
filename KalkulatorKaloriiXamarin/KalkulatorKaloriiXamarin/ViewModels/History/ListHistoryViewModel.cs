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

        private string _mealname;
        public string MealName
        {
            get => _mealname;
            set => SetProperty(ref _mealname, value);
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
            UserID = Models.SelectedUser.SelectedUserID;
            UserHistories = new ObservableCollection<Models.UserHistory>();
            LoadHistoriesCommand = new Command(async () => await ExecuteLoadHistoriesCommand());
            AddHistoryCommand = new Command(HistoryAdd);
            ItemTapped = new Command<Models.UserHistory>(HistorySelected);
        }

        async Task ExecuteLoadHistoriesCommand()
        {
            IsBusy = true;
            string date = SelectedDate.ToString("dd/MM/yyyy");
            UserHistories.Clear();
            var items = await App.db.SelectHistoryForDate(UserID, date);
            foreach (var item in items)
            {
                UserHistories.Add(item);
            }

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
