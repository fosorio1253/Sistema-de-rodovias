using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class GestaoInteressadoEnderecoMap : EntityTypeConfiguration<GestaoInteressadoEndereco>
    {
        public GestaoInteressadoEnderecoMap()
        {
            ToTable("tab_gestao_interessado_endereco");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("int_end_id")
                .IsRequired();

            Property(p => p.GestaoInteressadoId)
                .HasColumnName("int_id")
                .IsRequired();

            Property(p => p.UnidadeId)
               .HasColumnName("dmv_id_unidade")
               .IsRequired();

            Property(p => p.Logradouro)
              .HasColumnName("int_end_logradouro")
              .HasMaxLength(100)
              .IsRequired();

            Property(p => p.CEP)
              .HasColumnName("int_end_cep")
              .HasMaxLength(9)
              .IsRequired();

            Property(p => p.Numero)
              .HasColumnName("int_end_numero")
              .HasMaxLength(20)
              .IsRequired();

            Property(p => p.Complemento)
              .HasColumnName("int_end_complemento")
              .HasMaxLength(50)
              .IsRequired();

            Property(p => p.Bairro)
             .HasColumnName("int_end_bairro")
             .HasMaxLength(100)
             .IsRequired();

            Property(p => p.MunicipioId)
             .HasColumnName("dmv_id_municipio")
             .IsRequired();

            Property(p => p.NomeDoContato)
             .HasColumnName("int_end_nome_contato")
             .HasMaxLength(9)
             .IsRequired();

            Property(p => p.Principal)
             .HasColumnName("int_end_principal")
             .IsOptional();

            HasRequired(c => c.GestaoInteressado)
             .WithMany(c => c.Enderecos)
             .HasForeignKey(c => c.GestaoInteressadoId);
             
            HasRequired(c => c.Unidade)
              .WithMany(c => c.GestaoInteressadosEnderecosUnidade)
              .HasForeignKey(c => c.UnidadeId);

            HasRequired(c => c.Municipio)
              .WithMany(c => c.GestaoInteressadosEnderecosMunicipio)
              .HasForeignKey(c => c.MunicipioId);
        }
    }
}