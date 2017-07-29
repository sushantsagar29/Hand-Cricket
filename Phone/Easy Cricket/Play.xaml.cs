using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace Easy_Cricket
{
    public partial class Play : PhoneApplicationPage
    {
        public Play()
        {
            InitializeComponent();
        }

        int currentscore, c_rand;
        string makecomment;
        int usermakes; //stores the score made by user

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (Easy_Cricket.MainPage.selection == 1)
            {
                usertext.Text = Easy_Cricket.MainPage.user_name + "*";
                comptext.Text = "Computer";
            }

            else
            {
                usertext.Text = Easy_Cricket.MainPage.user_name;
                comptext.Text = "Computer" + "*";
            }

            inning.Text = "1st inning";



        }

        private void zero_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            user.Visibility = System.Windows.Visibility.Visible;
            computer.Visibility = System.Windows.Visibility.Visible;

           /* Uri usertemp = new Uri("ms-appx:///Assets/fist.png", UriKind.Absolute);
            BitmapImage imgSource1 = new BitmapImage(usertemp);
            this.user.Source = imgSource1;*/


            BitmapImage tn = new BitmapImage();
            tn.SetSource(Application.GetResourceStream(new Uri(@"Assets/fist.png", UriKind.Relative)).Stream);
            user.Source = tn;


            usermakes = 0;
            
            generate_computer();
        }

        private void one_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            user.Visibility = System.Windows.Visibility.Visible;
            computer.Visibility = System.Windows.Visibility.Visible;

            BitmapImage tn = new BitmapImage();
            tn.SetSource(Application.GetResourceStream(new Uri(@"Assets/Hands-One-finger-icon.png", UriKind.Relative)).Stream);
            user.Source = tn;
            usermakes = 1;
            
            generate_computer();
        }

        private void two_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            user.Visibility = System.Windows.Visibility.Visible;
            computer.Visibility = System.Windows.Visibility.Visible;

            
            BitmapImage tn = new BitmapImage();
            tn.SetSource(Application.GetResourceStream(new Uri(@"Assets/Hands-Two-fingers-icon.png", UriKind.Relative)).Stream);
            user.Source = tn;
            usermakes = 2;
            
            generate_computer();
        }

        private void three_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            user.Visibility = System.Windows.Visibility.Visible;
            computer.Visibility = System.Windows.Visibility.Visible;

            BitmapImage tn = new BitmapImage();
            tn.SetSource(Application.GetResourceStream(new Uri(@"Assets/Hands-Three-fingers-icon.png", UriKind.Relative)).Stream);
            user.Source = tn;
            usermakes = 3;
            
            generate_computer();
        }

        private void four_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            user.Visibility = System.Windows.Visibility.Visible;
            computer.Visibility = System.Windows.Visibility.Visible;

            BitmapImage tn = new BitmapImage();
            tn.SetSource(Application.GetResourceStream(new Uri(@"Assets/Hands-Four-fingers-icon.png", UriKind.Relative)).Stream);
            user.Source = tn;
            usermakes = 4;
         
            generate_computer();
        }

        private void six_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            user.Visibility = System.Windows.Visibility.Visible;
            computer.Visibility = System.Windows.Visibility.Visible;

            BitmapImage tn = new BitmapImage();
            tn.SetSource(Application.GetResourceStream(new Uri(@"Assets/Hands-Thumb-up-icon.png", UriKind.Relative)).Stream);
            user.Source = tn;
            usermakes = 6;
            
            generate_computer();
        }

        void generate_computer() // this works on the usermakes variable
        {
            next.Visibility = System.Windows.Visibility.Visible; // makes the next button visible
            next.IsEnabled = true;

            zero.IsHitTestVisible = false;
            one.IsHitTestVisible = false;
            two.IsHitTestVisible = false;
            three.IsHitTestVisible = false;
            four.IsHitTestVisible = false;
            six.IsHitTestVisible = false;


            Random rnd = new Random();
            c_rand = rnd.Next(0, 7);

            while (c_rand == 5)
                c_rand = rnd.Next(0, 7);

            display();

            if (c_rand == usermakes)
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
            if (Easy_Cricket.MainPage.selection == 1) //this means user is batting
            {


                Easy_Cricket.MainPage.user_wicket += 1;
                user_score.Text = Easy_Cricket.MainPage.user_score.ToString() + "/" + Easy_Cricket.MainPage.user_wicket.ToString();


                if (Easy_Cricket.MainPage.user_wicket < Easy_Cricket.MainPage.wicket_num)
                {
                    //bug was here

                    comment.Text = "That was a wicket.";
                    next.Visibility = System.Windows.Visibility.Visible;

                }
                else
                {
                    //bug was here                 

                    if (Easy_Cricket.MainPage.inning == 1)
                    {
                        next.Visibility = System.Windows.Visibility.Visible;

                        comment.Text = "Inning Is Over.";
                        Easy_Cricket.MainPage.inning = 2;
                        Easy_Cricket.MainPage.selection = 2;
                        usertext.Text = Easy_Cricket.MainPage.user_name;
                        comptext.Text = "Computer*";//this is for computer
                        inning.Text = "2nd inning";

                    }
                    else
                    {
                        //game over scenario
                        next.Visibility = System.Windows.Visibility.Collapsed;
                        battingdone();
                    }


                }

            }
            else if (Easy_Cricket.MainPage.selection == 2) //this means user is bowling
            {
                Easy_Cricket.MainPage.computer_wicket += 1;
                comp_score.Text = Easy_Cricket.MainPage.computer_score.ToString() + "/" + Easy_Cricket.MainPage.computer_wicket.ToString();
                next.IsEnabled = true;

                if (Easy_Cricket.MainPage.computer_wicket < Easy_Cricket.MainPage.wicket_num)
                {
                    //bug was here

                    comment.Text = "That was a wicket.";
                    next.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    //bug was here

                    if (Easy_Cricket.MainPage.inning == 1)
                    {
                        next.Visibility = System.Windows.Visibility.Visible;

                        comment.Text = "Inning Is Over.";
                        Easy_Cricket.MainPage.inning = 2;
                        Easy_Cricket.MainPage.selection = 1;

                        usertext.Text = Easy_Cricket.MainPage.user_name + "*";
                        comptext.Text = "Computer";//this is for computer
                        inning.Text = "2nd inning";
                    }
                    else
                    {
                        //game over scenario
                        next.Visibility = System.Windows.Visibility.Collapsed;
                        ballingdone();
                    }
                }

            }
        }//this checks if someone has lost a wicket

        void score_function()
        {

            if (Easy_Cricket.MainPage.selection == 1) //this means user is batting
            {

                //copied from here

                if (usermakes == 0) //if user takes out fist
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
            else if (Easy_Cricket.MainPage.selection == 2) //this means user is bowling
            {
                // copied from here

                if (c_rand == 0) //if computer generates fist
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
            switch (currentscore) //current score can never be zero
            {
                case 1:
                    Easy_Cricket.MainPage.user_score += 1;
                    makecomment = "That was a single!";
                    break;
                case 2:
                    Easy_Cricket.MainPage.user_score += 2;
                    makecomment = "That was a double";
                    break;
                case 3:
                    Easy_Cricket.MainPage.user_score += 3;
                    makecomment = "That was a three!";
                    break;
                case 4:
                    Easy_Cricket.MainPage.user_score += 4;
                    makecomment = "That was a four";
                    break;
                case 6:
                    Easy_Cricket.MainPage.user_score += 6;
                    makecomment = "And that's a six.";
                    break;
            }

            comment.Text = makecomment;
            user_score.Text = Easy_Cricket.MainPage.user_score.ToString() + "/" + Easy_Cricket.MainPage.user_wicket.ToString();

            battingdone();

        }

        void balling_procedure()
        {
            switch (currentscore) //current score can never be zero
            {
                case 1:
                    Easy_Cricket.MainPage.computer_score += 1;
                    makecomment = "That was a single!";
                    break;
                case 2:
                    Easy_Cricket.MainPage.computer_score += 2;
                    makecomment = "That was a double";
                    break;
                case 3:
                    Easy_Cricket.MainPage.computer_score += 3;
                    makecomment = "That was a three!";
                    break;
                case 4:
                    Easy_Cricket.MainPage.computer_score += 4;
                    makecomment = "That was a four";
                    break;
                case 6:
                    Easy_Cricket.MainPage.computer_score += 6;
                    makecomment = "And that's a six.";
                    break;
            }
            comp_score.Text = Easy_Cricket.MainPage.computer_score.ToString() + "/" + Easy_Cricket.MainPage.computer_wicket.ToString();
            comment.Text = makecomment;

            ballingdone();
        }

        void battingdone()
        {
            if ((Easy_Cricket.MainPage.inning == 2) && (Easy_Cricket.MainPage.user_score > Easy_Cricket.MainPage.computer_score))
            {
                //game winning scenario


                comment.Text = "Game Over. You won.";
                next.IsEnabled = false;
                home.Visibility = System.Windows.Visibility.Visible;

            }
            else if ((Easy_Cricket.MainPage.inning == 2) && (Easy_Cricket.MainPage.user_score == Easy_Cricket.MainPage.computer_score))
            {
                comment.Text = "Game Over. Match tie.";
                next.IsEnabled = false;
                home.Visibility = System.Windows.Visibility.Visible;
            }
            else if ((Easy_Cricket.MainPage.inning == 2) && (Easy_Cricket.MainPage.user_score < Easy_Cricket.MainPage.computer_score))
            {
                comment.Text = "Game Over. You lost.";
                next.IsEnabled = false;
                home.Visibility = System.Windows.Visibility.Visible;
            }
        }

        void ballingdone()
        {
            if ((Easy_Cricket.MainPage.inning == 2) && (Easy_Cricket.MainPage.user_score < Easy_Cricket.MainPage.computer_score))
            {
                comment.Text = "Game Over. You lost.";
                next.IsEnabled = false;
                home.Visibility = System.Windows.Visibility.Visible;
            }
            else if ((Easy_Cricket.MainPage.inning == 2) && (Easy_Cricket.MainPage.user_score == Easy_Cricket.MainPage.computer_score))
            {
                comment.Text = "Game Over. Match tie.";
                next.IsEnabled = false;
                home.Visibility = System.Windows.Visibility.Visible;
            }
            else if ((Easy_Cricket.MainPage.inning == 2) && (Easy_Cricket.MainPage.user_score > Easy_Cricket.MainPage.computer_score))
            {
                comment.Text = "Game Over. You won.";
                next.IsEnabled = false;
                home.Visibility = System.Windows.Visibility.Visible;
            }
        }

        void display() //works on the c_rand generated by computer
        {
            
            switch (c_rand)
            {
                case 0: BitmapImage tn0 = new BitmapImage();
                    tn0.SetSource(Application.GetResourceStream(new Uri(@"Assets/fist.png", UriKind.Relative)).Stream);
                    computer.Source = tn0;
                    break;
                case 1: BitmapImage tn1 = new BitmapImage();
                    tn1.SetSource(Application.GetResourceStream(new Uri(@"Assets/Hands-One-finger-icon.png", UriKind.Relative)).Stream);
                    computer.Source = tn1;
                    break;
                case 2: BitmapImage tn2 = new BitmapImage();
                    tn2.SetSource(Application.GetResourceStream(new Uri(@"Assets/Hands-Two-fingers-icon.png", UriKind.Relative)).Stream);
                    computer.Source = tn2;
                    break;
                case 3: BitmapImage tn3 = new BitmapImage();
                    tn3.SetSource(Application.GetResourceStream(new Uri(@"Assets/Hands-Three-fingers-icon.png", UriKind.Relative)).Stream);
                    computer.Source = tn3;
                    break;
                case 4: BitmapImage tn4 = new BitmapImage();
                    tn4.SetSource(Application.GetResourceStream(new Uri(@"Assets/Hands-Four-fingers-icon.png", UriKind.Relative)).Stream);
                    computer.Source = tn4;
                    break;
                case 6: BitmapImage tn6 = new BitmapImage();
                    tn6.SetSource(Application.GetResourceStream(new Uri(@"Assets/Hands-Thumb-up-icon.png", UriKind.Relative)).Stream);
                    computer.Source = tn6;
                    break;
            }

        }


        private void next_Click(object sender, RoutedEventArgs e)
        {
            comment.Text = "";
            next.IsEnabled = false;
            user.Visibility = System.Windows.Visibility.Collapsed;
            computer.Visibility = System.Windows.Visibility.Collapsed;
            zero.IsHitTestVisible = true;
            one.IsHitTestVisible = true;
            two.IsHitTestVisible = true;
            three.IsHitTestVisible = true;
            four.IsHitTestVisible = true;
            six.IsHitTestVisible = true;
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void back_Tapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

    }
}