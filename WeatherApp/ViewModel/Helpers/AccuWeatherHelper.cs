using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
    public static class AccuWeatherHelper
    {

        public const string BaseURL = "http://dataservice.accuweather.com/";
        public const string ApiKey = "asNUGUjQALGU7NGAxmJlGJ5Y8xlEB0YH";
        
        //AutoComplete EndPoint
        public const string AutoCompleteEndPoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}";

        public static string CityKey { get; set; }

        //CurrentConditions EndPoint
        public const string CurrentConditionsEndPoint = "currentconditions/v1/{0}?apikey={1}";


        public static async Task<List<City>> GetCities (string query)
        {

            //Setting up environment
            string formattedRequest = BaseURL + string.Format(AutoCompleteEndPoint, ApiKey, query);

            List<City> locationsCities = new List<City>();

            using HttpClient client = new HttpClient();

            
                //Sending Request & saving response

                var response = await client.GetAsync(formattedRequest);

                var jsonString = await response.Content.ReadAsStringAsync();

                //Deserialise the json string to get the list of cities

                locationsCities = JsonConvert.DeserializeObject<List<City>>(jsonString);

                if (locationsCities != null)
                {
                    CityKey = locationsCities.FirstOrDefault().Key;
                    
                }
                
               return locationsCities;

              

        }

        public static async Task<CurrentConditions> GetConditions(string cityKey)
        {
            CurrentConditions currentConditions = new CurrentConditions();

            //Setting up environment
            string formattedRequest = BaseURL + string.Format(CurrentConditionsEndPoint, cityKey, ApiKey);

            using HttpClient client = new HttpClient();
            
            //Sending Request & saving response

            var response = await client.GetAsync(formattedRequest);

            var jsonString = await response.Content.ReadAsStringAsync();

            //Deserialise the json string to get the list of cities

            currentConditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(jsonString)).FirstOrDefault();
            
            return currentConditions;
            
        }




        }

    }

    

