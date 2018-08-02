using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liveuamap
{
    class liveArea
    {
        public int id { get; set; }
        public int time { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public object city { get; set; }
        public int ttl { get; set; }
        public string source { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public int color_id { get; set; }
        public int cat_id { get; set; }
        public string picture { get; set; }
        public string link { get; set; }
        public string description { get; set; }
        public int status { get; set; }
        public int updated { get; set; }
        public int resource { get; set; }
        public List<List<object>> points { get; set; }
        public int type_id { get; set; }
        public string strokeweight { get; set; }
        public string strokeopacity { get; set; }
        public string strokecolor { get; set; }
        public string symbolpath { get; set; }
        public string fillcolor { get; set; }
        public string fillopacity { get; set; }
        public string twitpic { get; set; }
        public int user_added { get; set; }
        public int tts { get; set; }
        public int status_id { get; set; }
        public string tags { get; set; }
        public LiveJson json { get; set; }
        public int resid { get; set; }
        public int picw { get; set; }
        public int pich { get; set; }
        public int picwo { get; set; }
        public int picho { get; set; }
        public int picx { get; set; }
        public int picy { get; set; }
        public int picxo { get; set; }
        public int picyo { get; set; }
        public object picpath { get; set; }
        public object picpath_over { get; set; }
        public object videotype { get; set; }
        public object videocode { get; set; }
        public object timestamp { get; set; }
        public string lang { get; set; }
    }
}
