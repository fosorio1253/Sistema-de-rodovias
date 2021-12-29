using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class GestaoInteressadoMap : EntityTypeConfiguration<GestaoInteressado>
    {
        public GestaoInteressadoMap()
        {
            ToTable("tab_gestao_interessado");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("int_id")
                .IsRequired();

            Property(p => p.Ativo)
              .HasColumnName("int_ativo")
              .IsRequired();

            Property(p => p.NumeroSPDOC)
                .HasColumnName("int_numerospdoc")
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.StatusSPDOC)
                .HasColumnName("int_statusSPDOC")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("int_nome")
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.NaturezaJuridicaId)
                .HasColumnName("dmv_id_natureza_juridica")
                .IsOptional();

            Property(p => p.Documento)
               .HasColumnName("int_documento")
               .HasMaxLength(18)
               .IsRequired();

            Property(p => p.MatrizOuFilial)
               .HasColumnName("int_matrizOuFilial")
               .HasMaxLength(100)
               .IsRequired();

            Property(p => p.ValidoAte)
                .HasColumnName("int_validoAte")
                .IsRequired();

            Property(p => p.StatusAprovacaoId)
               .HasColumnName("sta_id")
               .IsRequired();

            Property(p => p.NomeFantasia)
               .HasColumnName("int_nomeFantasia")
               .HasMaxLength(100)
               .IsRequired();

            Property(p => p.TipoDeInteressadoId)
                .HasColumnName("dmv_id_tipo_interessado")
                .IsOptional();

            HasOptional(c => c.NaturezaJuridica)
                .WithMany(c => c.GestaoInteressadosJuridica)
                .HasForeignKey(c => c.NaturezaJuridicaId);

            HasRequired(c => c.StatusAprovacao)
                .WithMany(c => c.GestaoInteressados)
                .HasForeignKey(c => c.StatusAprovacaoId);

            HasOptional(c => c.TipoDeInteressado)
                .WithMany(c => c.GestaoInteressadosTipoDeInteressado)
                .HasForeignKey(c => c.TipoDeInteressadoId);
        }
    }
}