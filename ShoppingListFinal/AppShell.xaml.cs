using ShoppingListFinal.ViewModels;
using ShoppingListFinal.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ShoppingListFinal
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ProductListPage), typeof(ProductListPage));
            Routing.RegisterRoute(nameof(EditItemPage), typeof(EditItemPage));
        }
    }
}
