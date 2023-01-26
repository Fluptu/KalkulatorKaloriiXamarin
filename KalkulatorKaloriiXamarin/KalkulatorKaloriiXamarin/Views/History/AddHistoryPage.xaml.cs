using KalkulatorKaloriiXamarin.ViewModels.History;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalkulatorKaloriiXamarin.Views.History
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddHistoryPage : ContentPage
    {
        public AddHistoryPage()
        {
            InitializeComponent();
            this.BindingContext = new AddHistoryViewModel();
        }
    }
}