using KalkulatorKaloriiXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalkulatorKaloriiXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel(Navigation);

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(BindingContext is LoginViewModel vm)
            {
                vm.DisplayUsers();
            }
        }
    }
}