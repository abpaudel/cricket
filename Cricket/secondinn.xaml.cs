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
    public sealed partial class secondinn : Page
    {
        public static Random rn = new Random();
        
        public secondinn()
        {

            this.InitializeComponent();
            wait.Begin();
            progring.IsActive = true;
            int compr = rn.Next(24, 99);
            runs.Text = compr.ToString();
            play.target = compr+1;


        }

        private void resultview_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(resultpage));
        }
    }
}
