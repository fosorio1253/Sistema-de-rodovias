using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class EmpresaAtuacaoMap : EntityTypeConfiguration<EmpresaAtuacao>
    {
        public EmpresaAtuacaoMap()
        {
            ToTable("tab_empresa_atuacao");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("atu_id")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("atu_nome")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}