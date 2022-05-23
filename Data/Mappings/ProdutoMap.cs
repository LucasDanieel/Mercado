using Mercado.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mercado.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(60);
            
            builder.Property(x => x.Quantidade)
                .IsRequired()
                .HasColumnName("Quantidade")
                .HasColumnType("INT");
            
            builder.HasOne(x => x.Categorias)
                .WithMany(x => x.Produtos)
                .HasConstraintName("FK_Produto_Categoria")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}