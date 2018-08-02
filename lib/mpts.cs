using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Liveuamap
{
    class mpts
    {
        public bool success { get; set; }
        public string key { get; set; }
        public int freerequests { get; set; }
        public int last { get; set; }
        public List<liveEvent> events { get; set; }//events
        public List<liveArea> areas { get; set; }//areas

        public List<object> kmls { get; set; }//kmls used in region

        public int datats { get; set; }
        public string datac { get; set; }
        public string datamn { get; set; }
        public string datam { get; set; }
        public string datay { get; set; }
        public int amount { get; set; }
        public int count { get; set; }
        public List<int> res { get; set; }
        public List<Center> center { get; set; }
        public bool isGood { get; set; }
        public mpts()
        {
            //empty object
        }
        public mpts(Dictionary<string, object> jsonobj)
        {
            this.success = Convert.ToBoolean(jsonobj["success"]);
            this.key = jsonobj["key"].ToString();
            this.freerequests = Convert.ToInt32(jsonobj["freerequests"]);
            this.freerequests = Convert.ToInt32(jsonobj["amount"]);
            this.freerequests = Convert.ToInt32(jsonobj["count"]);

            this.last = Convert.ToInt32(jsonobj["last"]);
            this.datats = Convert.ToInt32(jsonobj["datats"]);

            this.datac = jsonobj["datac"].ToString();
            this.datamn = jsonobj["datamn"].ToString();
            this.datay = jsonobj["datay"].ToString();
            this.datam = jsonobj["datam"].ToString();

            this.isGood = Convert.ToBoolean(jsonobj["isGood"]);

            List<liveEvent> li = new List<liveEvent>();

           foreach (Dictionary<string, object> diEvent in (ArrayList)jsonobj["venues"])
            {

                li.Add(new liveEvent(diEvent));
            }
            this.events = li;
        }
    
    }
}
