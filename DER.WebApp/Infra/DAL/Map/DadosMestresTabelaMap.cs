using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class DadosMestresTabelaMap : EntityTypeConfiguration<DadosMestresTabela>
    {
        public DadosMestresTabelaMap()
        {
            ToTable("tab_dadosMestres_tbl");

            HasKey(c => c.Codigo);

            Property(p => p.Codigo)
                .HasColumnName("dmt_codigo")
                .IsRequired();

            Property(p => p.Nome)
               .HasColumnName("dmt_nome")
               .HasMaxLength(100)
               .IsRequired();

            Property(p => p.NumeroCodigo)
                .HasColumnName("dmt_id")
                .IsRequired();
        }
    }
}