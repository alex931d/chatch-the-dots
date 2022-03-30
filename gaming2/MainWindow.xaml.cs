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
      
        Random rnd = new Random();
        double x = 0;
        bool player_right = false;
        bool player_left = false;
        bool player_none = false;
       
        bool start_game = false;
        string sMessageBoxTextWon = "you won! do you want to continue?";
        string sMessageBoxTextLost = "you lost do you want to continue?";
        string sMessageBoxTextStart = "starting game be ready";
        string sCaption = "mini chatch the dots game";
        double y = 0;
        int score1 = 0;

        BitmapImage green = new BitmapImage(new Uri("C:/Users/alex931d/source/repos/gaming2/gaming2/imgs/gray_8bit_image1.jpg"));
        BitmapImage gray = new BitmapImage(new Uri("C:/Users/alex931d/source/repos/gaming2/gaming2/imgs/green_8bit_image1.jpg"));
    

        List<BitmapImage> backgrounds = new List<BitmapImage>();
        List<Point> points = new List<Point>();
         DispatcherTimer timer = new DispatcherTimer();

           DispatcherTimer pointTimer = new DispatcherTimer();
        public MainWindow()
        {

           

           

          

           
            InitializeComponent();
            backgrounds.Add(gray);
            backgrounds.Add(green);
            mainCanvas.Background = new ImageBrush(backgrounds[0]);
            playerRec = Player;
          
          
            timer.Tick += new EventHandler(drawpoints);
            pointTimer.Tick += new EventHandler(addpoints);
            pointTimer.Interval = new TimeSpan(0,0,0,0,3000);
            timer.Interval = new TimeSpan(0,0,0,0,01);
          
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            
          
         


         





        }

        
        private void drawpoints(object sender, EventArgs e)
        {
           

          
            PlayArea.Children.Clear();
            PlayArea.Children.Add(playerRec); 
            
                       

                    
            for (int i = 0; i < points.Count; i++)
            {
          
                //points.SetByIndex(i,points[i].Y -5);
              
                Ellipse ellipse = new Ellipse() { Width = 20, Height = 20 };
                PlayArea.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, points[i].X);
                Canvas.SetTop(ellipse, points[i].Y);
                ellipse.Fill = Brushes.Red;

             Point point = points[i];
              point.Y += 0.2;
               points[i] = point;
                        

                //if (Canvas.SetTop(ellipse, length) = Canvas.SetLeft(playerRec, Left)&& Canvas.SetLeft(ellipse, length) = Canvas.setleft(playerRec, Left))
                //{
                //
                // }
                // else if (Canvas)
                //{
                //
                // }
                //  else
                // 
                //  {
                //      score1++;
                //    score.Content = score1
                //     
                //   }
                foreach (Point item in points)
                {

                    if (Canvas.GetTop(playerRec) <= item.Y && Canvas.GetTop(playerRec)+playerRec.Height >= item.Y && item.X > Canvas.GetLeft(playerRec) && item.X < Canvas.GetLeft(playerRec) + playerRec.Width)
                   {

                        score1++;
                        score.Content = score1;
                        points.Remove(item);
                     
                        break;
                   }
                    else if(item.Y > Canvas.GetTop(playerRec))
                    {
                        score1--;
                        points.Remove(item);
                        score.Content = score1;
                        break;
                    }
                    else
                    {
                        //score.Content = score1;
                    }
                }


                if (score1 == -1)
                {
                        PlayArea.Children.Clear();
                        MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                    MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                    MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxTextLost, sCaption, btnMessageBox, icnMessageBox);

                    switch (rsltMessageBox)
                    {



                        case MessageBoxResult.Yes:
                            timer.Stop();
                            pointTimer.Stop();
                            reboot();
                            break;
                        case MessageBoxResult.No:
                            System.Environment.Exit(0);

                            start_game = false;

                            break;
                        default:
                            break;
                    } 
                        
                        break;
                        
                }
                else if (score1 == 2)
                {
                    
                    MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
                    MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                    MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxTextWon, sCaption, btnMessageBox, icnMessageBox);

                    switch (rsltMessageBox)
                    {
                      
                       
                   
                        case MessageBoxResult.Yes:
                            timer.Stop();
                            pointTimer.Stop();
                            reboot();
                           
                            break;
                        case MessageBoxResult.No:
                            System.Environment.Exit(0);
                            start_game = false;
                            break;
                        default:
                            break;
                    }  
                     
                      break;
                      
             
                }
                
                       
         
            
           }
            
            // PlayArea.Children.Add(playerRec);

        }
        private void reboot()
        {

            points.Clear();
            PlayArea.Children.Clear(); 
            score1 = 0;
            score.Content = score1;
          
            start.Visibility = Visibility.Visible;

        }

        private void addpoints(object sender, EventArgs e)
        {
            // (int)((System.Windows.Controls.Panel)Application.Current.MainWindow.Content).ActualWidth)

           points.Add(new Point(rnd.Next(1, (int)((System.Windows.Controls.Panel)Application.Current.MainWindow.Content).ActualWidth),0));
            //  points.Add(new Point(rnd.Next(1, 100),0));
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
              
                case Key.Left:
                    x -= 30;
                    Canvas.SetLeft(playerRec, x);
                    //direction = Direction.left;
                    player_left = true;
                
                    break;
                case Key.Right:
                    x += 30;
                    Canvas.SetLeft(playerRec, x);
                    player_right = true;
                    //direction = Direction.right;
                  
                    break;
                default:
                    // direction = Direction.none;
                    player_none = true;
                    player_left = false;
                    player_right = false;
                    break;
            }
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {

            start_game = true;
            start.Visibility = Visibility.Collapsed;
            timer.Start();
            pointTimer.Start();

        }
    }
}
