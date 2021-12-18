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

        private static IManageWeatherForecast Init(IConfiguration configuration)
        {
            InterceptorConfiguration.ConfigureFor<FileContextProvider, JsonObjectSerializer>(_container);
            _container.Register(Component.For<IAct>().ImplementedBy<RandomActor>().LifestyleSingleton());
            _container.Register(Component.For<IManageWeatherForecast>().ImplementedBy<WeatherForecastManager>().LifestyleSingleton());
            _container.Register(Component.For<ILogger>().ImplementedBy<DummyLogger>().LifestyleSingleton());
            _container.Register(Component.For<IConfiguration>().Instance(configuration));
            return _container.Resolve<IManageWeatherForecast>();
        }
    }
}
