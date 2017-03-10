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
    /// 
    public partial class RecipeIcon : UserControl
    {
        private Boolean mouseEntered;
        private Boolean pressed;
        public RecipeIcon(string imagePath, string title)
        {
            InitializeComponent();
            mouseEntered = false;
            pressed = false;

            var uri = new Uri("pack://application:,,,/" + imagePath);
            recipePicture.Source = new BitmapImage(uri);

            titleBox.Text = title;

        }

        public Boolean isPressed()
        {
            return pressed;
        }

        private void RecipeIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            recipePicture.Opacity = 0.8;
            mouseEntered = true;
        }
        private void RecipeIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            recipePicture.Opacity = 1.0;
            mouseEntered = false;
        }
        private void RecipeIcon_Pressed(object sender, MouseEventArgs e)
        {
            if (mouseEntered)
            {
                pressed = true;
            }
        }
    }
}
