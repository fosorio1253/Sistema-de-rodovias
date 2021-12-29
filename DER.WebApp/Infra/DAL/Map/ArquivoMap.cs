using DER.WebApp.Domain.Models;
using DER.WebApp.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class ArquivoMap : EntityTypeConfiguration<Arquivo>
    {
        public ArquivoMap()
        {
            ToTable("tab_arquivos");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("arq_id")
                .IsRequired();

            Property(p => p.Apagado)
                .HasColumnName("arq_apagado")
                .IsRequired();

            Property(p => p.ArquivoNome)
               .HasColumnName("arq_nome")
               .HasMaxLength(100);

            Property(p => p.ArquivoExtensao)
                .HasColumnName("arq_extensao");          

            Property(p => p.DataCadastro)
               .HasColumnName("arq_data_cadastro")
               .IsRequired();

            Property(p => p.DataAtualizacao)
               .HasColumnName("arq_data_atualizacao")
            .IsRequired();            

            Property(p => p.usu_id)
                .HasColumnName("usu_id")
                .IsRequired();
           
        }
    }
}