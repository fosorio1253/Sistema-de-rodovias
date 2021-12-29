using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class DadosMestresValoresMap : EntityTypeConfiguration<DadosMestresValores>
    {
        public DadosMestresValoresMap()
        {
            ToTable("tab_dadosMestres_val");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("dmv_id")
                .IsRequired();

            Property(p => p.Linha)
                .HasColumnName("dmv_linha")
                .IsRequired();

            Property(p => p.Valor)
                .HasColumnName("dmv_valor")
                .IsRequired();

            Property(p => p.ColunaId)
              .HasColumnName("col_id")
              .IsRequired();

            HasRequired(c => c.Coluna)
             .WithMany(c => c.Valores)
             .HasForeignKey(c => c.ColunaId);
        }
    }
}