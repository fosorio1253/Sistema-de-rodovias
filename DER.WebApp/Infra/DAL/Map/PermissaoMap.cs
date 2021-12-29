using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class PermissaoMap : EntityTypeConfiguration<Permissao>
    {
        public PermissaoMap()
        {
            ToTable("tab_permissoes");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("per_id")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("per_nome")
                .HasMaxLength(150);

            Property(p => p.Codigo)
                .HasColumnName("per_codigo");

            Property(p => p.Excluido)
                .HasColumnName("per_excluido")
                .IsRequired();

            Property(p => p.PermissaoPaiId)
                .HasColumnName("per_paiId");

            HasRequired(c => c.PermissaoPai)
                .WithMany(c => c.PermissoesFilhos)
                .HasForeignKey(c => c.PermissaoPaiId);
        }
    }
}