using KalkulatorKaloriiXamarin.ViewModels.History;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KalkulatorKaloriiXamarin.Views.History
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListHistoryPage : ContentPage
    {
        public ListHistoryPage()
        {
            InitializeComponent();
            this.BindingContext = new ListHistoryViewModel();
        }
    }
}