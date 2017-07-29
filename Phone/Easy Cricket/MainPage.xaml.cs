using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Easy_Cricket.Resources;

namespace Easy_Cricket
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        public static string user_name = "You";
        public static string wicket;
        public static int wicket_num;

        public static int inning;
        public static int selection;
        public static int result;

        public static int user_score;
        public static int computer_score;
        public static int user_wicket = 0;
        public static int computer_wicket = 0;


        private void play_button_Click(object sender, RoutedEventArgs e)
        {
            wicket = "0";
            wicket_num = 0;

            inning = 0;
            selection = 0;
            //result = 0;

            user_score = 0;
            computer_score = 0;
            user_wicket = 0;
            computer_wicket = 0;

            NavigationService.Navigate(new Uri("/entry.xaml", UriKind.Relative));
        }

        private void about_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/about.xaml", UriKind.Relative));
        }

        private void inst_button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/instructions.xaml", UriKind.Relative));

        }

        private void exit_button_Click(object sender, RoutedEventArgs e)
        {

            Application.Current.Terminate();
        }
    
    }
}