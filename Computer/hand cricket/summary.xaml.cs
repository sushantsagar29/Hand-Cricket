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
using Windows.Storage;
using Windows.Storage.Streams;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace hand_cricket
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class summary : Page
    {
        public summary()
        {
            this.InitializeComponent();
            data.Add("");
            data.Add("");
            data.Add("");
            score.Add("");
            score.Add("");
            score.Add("");//so that both the list has 3 shells in advance
        }

        Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder; //this is the folder in which the file has been written
        //knows folder could also have been used here  StorageFolder folder = KnownFolders.PicturesLibrary;

        List<string> data = new List<string>();//this stores the name which has to be written
        List<string> score = new List<string>();//this stores the score which has to written


        IList<string> data_input;//this store the name which is read from the file

        IList<string> temp;//this stores the score which is read from file in string datatype
        int[] score_input = new int[3];//this stores the score in numeric type from temp
        
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {           
            this.Frame.Navigate(typeof(MainPage));
        }

        string newname;//this store the name to be printed
        int cases;//this store the case constant for score updating

        void calculate()
        {
            int mywdif = hand_cricket.MainPage.wicket_num - hand_cricket.MainPage.user_wicket;
            int cmpwdiff = hand_cricket.MainPage.wicket_num - hand_cricket.MainPage.computer_wicket;

            int mysdiff = hand_cricket.MainPage.user_score - hand_cricket.MainPage.computer_score;
            int cmpsdiff = hand_cricket.MainPage.computer_score - hand_cricket.MainPage.user_score;


            if(hand_cricket.MainPage.selection == 1) //means user batted last
            {
                if(hand_cricket.MainPage.user_score < hand_cricket.MainPage.computer_score )
                {
                    heading.Text = "Sorry. You lost by " + cmpsdiff + " runs";

                    Uri usertemp0 = new Uri("ms-appx:///Assets/try-again.png", UriKind.Absolute);
                    BitmapImage imgSource0 = new BitmapImage(usertemp0);
                    this.smiley.Source = imgSource0;

                }
                else if (hand_cricket.MainPage.user_score == hand_cricket.MainPage.computer_score)
                {
                    heading.Text = "Match Tie!!";

                    Uri usertemp0 = new Uri("ms-appx:///Assets/success-icon.png", UriKind.Absolute);
                    BitmapImage imgSource0 = new BitmapImage(usertemp0);
                    this.smiley.Source = imgSource0;

                }
                else
                {
                    heading.Text = "Congratulations. You won by " + mywdif + " wicket";

                    Uri usertemp0 = new Uri("ms-appx:///Assets/happy-icon.png", UriKind.Absolute);
                    BitmapImage imgSource0 = new BitmapImage(usertemp0);
                    this.smiley.Source = imgSource0;
                }
            }
            else if(hand_cricket.MainPage.selection == 2) //means user bowled last
            {
                if(hand_cricket.MainPage.computer_score < hand_cricket.MainPage.user_score)
                {
                    heading.Text = "Congratulations. You won by " + mysdiff + " runs";

                    Uri usertemp0 = new Uri("ms-appx:///Assets/happy-icon.png", UriKind.Absolute);
                    BitmapImage imgSource0 = new BitmapImage(usertemp0);
                    this.smiley.Source = imgSource0;

                }
                else if (hand_cricket.MainPage.user_score == hand_cricket.MainPage.computer_score)
                {
                    heading.Text = "Match Tie!!";

                    Uri usertemp0 = new Uri("ms-appx:///Assets/success-icon.png", UriKind.Absolute);
                    BitmapImage imgSource0 = new BitmapImage(usertemp0);
                    this.smiley.Source = imgSource0;

                }
                else
                {
                    heading.Text = "Sorry. You lost by " + cmpwdiff + " wicket";
                    Uri usertemp0 = new Uri("ms-appx:///Assets/try-again.png", UriKind.Absolute);
                    BitmapImage imgSource0 = new BitmapImage(usertemp0);
                    this.smiley.Source = imgSource0;

                }


            }

        }


        void xcalculate()
        {
            score_input[0] = int.Parse(temp[0]);//these lines stores the score in numeric form for comparison
            score_input[1] = int.Parse(temp[1]);
            score_input[2] = int.Parse(temp[2]);

            if (hand_cricket.MainPage.user_score >= score_input[0])
                cases = 1;
            else if (hand_cricket.MainPage.user_score >= score_input[1])
                cases = 2;
            else if (hand_cricket.MainPage.user_score >= score_input[2])
                cases = 3;


            switch (cases)
            {
                case 1: data[2] = data_input[1];
                    data[1] = data_input[0];
                    data[0] = newname;
                    write();
                    score[2] = temp[1];
                    score[1] = temp[0];
                    score[0] = hand_cricket.MainPage.user_score.ToString();
                    writex();
                    highscore_canvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    over.IsEnabled = false;
                    break;
                case 2: data[2] = data_input[1];
                    data[1] = newname;
                    data[0] = data_input[0];
                    write();
                    score[2] = temp[1];
                    score[1] = hand_cricket.MainPage.user_score.ToString();
                    score[0] = temp[0];
                    writex();
                    highscore_canvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    over.IsEnabled = false;
                    break;
                case 3: data[2] = newname;
                    data[1] = data_input[1];
                    data[0] = data_input[0];
                    write();
                    score[2] = hand_cricket.MainPage.user_score.ToString();
                    score[1] = temp[1];
                    score[0] = temp[0];
                    writex();
                    highscore_canvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
                    over.IsEnabled = false;
                    break;
            }

        }



        private void lastcode(object sender, RoutedEventArgs e)
        {
            if (hand_cricket.MainPage.music == true)
            {
                chimes.AutoPlay = true;
            }

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
            }
            else
                newname = hand_cricket.MainPage.user_name;// if not longer than 13 chars the whole name is taken

            userblock.Text = newname;//finally this prints the name

            userscore.Text = "run: " + hand_cricket.MainPage.user_score + "\n" +  "wicket: " + hand_cricket.MainPage.user_wicket;
            compscore.Text = "run: " + hand_cricket.MainPage.computer_score + "\n" + "wicket: " + hand_cricket.MainPage.computer_wicket;

            calculate();
            read();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            over.IsEnabled = true;
            highscore_canvas.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }

        async void write()
        {
            StorageFile sampleFile = await localFolder.CreateFileAsync("name.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteLinesAsync(sampleFile, data);
        }

        async void writex()
        {
            StorageFile sampleFile1 = await localFolder.CreateFileAsync("score.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteLinesAsync(sampleFile1, score);
        }


        async void read()
        {
            try
            {
                StorageFile sampleFile = await localFolder.GetFileAsync("name.txt");
                data_input = await FileIO.ReadLinesAsync(sampleFile);
               // xcalculate();
            }
            catch (Exception)
            {
                data[0] = newname;
                data[1] = "<empty>";
                data[2] = "<empty>";
                write();
               // highscore_canvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
               // over.IsEnabled = false;
            }
             try
            {
                StorageFile sampleFile1 = await localFolder.GetFileAsync("score.txt");
                temp = await FileIO.ReadLinesAsync(sampleFile1);
                xcalculate();
            }
            catch (Exception)
            {
                score[0] = hand_cricket.MainPage.user_score.ToString();
                score[1] = "0";
                score[2] = "0";
                writex();
                highscore_canvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
                over.IsEnabled = false;
            }

           
        }


    }
}
