using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Next.Steps.Application.Utils;
using Next.Steps.Domain.Interfaces.Repositories;
using Next.Steps.Domain.Interfaces.Services;
using Next.Steps.Domain.Services;
using Next.Steps.Infrastructure.Context;
using Next.Steps.Infrastructure.Fake;
using Next.Steps.Infrastructure.Repository;
using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace Next.Steps.API
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
            services.AddControllers();

            var connection = Configuration["ConnectionString"];
            services.AddDbContext<NextStepsContext>
                (options => options.UseSqlServer(connection));

            services.AddScoped(typeof(IRepositoryPerson), typeof(PersonRepository));

            //services.AddSingleton(typeof(IRepositoryPerson), typeof(FakeRepository));

            services.AddScoped(typeof(IServicePerson), typeof(PersonService));

            services.AddMvc();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            var assembly = AppDomain.CurrentDomain.Load("Next.Steps.Application");
            services.AddMediatR(assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NextSteps", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "swagger");
            });

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<NextStepsContext>();
            context.Database.Migrate();
        }
    }
}