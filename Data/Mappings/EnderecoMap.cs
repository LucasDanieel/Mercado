using Mercado.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mercado.Data.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(x => x.UserId);

            builder.Property(x => x.Rua)
                .IsRequired()
                .HasColumnName("Rua")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.NumeroCasa)
                .IsRequired()
                .HasColumnName("NumeroCasa")
                .HasColumnType("INT");
            
            builder.Property(x => x.Bairro)
                .IsRequired()
                .HasColumnName("Bairro")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);
            
            builder.Property(x => x.CEP)
                .IsRequired()
                .HasColumnName("CEP")
                .HasColumnType("INT");
            
            builder.Property(x => x.Cidade)
                .IsRequired()
                .HasColumnName("Cidade")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);
        }
    }
}