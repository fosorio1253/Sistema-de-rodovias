using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class TipoInteressadoMap : EntityTypeConfiguration<TipoInteressado>
    {
        public TipoInteressadoMap()
        {
            ToTable("tab_tipo_interessado");

            HasKey(p => p.Id);

            Property(p => p.Id)
                .HasColumnName("tip_id")
                .IsRequired();

            Property(p => p.TipoDescricao)
              .HasColumnName("tip_descricao")
              .HasMaxLength(100);
        }
    }
}