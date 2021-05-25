using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab6_7.Classes
{
    public static class Serialization
    {
        public static void Serialize(List<Ad> adsForSerialize)
        {
            List<Ad> advertsForSerialize = adsForSerialize;
            XmlSerializer xmlf = new XmlSerializer(advertsForSerialize.GetType());

            using (FileStream fs = new FileStream("data.xml", FileMode.Create))
            {
                xmlf.Serialize(fs, advertsForSerialize);
            }
        }

        public static void Serialize(Ad ad)
        {
            List<Ad> advertsForSerialize;
            advertsForSerialize = Deserialize();
            advertsForSerialize.Add(ad);
            XmlSerializer xmlf = new XmlSerializer(advertsForSerialize.GetType());

            using (FileStream fs = new FileStream("data.xml", FileMode.OpenOrCreate))
            {
                xmlf.Serialize(fs, advertsForSerialize);
            }
        }

        public static List<Ad> Deserialize()
        {
            if (File.Exists("data.xml"))
            {
                List<Ad> advertsForSerialize = new List<Ad>();

                XmlSerializer xmlf = new XmlSerializer(advertsForSerialize.GetType());

                using (FileStream fs = new FileStream("data.xml", FileMode.OpenOrCreate))
                {
                    advertsForSerialize = (List<Ad>)xmlf.Deserialize(fs);
                }

                return advertsForSerialize;
            }
            else return new List<Ad>();
        }
    }
}
