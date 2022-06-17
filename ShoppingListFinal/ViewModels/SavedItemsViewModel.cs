using ShoppingListFinal.Models;
using ShoppingListFinal.Services;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

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
