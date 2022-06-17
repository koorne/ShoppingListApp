using ShoppingListFinal.Services;
using ShoppingListFinal.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using ShoppingListFinal.Views;

namespace ShoppingListFinal.ViewModels
{
    class ProductListViewModel : BaseViewModel
    {

        public ObservableRangeCollection<ProductItem> ProductItems { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<ProductItem> EditCommand { get; }
        public AsyncCommand<ProductItem> RemoveCommand { get; }
        public AsyncCommand<ProductItem> CheckItemCommand { get; }

        public ProductListViewModel()
        {
            Title = "Meine Einkaufsliste";

            ProductItems = new ObservableRangeCollection<ProductItem>();

            AddCommand = new AsyncCommand(AddProductItem);
            RefreshCommand = new AsyncCommand(Refresh);
            RemoveCommand = new AsyncCommand<ProductItem>(RemoveProductItem);
            CheckItemCommand = new AsyncCommand<ProductItem>(CheckItem);
            EditCommand = new AsyncCommand<ProductItem>(EditProductItem);


        }

        public string NewProductInputValue { get; set; }
        async Task AddProductItem()
        {
            await ProductItemService.AddItem(NewProductInputValue, false);
            await Refresh();
           
        }

        async Task RemoveProductItem(ProductItem productItem)
        {
            await ProductItemService.RemoveItem(productItem.Id);
            await Refresh();

        }

        async Task EditProductItem(ProductItem productItem)
        {
            var route = $"{nameof(EditItemPage)}?ItemId={productItem.Id}";
            await Shell.Current.GoToAsync(route);
        }

        async Task CheckItem(ProductItem productItem)
        {
            await ProductItemService.CheckItem(productItem);
            await Refresh();
        }

        async Task Refresh()
        {
            IsBusy = true;
            ProductItems.Clear();

            var items = await ProductItemService.GetItem();

            ProductItems.AddRange(items);
            IsBusy = false;

        }
    }
}
