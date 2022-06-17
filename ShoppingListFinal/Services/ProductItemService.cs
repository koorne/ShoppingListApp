using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Essentials;
using ShoppingListFinal.Models;

namespace ShoppingListFinal.Services
{
    public static class ProductItemService
    {
        static SQLiteAsyncConnection db;

        static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData2.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<ProductItem>();
            await db.CreateTableAsync<SavedItem>();
        }

        public static async Task AddItem(string name, bool isChecked)
        {
            await Init();

            var item = new ProductItem();

            var savedItem = await SavedItemService.GetItemByName(name);

            if (savedItem != null)
            {
                item = new ProductItem
                {
                    ProductName = savedItem.ProductName,
                    ProductColor = savedItem.ProductColor,
                    IsChecked = isChecked,
                    ListId = 1,
                    Unit = ""
                };
            } else
            {
                item = new ProductItem
                {
                    ProductName = name,
                    ProductColor = "IndianRed",
                    IsChecked = isChecked,
                    ListId = 1,
                    Unit = ""
                };
                var newSavedItem = new SavedItem
                {
                    ProductName = name,
                    ProductColor = "IndianRed"
                };
                var savedItemId = await SavedItemService.db.InsertAsync(newSavedItem);
                
            }

            var id = await db.InsertAsync(item);
        }

        public static async Task RemoveItem(int id)
        {
            await Init();

            await db.DeleteAsync<ProductItem>(id);
        }

        public static async Task<int> CheckItem(ProductItem productItem)
        {
            await Init();
            productItem.IsChecked = !productItem.IsChecked;
            return await db.UpdateAsync(productItem);
        }

        public static async Task<int> UpdateItem(ProductItem productItem)
        {
            await Init();

            var savedItem = await SavedItemService.GetItemByName(productItem.ProductName);

            savedItem.ProductName = productItem.ProductName;
            savedItem.ProductColor = productItem.ProductColor;

            var updatedItem = await db.UpdateAsync(savedItem);
            return await db.UpdateAsync(productItem);
        }

        public static async Task<IEnumerable<ProductItem>> GetItem()
        {
            await Init();

            var items = await db.Table<ProductItem>().ToListAsync();
            return items;
        }

        public static async Task<ProductItem> GetItem(int id)
        {
            await Init();

            var item = await db.Table<ProductItem>().FirstOrDefaultAsync(c => c.Id == id);
            return item;
        }
    }
}
