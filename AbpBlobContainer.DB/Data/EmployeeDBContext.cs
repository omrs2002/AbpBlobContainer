
using AbpBlobContainer.DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AbpBlobContainer.DB.Data
{

    public class EmployeeDBContext : DbContext
    {

        private readonly string _connectionString;

        public EmployeeDBContext()
        {
            //System.Diagnostics.Debugger.Launch();

            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //System.Diagnostics.Debugger.Launch();
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
