using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class ChangeLogMap : EntityTypeConfiguration<LogAlteracao>
    {
        public ChangeLogMap()
        {
            ToTable("tab_logAlteracao");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("loa_id")
                .IsRequired();

            Property(p => p.NomeEntidade)
               .HasColumnName("loa_NomeEntidade");

            Property(p => p.IdPrimaryKey)
               .HasColumnName("loa_idAlterado");

            Property(p => p.ValorAntigo)
               .HasColumnName("loa_valorAntigo");

            Property(p => p.NovoValor)
               .HasColumnName("loa_novoValor");

            Property(p => p.ReponsavelAlteracao)
               .HasColumnName("loa_usuarioResponsavel")
               .IsRequired();

            Property(p => p.NomeUsuarioResponsavel)
               .HasColumnName("loa_nomeUsuarioResponsavel");

            Property(p => p.DataAlteracao)
               .HasColumnName("loa_dataAlteracao")
               .IsRequired();

            Property(p => p.TipoAlteracao)
               .HasColumnName("loa_tipoAlteracao")
               .IsRequired();
        }
    }
}