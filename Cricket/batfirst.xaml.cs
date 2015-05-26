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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Cricket
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class batfirst : Page
    {
        public static Random rnd = new Random();
        public batfirst()
        {
            this.InitializeComponent();
        }

        private void compbat_Click(object sender, RoutedEventArgs e)
        {
            play.target = rnd.Next(35, 100);
            progring.IsActive = true;
            gayeb.Begin();
            targt.Text = play.target.ToString();         

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            play.trgtcheck = 1;
            this.Frame.Navigate(typeof(play));
        }

        private void mebat_Click(object sender, RoutedEventArgs e)
        {
            play.trgtcheck = 0;
            this.Frame.Navigate(typeof(play));
        }
    }
}
