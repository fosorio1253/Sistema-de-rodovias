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
    public class GestaoOcupacaoTrechoInterferenciaDAO : BaseDAO<GestaoOcupacaoTrechoInterferencia>
    {
        
        public GestaoOcupacaoTrechoInterferenciaDAO(DerContext context) : base(context)
        {
        
        }

        public void ExcluirPorIdOcupacao(int idOcupacao)
        //-- Description:	Deleta uma Interferência de um determinado Trecho.
        //PROC: [STP_DEL_GESTAO_OCUPACAO_TRECHO_INTERFERENCIA]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"DELETE FROM tab_gestao_ocupacao_trecho_interferencia
	                                WHERE exists( SELECT ocu_tre_id FROM tab_gestao_ocupacao_trecho where ocu_id = @idOcupacao)";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).ToList();

                conexao.Close();
                
            }
        }

        public List<GestaoOcupacoesTrechoInterferenciaViewModel> GetByTrechoId(int idTrecho)
        //-- Description:	Busca as Interferências de um Trecho pelo ID.
        //PROC: [STP_SEL_GESTAO_OCUPACAO_TRECHO_INTERFERENCIA_ID]

        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoOcupacoesTrechoInterferenciaViewModel>();

            const string sql = @"select
                                    ocu_tre_int_id as Id,
                                    ocu_tre_id as GestaoOcupacaoTrechoId,
                                    ocu_tre_int_tipo_id as interferencia_tipo_id,
                                    ocu_tre_int_volume as volume_unitario,
                                    ocu_tre_int_quantidade as quantidade,
                                    ocu_tre_int_volume_total as volume_total
                                from tab_gestao_ocupacao_trecho_interferencia where ocu_tre_id = @idTrecho";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                retorno = db.Query<GestaoOcupacoesTrechoInterferenciaViewModel>(sql, new { idTrecho = idTrecho }, commandType: CommandType.Text).ToList();
            }

            return retorno;
        }

        public void Inserir(GestaoOcupacaoTrechoInterferencia domain)
        //-- Description:	Insere uma nova Interferência em um Trecho da Ocupação.
        //PROC: [STP_INS_GESTAO_OCUPACAO_TRECHO_INTERFERENCIA]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            string sqlUpdate = @"INSERT INTO tab_gestao_ocupacao_trecho_interferencia
                                VALUES( @gestaoOcupacaoTrechoId,
                                        @tipoInterferencia,
                                        @volume,
                                        @quantidade,
                                        @volumeTotal)";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sqlUpdate, new
                {
                    gestaoOcupacaoTrechoId = domain.GestaoOcupacaoTrechoId,
                    tipoInterferencia = domain.TipoInterferencia,
                    quantidade = domain.Quantidade,
                    volume = domain.Volume,
                    volumeTotal = domain.VolumeTotal
                }, commandType: CommandType.Text);

                conexao.Close();
                
            }
        }
    }
}