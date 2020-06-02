using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.May2020.Data.Context;
using Hahn.ApplicatonProcess.May2020.Data.Repositories;
using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces.Repository;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces.Service;
using Hahn.ApplicatonProcess.May2020.Domain.Validation;
using Hahn.ApplicatonProcess.May2020.Web.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hahn.ApplicatonProcess.May2020.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationProcessContext>();

            services.AddControllers().AddFluentValidation();
            
            RegisterService(services);
            RegisterValidators(services);
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

        private void RegisterService(IServiceCollection services)
        {
            // Services
            services.AddScoped<IApplicantService, ApplicantService>();

            // Repositories
            services.AddScoped<IApplicantRepository, ApplicantRepository>();
        }

        private void RegisterValidators(IServiceCollection services)
        {
            services.AddTransient<IValidator<Applicant>, ApplicantValidation>();
        }
    }
}
