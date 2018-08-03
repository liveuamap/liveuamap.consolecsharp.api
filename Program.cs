using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Liveuamap;


namespace csharpapi
{
    class Program
    {
        //see more information at https://me.liveuamap.com/devapi
        //get api key at https://me.liveuamap.com/devapi Your api key
        static void Main(string[] args)
        {
            string access_token = "25b7c1b9905101cbf1551d534da9e811";
            liveuamap lapi = new liveuamap(access_token);

            lapi.setCount(20);//20 latest events

            //get latest liveuamap points for Afghanistan and Now
            mpts newmpts = lapi.getMpts(Regions.Afghanistan,DateTime.Now);

            if (!lapi.wasExecutedWithError()) { 
            foreach(liveEvent le in newmpts.events)
            {
                    Console.WriteLine(string.Format("{0}: {1} at {2},{3}", le.timeDt.ToString("HH:mm dd.MM"), le.name.Trim(),le.lat,le.lng));
                }
            }
            else
            {
                Console.WriteLine("There was an error");
            }
            Console.WriteLine("Press any key");
            Console.Read();
            
        }
    }
}
