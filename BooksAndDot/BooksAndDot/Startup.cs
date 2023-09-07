using BooksAndDot.Authentication;
using BooksAndDot.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
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
                    policy.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                }));
            services.AddControllersWithViews()
            .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //services.AddControllers(opt => opt.RespectBrowserAcceptHeader = true).AddNewtonsoftJson(opt => opt.JsonSerializerOptions.Re)
            //services.AddControllers().AddNewtonsoftJson()
            services.AddControllers();
            services.AddDbContext<AppDbContext>();
            services.AddSwaggerGen(c => { 
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BooksAndDot", Version = "v1" }); });
            
            // Добавление сервиса аутенфикации. Аутенфикация - процесс проверки что пользователь
            // является тем, за кого себя выдает (проверка по имени и паролю)
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false; // Указывает что SSL при отправке токена не используется
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Указывает будет ли валидироваться издатель при валидации
                        ValidateIssuer = true,
                        // Строка, представляющая издателя
                        ValidIssuer = AuthOptions.ISSUER,
                        // Будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // Установка потребителя токена
                        ValidAudience = AuthOptions.AUDINCE,
                        // Будет ли валидироваться время существования
                        ValidateLifetime = true,
                        // Установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // Валидация ключа безопасноти
                        ValidateIssuerSigningKey = true,
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            /*
             * app.Run(async (context) =>
            {
                //await context.Response.WriteAsync("Hello World!");
            });*/
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(
                    c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookAndDot v1"));
            }
            
            app.UseCors(MyAppCors);
            //использовать Serilog при каждом запросе
            app.UseSerilogRequestLogging();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
                //endpoints.MapSwagger();
            });
        }
    }
}
