using DER.WebApp.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DER.WebApp.Infra.DAL.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("tab_usuarios");

            HasKey(c => c.Id);

            Property(p => p.Id)
                .HasColumnName("usu_id")
                .IsRequired();

            Property(p => p.Ativo)
                .HasColumnName("usu_ativo")
                .IsRequired();

            Property(p => p.Externo)
               .HasColumnName("usu_externo")
               .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("usu_nome")
                .HasMaxLength(150)
                .IsRequired();

            Property(p => p.Cargo)
                .HasColumnName("usu_cargo")
                .HasMaxLength(50);

            Property(p => p.Login)
                .HasColumnName("usu_login")
                .HasMaxLength(10)
                .IsRequired();

            Property(p => p.Senha)
               .HasColumnName("usu_senha")
               .HasMaxLength(255)
               .IsRequired();

            Property(p => p.Email)
               .HasColumnName("usu_email")
               .HasMaxLength(255)
               .IsRequired();

            Property(p => p.RegionalId)
              .HasColumnName("dmv_id_regional")
              .IsOptional();

            Property(p => p.DDD)
                .HasColumnName("usu_ddd")
                .HasMaxLength(2);

            Property(p => p.TelefoneRamal)
               .HasColumnName("usu_telefoneRamal");

            Property(p => p.DataCriacao)
               .HasColumnName("usu_dataCriacao")
               .IsRequired();

            Property(p => p.Excluido)
              .HasColumnName("usu_excluido")
              .IsRequired();

            Property(p => p.CPF)
               .HasColumnName("usu_cpf")
               .HasMaxLength(15);

            Property(p => p.AlteracaoGuid)
               .HasColumnName("usu_token_alteracao")
               .IsRequired();

            Property(p => p.StatusAprovacaoId)
                .HasColumnName("sta_id")
                .IsRequired();

            HasRequired(c => c.StatusAprovacao)
               .WithMany(c => c.Usuarios)
               .HasForeignKey(c => c.StatusAprovacaoId);

            HasRequired(c => c.Regional)
              .WithMany(c => c.Usuarios)
              .HasForeignKey(c => c.RegionalId);

            HasMany<Grupo>(x => x.Grupos)
              .WithMany(c => c.Usuarios)
              .Map(cs =>
              {
                  cs.MapLeftKey("usu_id");
                  cs.MapRightKey("grp_id");
                  cs.ToTable("tab_usuario_grupo");
              });

            HasMany<Empresa>(x => x.Empresas)
              .WithMany(c => c.Usuarios)
              .Map(cs =>
              {
                  cs.MapLeftKey("usu_id");
                  cs.MapRightKey("emp_id");
                  cs.ToTable("tab_usuario_empresa");
              });
        }
    }
}