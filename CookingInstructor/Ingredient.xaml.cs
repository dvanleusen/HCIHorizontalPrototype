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

namespace CookingInstructor
{
    /// <summary>
    /// Interaction logic for Ingredient.xaml
    /// </summary>
    public partial class Ingredient : UserControl
    {
        public Ingredient(string name, string quantity,List<string> sub)
        {
            InitializeComponent();
            this.quantity.Text = quantity;
            ingredientName.Text = name;
            for(int i = 0; i < sub.Count; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                TextBlock text = new TextBlock();
                text.Text = sub.ElementAt(i);
                item.Content = text;
                substitutons.Items.Add(item);
            }

        }

        public Ingredient(string name, string quantity, string unit, List<string> units, List<string> sub): this(name,quantity,sub)
        {
            unitBox.Width = Double.NaN;
            ComboBoxItem item = new ComboBoxItem();
            TextBlock text = new TextBlock();
            text.Text = unit;
            item.Content = text;
            unitBox.Items.Add(item);
            unitBox.SelectedIndex = 0;

            for(int i = 0; i < units.Count(); i++)
            {
                ComboBoxItem it = new ComboBoxItem();
                TextBlock t = new TextBlock();
                t.Text = units.ElementAt(i);
                it.Content = t;
                unitBox.Items.Add(it);
            }
            
        }
    }
}
