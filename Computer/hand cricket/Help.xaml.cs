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

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace hand_cricket
{
    public sealed partial class Help : SettingsFlyout
    {
        public Help()
        {
            this.InitializeComponent();
            tb.Text = "\nThis game is played between two people. Here you play against computer.\n Both the player and the computer selects any of the six hand gestures.\n1> While batting whatever hand gesture you choose that many runs will be added to your score.\n 2> If you select the fist then whatever number of runs the computer selects, will be added to your score.\n 3> You loose a wicket when both you and the computer choses the same hand gesture.\n 4> An innings ends when the batting team looses all wickets.\n\nYou can turn the music in game ON or OFF using the toggle button provided during game.\nFor further help you can contact the publisher.";

        }
    }
}
