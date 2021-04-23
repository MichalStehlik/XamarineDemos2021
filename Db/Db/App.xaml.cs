using Db.Services;
using Db.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Db
{
    public partial class App : Application
    {
        //public static AppDbContext Db;
        public App(string dbPath)
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            Db = new AppDbContext(dbPath);
            DependencyService.Register<AppDbContext>();
            DependencyService.Register<ItemStore>();
            MainPage = new AppShell();

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
