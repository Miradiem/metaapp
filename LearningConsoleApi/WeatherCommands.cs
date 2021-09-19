//using metaapp.WeatherApi;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace metaapp
//{
//    public class WeatherCommands
//    {
//        private readonly string[] _argsCities;
//        private readonly AuthorizedWeatherApi _api;


//        public WeatherCommands(string[] argsCities, AuthorizedWeatherApi api)
//        {
//            _argsCities = argsCities;
//            _api = api;
//        }

//        public async Task Build()
//        {
//            foreach (var town in _argsCities)
//            {
//                WeatherDisplay.Show(await _api.WeatherData(town));
//            }
//        }
//    }
//}
