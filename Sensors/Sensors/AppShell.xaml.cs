using Sensors.ViewModels;
using Sensors.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Sensors
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(CompassPage), typeof(CompassPage));
            Routing.RegisterRoute(nameof(LocationPage), typeof(LocationPage));
            Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
        }

    }
}
