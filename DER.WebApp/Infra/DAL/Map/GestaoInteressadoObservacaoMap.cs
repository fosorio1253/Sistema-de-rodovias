using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class GestaoInteressadoObservacaoMap : EntityTypeConfiguration<GestaoInteressadoObservacao>
    {
        public GestaoInteressadoObservacaoMap()
        {
            ToTable("tab_gestao_interessado_observacao");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("int_obs_id")
                .IsRequired();

            Property(p => p.GestaoInteressadoId)
                .HasColumnName("int_id")
                .IsRequired();

            Property(p => p.Observacao)
                .HasColumnName("int_obs_observacao")
                .HasMaxLength(500)
                .IsRequired();

            Property(p => p.AdicionadoPor)
               .HasColumnName("int_obs_addPor")
               .HasMaxLength(10)
               .IsRequired();

            Property(p => p.Data)
               .HasColumnName("int_obs_data")
               .IsRequired();
            
            HasRequired(c => c.GestaoInteressado)
                .WithMany(c => c.Observacoes)
                .HasForeignKey(c => c.GestaoInteressadoId);
        }
    }
}