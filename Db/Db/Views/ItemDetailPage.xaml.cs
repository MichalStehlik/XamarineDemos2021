using Db.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Db.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        async void Delete_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirm", "Are you sure you want to remove item " + (BindingContext as ItemDetailViewModel).Text + " from database?", "Yes", "No");
            if (answer)
            {
                (BindingContext as ItemDetailViewModel).DeleteItemCommand.Execute(null);
            }
        }
    }
}