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
    public class GestaoOcupacaoOcorrenciaDAO : BaseDAO<GestaoOcupacaoOcorrencia>
    {
        public GestaoOcupacaoOcorrenciaDAO(DerContext context) : base(context)
        {
            
        }

        public void ExcluirPorIdOcupacao(int idOcupacao)
        //-- Description:	Deleta um item No menu Ocorrência.
        //PROC: [STP_DEL_GESTAO_OCUPACAO_OCORRENCIA]
        {
            var oldValue = GetByOcupacaoId(idOcupacao);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"delete from tab_gestao_ocupacao_ocorrencia where ocu_id = @idOcupacao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).ToList();

                conexao.Close();
                
            }
        }

        public List<RetornoOcorrenciaViewModel> GetByOcupacaoId(int idOcupacao)
        //-- Description:	Busca as Ocorrências do menu Ocorrências pelo ID.
        //PROC: [STP_SEL_GESTAO_OCUPACAO_OCORRENCIA_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<RetornoOcorrenciaViewModel>();

            const string sql = @"select 
                                       ocu_oco_int as Id,
                                       ocu_oco_dataOcorrencia as DataOcorrencia,
	                                   ocu_oco_autor as Autor,
	                                   ocu_oco_area as Area,
	                                   ocu_oco_ocorrencia as Ocorrencia,
                                       ocu_oco_areaId as AreaId
                                from tab_gestao_ocupacao_ocorrencia
                                where ocu_id = @idOcupacao";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                retorno = db.Query<RetornoOcorrenciaViewModel>(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).ToList();
            }

            return retorno;
        }

        public void Inserir(GestaoOcupacaoOcorrencia domain)
        //-- Description:	Insere uma nova Ocorrência no Menu de Ocorrências.
        //PROC: [STP_INS_GESTAO_OCUPACAO_OCORRENCIA]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            string sqlUpdate = @"INSERT INTO tab_gestao_ocupacao_ocorrencia
                                VALUES( @gestaoOcupacaoId,
                                        @dataOcorrencia,
                                        @autor,
                                        @area,
                                        @ocorrencia,
                                        @areaId)";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sqlUpdate, new
                {
                    gestaoOcupacaoId = domain.GestaoOcupacaoId,
                    dataOcorrencia = domain.DataOcorrencia,
                    autor = domain.Autor,
                    area = domain.Area,
                    areaId = domain.AreaId,
                    ocorrencia = domain.Ocorrencia,
                }, commandType: CommandType.Text);

                conexao.Close();
            }
        }
    }
}