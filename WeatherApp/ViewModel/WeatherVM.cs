using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        public SearchCommand SearchCommand { get; set; }

        public ObservableCollection<City> Cities { get; set; }
        

        public WeatherVM()
        {

            //Only set initial values when in "Design Mode". When application runs, it wont be set
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                SelectedCity = new City {LocalizedName = "Cape Town"};
                CurrentConditions = new CurrentConditions
                {
                    WeatherText = "Hot and sunny day",
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = "32"
                        }
                    }
                };
            }

            SearchCommand = new SearchCommand(this);

            Cities = new ObservableCollection<City>();

        }
            

        private string _query;

        public string Query
        {
            get  => _query; 
            set
            {
                _query = value;
                OnPropertyChanged("Query");
            }
        }
        
        private CurrentConditions _currentConditions;

        public CurrentConditions CurrentConditions
        {
            get  => _currentConditions;

            set
            {
                _currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        private City _selectedCity;

        public City SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
               
                if (_selectedCity != null)
                {
                    OnPropertyChanged("SelectedCity");
                    GetCurrentConditions();
                }
                
            }
        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);
            
            //Avoiding duplicates and always clear before generation
            Cities.Clear();
            
            //Adding cities to observable collection
            foreach (var city in cities)
            {
                Cities.Add(city);
            }
            
        }

        private async void GetCurrentConditions()
        {
            //Once city is found, Query and list of cities is no longer needed
           Query = string.Empty;
            //Cities.Clear();

            //_currentConditions = new CurrentConditions();
            _currentConditions = await AccuWeatherHelper.GetConditions(SelectedCity.Key);
            
        }

       


        public event PropertyChangedEventHandler PropertyChanged;
        
        private void OnPropertyChanged(string propertyName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }


    }
}
