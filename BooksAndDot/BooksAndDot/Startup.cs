using BooksAndDot.Models;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace BooksAndDot {
    public class Startup {

        readonly string MyAppCors = "_myAppCors";
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services) {
            services.AddCors(opt => opt.AddPolicy(name: MyAppCors,
                policy =>
                {
                    policy.WithOrigins("http://localhost:3000");
                }));
            services.AddControllers();
            services.AddDbContext<AppDbContext>();
            services.AddSwaggerGen(c => { 
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BooksAndDot", Version = "v1" }); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(
                    c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookAndDot v1"));
            }

            app.UseCors(MyAppCors);

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                //endpoints.MapSwagger();
            });
        }
    }
}
