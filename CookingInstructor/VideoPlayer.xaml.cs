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
            DataContext = new VideoPlayerViewModel();

            Media.MediaOpened += (o, e)=>{
                Slider.Maximum = Media.NaturalDuration.TimeSpan.Seconds;
            };
        }

        
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Slider slr = sender as Slider;
            //TimeSpan curTime = Media.NaturalDuration.TimeSpan;
            //Media.Position = TimeSpan.FromMilliseconds(curTime.Milliseconds + slr.Value * (curTime.TotalMilliseconds/slr.Maximum));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VideoPlayerViewModel v = DataContext as VideoPlayerViewModel;
            if (v.Play)
            {
                Media.Pause();
            }
            else
            {
                Media.Play();
            }
        }
    }
}
