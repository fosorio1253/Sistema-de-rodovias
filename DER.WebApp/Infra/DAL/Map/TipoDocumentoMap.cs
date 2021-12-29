using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class TipoDocumentoMap : EntityTypeConfiguration<TipoDocumento>
    {
        public TipoDocumentoMap()
        {
            ToTable("tab_tipo_documentos");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("doc_id")
                .IsRequired();

            Property(p => p.DocTipoInteressado)
              .HasColumnName("doc_tipo_interessado");

            Property(p => p.NomeDocumento)
               .HasColumnName("doc_documentos");


            Property(p => p.DataCadastro)
                .HasColumnName("doc_data_cadastro")
                .IsRequired();

            Property(p => p.DataAtualizacao)
                .HasColumnName("doc_data_atualizacao")
                .IsRequired();
        }
    }
}