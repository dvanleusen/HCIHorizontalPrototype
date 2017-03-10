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
    /// Interaction logic for RecipePage.xaml
    /// </summary>
    public partial class RecipePage : UserControl
    {
        public RecipePage()
        {
            InitializeComponent();
            Ingredient i1 = new Ingredient("whole chicken", "1", new List<string>());
            Ingredient i2 = new Ingredient("salt", "1", "tsp", new List<string>() {"tbsp", "cup"}, new List<string>() { });
            Ingredient i3 = new Ingredient("onion powder", "1" ,"tbsp", new List<string>() {"tsp", "cup"}, new List<string>());
            Ingredient i4 = new Ingredient("margarine", "1/2", "cup", new List<string>() {"tbsp", "oz","tsp"}, new List<string>());
            Ingredient i5 = new Ingredient("stalk celery, leaves removed", "1", new List<string>());

            ListBoxItem l1 = new ListBoxItem();
            l1.Content = i1;
            ListBoxItem l2 = new ListBoxItem();
            l2.Content = i2;
            ListBoxItem l3 = new ListBoxItem();
            l3.Content = i3;
            ListBoxItem l4 = new ListBoxItem();
            l4.Content = i4;
            ListBoxItem l5 = new ListBoxItem();
            l5.Content = i5;
            ingredientBox.Items.Add(l1);
            ingredientBox.Items.Add(l2);
            ingredientBox.Items.Add(l3);
            ingredientBox.Items.Add(l4);
            ingredientBox.Items.Add(l5);
        }
    }
}
