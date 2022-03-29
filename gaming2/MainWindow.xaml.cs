using System;
using System.Collections.Generic;
using System.Collections;
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
using System.Windows.Threading;

namespace gaming2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        enum Direction { left, right, none};
        Direction direction = Direction.none;
        Rectangle playerRec;
        Ellipse ellipse;
        Random rnd = new Random();
        double x = 0;
        double y = 0;
        int score1 = 0;
        List<Point> points = new List<Point>();
        
        public MainWindow()
        {


            InitializeComponent();
            playerRec = Player;
           DispatcherTimer timer = new DispatcherTimer();

           DispatcherTimer pointTimer = new DispatcherTimer();

            timer.Tick += new EventHandler(drawpoints);
            pointTimer.Tick += new EventHandler(addpoints);
            pointTimer.Interval = new TimeSpan(3000);
            timer.Interval = new TimeSpan(20);
            pointTimer.Start();
            timer.Start();

            foreach (var item in collection)
            {

            }

            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
        }

        
        private void drawpoints(object sender, EventArgs e)
        {
            for (int i = 0; i < points.Count; i++)
            {
              
                //points.SetByIndex(i,points[i].Y -5);

                ellipse = new Ellipse() { Width = 2, Height = 2 };
                PlayArea.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, points[i].X - ellipse.Width);
                Canvas.SetTop(ellipse, points[i].Y - ellipse.Height);
                Point point = points[i];
                point.Y += 5;
                points[i] = point;
           
                
               // PlayArea.Children.Clear();
            }
      
            // PlayArea.Children.Add(playerRec);

        }

        private void addpoints(object sender, EventArgs e)
        {
            // (int)((System.Windows.Controls.Panel)Application.Current.MainWindow.Content).ActualWidth)

         //   points.Add(new Point(rnd.Next(1, (int)((System.Windows.Controls.Panel)Application.Current.MainWindow.Content).ActualWidth),0));
            points.Add(new Point(rnd.Next(1, 100),0));
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
              
                case Key.Left:
                    x -= 30;
                    Canvas.SetLeft(playerRec, x);
                    //direction = Direction.left;
                
                    break;
                case Key.Right:
                    x += 30;
                    Canvas.SetLeft(playerRec, x);
                    //direction = Direction.right;
                  
                    break;
                default:
                   // direction = Direction.none;
                    break;
            }
        }
    }
}
