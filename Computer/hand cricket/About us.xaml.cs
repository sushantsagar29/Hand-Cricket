﻿using System;
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
    public sealed partial class About_us : SettingsFlyout
    {
        public About_us()
        {
            this.InitializeComponent();
            tb.Text = "\nSushant Sagar\nKiit University\nComputer Science And Engg.\n\nMail me at:\nsushant.sagar29@gmail.com\n";

        }
    }
}
