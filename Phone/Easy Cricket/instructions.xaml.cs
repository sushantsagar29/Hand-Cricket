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
    public partial class instructions : PhoneApplicationPage
    {
        public instructions()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            content.Text = " Both the player and the computer selects any of the six hand gestures.\n 1> While batting whatever hand gesture you choose that many runs will be added to your score.\n 2> If you select the fist then whatever number of runs the computer selects, will be added to your score.\n 3> You loose a wicket when both you and the computer choses the same hand gesture.\n 4> An innings ends when the batting team looses all wickets.";
        }
    }
}