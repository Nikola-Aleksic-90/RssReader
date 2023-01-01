using RssReader.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RssReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            // ovo je bitna naredba jer biramo da li zelimo pravi RssHelper ili "lazni"
            DependencyInjector.Register<IRssHelper, RssHelper>();

            MainWindow = DependencyInjector.Retrieve<MainWindow>();
            MainWindow.Show();
        }
    }
}
