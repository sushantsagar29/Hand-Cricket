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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace hand_cricket
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class toss : Page
    {
        public toss()
        {
            this.InitializeComponent();
        }

        int rhead = 0;
        int rtail = 0;
        string message1 = "You Win";
        string message2 = "You Loose";
        int c_rand, sum;
        int userwin = 0 , userloss = 0;
        string newname;
        
        private void zero_Click(object sender, RoutedEventArgs e)
        {

            cname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            cchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;

           // usertext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            Uri usertemp = new Uri("ms-appx:///Assets/fist.png", UriKind.Absolute);
            BitmapImage imgSource1 = new BitmapImage(usertemp);
            this.user.Source = imgSource1;

            tosschoice(0);

        }

        private void single_Click(object sender, RoutedEventArgs e)
        {

            cname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            cchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;

            //usertext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            Uri usertemp = new Uri("ms-appx:///Assets/Hands-One-finger-icon.png", UriKind.Absolute);
            BitmapImage imgSource1 = new BitmapImage(usertemp);
            this.user.Source = imgSource1;


            tosschoice(1);
        }

        private void _double_Click(object sender, RoutedEventArgs e)
        {

            cname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            cchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;

            //usertext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            Uri usertemp = new Uri("ms-appx:///Assets/Hands-Two-fingers-icon.png", UriKind.Absolute);
            BitmapImage imgSource1 = new BitmapImage(usertemp);
            this.user.Source = imgSource1;


            tosschoice(2);
        }

        private void triple_Click(object sender, RoutedEventArgs e)
        {
            cname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            cchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;

           // usertext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            Uri usertemp = new Uri("ms-appx:///Assets/Hands-Three-fingers-icon.png", UriKind.Absolute);
            BitmapImage imgSource1 = new BitmapImage(usertemp);
            this.user.Source = imgSource1;


            tosschoice(3);
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            cname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            cchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;

           // usertext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            Uri usertemp = new Uri("ms-appx:///Assets/Hands-Four-fingers-icon.png", UriKind.Absolute);
            BitmapImage imgSource1 = new BitmapImage(usertemp);
            this.user.Source = imgSource1;


            tosschoice(4);
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {

            cname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            cchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;

           // usertext.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            Uri usertemp = new Uri("ms-appx:///Assets/Hands-Thumb-up-icon.png", UriKind.Absolute);
            BitmapImage imgSource1 = new BitmapImage(usertemp);
            this.user.Source = imgSource1;


            tosschoice(6);   
        }

        void tosschoice(int a)
        {
            zero.IsEnabled = false;
            single.IsEnabled = false;
            _double.IsEnabled = false;
            triple.IsEnabled = false;
            four.IsEnabled = false;
            six.IsEnabled = false;

            arrow.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            
            Random rnd = new Random();
            c_rand = rnd.Next(0,7);

            while(c_rand == 5)
                c_rand = rnd.Next(0, 7);

            display(c_rand); //this function associates the computer's choice with its image
            sum = a + c_rand;

            winloose.Visibility = Windows.UI.Xaml.Visibility.Visible;

            if(rhead == 1) //chooses head
            {
                if (sum % 2 == 1) //wins
                {
                    userwin = 1;
                    display_result.Text = "\n" + message1;
                    choose.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                else //looses
                {
                    userloss = 1;
                    display_result.Text = "\n" + message2;
                    computerchooses.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }

                if (hand_cricket.MainPage.music == true)// plays the media element depending on toggle switch
                chimes.Play();

            }
            else if (rtail == 1) //chooses tail
            {
                if (sum % 2 == 1) //looses
                {
                    userloss = 1;
                    display_result.Text = "\n" + message2;
                    computerchooses.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
                else //wins
                {
                    userwin = 1;
                    display_result.Text = "\n" + message1;
                    choose.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }

                if (hand_cricket.MainPage.music == true)// plays the media element depending on toggle switch
                chimes.Play();
            }

        }


        void display(int b)
        {

            switch(b)
            {
                case 0 : Uri usertemp0 = new Uri("ms-appx:///Assets/fist.png", UriKind.Absolute);
                         BitmapImage imgSource0 = new BitmapImage(usertemp0);
                         this.computer.Source = imgSource0;
                         break;
                case 1:  Uri usertemp1 = new Uri("ms-appx:///Assets/Hands-One-finger-icon.png", UriKind.Absolute);
                         BitmapImage imgSource1 = new BitmapImage(usertemp1);
                         this.computer.Source = imgSource1;
                         break;
                case 2: Uri usertemp2 = new Uri("ms-appx:///Assets/Hands-Two-fingers-icon.png", UriKind.Absolute);
                         BitmapImage imgSource2 = new BitmapImage(usertemp2);
                         this.computer.Source = imgSource2;
                         break;
                case 3: Uri usertemp3 = new Uri("ms-appx:///Assets/Hands-Three-fingers-icon.png", UriKind.Absolute);
                         BitmapImage imgSource3 = new BitmapImage(usertemp3);
                         this.computer.Source = imgSource3;
                         break;
                case 4: Uri usertemp4 = new Uri("ms-appx:///Assets/Hands-Four-fingers-icon.png", UriKind.Absolute);
                         BitmapImage imgSource4 = new BitmapImage(usertemp4);
                         this.computer.Source = imgSource4;
                         break;
                case 6: Uri usertemp6 = new Uri("ms-appx:///Assets/Hands-Thumb-up-icon.png", UriKind.Absolute);
                         BitmapImage imgSource6 = new BitmapImage(usertemp6);
                         this.computer.Source = imgSource6;
                         break;
            }

        }

        private void System(string p)
        {
            throw new NotImplementedException();
        }

        public BitmapImage Bitmap { get; set; }

        private void tossload(object sender, RoutedEventArgs e)
        {
            tossblock.Text = "        Time To Toss\n\nSelect ->";

            if (hand_cricket.MainPage.user_name.Length > 13) // this funtion here makes the only first name visible if the name entered by the user it loger than 13 chars
            {
                string comparison;
                for (int x = 0; x < hand_cricket.MainPage.user_name.Length; x++)
                {
                    comparison = (hand_cricket.MainPage.user_name.Substring(x, 1));

                    if (comparison.Equals(" "))//this method works only on strings therefore comparison is kept string type
                        break;
                    else
                        newname = newname + comparison;//concat operation is done
                }
                usertext.Text = newname;
            }
            else
                usertext.Text = hand_cricket.MainPage.user_name;// if not longer than 13 chars the whole name is taken

        }

        private void tail_Click(object sender, RoutedEventArgs e)
        {
            rtail = 1;
            visibility();// this make all the required things visible
        }

        private void head_Click(object sender, RoutedEventArgs e)
        {
            rhead = 1;
            visibility();// this make all the required things visible
        }

        private void gameplayw_Click(object sender, RoutedEventArgs e)
        {

            if(userloss == 1)
            {
                hand_cricket.MainPage.selection = 2; //2 is for bowling
            }
            else if(userwin == 1)
            {
                if(bat.IsChecked == true)
                {
                    hand_cricket.MainPage.selection = 1; //batting
                }
                else if(bowl.IsChecked == true)
                {
                    hand_cricket.MainPage.selection = 2; //bowling
                }
            }

            hand_cricket.MainPage.inning = 1;
            this.Frame.Navigate(typeof(game));

        }


        void visibility()
        {
            tossborder.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cname_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            uname_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            options.Visibility = Windows.UI.Xaml.Visibility.Visible;
            arrow.Visibility = Windows.UI.Xaml.Visibility.Visible;
            a.Visibility = Windows.UI.Xaml.Visibility.Visible;
            b.Visibility = Windows.UI.Xaml.Visibility.Visible;
            c.Visibility = Windows.UI.Xaml.Visibility.Visible;
            d.Visibility = Windows.UI.Xaml.Visibility.Visible;
            e.Visibility = Windows.UI.Xaml.Visibility.Visible;
            f.Visibility = Windows.UI.Xaml.Visibility.Visible;

            a1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            b1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            c1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            d1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            e1.Visibility = Windows.UI.Xaml.Visibility.Visible;
            f1.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        
    }
}
