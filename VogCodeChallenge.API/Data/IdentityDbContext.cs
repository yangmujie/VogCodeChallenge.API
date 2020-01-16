using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VogCodeChallenge.API.Models;

    public class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext (DbContextOptions<EmployeesDbContext> options)
            : base(options)
        {
        }

        public DbSet<VogCodeChallenge.API.Models.Employee> Employee { get; set; }
    }
