using SQLite;

namespace ShoppingListFinal.Models
{
    public class SavedItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductColor { get; set; }
    }
}
