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

            bool UseDataBase = bool.Parse(Configuration.GetValue(typeof(string), "DataBase").ToString());

            
            if (UseDataBase)
            {
                services.AddScoped<IEmployeeService, DBEmployeeService>();
                services.AddDbContext<EmployeesDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("EmployeesDbContext")));
                services.AddScoped<TestEmployee>();
            }
            else
            {
                services.AddSingleton<IEmployeeService, EmployeeService>();
                services.AddSingleton<TestEmployee>();
            }
  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TestEmployee testEmployee)
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


            bool UseDataBase = bool.Parse(Configuration.GetValue(typeof(string), "DataBase").ToString());


            if (UseDataBase)
            {
                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    EmployeesDbContext employeesDb = serviceScope.ServiceProvider.GetService<EmployeesDbContext>();

                    employeesDb.Database.EnsureCreated();

                    //Insert Test Data
                    if (employeesDb.Employees.Count() == 0)
                    {
                        testEmployee.CreateTestEmployees();

                    }
                }
                
            }
            else
            {
                testEmployee.CreateTestEmployees();
            }

            


        }
    }
}
