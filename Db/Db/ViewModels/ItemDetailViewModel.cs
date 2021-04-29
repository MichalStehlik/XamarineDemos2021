using Db.Models;
using Db.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Db.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;

        public ItemDetailViewModel()
        {
            DeleteItemCommand = new Command(OnDeleteItem);
            EditItemCommand = new Command(OnEditItem);
        }

        public string Id { get; set; }

        public Command DeleteItemCommand { get; }
        public Command EditItemCommand { get; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        private async void OnDeleteItem(object obj)
        {
            if (await DataStore.DeleteItemAsync(itemId))
            {
                //MessagingCenter.Send(this, "UpdateItems");
                await Shell.Current.GoToAsync("..");
            }           
        }

        private async void OnEditItem(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(EditItemPage)}?{nameof(EditItemViewModel.ItemId)}={ItemId}");
        }
    }
}
