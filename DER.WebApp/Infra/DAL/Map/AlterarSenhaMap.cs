using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class AlterarSenhaMap : EntityTypeConfiguration<AlterarSenha>
    {
        public AlterarSenhaMap()
        {
            ToTable("tab_alteraSenha");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("als_id")
                .IsRequired();

            Property(p => p.DataExpiracao)
                .HasColumnName("als_dataExpiracao")
                .IsRequired();

            Property(p => p.JaUtilizado)
                .HasColumnName("als_jaUtilizado")
                .IsRequired();

            Property(p => p.UsuarioId)
                .HasColumnName("usu_id")
                .IsRequired();

            HasRequired(c => c.Usuario)
              .WithMany(c => c.AlterarSenhas)
              .HasForeignKey(c => c.UsuarioId);
        }
    }
}