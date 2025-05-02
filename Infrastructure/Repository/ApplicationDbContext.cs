using Core.Entity;
using Infrastructure.Repository.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;
        public ApplicationDbContext()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        /*override sobreescrever*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            { 
                optionsBuilder.UseSqlServer(_connectionString);
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //pegar todas as classes q estao no projeto q usam a interfaze IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}
