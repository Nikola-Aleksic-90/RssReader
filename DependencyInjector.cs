using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace RssReader
{
    public class DependencyInjector
    {
        private static readonly UnityContainer unityContainer = new UnityContainer();
        
        // kreiramo genericku metodu koja ce raditi sa svim Interfejsima i Tipovima
        // Registrujemo sve tipove koji implementiraju ovaj Interface
        public static void Register<I, T>() where T : I
        {
            unityContainer.RegisterType<I, T>(new ContainerControlledLifetimeManager() );
        }

        // Iz glavnog VM pozvacemo metodu da dobijemo taj instance
        public static T Retrieve<T>()
        {
            // Pogledace instancu ovog odredjenog tipa koji koristimo i vratice tu instancu iz unity container-a.
            return unityContainer.Resolve<T>();
        }

        // Inject instance
        public static void Inject<I>(I instance)
        {
            unityContainer.RegisterInstance<I>(instance, new ContainerControlledLifetimeManager() );
        }
    }
}
