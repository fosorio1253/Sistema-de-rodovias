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
    public class GestaoOcupacaoRegularizacaoDAO : BaseDAO<GestaoOcupacaoRegularizacao>
    {
        
        public GestaoOcupacaoRegularizacaoDAO(DerContext context) : base(context)
        {
            
        }

        public void ExcluirPorIdOcupacao(int idOcupacao)
        //-- Description:	Deleta um Regularizacao da Ocupação.
        //[STP_DEL_GESTAO_OCUPACAO_Regularizacao]
        {
            var oldValue = GetByOcupacaoId(idOcupacao);

            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"delete from tab_gestao_ocupacao_Regularizacao where ocu_id = @idOcupacao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).ToList();

                conexao.Close();
                
            }
        }

        public GestaoOcupacaoRegularizacaoViewModel GetByOcupacaoId(int idOcupacao)
        //-- Description:	Busca um Regularizacao em Ocupações.
        //PROC: [STP_SEL_GESTAO_OCUPACAO_Regularizacao_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new GestaoOcupacaoRegularizacaoViewModel();

            const string sql = @"select 
                                    [ocu_reg_id] as id,
	                                [ocu_id] as GestaoOcupacaoId ,
	                                [ocu_reg_data_provavel_implantacao] as DataProvavelImplantacao
                                from tab_gestao_ocupacao_Regularizacao
                                where ocu_id = @idOcupacao";

            using (SqlConnection db = new SqlConnection(connectionString))
            {
                retorno = db.Query<GestaoOcupacaoRegularizacaoViewModel>(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).FirstOrDefault();
            }

            return retorno;
        }

        public void Inserir(GestaoOcupacaoRegularizacao domain)
        //-- Description:	Insere um novo Regularizacao na Gestão de Ocupações
        //PROC: [STP_INS_GESTAO_OCUPACAO_Regularizacao]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            string sqlUpdate = @"INSERT INTO tab_gestao_ocupacao_Regularizacao
                                VALUES( @ocu_id,
                                        @ocu_reg_data_provavel_implantacao
                                       )";


            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sqlUpdate, new
                {
                    ocu_id = domain.GestaoOcupacaoId,
                    ocu_reg_data_provavel_implantacao = domain.DataProvavelImplantacao
                }, commandType: CommandType.Text);

                conexao.Close();
            }
        }
    }
}