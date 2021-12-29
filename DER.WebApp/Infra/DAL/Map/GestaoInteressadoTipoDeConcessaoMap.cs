using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class GestaoInteressadoTipoDeConcessaoMap : EntityTypeConfiguration<GestaoInteressadoTipoDeConcessao>
    {
        public GestaoInteressadoTipoDeConcessaoMap()
        {
            ToTable("tab_gestao_interessado_tipo_de_concessao");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("int_tipo_concessao")
                .IsRequired();

            Property(p => p.GestaoInteressadoId)
                .HasColumnName("int_id")
                .IsRequired();

            Property(p => p.TipoDeConcessaoId)
                .HasColumnName("dmv_id_tipo_concessao")
                .IsRequired();

            Property(p => p.Marcado)
                .HasColumnName("int_tipo_concessao_marcado")
                .IsRequired();

            HasRequired(c => c.GestaoInteressado)
                .WithMany(c => c.GestaoInteressadosTiposDeConcessoes)
                .HasForeignKey(c => c.GestaoInteressadoId);

            HasRequired(c => c.TipoDeConcessao)
                .WithMany(c => c.GestaoInteressadoTipoDeConcessoes)
                .HasForeignKey(c => c.TipoDeConcessaoId);
        }
    }
}