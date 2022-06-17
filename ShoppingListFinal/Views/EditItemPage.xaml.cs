using ShoppingListFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ShoppingListFinal.Services;
using ShoppingListFinal.Models;
using System.Collections.ObjectModel;

namespace ShoppingListFinal.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditItemPage : ContentPage
    {
        public string ItemId { get; set; }

        private ObservableCollection<ItemColors> itemColors;
        public ObservableCollection<ItemColors> ItemColors
        {
            get { return itemColors; }
            set { itemColors = value; }
        }


        public EditItemPage()
        {
            InitializeComponent();

            /*ItemColors = new ObservableCollection<ItemColors>()
            {
                new ItemColors{PublicName="Red", InternalName="IndianRed"},
                new ItemColors{PublicName="Blue", InternalName="LightSkyBlue"},
                new ItemColors{PublicName="Yellow", InternalName="Yellow"},
                new ItemColors{PublicName="Green", InternalName="DarkGreen"},
                new ItemColors{PublicName="Cyan", InternalName="DarkCyan"},
                new ItemColors{PublicName="Black", InternalName="Black"},
                new ItemColors{PublicName="Violet", InternalName="DarkViolet"},
                new ItemColors{PublicName="Gray", InternalName="DimGray"}
            };*/
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            int.TryParse(ItemId, out var result);

            BindingContext = await ProductItemService.GetItem(result);
            
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var productItem = button.BindingContext as ProductItem;

            await ProductItemService.UpdateItem(productItem);
            await Shell.Current.GoToAsync("..");
        }
    }
}