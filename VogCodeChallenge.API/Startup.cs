using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VogCodeChallenge.API.Services;
using Microsoft.EntityFrameworkCore;
using VogCodeChallenge.API.Models;

namespace VogCodeChallenge.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            //using Memory implementation,
            services.AddSingleton<IEmployeeService, EmployeeService>();

            //using Database
            //services.AddScoped<IEmployeeService, DBEmployeeService>();


            services.AddScoped<TestEmployee>();


            services.AddDbContext<EmployeesDbContext>(options =>
                    options.UseMySQL(Configuration.GetConnectionString("EmployeesDbContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TestEmployee testEmployee, EmployeesDbContext employeesDb)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();


            //Create the database if it does not exist
            employeesDb.Database.EnsureCreated();

           
            testEmployee.CreateTestEmployees();
            

        }
    }
}
