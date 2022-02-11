using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Dejavu;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;

namespace ConsoleApp
{
    public class Program
    {
        private static readonly WindsorContainer _container = new WindsorContainer();

        public static void Main(string[] args)
        {
            var serializer = new JsonObjectSerializer();
            var context = new MemContextProvider(serializer);
            var config = CreateDummyConfiguration(args, context);
            var manager = Init(config, context, serializer);
            var result = manager.Get();
            var content = JsonConvert.SerializeObject(result, Formatting.Indented);
            Console.WriteLine(content);
            Finalize(args, context);
        }

        private static IConfiguration CreateDummyConfiguration(string[] args, MemContextProvider context)
        {
            var dummyConfiguration = new DummyConfiguration();
            if (args.Length == 1)
            {
                if (args[0] == "r")
                {
                    dummyConfiguration["dcir"] = "test_data";
                    context.StartRecording("test_data");
                }
                else if (args[0] == "p")
                {
                    dummyConfiguration["dcip"] = "test_data";
                    context.StartReplaying("test_data", new StreamReader("test_data"));
                }
            }
            else if (args.Length == 2)
            {
                if (args[0] == "r")
                {
                    dummyConfiguration["dcir"] = args[1];
                    context.StartRecording(args[1]);
                }
                else if (args[0] == "p")
                {
                    dummyConfiguration["dcip"] = args[1];
                    context.StartReplaying(args[1], new StreamReader(args[1]));
                }
            }
            return dummyConfiguration;
        }

        private static IExampleManager Init(IConfiguration configuration, IProvideContext context, ISerializeObject serializer)
        {
            InterceptorConfiguration.ConfigureFor(_container, context, serializer);
            _container.Register(Component.For<IRandomNumber>().ImplementedBy<RandomNumber>().LifestyleSingleton());
            _container.Register(Component.For<IRandomActor>().ImplementedBy<RandomActor>().LifestyleSingleton());
            _container.Register(Component.For<IExampleManager>().ImplementedBy<ExampleManager>().LifestyleSingleton());
            _container.Register(Component.For<ILogger>().ImplementedBy<DummyLogger>().LifestyleSingleton());
            _container.Register(Component.For<IConfiguration>().Instance(configuration));
            return _container.Resolve<IExampleManager>();
        }

        private static void Finalize(string[] args, MemContextProvider context)
        {
            if (args.Length == 1)
            {
                if (args[0] == "r")
                {
                    context.StopRecording("test_data", new StreamWriter("test_data"));
                }
                else if (args[0] == "p")
                {
                    context.StopReplaying("test_data");
                }
            }
            else if (args.Length == 2)
            {
                if (args[0] == "r")
                {
                    context.StopRecording(args[1], new StreamWriter(args[1]));
                }
                else if (args[0] == "p")
                {
                    context.StopReplaying(args[1]);
                }
            }
        }
    }
}
