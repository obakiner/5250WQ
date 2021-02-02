using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mine.Services;
using Mine.Views;

namespace Mine
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            // hooks up the app to the Database Service
            DependencyService.Register<DatabaseService>();
            MainPage = new MainPage();
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
