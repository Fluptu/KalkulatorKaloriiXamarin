using KalkulatorKaloriiXamarin.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalkulatorKaloriiXamarin.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteUserPage : ContentPage
    {
        private Models.User User { get; set; }
        public DeleteUserPage(Models.User u)
        {
            InitializeComponent();
            User = u;
            this.BindingContext = new DeleteUserViewModel(Navigation);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is DeleteUserViewModel vm)
            {
                bool res = await DisplayAlert("Uwaga", "Czy na pewno usunąć użytkownika?", "Tak", "Nie");
                if (res)
                {
                    vm.DeleteUser(User);
                }
                else
                {
                    await Navigation.PopToRootAsync();
                }
            }
        }
    }
}