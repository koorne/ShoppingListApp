using SQLite;

namespace ShoppingListFinal.Models
{
    public class ProductList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
