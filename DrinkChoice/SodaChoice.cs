using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DrinkChoice
{
    public class SodaChoice : INotifyPropertyChanged
    {

        public SodaType Soda { get; init; }

        private bool _choosen = false;
        public bool Chosen
        {
            get => _choosen;
            set 
            {
                _choosen= value;
                PropertyChanged?.Invoke(this, 
                    new PropertyChangedEventArgs
                    (nameof(Chosen)));
            }
        }

        public SodaChoice(SodaType type)
        {
            Soda = type;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override string ToString()
        {
            switch (Soda)
            {
                case SodaType.Coke:
                    return "Coke";
                case SodaType.DietCoke:
                    return "Diet Coke";
                case SodaType.DrPepper:
                    return "Dr. Pepper";
                case SodaType.DietDrPepper:
                    return "Diet Dr. Pepper";
                case SodaType.MountainDew:
                    return "Mountain Dew";
                case SodaType.Sprite:
                    return "Sprite";
                case SodaType.RootBeer:
                    return "Root Beer";
                default:
                    return "No match";
            }
        }
    }
}
