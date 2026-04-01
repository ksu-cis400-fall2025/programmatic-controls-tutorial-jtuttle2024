using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrinkChoice
{
    /// <summary>
    /// Interaction logic for RestaurantControl.xaml
    /// </summary>
    public partial class RestaurantControl : UserControl
    {
        public RestaurantControl()
        {
            InitializeComponent();
            
        }
        public void LoadChoices()
        {
            
            //create and add CheckBoxes for all SodaChioces
            if (DataContext is Restaurant r)
            {
                StackPanel stack = new();

                //Checkbox in everything in r.PossibleSodas
                foreach(SodaChoice chioce in r.PossibleSodas)
                {
                    CheckBox box = new();
                    box.DataContext = chioce;
                    Binding binding = new();
                    binding.Path = new PropertyPath(nameof(chioce.Chosen));
                    binding.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(box, CheckBox.IsCheckedProperty, binding );

                    //text of what kind of soda
                    TextBlock block = new();
                    block.Text = chioce.ToString();
                    box.Content = block;
                    stack.Children.Add(box);// adds checkbox to a stackpanel


                }
                //add stack to docpanel
                restDock.Children.Add(stack);


            }
        }
    }
}
