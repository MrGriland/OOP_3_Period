using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_7.Classes
{
    public class Ad
    {
        public int ID { get; set; }
        public string FullName { get; set; } 
        public string ShortName { get; set; } 
        public string Category { get; set; }
        public double Raiting { get; set; } 
        public decimal Cost { get; set; } 
        public int Amount { get; set; }

        public int GetID()
        {
            bool uniquenessFlag = true;
            List<Ad> adList = Serialization.Deserialize();
            int unicID = 0;
            Random rnd = new Random();
            while (uniquenessFlag)
            {
                unicID = rnd.Next(0, 9999);
                var linqQuery = from ad in adList where ad.ID == unicID select ad;
                if (linqQuery.Count() == 0)
                {
                    uniquenessFlag = false;
                }
            }

            return unicID;
        }
    }
}
