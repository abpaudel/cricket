using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Cricket
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class play : Page
    {
        public static Random rand = new Random();
        public static Random anirand= new Random();
        static public int run, wicket, nball, target, trgtcheck;
        static public float run_rate;
        static public string over;
        
        
        
        public play()
        {
            this.InitializeComponent();
            run = 0; wicket = 0; nball = 0;
            if (trgtcheck == 0) { targetbox.Visibility = Visibility.Collapsed; targetcap.Visibility = Visibility.Collapsed; }
            targetbox.Text = target.ToString();
            fielder.Begin();
            fielder.Pause();
        }
        

        
        private void display(int r)
        {
            int ani = anirand.Next(0, 6);
            int y;
            zero.Stop();one.Stop();two.Stop();three.Stop();four.Stop();outt.Stop();six.Stop();
            one1.Stop(); two1.Stop(); three1.Stop(); four1.Stop(); six1.Stop();
            one2.Stop(); two2.Stop(); three2.Stop(); four2.Stop(); six2.Stop();
            one3.Stop(); two3.Stop(); three3.Stop(); four3.Stop(); six3.Stop();
            one4.Stop(); two4.Stop(); three4.Stop(); four4.Stop(); six4.Stop();
            one5.Stop(); two5.Stop(); three5.Stop(); four5.Stop(); six5.Stop();
            fielder.Begin();
            disableanim.Begin();
            
            switch (r)
            {
                case 0:
                    zero.Begin();
                    info.Text = "Sorry, no runs made!";
                    break;
                case 1:
                    do
                    {
                        y = rand.Next(0, 7);
                    } while (y == 1);
                    ani = y;
                    if (ani == 0) { one.Begin(); }
                    else if (ani == 6) { one1.Begin(); }
                    else if (ani == 2) { one2.Begin(); }
                    else if (ani == 3) { one3.Begin(); }
                    else if (ani == 4) { one4.Begin(); }
                    else if (ani == 5) { one5.Begin(); }
                    info.Text = "That was just one run!";
                    break;
                case 2:
                    do
                    {
                        y = rand.Next(0, 7);
                    } while (y == 2);
                    ani = y;
                    if (ani == 0) { two.Begin(); }
                    else if (ani == 1) { two1.Begin(); }
                    else if (ani == 6) { two2.Begin(); }
                    else if (ani == 3) { two3.Begin(); }
                    else if (ani == 4) { two4.Begin(); }
                    else if (ani == 5) { two5.Begin(); }
                    info.Text = "Two runs";
                    break;
                case 3:
                    do
                    {
                        y = rand.Next(0, 7);
                    } while (y == 3);
                    ani = y;
                    if (ani == 0) { three.Begin(); }
                    else if (ani == 1) { three1.Begin(); }
                    else if (ani == 2) { three2.Begin(); }
                    else if (ani == 6) { three3.Begin(); }
                    else if (ani == 4) { three4.Begin(); }
                    else if (ani == 5) { three5.Begin(); }
                    info.Text = "Three runs";
                    break;
                case 4:
                    do
                    {
                        y = rand.Next(0, 7);
                    } while (y ==4);
                    ani = y;
                    if (ani == 0) { four.Begin(); }
                    else if (ani == 1) { four1.Begin(); }
                    else if (ani == 2) { four2.Begin(); }
                    else if (ani == 3) { four3.Begin(); }
                    else if (ani == 6) { four4.Begin(); }
                    else if (ani == 5) { four5.Begin(); }
                    info.Text = "Woooo! Four!";
                    break;
                case 5:
                    outt.Begin();
                    wicket += 1;
                    info.Text = "Sorry, you're OUT!";
                    break;
                case 6:
                    do
                    {
                        y = rand.Next(0, 7);
                    } while (y == 6);
                    ani = y;
                    if (ani == 0) { six.Begin(); }
                    else if (ani == 1) { six1.Begin(); }
                    else if (ani == 2) { six2.Begin(); }
                    else if (ani == 3) { six3.Begin(); }
                    else if (ani == 4) { six4.Begin(); }
                    else if (ani == 5) { six5.Begin(); }
                    info.Text = "Wow! That's a SIX.";
                    break;
                default:
                    break;
            }

            if (r != 5) run += r;
            nball++;
            run_rate=((float)run/(float) nball);
            over = ((int)(nball / 6)).ToString() + "." + ((nball % 6)).ToString();
            runs.Text = run.ToString();
            wickets.Text = wicket.ToString();
            runrate.Text = (run_rate*6).ToString();
            overs.Text = over.ToString();  
        }

       
        async private void playnext_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog gameover = new MessageDialog("                                    Game Over!!!");
            MessageDialog onehalf = new MessageDialog("                                     End of 1st Innings!!!");

            playnext.IsEnabled = false;
            int x = rand.Next(0, 7);
            
            display(x);
            if (trgtcheck == 1)
            {
                if ((nball == 30 || wicket == 10||run>=target))
                {
                    await gameover.ShowAsync();
                    viewresult.Visibility = Visibility.Visible;
                }
                else playnext.IsEnabled = true;
            }
            else
            {
                if ((nball == 30 || wicket == 10))
                {
                    await onehalf.ShowAsync();
                    nexthalf.Visibility = Visibility.Visible;
                }
                else playnext.IsEnabled = true;
            }
        }

        private void viewresult_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(resultpage));
        }

        private void retbut_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void nexthalf_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(secondinn));
        }

       
    }
}
