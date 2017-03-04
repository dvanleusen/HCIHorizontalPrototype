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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Category : UserControl
    {
     
        string title; 
        public Category(string title)
        {
            InitializeComponent();
            this.title = title;
            titleBox.Text = title;
        }

        public void addRecipe(RecipeIcon rec)
        {
            imagePane.Children.Add(rec);
        }



        //should be in a separate class later
        private void leftPressed(object sender, RoutedEventArgs e)
        {
            ScrollControl.PageLeft();
        }

        private void rightPressed(object sender, RoutedEventArgs e)
        {
            ScrollControl.PageRight();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button curButton = sender as Button;
            curButton.Opacity = 100;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button curButton = sender as Button;
            curButton.Opacity = 0;

        }
    }
}
