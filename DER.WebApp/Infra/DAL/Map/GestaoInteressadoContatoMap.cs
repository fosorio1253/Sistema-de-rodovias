using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class GestaoInteressadoContatoMap : EntityTypeConfiguration<GestaoInteressadoContato>
    {
        public GestaoInteressadoContatoMap()
        {
            ToTable("tab_gestao_interessado_contato");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("int_con_id")
                .IsRequired();

            Property(p => p.GestaoInteressadoId)
                .HasColumnName("int_id")
                .IsRequired();

            Property(p => p.UsuarioId)
              .HasColumnName("usu_id")
              .IsRequired();

            Property(p => p.Principal)
             .HasColumnName("int_con_principal")
             .IsOptional();

            HasRequired(c => c.GestaoInteressado)
               .WithMany(c => c.Contatos)
               .HasForeignKey(c => c.GestaoInteressadoId);

            HasRequired(c => c.Usuario)
               .WithMany(c => c.GestaoInteressadosContatos)
               .HasForeignKey(c => c.UsuarioId);
        }
    }
}