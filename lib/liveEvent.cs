using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liveuamap
{
    public class liveEvent
    {
        public string videocode { get; set; }
        public int? videotype { get; set; }
        public int resid { get; set; }
        public string name { get; set; }
        public string video { get; set; }
        public int id { get; set; }
        public string time { get; set; }
        public DateTime timeDt { get; set; }//datetime

        public List<object> pics { get; set; }
        public int timestamp { get; set; }
        public string source { get; set; }
        public string picpath { get; set; }
        public int status_id { get; set; }
        public string svimg { get; set; }//category
        public int resource { get; set; }
        public int type_id { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string link { get; set; }
        public string picture { get; set; }
        public string otherregions { get; set; }
        public object city { get; set; }
        public string img_share { get; set; }
        public string location { get; set; }
        public string points { get; set; }
        public string viaSource { get; set; }
        public bool runway { get; set; }


        public liveEvent(Dictionary<string, object> jsonobj)
        {
            if(jsonobj["videocode"]!=null)
            this.videocode = jsonobj["videocode"].ToString();

            this.name = jsonobj["name"].ToString();

            if (jsonobj["location"] != null)
                this.location = jsonobj["location"].ToString();

            if (jsonobj["picture"] != null)
                this.picture = jsonobj["picture"].ToString();

            this.lat = jsonobj["lat"].ToString();
            this.lng = jsonobj["lng"].ToString();
            this.source = jsonobj["source"].ToString();
            this.link = jsonobj["link"].ToString();
            this.time = jsonobj["timestamp"].ToString();

            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            this.timeDt = epoch.AddSeconds(Convert.ToInt64(this.time));

            //resources
            this.resid = Convert.ToInt32(jsonobj["resid"]);
            this.resource= Convert.ToInt32(jsonobj["resource"]);
            //this.rid = Convert.ToInt32(jsonobj["rid"]);


            
        }
    }
}
