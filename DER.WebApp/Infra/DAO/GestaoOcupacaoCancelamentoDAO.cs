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
    public class GestaoOcupacaoCancelamentoDAO : BaseDAO<GestaoOcupacaoCancelamento>
    {
        
        public GestaoOcupacaoCancelamentoDAO(DerContext context) : base(context)
        {
            
        }

        public void ExcluirPorIdOcupacao(int idOcupacao)
        //-- Description:	Deleta um Cancelamento da Ocupação.
        //[STP_DEL_GESTAO_OCUPACAO_Cancelamento]
        {
            var oldValue = GetByOcupacaoId(idOcupacao);

            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"delete from tab_gestao_ocupacao_Cancelamento where ocu_id = @idOcupacao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).ToList();

                conexao.Close();
                
            }
        }

        public GestaoOcupacaoCancelamentoViewModel GetByOcupacaoId(int idOcupacao)
        //-- Description:	Busca um Cancelamento em Ocupações.
        //PROC: [STP_SEL_GESTAO_OCUPACAO_Cancelamento_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new GestaoOcupacaoCancelamentoViewModel();


        const string sql = @"select 
                                    [ocu_can_id] as id,
	                                [ocu_id] as GestaoOcupacaoId,
	                                [ocu_can_motivo] as MotivoCancelamento
                                from tab_gestao_ocupacao_Cancelamento
                                where ocu_id = @idOcupacao";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                retorno = db.Query<GestaoOcupacaoCancelamentoViewModel>(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).FirstOrDefault();
            }

            return retorno;
        }

        public void Inserir(GestaoOcupacaoCancelamento domain)
        //-- Description:	Insere um novo Cancelamento na Gestão de Ocupações
        //PROC: [STP_INS_GESTAO_OCUPACAO_Cancelamento]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            string sqlUpdate = @"INSERT INTO tab_gestao_ocupacao_Cancelamento
                                VALUES( @ocu_id,
                                        @ocu_can_motivo 
                                        )";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sqlUpdate, new
                {
                    ocu_id = domain.GestaoOcupacaoId,
                    ocu_can_motivo = domain.MotivoCancelamento
                }, commandType: CommandType.Text);


                conexao.Close();
            }
        }
    }
}