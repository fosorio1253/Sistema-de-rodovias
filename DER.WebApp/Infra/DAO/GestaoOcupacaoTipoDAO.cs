using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoInteressados;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DER.WebApp.Helper;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoOcupacaoTipoDAO : BaseDAO<TipoDeOcupacao>
    {
        private Logger _logger;
        public GestaoOcupacaoTipoDAO(DerContext context) : base(context)
        {
            _logger = new Logger("Gestão Ocupação Tipo", context);
        }

        public List<GestaoOcupacoesTipoOcupacaoViewModel> GetByIdInteressado(int idInteressado)
        //-- Description:	Busca um Tipo de Ocupação.
        //PROC: [STP_SEL_GESTAO_OCUPACAO_TIPO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoOcupacoesTipoOcupacaoViewModel>();

            const string sql = @"select val.dmv_id as TipoOcupacaoId,
		                                val.dmv_valor as Nome
	                                from tab_gestao_interessado_tipo_de_concessao conc
	                                inner join tab_dadosMestres_val val on conc.dmv_id_tipo_concessao = val.dmv_id
                                where conc.int_id = @idInteressado";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                retorno = db.Query<GestaoOcupacoesTipoOcupacaoViewModel>(sql, new { idInteressado = idInteressado }, commandType: CommandType.Text).ToList();
            }

            return retorno;
        }
    }
}