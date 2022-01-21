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
    public class GestaoOcupacaoTransferenciaDAO : BaseDAO<GestaoOcupacaoTransferencia>
    {
        
        public GestaoOcupacaoTransferenciaDAO(DerContext context) : base(context)
        {
            
        }

        public void ExcluirPorIdOcupacao(int idOcupacao)
        //-- Description:	Deleta um Transferencia da Ocupação.
        //[STP_DEL_GESTAO_OCUPACAO_Transferencia]
        {
            var oldValue = GetByOcupacaoId(idOcupacao);

            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            const string sql = @"delete from tab_gestao_ocupacao_Transferencia where ocu_id = @idOcupacao";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).ToList();

                conexao.Close();
                
            }
        }

        public GestaoOcupacaoTransferenciaViewModel GetByOcupacaoId(int idOcupacao)
        //-- Description:	Busca um Transferencia em Ocupações.
        //PROC: [STP_SEL_GESTAO_OCUPACAO_Transferencia_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var model = new GestaoOcupacaoTransferencia();

            const string sql = @"select 
                                    A.ocu_tra_id as id,
                                    A.ocu_id as GestaoOcupacaoId,
                                    A.ocu_tra_antecessor_int_id as InteressadoAntecessorId,
                                    A.ocu_tra_antecessor_numerospdoc as NumerospdocAntecessor,
                                    A.ocu_tra_antecessor_numeroProcesso as NumeroProcessoAntecessor,
                                    A.ocu_tra_recolher as Recolher,
                                    A.ocu_tra_liminar_deposito_judicial as LiminarDepositoJudicial,
                                    A.ocu_tra_liminar_suspensao_recolhimento as LiminarSuspensoRecolhimento,
                                    A.ocu_tra_observacoes as Observacao,
                                    B.int_nome as AntecessorInteressado,
									C.usu_email as AntecessorInteressadoEmail,
									B.int_documento as AntecessorDocumento,
                                    A.ocu_tra_data_solicitacao as DataSolicitacao
                                from tab_gestao_ocupacao_Transferencia A
								inner join [dbo].[tab_gestao_interessado] B on B.int_id=A.ocu_tra_antecessor_int_id
								inner join [dbo].[tab_usuarios] C on C.usu_id=B.int_usuario_id
                                where ocu_id = @idOcupacao";



            using (SqlConnection db = new SqlConnection(connectionString))
            {
                model = db.Query<GestaoOcupacaoTransferencia>(sql, new { idOcupacao = idOcupacao }, commandType: CommandType.Text).FirstOrDefault();
            }
            if (model == null) return null;

            var retorno = new GestaoOcupacaoTransferenciaViewModel();
            retorno.id = model.id;
            retorno.InteressadoAntecessorId = model.InteressadoAntecessorId;
            retorno.NumerospdocAntecessor = model.NumerospdocAntecessor;
            retorno.NumeroProcessoAntecessor = model.NumeroProcessoAntecessor;
            retorno.Recolher = model.Recolher;
            retorno.LiminarDepositoJudicial = model.LiminarDepositoJudicial;
            retorno.LiminarSuspensoRecolhimento = model.LiminarSuspensoRecolhimento;
            retorno.Observacao = model.Observacao;
            retorno.AntecessorInteressado = model.AntecessorInteressado;
            retorno.AntecessorInteressadoEmail = model.AntecessorInteressadoEmail;
            retorno.AntecessorDocumento = model.AntecessorDocumento;
            retorno.DataSolicitacao = model.DataSolicitacao.ToString("yyyy-MM-dd");

            return retorno;
        }

        public void Inserir(GestaoOcupacaoTransferencia domain)
        //-- Description:	Insere um novo Transferencia na Gestão de Ocupações
        //PROC: [STP_INS_GESTAO_OCUPACAO_Transferencia]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;


            string sqlUpdate = @"INSERT INTO tab_gestao_ocupacao_Transferencia
                                VALUES( @ocu_id,
                                        @ocu_tra_antecessor_int_id,
                                        @ocu_tra_antecessor_numerospdoc,
                                        @ocu_tra_antecessor_numeroProcesso,
                                        @ocu_tra_recolher,
                                        @ocu_tra_liminar_deposito_judicial,
                                        @ocu_tra_liminar_suspensao_recolhimento,
                                        @ocu_tra_observacoes,
                                        @ocu_tra_data_solicitacao)";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                conexao.Query(sqlUpdate, new
                {
                    ocu_id = domain.GestaoOcupacaoId,
                    ocu_tra_antecessor_int_id = domain.InteressadoAntecessorId,
                    ocu_tra_antecessor_numerospdoc = domain.NumerospdocAntecessor,
                    ocu_tra_antecessor_numeroProcesso = domain.NumeroProcessoAntecessor,
                    ocu_tra_recolher = domain.Recolher,
                    ocu_tra_liminar_deposito_judicial = domain.LiminarDepositoJudicial,
                    ocu_tra_liminar_suspensao_recolhimento = domain.LiminarSuspensoRecolhimento,
                    ocu_tra_observacoes = domain.Observacao,
                    ocu_tra_data_solicitacao = domain.DataSolicitacao
                }, commandType: CommandType.Text);

                conexao.Close();
            }
        }
    }
}