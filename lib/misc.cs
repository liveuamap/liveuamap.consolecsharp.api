using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liveuamap
{
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class WeatherProperties
    {
        public double temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
    }
    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }
    public class Rain
    {
        public double chance { get; set; }
    }

    public class Sys
    {
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public int? type { get; set; }
        public int? id { get; set; }
    }

    public class Wt
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public WeatherProperties main { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
        public Rain rain { get; set; }
        public int? visibility { get; set; }
    }
    public class LiveJson
    {
        public string video { get; set; }
        public string d { get; set; }
        public string w { get; set; }
        public object p { get; set; }
        public List<object> moreRegs { get; set; }
        public string location { get; set; }
        public List<double> square { get; set; }
        public object runway { get; set; }
        public Wt wt { get; set; }
    }
    public class Center
    {
        public string type { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public int zoom { get; set; }
        public string align { get; set; }
    }
}
