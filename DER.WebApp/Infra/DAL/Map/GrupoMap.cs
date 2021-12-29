using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class GrupoMap : EntityTypeConfiguration<Grupo>
    {
        public GrupoMap()
        {
            ToTable("tab_grupos");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("grp_id")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("grp_nome")
                .HasMaxLength(50);

            Property(p => p.Descricao)
                .HasColumnName("grp_descricao")
                .HasMaxLength(150);

            Property(p => p.PerfilId)
                .HasColumnName("prf_id")
                .IsRequired();

            Property(p => p.Excluido)
                .HasColumnName("grp_excluido")
                .IsRequired();

            Property(p => p.Ativo)
                .HasColumnName("grp_ativo")
                .IsRequired();


            HasRequired(c => c.Perfil)
              .WithMany(c => c.Grupos)
              .HasForeignKey(c => c.PerfilId);
        }
    }
}