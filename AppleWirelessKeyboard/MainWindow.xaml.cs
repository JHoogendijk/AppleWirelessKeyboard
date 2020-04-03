﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace AppleWirelessKeyboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void ShowOff(Control glyph, bool valueBar = false, int value = 0)
        {
            this.DataContext = new { Glyph = glyph };

            if (valueBar) ValueBar.Visibility = System.Windows.Visibility.Visible;
            else ValueBar.Visibility = System.Windows.Visibility.Collapsed;

            MakeValue(value);

            this.Show();

            DoubleAnimationUsingKeyFrames Fade = new DoubleAnimationUsingKeyFrames();
            Fade.Duration = new Duration(TimeSpan.FromSeconds(1));
            Fade.KeyFrames.Add(new LinearDoubleKeyFrame(1, KeyTime.FromPercent(0)));
            Fade.KeyFrames.Add(new LinearDoubleKeyFrame(1, KeyTime.FromPercent(0.5)));
            Fade.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromPercent(1)));
            BeginAnimation(OpacityProperty, Fade);
        }
        public void MakeValue(int value)
        {
            ValueBar.Children.Clear();

            for (int i = 0; i <= value; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Fill = new SolidColorBrush(Colors.White);
                rect.Width = 6;
                rect.Height = 6;
                rect.Margin = new Thickness(0, 0, 3, 0);
                ValueBar.Children.Add(rect);
            }
        }
    }
}
