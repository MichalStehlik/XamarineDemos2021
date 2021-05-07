using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Sensors.ViewModels
{
    class CompassViewModel : BaseViewModel
    {
        private double _magneticNorth;
        private string _triggerText;

        public CompassViewModel()
        {
            Title = "Compass";
            TriggerText = "On";
            Compass.ReadingChanged += CompassReadingChanged;
            ToggleCompassCommand = new Command(
                () =>
                {
                    if (Compass.IsMonitoring)
                    {
                        Compass.Stop();
                        TriggerText = "On";
                    }
                    else
                    {
                        Compass.Start(SensorSpeed.UI);
                        TriggerText = "Off";
                    }
                }
                );
        }

        private void CompassReadingChanged(object sender, CompassChangedEventArgs e)
        {
            MagneticNorth = Math.Round(e.Reading.HeadingMagneticNorth,0);
        }

        public Command ToggleCompassCommand { get; set; }

        public double MagneticNorth
        {
            get { return _magneticNorth; }
            set { SetProperty(ref _magneticNorth, value); }
        }
        public string TriggerText
        {
            get { return _triggerText; }
            set { SetProperty(ref _triggerText, value); }
        }
    }
}
