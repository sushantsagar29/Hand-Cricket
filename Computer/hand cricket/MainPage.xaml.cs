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
using Windows.UI.ViewManagement;
using Windows.Storage;
using Windows.Storage.Streams;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace hand_cricket
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

     
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

        public static bool music; //wheather to play music in the game or not

        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

        IList<string> data_input;//this store the name which is read from the file

        IList<string> temp;//this stores the score which is read from file in string datatype
        //int[] score_input = new int[3];//this stores the score in numeric type from temp

        private void button_score_Click(object sender, RoutedEventArgs e) //change
        {
            border2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            border3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            border1.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void button_instruction_Click(object sender, RoutedEventArgs e)
        {
            border1.Visibility = Windows.UI.Xaml.Visibility.Collapsed; //change
            border3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            border2.Visibility = Windows.UI.Xaml.Visibility.Visible;
            instruction_block.Text = "                        Instructions\n Both the player and the computer selects any of the six hand gestures.\n 1> While batting whatever hand gesture you choose that many runs will be added to your score.\n 2> If you select the fist then whatever number of runs the computer selects, will be added to your score.\n 3> You loose a wicket when both you and the computer choses the same hand gesture.\n 4> An innings ends when the batting team looses all wickets.";
        }

        private void button_about_Click(object sender, RoutedEventArgs e)
        {
            border1.Visibility = Windows.UI.Xaml.Visibility.Collapsed; //change
            border2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            about_block.Text = "\n                         About Us        \n\n Sushant Sagar\n Kiit University\n Computer Science And Engg.\n sushant.sagar29@gmail.com";
            border3.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }

        private void close_score_Click(object sender, RoutedEventArgs e)//change
        {
            border1.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void close_instruction_Click(object sender, RoutedEventArgs e)
        {
            border2.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void close_about_Click(object sender, RoutedEventArgs e)
        {
            border3.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        private void play_hyper_Click(object sender, RoutedEventArgs e)
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
            this.Frame.Navigate(typeof(entry));
        }

        private void mainloaded(object sender, RoutedEventArgs e)
        {
            read();
        }

        async void read()
        {
            //deep.Text = data[2];
            try
            {
                StorageFile sampleFile = await localFolder.GetFileAsync("name.txt");
                data_input = await FileIO.ReadLinesAsync(sampleFile);
                n1.Text = data_input[0];
                n2.Text = data_input[1];
                n3.Text = data_input[2];
            }
            catch (Exception)
            {
                // file not found
                n1.Text = "<empty>";
                n2.Text = "<empty>";
                n3.Text = "<empty>";
                
            }
            try
            {
                StorageFile sampleFile1 = await localFolder.GetFileAsync("score.txt");
                temp = await FileIO.ReadLinesAsync(sampleFile1);

                s1.Text = temp[0];
                s2.Text = temp[1];
                s3.Text = temp[2];
            }
            catch (Exception)
            {
                s1.Text = "0";
                s2.Text = "0";
                s3.Text = "0";
               
            }
        }
    }
}
