using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DER.WebApp.Helper;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoOcupacaoDeferimentoDAO : BaseDAO<GestaoOcupacaoDeferimento>
    {

        public GestaoOcupacaoDeferimentoDAO(DerContext context) : base(context)
        {
        }

        public void ExcluirPorIdOcupacao(int idOcupacao)
        //-- Description:	Deleta um item No menu Deferimento.
        //PROC: [STP_DEL_GESTAO_OCUPACAO_DEFERIMENTO]
        {
            var old_value = GetByOcupacaoId(idOcupacao);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_GESTAO_OCUPACAO_DEFERIMENTO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@idOcupacao", idOcupacao));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                }
            }
        }

        public GestaoOcupacaoDeferimentoViewModel GetByOcupacaoId(int idOcupacao)
        //-- Description:	Busca um Deferimento no menu Deferimento pelo ID.
        //[STP_SEL_GESTAO_OCUPACAO_DEFERIMENTO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var gestao = new GestaoOcupacaoDeferimentoViewModel();            

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACAO_DEFERIMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@idOcupacao", idOcupacao));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            DateTime? VariavelDateNula = null;

                            gestao.Id = (result["Id"]) == null ? 0 : Convert.ToInt32(result["Id"]);
                            gestao.DataAssinatura = result["DataAssinatura"] != DBNull.Value ? Convert.ToDateTime(result["DataAssinatura"]) : VariavelDateNula;
                            gestao.DataPublicacao = result["DataPublicacao"] != DBNull.Value ? Convert.ToDateTime(result["DataPublicacao"]) : VariavelDateNula;
                            gestao.DataDespachoAutorizativo = result["DataDespachoAutorizativo"] != DBNull.Value ? Convert.ToDateTime(result["DataDespachoAutorizativo"]) : VariavelDateNula;
                            gestao.NumeroProcesso = result["NumeroProcesso"].ToString() == null ? String.Empty : result["NumeroProcesso"].ToString();
                            gestao.CaminhoArquivo = result["CaminhoArquivo"].ToString() == null ? String.Empty : result["CaminhoArquivo"].ToString();

                        }
                        conn.Close();
                    }
                }
                return gestao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Inserir(GestaoOcupacaoDeferimento domain)
        //-- Description:	Insere um novo Deferimento no Menu de Deferimento.
        //PROC: [STP_INS_GESTAO_OCUPACAO_DEFERIMENTO]
        {
            
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
                     
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_OCUPACAO_DEFERIMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@gestaoOcupacaoId", domain.GestaoOcupacaoId));
                        command.Parameters.Add(new SqlParameter("@dataAssinatura", domain.DataAssinatura));
                        command.Parameters.Add(new SqlParameter("@dataPublicacao", domain.DataPublicacao));
                        command.Parameters.Add(new SqlParameter("@dataDespachoAutorizativo", domain.DataDespachoAutorizativo));
                        command.Parameters.Add(new SqlParameter("@numeroProcesso", domain.NumeroProcesso));
                        command.Parameters.Add(new SqlParameter("@termoAnexadoArquivo", domain.TermoAnexadoArquivo));

                        var result = command.ExecuteNonQuery();
                        var value = GetByOcupacaoId(domain.GestaoOcupacaoId);
                        conn.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}