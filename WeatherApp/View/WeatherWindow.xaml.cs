﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WeatherApp.Model;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.View
{
    /// <summary>
    /// Interaction logic for Weather.xaml
    /// </summary>
    public partial class WeatherWindow : Window
    {
        public WeatherWindow()
        {
            InitializeComponent();
        }

        private List<City> cities = new List<City>();

        private void SubmitSearchTerm_OnClick(object sender, RoutedEventArgs e)
        {
            

                
        }
    }
}
