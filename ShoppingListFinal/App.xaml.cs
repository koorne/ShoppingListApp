using ShoppingListFinal.Resources;
using ShoppingListFinal.Services;
using ShoppingListFinal.Views;
using System;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingListFinal
{
    public partial class App : Application
    {

        public App()
        {

            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);
            InitializeComponent();

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
