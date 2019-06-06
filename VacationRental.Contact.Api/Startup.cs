namespace VacationRental.Contact.Api
{
    using Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;
    using VacationRental.Contact.Domain.Extensions;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddRentalServices();
            services.AddSwaggerGen(opts => opts.SwaggerDoc("v1", new Info { Title = "Vacation rental contact information", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionMiddleware();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(opts => opts.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact v1"));

            // Uncomment this line if using a full SqlServer database to ensure the sql
            // schema gets generated the first time on the target database.
            // app.ApplicationServices.EnsureDatabaseCreated();
        }
    }
}
