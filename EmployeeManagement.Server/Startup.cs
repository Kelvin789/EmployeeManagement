using EmployeeManagement.Server.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Server
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
            // TODO: Custom services via EmployeeManagement.Shared.Services class approach
            //services.AddScoped<ConfigService>();
            //services.AddScoped<EmployeeManagementDb>();

            // Database context connection link
            services.AddDbContext<EmployeeManagementDb>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EmployeeManagementDb"));
            });

            // Define connection policy
            services.AddCors(options => 
            {
                options.AddPolicy(name: "CorsPolicy",
                    builder =>
                    {
                        // Code to allow ANY origin (for testing)
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();

                        // Code to specify origin
                        //builder.WithOrigins("https://localhost:44376/")
                        //       .WithMethods("GET", "POST");
                    });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy"); // Allows connection between Client and Server projects

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
