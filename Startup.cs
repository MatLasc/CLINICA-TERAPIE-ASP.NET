using DAWPROIECTR.Interfaces;
using DAWPROIECTR.Managers;
using DAWPROIECTR.Repositories;
using DAWPROIECTR.Entities;
using DAWPROIECTR.Helpers;
using DAWPROIECTR.Seeds;
using DAWPROIECTR.Configurations;
using DAWPROIECTR.Models;
using DAWPROIECTR.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAWPROIECTR
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

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnString")));
            //services.AddControllers().AddJsonOptions(x =>
            //    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddTransient<IClinicaRepository, ClinicaRepository>();
            services.AddTransient<ITerapeutRepository, TerapeutRepository>();
            services.AddTransient<IProgramareRepository, ProgramareRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IClinicaManager, ClinicaManager>();
            services.AddTransient<IClientManager, ClientManager>();
            services.AddTransient<ITerapeutManager, TerapeutManager>();
            services.AddTransient<IProgramareManager, ProgramareManager>();
            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<ITokenHelper, TokenHelper>();
            //services.AddTransient<Seed>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lab210", Version = "v1" });
            });

        }
            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
         public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seed Seed)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.UseSwagger();
                    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab210 v1"));
                }

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

                Seed.CreateRoles();
            }
        
    }
}
