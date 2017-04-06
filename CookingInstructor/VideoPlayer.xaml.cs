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
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

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
                 new UIPropertyMetadata("", Changed)
            );

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           
        }
        #endregion

        public string Video
        {
            get { return (string)GetValue(VideoElement); }
            set { SetValue(VideoElement, value); }
        }

        private DispatcherTimer timer;
        private Boolean isDragging;
        public VideoPlayer()
        {
            InitializeComponent();
            Play = false;
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            isDragging = false;
            //DataContext = this;
        }

        private Boolean play;
        public Boolean Play
        {
            get { return play; }
            set { play = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Play = !Play;
            if (!Play)
            {
                Media.Pause();
                timer.Stop();
                buttonImage.Source = new BitmapImage(new Uri("pack://application:,,,/tutorial.png"));
            }
            else
            {
                Media.Play();
                timer.Start();
                buttonImage.Source = new BitmapImage(new Uri("pack://application:,,,/pause.png"));
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (!isDragging)
            {
                Slider.Value = Media.Position.TotalSeconds;
            }

        }

private void seekBar_DragStarted(object sender, DragStartedEventArgs e)
{
    isDragging = true;

}

 
private void seekBar_DragCompleted(object sender, DragCompletedEventArgs e)
{

    isDragging = false;

    Media.Position = TimeSpan.FromSeconds(Slider.Value);
}

private void Media_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (Media.NaturalDuration.HasTimeSpan)
            {

                TimeSpan ts = Media.NaturalDuration.TimeSpan;
                Slider.Maximum = ts.TotalSeconds;
                Slider.SmallChange = 1;
                Slider.LargeChange = Math.Min(10, ts.Seconds / 10);
                timer.Interval = TimeSpan.FromMilliseconds(ts.TotalMilliseconds);
            }
            timer.Start();
        }
    }
}
