using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkChoice
{
    public class Restaurant : INotifyPropertyChanged
    {
        public string Name { get; init; }

        private List<SodaChoice> _possibleSodas = new List<SodaChoice>();

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<SodaChoice> PossibleSodas => _possibleSodas;

        //public Restaurant(string n)
        //{
        //    Name = n;

        //    foreach (SodaType soda in Enum.GetValues(typeof(SodaType)))
        //    {
        //        SodaChoice choice = new SodaChoice(soda);
        //        PossibleSodas.Add(new SodaChoice(soda));
        //    }
        //}

        /// <summary>
        /// THE PROPER CONSTRUCTOR TO BE ENABLLED AT 33 MINs
        /// </summary>
        public Restaurant(string n)
        {
            Name = n;
            foreach (SodaType soda in Enum.GetValues(typeof(SodaType)))
            {
                SodaChoice choice = new SodaChoice(soda);
                PossibleSodas.Add(choice);
            }
            foreach(SodaChoice choice in PossibleSodas)
            {
                choice.PropertyChanged += OnChoosen;
            }
        }

        public int NumChosen
        {
            get
            {
                int count = 0;
                foreach (SodaChoice choice in PossibleSodas)
                {
                    if (choice.Chosen) count++;
                }
                
                return count;
            }
        }
        public void OnChoosen (object? sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke
                (this, new PropertyChangedEventArgs
                (nameof(NumChosen)));
        }
    }
}
