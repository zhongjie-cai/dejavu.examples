using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dejavu;

namespace WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllers().AddControllersAsServices();
        }

        public void ConfigureContainer(IWindsorContainer container)
        {
            InterceptorConfiguration.ConfigureFor<HttpContextProvider, JsonObjectSerializer>(container);

            container.Register(Component.For<IRandomActor>().ImplementedBy<RandomActor>().LifestyleSingleton());
            container.Register(Component.For<IRandomNumber>().ImplementedBy<RandomNumber>().LifestyleSingleton());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
