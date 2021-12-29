using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            ToTable("tab_empresa");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("emp_id")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("emp_nome");

            Property(p => p.CNPJ)
                .HasColumnName("emp_CNPJ");

            Property(p => p.Excluido)
                .HasColumnName("emp_excluido")
                .IsRequired();
        }
    }
}