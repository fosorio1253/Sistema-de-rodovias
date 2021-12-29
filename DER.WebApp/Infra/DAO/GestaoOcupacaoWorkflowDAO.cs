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
    public class GestaoOcupacaoWorkflowDAO : BaseDAO<GestaoOcupacaoWorkflow>
    {
        private Logger _logger;
        public GestaoOcupacaoWorkflowDAO(DerContext context) : base(context)
        {
            _logger = new Logger("Gestão Ocupação Workflow", context);
        }

        public GestaoOcupacaoWorkflow Inserir(GestaoOcupacaoWorkflow domain)
        //-- Description:	Insere um novo Workflow na Gestão de Ocupações
        //PROC: [STP_INS_GESTAO_OCUPACAO_Workflow]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            string InsertQueryReturnInserted = $"INSERT INTO tab_gestao_ocupacao_workflow OUTPUT " +
                $"INSERTED.ocu_wor_id as Id" +
                $",INSERTED.ocu_wor_dataCadastro as DataCadastro" +
                $" VALUES (" +
                $"@ocu_wor_dataCadastro" +
                $")";
            GestaoOcupacaoWorkflow retorno = new GestaoOcupacaoWorkflow();

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                retorno = conexao.Query<GestaoOcupacaoWorkflow>(InsertQueryReturnInserted, new
                {
                    ocu_wor_dataCadastro = domain.DataCadastro
                }, commandType: CommandType.Text).FirstOrDefault();

                _logger.salvarLog(TipoAlteracao.Criacao, "", "", _logger.serializer.Serialize(domain));
                conexao.Close();
            }

            return retorno;
        }
    }
}