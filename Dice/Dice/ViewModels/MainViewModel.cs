using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Dice.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _number;
        private int _max;
        private Random _rand;

        public Command Roll { get; set; }
        public Command<string> SetMax { get; set; }

        public MainViewModel()
        {
            _rand = new Random();
            Max = 6;
            Number = _rand.Next(Max);
            Roll = new Command(
                () => { Number = _rand.Next(Max); },
                () => true
                );
            SetMax = new Command<string>(
                (val) => {
                    if (Int32.TryParse(val, out int result))
                    {
                        Max = result;
                    }
                },
                (val) => {
                    if (Int32.TryParse(val, out int result))
                    {
                        if (result != Max) return true;
                    }
                    return false;
                });
        }

        public int Max { get { return _max; } set { _max = value; if (SetMax != null) SetMax.ChangeCanExecute(); NotifyPropertyChanged(); } }

        public int Number { get { return _number; } set { _number = value; NotifyPropertyChanged(); } }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
