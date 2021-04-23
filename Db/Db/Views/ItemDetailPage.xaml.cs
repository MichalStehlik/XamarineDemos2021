using Db.ViewModels;
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
    }
}