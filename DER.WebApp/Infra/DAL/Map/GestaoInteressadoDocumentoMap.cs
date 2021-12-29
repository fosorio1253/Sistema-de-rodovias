using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class GestaoInteressadoDocumentoMap : EntityTypeConfiguration<GestaoInteressadoDocumento>
    {
        public GestaoInteressadoDocumentoMap()
        {
            ToTable("tab_gestao_interessado_documento");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("int_doc_id")
                .IsRequired();

            Property(p => p.GestaoInteressadoId)
               .HasColumnName("int_id")
               .IsOptional();

            Property(p => p.Documento)
              .HasColumnName("int_doc_documento")
              .HasMaxLength(100)
              .IsRequired();

            Property(p => p.AdicionadoPor)
                   .HasColumnName("int_doc_addPor")
                   .HasMaxLength(50)
                   .IsRequired();

            Property(p => p.DataCadastro)
               .HasColumnName("int_doc_data")
               .IsRequired();

            Property(p => p.Arquivo)
          .HasColumnName("int_doc_arquivo")
          .HasMaxLength(500)
          .IsRequired();

            HasRequired(c => c.GestaoInteressado)
              .WithMany(c => c.Documentos)
              .HasForeignKey(c => c.GestaoInteressadoId);
        }
    }
}