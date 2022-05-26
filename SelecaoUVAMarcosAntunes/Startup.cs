using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SelecaoUVA.Application;
using SelecaoUVA.Application.Contracts;
using SelecaoUVA.Persistence;
using SelecaoUVA.Persistence.Config;
using SelecaoUVA.Persistence.Contracts;
using System;

namespace SelecaoUVAMarcosAntunes
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
            string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SELECAOUVA;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //services.AddDbContext<ContextBase>(options => options.UseSqlServer(
            //    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ContextBase>(options => options.UseSqlServer(connection));

            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserPersist, UserPersist>();
            services.AddScoped<IGenericPersist, GenericPersist>();

            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "SelecaoUVAMarcosAntunes", 
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Marcos Antunes",
                        Email = "antunesm@hotmail.com",
                        Url = new Uri("http://www.marcosantunes.com.br")
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SelecaoUVAMarcosAntunes v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(cors => cors.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
