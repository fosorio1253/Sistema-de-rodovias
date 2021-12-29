using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class ProjetosMelhoriasMap : EntityTypeConfiguration<ProjetosMelhorias>
    {
        public ProjetosMelhoriasMap()
        {
            ToTable("tab_projetos_melhorias");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("pro_id")
                .IsRequired();

            Property(p => p.RegionalId)
                .HasColumnName("pro_regional")
                .IsOptional();

            Property(p => p.MunicipioId)
                .HasColumnName("pro_municipio")
                .IsOptional();

            Property(p => p.RodoviaId)
                .HasColumnName("pro_rodovia")
                .IsOptional();

            Property(p => p.Nome)
                .HasColumnName("pro_nome")
                .HasMaxLength(250)
                .IsOptional();

            Property(p => p.KmInicial)
                .HasColumnName("pro_km_inicial")
                .IsOptional();

            Property(p => p.KmFinal)
                .HasColumnName("pro_km_final")
                .IsOptional();

            Property(p => p.Extensao)
                .HasColumnName("pro_extensao")
                .IsOptional();

            Property(p => p.Sentido)
                .HasColumnName("pro_sentido")
                .HasMaxLength(10)
                .IsOptional();

            Property(p => p.LadoId)
                .HasColumnName("pro_lado")
                .IsOptional();

            Property(p => p.Lote)
                .HasColumnName("pro_lote")
                .HasMaxLength(10)
                .IsOptional();

            Property(p => p.Status)
                .HasColumnName("pro_status")
                .HasMaxLength(20)
                .IsOptional();

            Property(p => p.NumeroContrato)
               .HasColumnName("pro_num_contrato")
               .HasMaxLength(50)
               .IsOptional();

            Property(p => p.Prazo)
               .HasColumnName("pro_prazo")
               .IsOptional();

            Property(p => p.PrevisaoInicio)
              .HasColumnName("pro_previsao_inicio")
              .IsOptional();

            Property(p => p.Descricao)
               .HasColumnName("pro_descricao")
               .HasMaxLength(500)
               .IsOptional();

            Property(p => p.Ativo)
                .HasColumnName("pro_ativo")
                .IsRequired();

            Property(p => p.UnidadeConservacao)
               .HasColumnName("pro_unidade_conservacao")
               .HasMaxLength(50)
               .IsOptional();

            ////HasOptional(c => c.Rodovias)
            ////  .WithMany(c => c.ProjetosMelhoriasRodovia)
            ////  .HasForeignKey(c => c.RodoviaId);

            ////HasOptional(c => c.Regionais)
            ////  .WithMany(c => c.ProjetosMelhoriasRegional)
            ////  .HasForeignKey(c => c.RegionalId);
        }
    }
}