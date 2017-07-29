using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Easy_Cricket
{
    public partial class entry : PhoneApplicationPage
    {
        public entry()
        {
            InitializeComponent();
        }


        string message1 = "You Win";
        string message2 = "You Loose";
        int c_rand;
        int userwin = 0, userloss = 0;


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            enter_name.Text = Easy_Cricket.MainPage.user_name;
        }

        private void toss_Click(object sender, RoutedEventArgs e)
        {
            if (enter_name.Text == "")
            {
                Easy_Cricket.MainPage.user_name = enter_name.Text;
            }
            else
                Easy_Cricket.MainPage.user_name = enter_name.Text;



         //   Easy_Cricket.MainPage.wicket = enter_wicket.SelectedItem.ToString();
          //  Easy_Cricket.MainPage.wicket_num = int.Parse(Easy_Cricket.MainPage.wicket);

            toss.IsEnabled = false;
            //enter_name.Focus(FocusState.Programmatic);
            toss_result();

        }

        void toss_result()
        {
            Random rnd = new Random();
            c_rand = rnd.Next(1, 11);

            if (c_rand % 2 == 0) //if even, user wins the toss
            {
                userwin = 1;
                result.Text = message1;
                bat.Visibility = System.Windows.Visibility.Visible;
                bowl.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                userloss = 1;
                result.Text = message2;
                comment.Visibility = System.Windows.Visibility.Visible;
            }
            next.Visibility = System.Windows.Visibility.Visible;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (userloss == 1)
            {
                Easy_Cricket.MainPage.selection = 2; //2 is for bowling
            }
            else if (userwin == 1)
            {
                if (bat.IsChecked == true)
                {
                    Easy_Cricket.MainPage.selection = 1; //batting
                }
                else if (bowl.IsChecked == true)
                {
                    Easy_Cricket.MainPage.selection = 2; //bowling
                }
            }

            Easy_Cricket.MainPage.inning = 1;

            NavigationService.Navigate(new Uri("/play.xaml", UriKind.Relative));
        }

        private void one_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Easy_Cricket.MainPage.wicket_num = 1;
        }

        private void three_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Easy_Cricket.MainPage.wicket_num = 2;
        }

        private void two_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Easy_Cricket.MainPage.wicket_num = 3;
        }

    }
}