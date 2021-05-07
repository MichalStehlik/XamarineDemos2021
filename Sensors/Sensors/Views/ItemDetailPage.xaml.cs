using Sensors.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Sensors.Views
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