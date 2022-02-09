using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Dejavu;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace ConsoleApp
{
    public class Program
    {
        private static readonly WindsorContainer _container = new WindsorContainer();

        public static void Main(string[] args)
        {
            var config = CreateDummyConfiguration(args);
            var manager = Init(config);
            var result = manager.Get();
            var content = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(content);
        }

        private static IConfiguration CreateDummyConfiguration(string[] args)
        {
            var dummyConfiguration = new DummyConfiguration();
            if (args.Length == 1)
            {
                if (args[0] == "r")
                {
                    dummyConfiguration["dcir"] = "test_data.json";
                }
                else if (args[0] == "p")
                {
                    dummyConfiguration["dcip"] = "test_data.json";
                }
            }
            else if (args.Length == 2)
            {
                if (args[0] == "r")
                {
                    dummyConfiguration["dcir"] = args[1];
                }
                else if (args[0] == "p")
                {
                    dummyConfiguration["dcip"] = args[1];
                }
            }
            return dummyConfiguration;
        }

        private static IExampleManager Init(IConfiguration configuration)
        {
            InterceptorConfiguration.ConfigureFor<FileContextProvider, JsonObjectSerializer>(_container);
            _container.Register(Component.For<IRandomNumber>().ImplementedBy<RandomNumber>().LifestyleSingleton());
            _container.Register(Component.For<IRandomActor>().ImplementedBy<RandomActor>().LifestyleSingleton());
            _container.Register(Component.For<IExampleManager>().ImplementedBy<ExampleManager>().LifestyleSingleton());
            _container.Register(Component.For<ILogger>().ImplementedBy<DummyLogger>().LifestyleSingleton());
            _container.Register(Component.For<IConfiguration>().Instance(configuration));
            return _container.Resolve<IExampleManager>();
        }
    }
}
