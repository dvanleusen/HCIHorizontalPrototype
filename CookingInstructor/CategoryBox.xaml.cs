using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace CookingInstructor
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class CategoryBox : UserControl
    {
    
        public CategoryBox()
        {
            InitializeComponent();
        }

        #region Title DP
        public static readonly DependencyProperty TitleElement = DependencyProperty.Register
            (
                 "Title",
                 typeof(string),
                 typeof(CategoryBox),
                 new PropertyMetadata("")
            );

        public string Title
        {
            get { return (string)GetValue(TitleElement); }
            set { SetValue(TitleElement, value); }
        }

        #endregion

        #region Recipes DP
        public static readonly DependencyProperty VideoElement = DependencyProperty.Register
            (
                 "Video",
                 typeof(List<TabControl>),
                 typeof(VideoPlayer),
                 new PropertyMetadata("")
            );

        public string Video
        {
            get { return (string)GetValue(VideoElement); }
            set { SetValue(VideoElement, value); }
        }

        #endregion



        //should be in a separate class later
        private void leftPressed(object sender, RoutedEventArgs e)
        {
           // ScrollControl.PageLeft();
        }

        private void rightPressed(object sender, RoutedEventArgs e)
        {
           // ScrollControl.PageRight();
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
