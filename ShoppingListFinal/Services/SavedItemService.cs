using ShoppingListFinal.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ShoppingListFinal.Services
{
    public static class SavedItemService
    {
        public static SQLiteAsyncConnection db;

        public static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData2.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<SavedItem>();
        }

        public static async Task AddItem(string name, string color)
        {
            await Init();
            var item = new SavedItem
            {
                ProductName = name,
                ProductColor = color
            };

            var id = await db.InsertAsync(item);
        }

        public static async Task RemoveItem(int id)
        {
            await Init();
            await db.DeleteAsync<SavedItem>(id);
        }

        public static async Task<int> UpdateItem(SavedItem savedItem)
        {
            await Init();
            return await db.UpdateAsync(savedItem);
        }

        public static async Task<IEnumerable<SavedItem>> GetItem()
        {
            await Init();

            var items = await db.Table<SavedItem>().ToListAsync();
            return items;
        }

        public static async Task<SavedItem> GetItem(int id)
        {
            await Init();

            var item = await db.Table<SavedItem>().FirstOrDefaultAsync(c => c.Id == id);
            return item;
        }

        public static async Task<SavedItem> GetItemByName(string name)
        {
            await Init();

            var item = await db.Table<SavedItem>().FirstOrDefaultAsync(c => c.ProductName == name);
            return item;
        }
    }
}
