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
    /// Interaction logic for ValueEntry.xaml
    /// </summary>
    public partial class ValueEntry : UserControl
    {
        public ValueEntry()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty Value = DependencyProperty.Register
            (
                 "Value",
                 typeof(string),
                 typeof(ValueEntry),
                 new PropertyMetadata(string.Empty)
            );

       /* public string Value
        {
            get { return (string)GetValue(Value); }
            set { SetValue(Value, value); }
        }*/


        private void decrement_Click(object sender, RoutedEventArgs e)
        {
            int val = Convert.ToInt32(value.Text);
            value.Text = Convert.ToString(--val);
        }

        private void increment_Click(object sender, RoutedEventArgs e)
        {
            int val = Convert.ToInt32(value.Text);
            value.Text = Convert.ToString(++val);
        }
    }
}
