using AbpBlobContainer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;

namespace AbpBlobContainer.Data
{
    public class EmployeeDBContext : DbContext
    {

        private readonly string _connectionString;
        
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

            _connectionString = configuration.GetConnectionString("DefaultConnection");
            //_connectionString = "Data Source=LAPTOP-222BF6UA\\SQLEXPRESS;Initial Catalog=AbpBlobDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ConfigureBlobStoring();
            base.OnModelCreating(builder);
        }



        public DbSet<Employee> Employees { get; set; }




    }

}
