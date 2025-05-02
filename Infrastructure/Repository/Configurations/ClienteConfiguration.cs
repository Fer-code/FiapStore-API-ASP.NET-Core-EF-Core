using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            /*Define q tal tabela corresponde a tal classe
            HasKey chave primaria
            p. acessa as propriedades da entidade
            ValueGeneratedNever tira a responsabilidade do EF
            de criar valores para PK e deixa a responsabilidade para o BD
            */

            builder.ToTable("Cliente");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("int").UseIdentityColumn();
            builder.Property(p => p.DataCriacao).HasColumnType("DATETIME").IsRequired();
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.DataNascimento).HasColumnType("DATETIME");
            builder.Property(p => p.CPF).HasColumnType("VARCHAR(11)").IsRequired();
        }
    }
}
