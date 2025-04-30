using Core.Entity;
using Microsoft.EntityFrameworkCore;
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
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Define q tal tabela corresponde a tal classe
            HasKey chave primaria
            p. acessa as propriedades da entidade
            ValueGeneratedNever tira a responsabilidade do EF
            de criar valores para PK e deixa a responsabilidade para o BD*/
            modelBuilder.Entity<Cliente>(e => {
                e.ToTable("Cliente");
                e.HasKey(p => p.Id);
                e.Property(p => p.Id).HasColumnType("int").ValueGeneratedNever().UseIdentityColumn();
                e.Property(p => p.DataCriacao).HasColumnType("DATETIME").IsRequired();
                e.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired();
                e.Property(p => p.DataNascimento).HasColumnType("DATETIME");
            });

            modelBuilder.Entity<Livro>(e => {
                e.ToTable("Livro");
                e.HasKey(p => p.Id);
                e.Property(p => p.Id).HasColumnType("int").ValueGeneratedNever().UseIdentityColumn();
                e.Property(p => p.DataCriacao).HasColumnType("DATETIME").IsRequired();
                e.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired();
                e.Property(p => p.Editora).HasColumnType("VARCHAR(100)").IsRequired();
            });

            modelBuilder.Entity<Pedido>(e => {
                e.ToTable("Pedido");
                e.HasKey(p => p.Id);
                e.Property(p => p.Id).HasColumnType("int").ValueGeneratedNever().UseIdentityColumn();
                e.Property(p => p.DataCriacao).HasColumnType("DATETIME").IsRequired();
                e.Property(p => p.ClienteId).HasColumnType("int").IsRequired();
                e.Property(p => p.LivroId).HasColumnType("int").IsRequired();
            });
        }
    }
}
