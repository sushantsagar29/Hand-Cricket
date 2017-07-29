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

namespace hand_cricket
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class entry : Page
    {
        public entry()
        {
            this.InitializeComponent();
        }

        private void tossbutton_Click(object sender, RoutedEventArgs e)
        {
            if(enter_name.Text == "")
            {
                hand_cricket.MainPage.user_name = enter_name.PlaceholderText;
            }
            else
            hand_cricket.MainPage.user_name = enter_name.Text ;

            hand_cricket.MainPage.wicket = enter_wicket.SelectedItem.ToString();
            hand_cricket.MainPage.wicket_num = int.Parse(hand_cricket.MainPage.wicket);
            hand_cricket.MainPage.music = music_toggle.IsOn; // sets the value of toggle button to a boolean variable
            this.Frame.Navigate(typeof(toss));
        }

        private void entryloaded(object sender, RoutedEventArgs e)
        {
          //  enter_name.Text = hand_cricket.MainPage.user_name;
            enter_name.PlaceholderText = hand_cricket.MainPage.user_name;
        }

        
    }
}
