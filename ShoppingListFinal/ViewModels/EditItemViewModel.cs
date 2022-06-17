using ShoppingListFinal.Models;
using System.Collections.ObjectModel;

namespace ShoppingListFinal.ViewModels
{
    public class EditItemViewModel : BaseViewModel
    {
        public string ItemId { get; set; }
        public ProductItem Item { get; set; }

        private ObservableCollection<ItemColors> itemColors;
        public ObservableCollection<ItemColors> ItemColors
        {
            get { return itemColors; }
            set { SetProperty(ref itemColors, value); }
        }

        public EditItemViewModel()
        {

            ItemColors = new ObservableCollection<ItemColors>()
            {
                new ItemColors{PublicName="Red", InternalName="IndianRed"},
                new ItemColors{PublicName="Blue", InternalName="LightSkyBlue"},
                new ItemColors{PublicName="Yellow", InternalName="Yellow"},
                new ItemColors{PublicName="Green", InternalName="DarkGreen"},
                new ItemColors{PublicName="Cyan", InternalName="DarkCyan"},
                new ItemColors{PublicName="Black", InternalName="Black"},
                new ItemColors{PublicName="Violet", InternalName="DarkViolet"},
                new ItemColors{PublicName="Gray", InternalName="DimGray"}
            };


        }
    }
}
