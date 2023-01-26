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
    public partial class EditUserPage : ContentPage
    {
        public EditUserPage(Models.User u)
        {
            InitializeComponent();
            this.BindingContext = new EditUserViewModel(u,Navigation);
        }
    }
}