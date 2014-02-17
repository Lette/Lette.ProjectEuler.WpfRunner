using System.Windows;
using Lette.ProjectEuler.Math;
using Lette.ProjectEuler.WpfRunner.View;
using StructureMap;

namespace Lette.ProjectEuler.WpfRunner
{
    public partial class App
    {
        private void OnAppStartup(object sender, StartupEventArgs e)
        {
            InitializeMathLibrary();

            InitializeContainer();

            InitializeMainController();
        }

        private void InitializeMathLibrary()
        {
            // Force initialisation of Primes class
            // ReSharper disable IteratorMethodResultIsIgnored
            2L.Factors();
            // ReSharper restore IteratorMethodResultIsIgnored
        }

        private void InitializeContainer()
        {
            ObjectFactory.Configure(x => x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.Assembly("Lette.ProjectEuler.Core");
                    scan.WithDefaultConventions();
                }));
        }

        private static void InitializeMainController()
        {
            var controller = ObjectFactory.GetInstance<IMainController>();
            controller.Initialize();
        }
    }
}