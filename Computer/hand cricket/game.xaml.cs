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
    public sealed partial class game : Page
    {
        public game()
        {
            this.InitializeComponent();
        }

        int currentscore, c_rand;
        string makecomment;
        int usermakes; //stores the score made by user
        string newname;

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            cname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uname_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            uchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            cchoice_border.Visibility = Windows.UI.Xaml.Visibility.Visible;

            Uri usertemp = new Uri("ms-appx:///Assets/fist.png", UriKind.Absolute);
            BitmapImage imgSource1 = new BitmapImage(usertemp);
            this.user.Source = imgSource1;
            usermakes = 0;
            generate_computer();
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
            usermakes = 1;
            generate_computer();
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
            usermakes = 2;
            generate_computer();
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
            usermakes = 3;
            generate_computer();
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
            usermakes = 4;
            generate_computer();
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
            usermakes = 6;
            generate_computer();

        }

        void generate_computer() // this works on the usermakes variable
        {
            arrow.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            next.Visibility = Windows.UI.Xaml.Visibility.Visible; // makes the next button visible
            next.IsEnabled = true;
            
            zero.IsEnabled = false;
            single.IsEnabled = false;
            _double.IsEnabled = false;
            triple.IsEnabled = false;
            four.IsEnabled = false;
            six.IsEnabled = false;

            Random rnd = new Random();
            c_rand = rnd.Next(0, 7);

            while (c_rand == 5)
                c_rand = rnd.Next(0, 7);

            display(); // this function associates the computer's choice with its image

            if(c_rand == usermakes)
            {
                wicket_function();
            }
            else
            {
                score_function();
                
            }
        }


        void wicket_function()
        {
           if(hand_cricket.MainPage.selection == 1) //this means user is batting
           {


               hand_cricket.MainPage.user_wicket += 1;
               disuserwicket.Text = "wicket :   " + hand_cricket.MainPage.user_wicket;
               wicketcanvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
               next.IsEnabled = false;


               if( hand_cricket.MainPage.user_wicket < hand_cricket.MainPage.wicket_num)
               {
                   //bug was here

                   wicketdialog.Text = "You lost a significant wicket here :(";
                   nextball.Visibility = Windows.UI.Xaml.Visibility.Visible;
                   nextpage.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
               }
               else
               {
                  //bug was here                 
                  
                   if(hand_cricket.MainPage.inning == 1)
                   {
                       nextball.Visibility = Windows.UI.Xaml.Visibility.Visible;
                       nextpage.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                       wicketdialog.Text = "You lost a wicket and the Inning Is Over.";
                       hand_cricket.MainPage.inning = 2;
                       hand_cricket.MainPage.selection = 2;
                       icon1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                       icon2.Visibility = Windows.UI.Xaml.Visibility.Visible; //this is for computer
                   }
                   else
                   {
                       nextball.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                       nextpage.Visibility = Windows.UI.Xaml.Visibility.Visible;
                       wicketdialog.Text = "That was a wicket. Game Over. Click Next";
                   }
                  
                   
               }

           }
           else if(hand_cricket.MainPage.selection == 2) //this means user is bowling
           {
               hand_cricket.MainPage.computer_wicket += 1;
               discompwicket.Text = "wicket :   " + hand_cricket.MainPage.computer_wicket;
               wicketcanvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
               next.IsEnabled = false;

               if (hand_cricket.MainPage.computer_wicket < hand_cricket.MainPage.wicket_num)
               {
               //bug was here

                   wicketdialog.Text = "A great wicket by your bowler. :)";
                   nextball.Visibility = Windows.UI.Xaml.Visibility.Visible;
                   nextpage.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
               }
               else
               {
                //bug was here

                   if (hand_cricket.MainPage.inning == 1)
                   {
                       nextball.Visibility = Windows.UI.Xaml.Visibility.Visible;
                       nextpage.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                       wicketdialog.Text = "You got a wicket and the Inning Is Over.";
                       hand_cricket.MainPage.inning = 2;
                       hand_cricket.MainPage.selection = 1;
                       icon1.Visibility = Windows.UI.Xaml.Visibility.Visible;//this is for user
                       icon2.Visibility = Windows.UI.Xaml.Visibility.Collapsed; 
                   }
                   else
                   {
                       nextball.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                       nextpage.Visibility = Windows.UI.Xaml.Visibility.Visible;
                       wicketdialog.Text = "That was a wicket. Game Over. Click Next";
                   }
               }

           }
        }//this checks if someone has lost a wicket

        void score_function()
        {

            if (hand_cricket.MainPage.selection == 1) //this means user is batting
            {

                //copied from here
                                               
                    if(usermakes == 0) //if user takes out fist
                {
                    currentscore = c_rand;
                    batting_procedure();
                }
                else //rest condition
                {
                    currentscore = usermakes;
                    batting_procedure();
                }                                

            }
            else if(hand_cricket.MainPage.selection == 2) //this means user is bowling
            {
               // copied from here
                
                if(c_rand == 0) //if computer generates fist
                {
                    currentscore = usermakes;
                    balling_procedure();
                }
                else //rest condition
                {
                    currentscore = c_rand;
                    balling_procedure();
                }               
                            
            }
        
        
        }//this operates wen both player shows different gestures



        void batting_procedure() 
        {
            switch(currentscore) //current score can never be zero
            {
                case 1: scoredis.Text = "1";
                        hand_cricket.MainPage.user_score += 1;
                        makecomment = "And here you managed to steal a single!";
                        break;
                case 2: scoredis.Text = "2";
                        hand_cricket.MainPage.user_score += 2;
                        makecomment = "Nice running between the wickets!";
                        break;
                case 3: scoredis.Text = "3";
                        hand_cricket.MainPage.user_score += 3;
                        makecomment = "That was a nice stroke but missed the boundry!";
                        break;
                case 4: scoredis.Text = "4";
                        hand_cricket.MainPage.user_score += 4;
                        makecomment = "Superb shot and it goes for a boundry!";
                        break;
                case 6: scoredis.Text = "6";
                        hand_cricket.MainPage.user_score += 6;
                        makecomment = "And that's a six. Marvellous Batting!";
                        break;
            }

            comment.Text = makecomment;
            disuserrun.Text = "run :   " + hand_cricket.MainPage.user_score;
            if (hand_cricket.MainPage.music == true)
            {
                chimes.Play();
            }
            battingdone();

        }


        void balling_procedure()
        {
            switch (currentscore) //current score can never be zero
            {
                case 1: scoredis.Text = "1";
                        hand_cricket.MainPage.computer_score += 1;
                        makecomment = "Nice fielding seen here. keep it up!";
                        break;
                case 2: scoredis.Text = "2";
                        hand_cricket.MainPage.computer_score += 2;
                        makecomment = "The batsman managed to score a double!";
                        break;
                case 3: scoredis.Text = "3";
                        hand_cricket.MainPage.computer_score += 3;
                        makecomment = "Nice fielding, didn't let it become a boundry!";
                        break;
                case 4: scoredis.Text = "4";
                        hand_cricket.MainPage.computer_score += 4;
                        makecomment = "Poor fielding by the bowling team!";
                        break;
                case 6: scoredis.Text = "6";
                        hand_cricket.MainPage.computer_score += 6;
                        makecomment = "And that's a six! Opponents hitting hard!";
                        break;
            }
            discomprun.Text = "run :   " + hand_cricket.MainPage.computer_score;
            comment.Text = makecomment;
            if (hand_cricket.MainPage.music == true)
            {
                chimes.Play();
            }
            ballingdone();
        }


        void battingdone()//this function is called after every ball to constantly keep checking in second inning of the result
        {
            if ((hand_cricket.MainPage.inning == 2) && (hand_cricket.MainPage.user_score > hand_cricket.MainPage.computer_score))
            {
                wicketcanvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
                nextball.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                nextpage.Visibility = Windows.UI.Xaml.Visibility.Visible;
                wicketdialog.Text = "You chased it. Game Over. Click Next";
                next.IsEnabled = false;
            }

        }

        void ballingdone()
        {
            if ((hand_cricket.MainPage.inning == 2) && (hand_cricket.MainPage.user_score < hand_cricket.MainPage.computer_score))
            {
                wicketcanvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
                nextball.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                nextpage.Visibility = Windows.UI.Xaml.Visibility.Visible;
                wicketdialog.Text = "They chased it. Game Over. Click Next";
                next.IsEnabled = false;
            }

        }




        void display() //works on the c_rand generated by computer
        {

            switch (c_rand)
            {
                case 0: Uri usertemp0 = new Uri("ms-appx:///Assets/fist.png", UriKind.Absolute);
                    BitmapImage imgSource0 = new BitmapImage(usertemp0);
                    this.computer.Source = imgSource0;
                    break;
                case 1: Uri usertemp1 = new Uri("ms-appx:///Assets/Hands-One-finger-icon.png", UriKind.Absolute);
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



        private void nextball_Click(object sender, RoutedEventArgs e)
        {
            cname_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            uname_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            uchoice_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cchoice_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            arrow.Visibility = Windows.UI.Xaml.Visibility.Visible;
            comment.Text = "";
            scoredis.Text = "";
            zero.IsEnabled = true;
            single.IsEnabled = true;
            _double.IsEnabled = true;
            triple.IsEnabled = true;
            four.IsEnabled = true;
            six.IsEnabled = true;
            wicketcanvas.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void nextpage_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(summary));
        }

        private void gameloaded(object sender, RoutedEventArgs e)
        {

            if (hand_cricket.MainPage.user_name.Length > 13) // this funtion here makes the only first name visible if the name entered by the yser it loger than 13 chars
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
                disusername.Text = newname;
            }
            else
            {
                usertext.Text = hand_cricket.MainPage.user_name;// if not longer than 13 chars the whole name is taken
                disusername.Text = hand_cricket.MainPage.user_name;
            }
               

            comment.Text = "Welcome! Let's Start The Game";
            arrow.Visibility = Windows.UI.Xaml.Visibility.Visible;
            
            hand_cricket.MainPage.inning = 1;
            if(hand_cricket.MainPage.selection == 1)
            {
                icon1.Visibility = Windows.UI.Xaml.Visibility.Visible; //this is for user
                icon2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
            else
            {
                icon1.Visibility = Windows.UI.Xaml.Visibility.Collapsed ;
                icon2.Visibility = Windows.UI.Xaml.Visibility.Visible ; //for computer
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            next.IsEnabled = false;
            cname_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            uname_border.Visibility = Windows.UI.Xaml.Visibility.Visible;
            uchoice_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            cchoice_border.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            arrow.Visibility = Windows.UI.Xaml.Visibility.Visible;
            comment.Text = "";
            scoredis.Text = "";
            zero.IsEnabled = true;
            single.IsEnabled = true;
            _double.IsEnabled = true;
            triple.IsEnabled = true;
            four.IsEnabled = true;
            six.IsEnabled = true;
        }
    }
}
