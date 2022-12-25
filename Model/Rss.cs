using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Windows.Data;
using System.Xml.Serialization;
using System.Windows.Media;
using System.Globalization;
using Microsoft.VisualBasic;

namespace RssReader.Model
{
    // Rss feed koji ce se koristiti je : https://mexicomissouri.net/RSSFeed.aspx?ModID=76&CID=All-0
    // Za generisanje klasa koriscen je : https://json2csharp.com/code-converters/xml-to-csharp
    // preimenovana je klasa Rss u MexicoMissouri jer je tako lakse pratiti Udemy kurs
    // Cekirana je samo prva opcija pri konverziji XML u C# i to cemo koristiti. I adlje preimenujemo Rss u MM

    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(Rss));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (Rss)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "item")]
    public class Item
    {

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "link")]
        public string Link { get; set; }

        // Error XDG0003 The string 'Sun, 25 Dec 2022 12:00:07 -0600' is not a valid AllXsd value	
        /*
        [XmlElement(ElementName = "pubDate")]
        public DateTime PubDate { get; set; }
        */
        // Resicemo problem na sledeci nacin:
        // Kreiramo string i jos jedan pomocni property koji ce konvertovati DateTime i vratiti tom stringu
        // Obrati paznju gde stavljamo XmlElement a gde XmlIgnore. Obrati paznju da imamo get; a nemamo set; deo probnog property-ja
        [XmlElement(ElementName = "pubDate")]
        public string PubDate { get; set; }
        [XmlIgnore]
        public bool? Proba
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(PubDate)) return bool.Parse(PubDate);
                return null;
            }
        }
        // Napomena ! Da je propfull onda bi tag trebao da stoji ispod private clana full property-ja
        
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "guid")]
        public string Guid { get; set; }
    }

    [XmlRoot(ElementName = "channel")]
    public class Channel
    {

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "link")]
        public string Link { get; set; }

        /*
        [XmlElement(ElementName = "lastBuildDate")]
        public DateTime LastBuildDate { get; set; }
        */

        [XmlElement(ElementName = "description")]
        public string Description { get; set; }

        [XmlElement(ElementName = "language")]
        public string Language { get; set; }

        [XmlElement(ElementName = "item")]
        public List<Item> Item { get; set; }
    }

    [XmlRoot(ElementName = "rss")]
    public class MexicoMissouri
    {

        [XmlElement(ElementName = "channel")]
        public Channel Channel { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public double Version { get; set; }

        [XmlText]
        public string Text { get; set; }
    }


}
