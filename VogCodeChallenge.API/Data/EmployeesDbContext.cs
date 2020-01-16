using Microsoft.EntityFrameworkCore;
using VogCodeChallenge.API.Models;

public class EmployeesDbContext : DbContext
{
    public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options)
        : base(options)
    {
    }



    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().ToTable("Employee").HasKey(k => k.EmployeeID);
        
    }


}
