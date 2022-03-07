using DER.WebApp.Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web.Script.Serialization;
using DER.WebApp.Infra.DAL.Map;
using DER.WebApp.Models;
using System.Threading;
using DER.WebApp.Infra.DAO;
using DER.WebApp.Helper;

namespace DER.WebApp.Infra.DAL
{
    public class DerContext : DbContext
    {

        public DbSet<AlterarSenha> AlteraSenha { get; set; }
        public DbSet<DadosMestresColuna> DadosMestresColuna { get; set; }
        public DbSet<DadosMestresTabela> DadosMestresTabela { get; set; }
        public DbSet<DadosMestresValores> DadosMestresValores { get; set; }
        public DbSet<Emails> Emails { get; set; }
        public DbSet<GestaoInteressadoContato> GestaoInteressadosContatos { get; set; }
        public DbSet<GestaoInteressadoEndereco> GestaoInteressadoEnderecos { get; set; }
        public DbSet<GestaoInteressadoDocumento> GestaoInteressadosDocumentos { get; set; }
        public DbSet<GestaoInteressadoObservacao> GestaoInteressadosObservacoes { get; set; }
        public DbSet<GestaoInteressadoTipoDeConcessao> GestaoInteressadosTipoDeConcessoes { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Permissao> Permissao { get; set; }
        public DbSet<StatusAprovacao> StatusAprovacao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<LogAlteracao> LogAlteracao { get; set; }
        public DbSet<Arquivo> Arquivo { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<TipoInteressado> TipoInteressado { get; set; }
        public DbSet<ProjetosMelhorias> ProjetosMelhorias { get; set; }
        public DbSet<ProjetosMelhoriasInformacoesRelevantes> ProjetosMelhoriasInformacoesRelevantes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new AlterarSenhaMap());
            modelBuilder.Configurations.Add(new ChangeLogMap());
            modelBuilder.Configurations.Add(new DadosMestresColunaMap());
            modelBuilder.Configurations.Add(new DadosMestresTabelaMap());
            modelBuilder.Configurations.Add(new DadosMestresValoresMap());
            modelBuilder.Configurations.Add(new EmailsMap());
            modelBuilder.Configurations.Add(new EmpresaAtuacaoMap());
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new GestaoInteressadoContatoMap());
            modelBuilder.Configurations.Add(new GestaoInteressadoDocumentoMap());
            modelBuilder.Configurations.Add(new GestaoInteressadoEnderecoMap());
            modelBuilder.Configurations.Add(new GestaoInteressadoObservacaoMap());
            modelBuilder.Configurations.Add(new GestaoInteressadoTipoDeConcessaoMap());
            modelBuilder.Configurations.Add(new GrupoMap());
            modelBuilder.Configurations.Add(new PerfilMap());
            modelBuilder.Configurations.Add(new PermissaoMap());
            modelBuilder.Configurations.Add(new StatusAprovacaoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new ArquivoMap());
            modelBuilder.Configurations.Add(new TipoInteressadoMap());
            modelBuilder.Configurations.Add(new TipoDocumentoMap());
            modelBuilder.Configurations.Add(new ProjetosMelhoriasMap());
            modelBuilder.Configurations.Add(new ProjetosMelhoriasInformacoesRelevantesMap());
        }

        public static DerContext Create()
        {
            return new DerContext();
        }

        public override int SaveChanges()
        {
            //this.ChangeTracker.DetectChanges();
            //var Changes = this.ChangeTracker.Entries()
            //            .Where(t => t.State == EntityState.Added || t.State == EntityState.Modified || t.State == EntityState.Deleted)
            //            .Select(t => new { Entity = t.Entity, State = t.State, OriginalValue = t.OriginalValues, CurentValues = t.CurrentValues });

            //return base.SaveChanges();

            var modifiedEntities = ChangeTracker.Entries()
            .Where(p => p.State == EntityState.Modified).ToList();
            var now = DateTime.UtcNow;


            foreach (var change in modifiedEntities)
            {

                var userId = System.Web.HttpContext.Current.Session["UserId"];
                var userName = Thread.CurrentPrincipal.Identity.Name;
                if (userId == null)
                    userId = 0;

                var entityName = change.Entity.GetType().BaseType.Name;
                var primaryKey = GetPrimaryKeyValue(change);

                List<object> ListaAntigo = new List<object>();
                List<object> ListaNovo = new List<object>();

                foreach (var prop in change.OriginalValues.PropertyNames)
                {
                    var originalValue = change.OriginalValues[prop]?.ToString();
                    var currentValue = change.CurrentValues[prop]?.ToString();
                    if (originalValue != currentValue)
                    {
                        var ValorAntigo = new { NomeColuna = prop, Valor = originalValue };
                        var ValorNovo = new { NomeColuna = prop, Valor = currentValue };
                        ListaAntigo.Add(ValorAntigo);
                        ListaNovo.Add(ValorNovo);
                    }
                }
                if(ListaAntigo.Count > 0)
                {
                    var jsonSerialiser = new JavaScriptSerializer();
                    LogAlteracao log = new LogAlteracao()
                    {
                        NomeEntidade = entityName,
                        IdPrimaryKey = primaryKey.ToString(),
                        ValorAntigo = jsonSerialiser.Serialize(ListaAntigo),
                        NovoValor = jsonSerialiser.Serialize(ListaNovo),
                        DataAlteracao = now,
                        ReponsavelAlteracao = Convert.ToInt32(userId),
                        NomeUsuarioResponsavel = userName,
                        TipoAlteracao = change.State == EntityState.Modified ? TipoAlteracao.Edicao.Value : change.State == EntityState.Added ? TipoAlteracao.Criacao.Value : TipoAlteracao.Exclusao.Value
                    };
                    LogAlteracaoDAO logAlteracaoDAO = new LogAlteracaoDAO(this);
                    logAlteracaoDAO.Salvar(log);
                    //LogAlteracao.Add(log);
                }
            }
            return base.SaveChanges();
        }

        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }
    }
}