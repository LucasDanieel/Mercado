using Mercado.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mercado.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x=> x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);
            
            builder.Property(x => x.Cargo)
                .IsRequired()
                .HasColumnName("Cargo")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);
            
            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.User)
                .HasConstraintName("FK_User_Endereco")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}