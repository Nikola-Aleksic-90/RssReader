using RssReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.ViewModel
{
    public class FakeRssHelper : IRssHelper
    {
        public List<Item> GetPosts()
        {
            List<Item> items = new List<Item>();

            items.Add(new Item()
            {
                Title = "Naslov ne moze da stane u ceo prozor jer je previse dugacak. Zbog toga smo kreirali ovakav string da UI/UX vide da nesto treba da promeni",
                Description = "Naslov sam sebe opisuje",
                PubDate = "Malopre",
                Link = "www.sredi.ovo.sto.pre.com"
            });

            items.Add(new Item()
            {
                Title = "",
                Description = "Vidi se da fali naslov",
                PubDate = "Prepodne",
                Link = "naslova__bez.com"
            });

            items.Add(new Item()
            {
                Title = "чћжшђљњ   čćžšđ",
                Description = "proba da se vidi da li prepoznaje znakove",
                PubDate = "25:61:72 , 31.Feb. 3415",
                Link = "probaj__i__glagoljicu.co.rs"
            });

            return items;
        }
    }
}
