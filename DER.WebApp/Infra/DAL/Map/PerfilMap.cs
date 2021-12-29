using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class PerfilMap : EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            ToTable("tab_perfis");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("prf_id")
                .IsRequired();

            Property(p => p.Nome)
              .HasColumnName("prf_nome")
              .HasMaxLength(50);

            Property(p => p.Descricao)
              .HasColumnName("prf_descricao")
              .HasMaxLength(255);

            Property(p => p.Excluido)
               .HasColumnName("prf_excluido")
               .IsRequired();

            HasMany<Permissao>(x => x.Permissoes)
              .WithMany(c => c.Perfis)
              .Map(cs =>
              {
                  cs.MapLeftKey("prf_id");
                  cs.MapRightKey("per_id");
                  cs.ToTable("tab_perfil_permissao");
              });
        }
    }
}