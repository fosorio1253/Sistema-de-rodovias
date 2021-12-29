using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class ProjetosMelhoriasInformacoesRelevantesMap : EntityTypeConfiguration<ProjetosMelhoriasInformacoesRelevantes>
    {
        public ProjetosMelhoriasInformacoesRelevantesMap()
        {
            ToTable("tab_projetos_melhorias_informacoes_relevantes");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("info_id")
                .IsRequired();

            Property(p => p.ProjetosMelhoriasId)
             .HasColumnName("info_pro_id")
             .IsOptional();

            Property(p => p.DataAtualizacao)
                .HasColumnName("info_data_atualizacao")                
                .IsOptional();

            Property(p => p.AdicionadoPor)
                .HasColumnName("info_addpor")
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.Descricao)
                .HasColumnName("info_descricao")
                .HasMaxLength(10)
                .IsOptional();

            HasOptional(c => c.ProjetosMelhorias)
               .WithMany(c => c.Informacoes)
               .HasForeignKey(c => c.ProjetosMelhoriasId);
        }
    }
}