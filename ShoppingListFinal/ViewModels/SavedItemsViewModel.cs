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
    class SavedItemsViewModel : BaseViewModel
    {

        public ObservableRangeCollection<SavedItem> SavedItems { get; set; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<SavedItem> RemoveCommand { get; }
        public AsyncCommand RefreshCommand { get; }


        public SavedItemsViewModel()
        {
            Title = "Saved items";

            SavedItems = new ObservableRangeCollection<SavedItem>();

            AddCommand = new AsyncCommand(AddProductItem);
            RemoveCommand = new AsyncCommand<SavedItem>(RemoveSavedItem);
            RefreshCommand = new AsyncCommand(Refresh);
        }

        public string NewProductInputValue { get; set; }
        async Task AddProductItem()
        {
            await SavedItemService.AddItem(NewProductInputValue, "IndianRed");
            await Refresh();
        }

        async Task RemoveSavedItem(SavedItem savedItem)
        {
            await SavedItemService.RemoveItem(savedItem.Id);
            await Refresh();

        }

        async Task Refresh()
        {
            IsBusy = true;
            SavedItems.Clear();

            var items = await SavedItemService.GetItem();

            SavedItems.AddRange(items);
            IsBusy = false;

        }
    }
}
