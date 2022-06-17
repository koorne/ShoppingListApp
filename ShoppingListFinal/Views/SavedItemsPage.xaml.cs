using ShoppingListFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingListFinal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedItemsPage : ContentPage
    {
        public SavedItemsPage()
        {
            InitializeComponent();
            this.BindingContext = new SavedItemsViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (SavedItemsViewModel)BindingContext;
            await vm.RefreshCommand.ExecuteAsync();
        }
    }
}