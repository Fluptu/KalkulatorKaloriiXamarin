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
            RegisterRoutes();
            BindingContext = this;
        }

        // Code below

    }
}