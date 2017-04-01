using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CookingInstructorViewModel;

namespace CookingInstructor
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow()
        {
            InitializeComponent();
        }

     /*                 
    }
    private void button_mouse_enter(object sender, MouseEventArgs e)
    {
        Button btn = sender as Button;
        StackPanel pane = btn.Content as StackPanel;
        Image img = pane.Children[0] as Image;
        string curSrc = img.Source.ToString();
        var src = new Uri(curSrc.Substring(0, curSrc.Length - 4) + "_mouse_enter.png");
        img.Source = new BitmapImage(src);
    }

    private void button_mouse_leave(object sender, MouseEventArgs e)
    {
        Button btn = sender as Button;
        StackPanel pane = btn.Content as StackPanel;
        Image img = pane.Children[0] as Image;
        string curSrc = img.Source.ToString();
        var src = new Uri(curSrc.Substring(0, curSrc.Length - 16) + ".png");
        img.Source = new BitmapImage(src);

    }
    */
    }
   
}
