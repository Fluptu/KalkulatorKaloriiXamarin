
using KalkulatorKaloriiXamarin.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using KalkulatorKaloriiXamarin.DB;

namespace KalkulatorKaloriiXamarin
{
    public partial class App : Application
    {
        private static SQLiteHelper conn;
        public static SQLiteHelper db
        {
            get
            {
                if (conn == null)
                {
                    conn = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "User.db3"));
                }
                return conn;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            //MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
