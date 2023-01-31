using LaBrasa.Domain.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaBrasa.Infra.Data.Entities_Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.IdIdentity);

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Sobrenome)
                .HasColumnName("Sobrenome")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Endereco)
                .HasColumnName("Endereco")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Genero)
                .HasColumnName("Genero")
                .IsRequired();

            builder.Property(x => x.Idade)
                .HasColumnName("idade")
                .IsRequired();
        }
    }
}
