using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Sensors.ViewModels
{
    [QueryProperty(nameof(Latitude), nameof(Longitude))]
    class MapViewModel : BaseViewModel
    {
        private Position _position;
        public MapViewModel()
        {
            Title = "Map";
            ZeroCommand = new Command(
                () =>
                {
                    Position = new Position(50.76711, 15.05619);
                }
                );
            Map = new Map();
        }

        public  Map Map { get; set; }
        public Position Position 
        {
            get { return _position; }
            set { 
                SetProperty(ref _position, value);
                Map.MoveToRegion(new MapSpan(_position, 0.01, 0.01));
            }
        }

        public double Latitude
        {
            get { return Position.Latitude; }
            set
            {
                var pos = new Position(value, Longitude);
                SetProperty(ref _position, pos);
            }
        }

        public double Longitude
        {
            get { return Position.Longitude; }
            set
            {
                var pos = new Position(Latitude, value);
                SetProperty(ref _position, pos);
            }
        }

        public Command ZeroCommand { get; set; }
    }
}
