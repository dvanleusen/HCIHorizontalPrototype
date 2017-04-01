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

        #region Value DP
        public static DependencyProperty ValueElement = DependencyProperty.Register
            (
                 "Value",
                 typeof(string),
                 typeof(ValueEntry),
                 new PropertyMetadata("")
            );

        public string Value
        {
            get { return (string)GetValue(ValueElement); }
            set { SetValue(ValueElement, value); }
        }

        #endregion


        private void decrement_Click(object sender, RoutedEventArgs e)
        {
           int valInt = Convert.ToInt32(Value);
            Value = Convert.ToString(--valInt);
        }

        private void increment_Click(object sender, RoutedEventArgs e)
        {
            int valInt = Convert.ToInt32(Value);
            Value = Convert.ToString(++valInt);
        }
    }
}
