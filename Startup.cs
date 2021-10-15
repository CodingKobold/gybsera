using Gybs;
using Gybs.Data.Repositories;
using Gybs.DependencyInjection.Services;
using Gybs.Logic.Events.InMemory;
using Gybs.Logic.Operations;
using Gybs.Logic.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Gybsera
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RegisterGybsServices(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gybsera", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gybsera v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterGybsServices(IServiceCollection services)
        {
            services.AddGybs(builder =>
            {
                // Basic Dependency Injection
                builder.AddInterfaceServices();
                builder.AddAttributeServices();

                // Repositories
                builder.AddUnitOfWork(ServiceLifetime.Scoped);
                builder.AddRepositories(ServiceLifetime.Scoped);

                // Operations/CQRS
                builder.AddServiceProviderOperationBus();
                builder.AddOperationFactory();
                builder.AddOperationHandlers();

                // Validation
                builder.AddValidation();

                // Events
                builder.AddInMemoryEventBus();

                // EF
                // Not done as it's assuming using of Entity Framework
            });
        }
    }
}
