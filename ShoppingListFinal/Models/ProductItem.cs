using SQLite;

namespace ShoppingListFinal.Models
{
    public class ProductItem : SavedItem
    {
        public bool IsChecked { get; set; }
        public int ListId { get; set; }
        public string Unit { get; set; }
    }
}