using KalkulatorKaloriiXamarin.Views.History;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KalkulatorKaloriiXamarin.ViewModels.History
{
    public class HistoryMainViewModel : BaseViewModel
    {
        public Command HistoryList { get; }
        public HistoryMainViewModel()
        {
            HistoryList = new Command(ListHistory);
        }

        private async void ListHistory()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListHistoryPage());
        }
    }
}
