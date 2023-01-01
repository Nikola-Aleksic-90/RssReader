using RssReader.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssReader.ViewModel
{
    public class MainVM
    {
        // Implementacija Interfejsa
        IRssHelper rssHelper;

        public ObservableCollection<Item> Items { get; set; }

        public MainVM(IRssHelper rssHelper)
        {
            this.rssHelper = rssHelper;

            Items = new ObservableCollection<Item>();

            ReadRss();
        }

        private void ReadRss()
        {
            // Ispravna verzija
            // var posts = RssHelper.GetPosts();

            // Fake verzija
            // var posts = FakeRssHelper.GetPosts();

            var posts = rssHelper.GetPosts();

            Items.Clear();

            foreach(var post in posts)
            {
                Items.Add(post);
            }
            
        }
    }
}
