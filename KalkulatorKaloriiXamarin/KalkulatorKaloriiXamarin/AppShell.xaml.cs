using KalkulatorKaloriiXamarin.Views;
using KalkulatorKaloriiXamarin.Views.History;
using KalkulatorKaloriiXamarin.Views.User;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalkulatorKaloriiXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(NewUserPage), typeof(NewUserPage));
            Routing.RegisterRoute(nameof(HistoryMainPage), typeof(HistoryMainPage));
            Routing.RegisterRoute(nameof(AddHistoryPage), typeof(AddHistoryPage));
            BindingContext = this;
        }


        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

    }
}