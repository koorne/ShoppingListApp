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
    public partial class ProductListPage : ContentPage
    {
        public ProductListPage()
        {
            InitializeComponent();
            this.BindingContext = new ProductListViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (ProductListViewModel)BindingContext;
            await vm.RefreshCommand.ExecuteAsync();
        }
    }
}