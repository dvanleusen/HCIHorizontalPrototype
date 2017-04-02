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
using CookingInstructorViewModel;

namespace CookingInstructor
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class VideoPlayer : UserControl
    {

        #region Video DP
        public static readonly DependencyProperty VideoElement = DependencyProperty.Register
            (
                 "Video",
                 typeof(string),
                 typeof(VideoPlayer),
                 new PropertyMetadata("")
            );

        public string Video
        {
            get { return (string)GetValue(VideoElement); }
            set { SetValue(VideoElement, value); }
        }

        #endregion

        public VideoPlayer()
        {
            InitializeComponent();
            Play = false;
            DataContext = this;
            Slider.Minimum = 0;
            if (Media.NaturalDuration.HasTimeSpan)
            {
                Slider.Maximum = Media.NaturalDuration.TimeSpan.TotalMilliseconds;
            }
        }

        private Boolean play;
        public Boolean Play
        {
            get { return play; }
            set { play = value; }
        }

        
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Media.Position = TimeSpan.FromMilliseconds(Slider.Value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Play = !Play;
            if (!Play)
            {
                Media.Pause();
                buttonImage.Source = new BitmapImage(new Uri("pack://application:,,,/tutorial.png"));
            }
            else
            {
                Media.Play();
                buttonImage.Source = new BitmapImage(new Uri("pack://application:,,,/pause.png"));
            }
        }
    }
}
