using System;
using System.Threading;
using System.Web.Script.Serialization;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;

namespace DER.WebApp.Helper
{
    public class TipoAlteracao
    {
        private TipoAlteracao(string value) { Value = value; }

        public string Value { get; private set; }

        public static TipoAlteracao Criacao   { get { return new TipoAlteracao("Criação"); } }
        public static TipoAlteracao Edicao   { get { return new TipoAlteracao("Edição"); } }
        public static TipoAlteracao Exclusao    { get { return new TipoAlteracao("Exclusão"); } }

    }
    
    // _logger = new Logger("Nome Entidade");
    public class Logger
    {
        private DerContext _context;
        private String nomeEntidade;
        private JavaScriptSerializer serializer = new JavaScriptSerializer();

        public Logger(String nomeEntidade)
        {
            this.nomeEntidade = nomeEntidade;
            _context = new DerContext();
        } 

        public void salvarLog(TipoAlteracao tipoAlteracao, String id, Object valorNovo = null, Object valorAntigo = null)
        {
            var userId = System.Web.HttpContext.Current.Session["UserId"];
            var userName = Thread.CurrentPrincipal.Identity.Name;

            LogAlteracao log = new LogAlteracao()
            {
                NomeEntidade = nomeEntidade,
                IdPrimaryKey = id,
                ValorAntigo = valorAntigo == null ? "" : serialize(valorAntigo),
                NovoValor = valorNovo == null ? "" : serialize(valorNovo),
                DataAlteracao = DateTime.UtcNow,
                ReponsavelAlteracao = Convert.ToInt32(userId),
                NomeUsuarioResponsavel = userName,
                TipoAlteracao = tipoAlteracao.Value
            };
            LogAlteracaoDAO logAlteracaoDAO = new LogAlteracaoDAO(_context);
            logAlteracaoDAO.Salvar(log);
        }

        private String serialize(Object obj)
        {
            return serializer.Serialize(obj);
        }

    }
}