using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class StatusAprovacaoMap : EntityTypeConfiguration<StatusAprovacao>
    {
        public StatusAprovacaoMap()
        {
            ToTable("tab_status_aprovacao");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("sta_id")
                .IsRequired();

            Property(p => p.Nome)
              .HasColumnName("sta_nome")
              .HasMaxLength(100);
        }
    }
}