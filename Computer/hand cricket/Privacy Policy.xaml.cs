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
    public sealed partial class Privacy_Policy : SettingsFlyout
    {
        public Privacy_Policy()
        {
            this.InitializeComponent();
            tb.Text = "\nAll rights reserved with Sushant Sagar.\nIf you have any questions, complaints, or comments regarding the Privacy Policy or this app, please contact me.\n\nCopyright ©2014 Sushant Sagar";

        }
    }
}
