using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Net;
using System.IO;
using System.Web.Script.Serialization;//Project->References ->Add Reference -> [+] System.Web.Extensions 


namespace Liveuamap
{
    public enum errorCodes
    {
        BadApiMethod = 99,//Bad API Method provided
        NoApiKey = 100,//"No API key provided",
        BadApiKey = 101,//="Bad API key provided"
        WebServerError=97//Some server error (500,404 etc)
    }
    public enum Regions //actually use database for regions
    {
        Default = -1,
        Kenya = 135,
        Venezuela = 70,
        Kashmir = 55,
        Koreas = 9,
        Belarus = 31,
        Russia = 18,
        Spain = 146,
        Ukraine = 0,
        Afghanistan = 56,
        Egypt = 16,
        Iraq = 65,
        ISIS = 5,
        IsraelPalestine = 2,
        Libya = 54,
        Qatar = 73,
        Syria = 3,
        Turkey = 19,
        Yemen = 53,
        California = 75,
        DistrictColumbia = 125,
        Florida = 77,
        NewYork = 78,
        Texas = 76,
        USA = 22,
        Europe = 10,
        MiddleEast = 7,
        World = 1,
        Balkans = 29,
        Caucasus = 4,
        Hezbollah = 71,
        Iran = 66,
        Pakistan = 69,
        Philippines = 72,
        Virginia = 86,
        Africa = 8,
        Asia = 6,
        AlShabab = 67,
        DRCongo = 152,
        Ethiopia = 159,
        Nigeria = 158,
        Sahel = 166,
        Somalia = 138,
        SouthAfrica = 155,
        Sudans = 147,
        Tanzania = 157,
        Uganda = 144,
        Brazil = 64,
        Caribbean = 154,
        Colombia = 63,
        Guyana = 140,
        Mexico = 133,
        Nicaragua = 167,
        Bangladesh = 153,
        CentralAsia = 57,
        China = 24,
        HongKong = 12,
        India = 26,
        Japan = 149,
        Myanmar = 148,
        Taiwan = 142,
        Thailand = 151,
        Vietnam = 150,
        Baltics = 52,
        CentralandEasternEurope = 129,
        France = 162,
        Germany = 161,
        Hungary = 20,
        Ireland = 139,
        Italy = 163,
        MinskMonitor = 62,
        Moldova = 137,
        NorthEurope = 160,
        Poland = 30,
        UK = 141,
        Visegrad4 = 127,
        Kurds = 50,
        Lebanon = 74,
        Corruption = 136,
        Energy = 143,
        Indonesia = 156,
        Houston = 168,
        Alabama = 97,
        Alaska = 122,
        Arizona = 89,
        Arkansas = 105,
        Colorado = 96,
        Connecticut = 103,
        Delaware = 119,
        Georgia = 82,
        Hawaii = 114,
        Idaho = 113,
        Illinois = 79,
        Indiana = 90,
        Iowa = 104,
        Kansas = 108,
        Kentucky = 126,
        Louisiana = 99,
        Maine = 115,
        Maryland = 93,
        Massachusetts = 88,
        Michigan = 84,
        Minnesota = 95,
        Mississippi = 106,
        Missouri = 92,
        Montana = 118,
        Nebraska = 111,
        Nevada = 109,
        NewHampshire = 116,
        NewJersey = 85,
        NewMexico = 110,
        NorthCarolina = 83,
        NorthDakota = 121,
        Ohio = 81,
        Oklahoma = 102,
        Oregon = 101,
        Pennsylvania = 80,
        PuertoRico = 128,
        RhodeIsland = 117,
        SouthCarolina = 98,
        SouthDakota = 120,
        Tennessee = 91,
        USprotests = 15,
        Utah = 107,
        Vermont = 123,
        Washington = 87,
        WestVirginia = 112,
        Wisconsin = 94,
        Wyoming = 124,
        AlQaeda = 130,
        America = 11,
        Arctic = 49,
        Avia = 34,
        Climate = 145,
        Cyberwar = 21,
        Disasters = 27,
        DrugsWar = 131,
        Farleft = 165,
        Farright = 164,
        Health = 36,
        HumanRights = 28,
        LifeStyle = 35,
        Pacific = 23,
        Piracy = 68,
        Roads = 51,
        Sports = 37,
        TradeWars = 17,
        Travel = 32,
        War = 33,
        Wildlife = 38,
        Women = 14


    }

    class liveuamap
    {
        //Liveuamap server
        protected string liveuamapApi = "https://a.liveuamap.com/api";


        private string lastError = "";
        private bool executedWithError = false;
        private int lastErrorCode = -1;

        private string method = "";
        private string access_token = "";
        private int count = 100;
        private long liveTime = 0;
        private Regions liveRegion = Regions.Default;


        private mpts response;
        public liveuamap(string access_token)
        {
            this.access_token = access_token;

        }
        public void setRegion(Regions rgn)
        {
            this.liveRegion = rgn;
        }
        public void setCount(int count)
        {
            this.count = count;
        }
        public void setTime(DateTime dt)
        {
            long unixTime = ((DateTimeOffset)dt).ToUnixTimeSeconds();
            this.liveTime = unixTime;
        }
        private long timeNow()
        {
            DateTime foo = DateTime.UtcNow;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            return unixTime;
        }
        public mpts getMpts()
        {
            return getMpts("mpts", Regions.Syria, this.timeNow(), this.count);
        }
        public mpts getMpts(Regions rgn,DateTime dt)
        {
            long unixTime = ((DateTimeOffset)dt).ToUnixTimeSeconds();
            return getMpts("mpts", rgn, unixTime, this.count);
        }
        public mpts getMpts(string method, Regions region, long time, int count)
        {
            this.method = method;
            this.count = count;
            this.liveTime = time;
            this.liveRegion = region;

            Dictionary<string, object> resultJs = this.execute();


            mpts result;

            if (!this.executedWithError)
                result = new mpts(resultJs);
            else result = new mpts();

            return result;
        }
        public bool wasExecutedWithError()
        {
            return this.executedWithError;
        }
        private Dictionary<string, object> execute()
        {

            this.executedWithError = false;
            Dictionary<string, object> result = new Dictionary<string, object>();
            string url = String.Format("{3}?a={2}&resid={5}&time={4}&count={1}&key={0}", this.access_token, this.count, this.method, this.liveuamapApi, this.liveTime, (int)this.liveRegion);

            var liveapi = WebRequest.Create(url) as HttpWebRequest;
            liveapi.Method = "GET";
            string responseJson = "";
            try
            {
                string respbody = null;
                using (var resp = liveapi.GetResponse().GetResponseStream())//there request sends
                {
                    var respR = new StreamReader(resp);
                    responseJson = respR.ReadToEnd();


                }


                var JSONObj = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(responseJson);
                if (Convert.ToBoolean(JSONObj["success"]))
                {
                    result = JSONObj;
                }
                else
                {
                    this.executedWithError = true;
                    if(!string.IsNullOrEmpty(JSONObj["success"].ToString()))
                        this.lastError = Convert.ToString(JSONObj["message"]);

                    if (!string.IsNullOrEmpty(JSONObj["success"].ToString()))
                        this.lastErrorCode = Convert.ToInt32(JSONObj["error_code"]);
                }
            }
            catch (Exception ex)
            {
                this.executedWithError = true;
                this.lastError = "Web Server Error";
                this.lastErrorCode = 97;
            }

            return result;
        }
    }
}
