using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class DadosMestresColunaMap : EntityTypeConfiguration<DadosMestresColuna>
    {
        public DadosMestresColunaMap()
        {
            ToTable("tab_dadosMestres_col");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("dmc_id")
                .IsRequired();

            Property(p => p.Nome)
              .HasColumnName("dmc_nome")
              .HasMaxLength(100)
              .IsRequired();

            Property(p => p.TabelaId)
                .HasColumnName("dmt_codigo")
                .IsRequired();

            Property(p => p.TipoDado)
               .HasColumnName("dmc_tipoDado");

            HasRequired(c => c.Tabela)
                .WithMany(c => c.Dados)
             .HasForeignKey(c => c.TabelaId);
        }
    }
}