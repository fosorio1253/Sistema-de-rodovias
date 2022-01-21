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
    public class GestaoOcupacaoOcupacaoDAO : BaseDAO<GestaoOcupacaoOcupacao>
    {
                
        public GestaoOcupacaoOcupacaoDAO(DerContext context) : base(context)
        {
        }

        public void ExcluirPorIdOcupacao(int idOcupacao)
        //-- Description:	Deleta um item No menu Ocupação.
        //PROC: [STP_DEL_GESTAO_OCUPACAO_OCUPACAO]
        {
            var oldValue = GetByOcupacaoId(idOcupacao);
            
            
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"delete from tab_gestao_ocupacao_ocupacao where ocu_id = @idOcupacao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).ToList();

                conexao.Close();
            }
           
        }

        public GestaoOcupacaoOcupacaoViewModel GetByOcupacaoId(int idOcupacao)
        //-- Description:	Busca as Ocupacões do menu Ocupacões pelo ID.
        //PROC: [STP_SEL_GESTAO_OCUPACAO_OCUPACAO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new GestaoOcupacaoOcupacaoViewModel();

            const string sql = @"select 
		                                ocu_ocu_id as Id,
                                        ocu_ocu_assunto as Assunto,
	                                    ocu_ocu_observacao as Observacao
                                from tab_gestao_ocupacao_ocupacao
                                where ocu_id = @idOcupacao";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                retorno = db.Query<GestaoOcupacaoOcupacaoViewModel>(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).FirstOrDefault();
            }

            return retorno;
        }

        public void Inserir(GestaoOcupacaoOcupacao domain)
        //-- Description:	Insere uma nova Ocupação no Menu de Ocupações.
        // PROC: [STP_INS_GESTAO_OCUPACAO_OCUPACAO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            string sqlUpdate = @"INSERT INTO tab_gestao_ocupacao_ocupacao
                                VALUES( @gestaoOcupacaoId,
                                        @assunto,
                                        @observacao)";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sqlUpdate, new
                {
                    gestaoOcupacaoId = domain.GestaoOcupacaoId,
                    assunto = domain.Assunto,
                    observacao = domain.Observacao,
                }, commandType: CommandType.Text);

                conexao.Close();
            }
        }
    }
}