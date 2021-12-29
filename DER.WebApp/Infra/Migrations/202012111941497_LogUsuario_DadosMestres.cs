namespace DER.WebApp.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogUsuario_DadosMestres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tab_dadosMestres_col",
                c => new
                    {
                        dmc_id = c.Int(nullable: false, identity: true),
                        dmc_nome = c.String(),
                        dmt_codigo = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.dmc_id)
                .ForeignKey("dbo.tab_dadosMestres_tbl", t => t.dmt_codigo)
                .Index(t => t.dmt_codigo);
            
            CreateTable(
                "dbo.tab_dadosMestres_tbl",
                c => new
                    {
                        dmt_codigo = c.String(nullable: false, maxLength: 128),
                        dmt_nome = c.String(),
                    })
                .PrimaryKey(t => t.dmt_codigo);
            
            CreateTable(
                "dbo.tab_dadosMestres_val",
                c => new
                    {
                        dmv_id = c.Int(nullable: false, identity: true),
                        dmv_linha = c.Int(nullable: false),
                        dmv_valor = c.String(),
                        col_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.dmv_id)
                .ForeignKey("dbo.tab_dadosMestres_col", t => t.col_id, cascadeDelete: true)
                .Index(t => t.col_id);
            
            CreateTable(
                "dbo.tab_emails",
                c => new
                    {
                        eml_id = c.Int(nullable: false, identity: true),
                        eml_assunto = c.String(),
                        eml_corpoEmail = c.String(),
                        eml_codigo = c.String(),
                        eml_cc = c.String(),
                    })
                .PrimaryKey(t => t.eml_id);
            
            CreateTable(
                "dbo.tab_logAlteracao",
                c => new
                    {
                        loa_id = c.Int(nullable: false, identity: true),
                        loa_NomeEntidade = c.String(),
                        loa_idAlterado = c.String(),
                        loa_valorAntigo = c.String(),
                        loa_novoValor = c.String(),
                        loa_usuarioResponsavel = c.Int(nullable: false),
                        loa_dataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.loa_id);
            
            AddColumn("dbo.tab_usuarios", "usu_token_alteracao", c => c.Guid(nullable: false));
            AddColumn("dbo.tab_permissoes", "per_codigo", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tab_dadosMestres_val", "col_id", "dbo.tab_dadosMestres_col");
            DropForeignKey("dbo.tab_dadosMestres_col", "dmt_codigo", "dbo.tab_dadosMestres_tbl");
            DropIndex("dbo.tab_dadosMestres_val", new[] { "col_id" });
            DropIndex("dbo.tab_dadosMestres_col", new[] { "dmt_codigo" });
            DropColumn("dbo.tab_permissoes", "per_codigo");
            DropColumn("dbo.tab_usuarios", "usu_token_alteracao");
            DropTable("dbo.tab_logAlteracao");
            DropTable("dbo.tab_emails");
            DropTable("dbo.tab_dadosMestres_val");
            DropTable("dbo.tab_dadosMestres_tbl");
            DropTable("dbo.tab_dadosMestres_col");
        }
    }
}
