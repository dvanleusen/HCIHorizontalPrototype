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
    public partial class RecipeIcon : UserControl
    {
        public RecipeIcon(string imagePath, string title)
        {
            InitializeComponent();

            var uri = new Uri("pack://application:,,,/" + imagePath);
            recipePicture.Source = new BitmapImage(uri);

            titleBox.Text = title;

        }

        private void RecipeIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            recipePicture.Opacity = 0.8;
        }
        private void RecipeIcon_MouseLeave(object sender, MouseEventArgs e)
        {
            recipePicture.Opacity = 1.0;
        }
    }
}
