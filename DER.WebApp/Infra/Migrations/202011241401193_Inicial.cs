namespace DER.WebApp.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tab_alteraSenha",
                c => new
                    {
                        als_id = c.Guid(nullable: false),
                        als_dataExpiracao = c.DateTime(nullable: false),
                        als_jaUtilizado = c.Boolean(nullable: false),
                        usu_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.als_id)
                .ForeignKey("dbo.tab_usuarios", t => t.usu_id, cascadeDelete: true)
                .Index(t => t.usu_id);
            
            CreateTable(
                "dbo.tab_usuarios",
                c => new
                    {
                        usu_id = c.Int(nullable: false, identity: true),
                        usu_ativo = c.Boolean(nullable: false),
                        usu_externo = c.Boolean(nullable: false),
                        usu_nome = c.String(nullable: false, maxLength: 150),
                        usu_cargo = c.String(maxLength: 100),
                        usu_login = c.String(nullable: false, maxLength: 100),
                        usu_senha = c.String(maxLength: 255),
                        usu_email = c.String(nullable: false, maxLength: 255),
                        usu_regional = c.String(),
                        usu_ddd = c.String(maxLength: 2),
                        usu_telefoneRamal = c.String(),
                        usu_dataCriacao = c.DateTime(nullable: false),
                        sta_id = c.Int(nullable: false),
                        usu_excluido = c.Boolean(nullable: false),
                        usu_cpf = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.usu_id)
                .ForeignKey("dbo.tab_status_aprovacao", t => t.sta_id, cascadeDelete: true)
                .Index(t => t.sta_id);
            
            CreateTable(
                "dbo.tab_empresa",
                c => new
                    {
                        emp_id = c.Int(nullable: false, identity: true),
                        emp_nome = c.String(),
                        emp_CNPJ = c.String(),
                        emp_excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.emp_id);
            
            CreateTable(
                "dbo.tab_grupos",
                c => new
                    {
                        grp_id = c.Int(nullable: false, identity: true),
                        grp_nome = c.String(maxLength: 50),
                        grp_descricao = c.String(maxLength: 255),
                        prf_id = c.Int(nullable: false),
                        grp_excluido = c.Boolean(nullable: false),
                        grp_ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.grp_id)
                .ForeignKey("dbo.tab_perfis", t => t.prf_id, cascadeDelete: true)
                .Index(t => t.prf_id);
            
            CreateTable(
                "dbo.tab_perfis",
                c => new
                    {
                        prf_id = c.Int(nullable: false, identity: true),
                        prf_nome = c.String(maxLength: 50),
                        prf_descricao = c.String(maxLength: 255),
                        prf_excluido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.prf_id);
            
            CreateTable(
                "dbo.tab_permissoes",
                c => new
                    {
                        per_id = c.Int(nullable: false, identity: true),
                        per_nome = c.String(maxLength: 150),
                        per_excluido = c.Boolean(nullable: false),
                        per_paiId = c.Int(),
                    })
                .PrimaryKey(t => t.per_id)
                .ForeignKey("dbo.tab_permissoes", t => t.per_paiId)
                .Index(t => t.per_paiId);
            
            CreateTable(
                "dbo.tab_status_aprovacao",
                c => new
                    {
                        sta_id = c.Int(nullable: false, identity: true),
                        sta_nome = c.String(),
                    })
                .PrimaryKey(t => t.sta_id);
            
            CreateTable(
                "dbo.tab_usuario_empresa",
                c => new
                    {
                        usu_id = c.Int(nullable: false),
                        emp_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.usu_id, t.emp_id })
                .ForeignKey("dbo.tab_usuarios", t => t.usu_id, cascadeDelete: true)
                .ForeignKey("dbo.tab_empresa", t => t.emp_id, cascadeDelete: true)
                .Index(t => t.usu_id)
                .Index(t => t.emp_id);
            
            CreateTable(
                "dbo.tab_perfil_permissao",
                c => new
                    {
                        prf_id = c.Int(nullable: false),
                        per_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.prf_id, t.per_id })
                .ForeignKey("dbo.tab_perfis", t => t.prf_id, cascadeDelete: true)
                .ForeignKey("dbo.tab_permissoes", t => t.per_id, cascadeDelete: true)
                .Index(t => t.prf_id)
                .Index(t => t.per_id);
            
            CreateTable(
                "dbo.tab_usuario_grupo",
                c => new
                    {
                        usu_id = c.Int(nullable: false),
                        grp_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.usu_id, t.grp_id })
                .ForeignKey("dbo.tab_usuarios", t => t.usu_id, cascadeDelete: true)
                .ForeignKey("dbo.tab_grupos", t => t.grp_id, cascadeDelete: true)
                .Index(t => t.usu_id)
                .Index(t => t.grp_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tab_alteraSenha", "usu_id", "dbo.tab_usuarios");
            DropForeignKey("dbo.tab_usuarios", "sta_id", "dbo.tab_status_aprovacao");
            DropForeignKey("dbo.tab_usuario_grupo", "grp_id", "dbo.tab_grupos");
            DropForeignKey("dbo.tab_usuario_grupo", "usu_id", "dbo.tab_usuarios");
            DropForeignKey("dbo.tab_grupos", "prf_id", "dbo.tab_perfis");
            DropForeignKey("dbo.tab_perfil_permissao", "per_id", "dbo.tab_permissoes");
            DropForeignKey("dbo.tab_perfil_permissao", "prf_id", "dbo.tab_perfis");
            DropForeignKey("dbo.tab_permissoes", "per_paiId", "dbo.tab_permissoes");
            DropForeignKey("dbo.tab_usuario_empresa", "emp_id", "dbo.tab_empresa");
            DropForeignKey("dbo.tab_usuario_empresa", "usu_id", "dbo.tab_usuarios");
            DropIndex("dbo.tab_usuario_grupo", new[] { "grp_id" });
            DropIndex("dbo.tab_usuario_grupo", new[] { "usu_id" });
            DropIndex("dbo.tab_perfil_permissao", new[] { "per_id" });
            DropIndex("dbo.tab_perfil_permissao", new[] { "prf_id" });
            DropIndex("dbo.tab_usuario_empresa", new[] { "emp_id" });
            DropIndex("dbo.tab_usuario_empresa", new[] { "usu_id" });
            DropIndex("dbo.tab_permissoes", new[] { "per_paiId" });
            DropIndex("dbo.tab_grupos", new[] { "prf_id" });
            DropIndex("dbo.tab_usuarios", new[] { "sta_id" });
            DropIndex("dbo.tab_alteraSenha", new[] { "usu_id" });
            DropTable("dbo.tab_usuario_grupo");
            DropTable("dbo.tab_perfil_permissao");
            DropTable("dbo.tab_usuario_empresa");
            DropTable("dbo.tab_status_aprovacao");
            DropTable("dbo.tab_permissoes");
            DropTable("dbo.tab_perfis");
            DropTable("dbo.tab_grupos");
            DropTable("dbo.tab_empresa");
            DropTable("dbo.tab_usuarios");
            DropTable("dbo.tab_alteraSenha");
        }
    }
}
