using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DER.WebApp.Helper;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoOcupacaoRetificacaoDAO : BaseDAO<GestaoOcupacaoRetificacao>
    {
        private Logger _logger;
        public GestaoOcupacaoRetificacaoDAO(DerContext context) : base(context)
        {
            _logger = new Logger("Gestão Ocupação Retificacao", context);
        }

        public void ExcluirPorIdOcupacao(int idOcupacao)
        //-- Description:	Deleta um Retificacao da Ocupação.
        //[STP_DEL_GESTAO_OCUPACAO_Retificacao]
        {
            var oldValue = GetByOcupacaoId(idOcupacao);

            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"delete from tab_gestao_ocupacao_Retificacao where ocu_id = @idOcupacao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).ToList();

                conexao.Close();
                // _logger.salvarLog(TipoAlteracao.Exclusao,oldValue.Id.ToString(), _logger.serializer.Serialize(oldValue) , "");
            }
        }

        public GestaoOcupacaoRetificacaoViewModel GetByOcupacaoId(int idOcupacao)
        //-- Description:	Busca um Retificacao em Ocupações.
        //PROC: [STP_SEL_GESTAO_OCUPACAO_Retificacao_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var model = new GestaoOcupacaoRetificacao();

        const string sql = @"select 
                                    [ocu_ret_id] as id,
	                                [ocu_id] as GestaoOcupacaoId,
	                                [ocu_ret_data_solicitacao] as DataSolicitacao,
	                                [ocu_ret_objeto_termo_retificacao] as ObjetoTermoRetificacao
                                from tab_gestao_ocupacao_Retificacao
                                where ocu_id = @idOcupacao";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                model = db.Query<GestaoOcupacaoRetificacao>(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).FirstOrDefault();
            }
            if (model == null) return null;
            var retorno = new GestaoOcupacaoRetificacaoViewModel();
            retorno.DataSolicitacao = model.DataSolicitacao.ToString("yyyy-MM-dd");
            retorno.ObjetoTermoRetificacao = model.ObjetoTermoRetificacao;
            retorno.id = model.id;

            return retorno;
        }

        public void Inserir(GestaoOcupacaoRetificacao domain)
        //-- Description:	Insere um novo Retificacao na Gestão de Ocupações
        //PROC: [STP_INS_GESTAO_OCUPACAO_Retificacao]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;


            string sqlUpdate = @"INSERT INTO tab_gestao_ocupacao_Retificacao
                                VALUES( @ocu_id,
                                        @ocu_ret_data_solicitacao,
                                        @ocu_ret_objeto_termo_retificacao
                                        )";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sqlUpdate, new
                {
                    ocu_id = domain.GestaoOcupacaoId,
                    ocu_ret_data_solicitacao = domain.DataSolicitacao,
                    ocu_ret_objeto_termo_retificacao = domain.ObjetoTermoRetificacao
                }, commandType: CommandType.Text);

                _logger.salvarLog(TipoAlteracao.Criacao, "", "", _logger.serializer.Serialize(domain));
                conexao.Close();
            }
        }
    }
}