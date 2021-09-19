using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metaapp.WeatherApi
{
    public class WeatherModel
    {
        public string City { get; set; }

        public double Temperature { get; set; }

        public int Precipitation { get; set; }

        public string Weather { get; set; }
    }
}
