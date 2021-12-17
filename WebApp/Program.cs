using Castle.Windsor;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(
                args
            ).UseWindsorContainerServiceProvider(
                new WindsorContainer()
            ).ConfigureWebHostDefaults(
                webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }
            ).Build().Run();
        }
    }
}
