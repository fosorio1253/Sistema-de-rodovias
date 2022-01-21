using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoOcorrencias;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DER.WebApp.Helper;
using System;
using DER.WebApp.Domain.Models.DTO;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoOcorrenciaObservacaoDAO : BaseDAO<GestaoOcorrenciaObservacao>
    {
        
        public GestaoOcorrenciaObservacaoDAO(DerContext context) : base(context)
        {
        
        }

        public void ExcluirPorIdGestao(int idOcorrencia)
        //-- Description:	Deleta as Observações da Gestão de Ocorrências.
        //PROC: [STP_DEL_GESTAO_OCORRENCIAS_OBSERVACAO]
        {
            var oldValue = GetByGestaoId(idOcorrencia);            
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_DEL_GESTAO_OCORRENCIAS_OBSERVACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@idOcorrencia", idOcorrencia));
                        conn.Open();
                        command.ExecuteNonQuery();
                        command.Parameters.Clear();
                        conn.Close();

                        

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<GestaoObservacaoViewModel> GetByGestaoId(int idGestao)
        //-- Description:	Busca uma Observação em Gestão de Ocôrrências.
        //PROC: [STP_SEL_GESTAO_OCORRENCIAS_OBSERVACAO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoObservacaoViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCORRENCIAS_OBSERVACAO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@idGestao", idGestao));

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {                            
                            DateTime? VariavelDateNula = null;

                            var gestao = new GestaoObservacaoViewModel();
                           //gestao.Id = result["Id"] == null ? 0 : Convert.ToInt32(result["Id"]);
                           gestao.Observacao = (result["Observacao"] == null ? string.Empty : result["Observacao"].ToString());
                           gestao.Nome = (result["Nome"] == null ? string.Empty : result["Nome"].ToString());
                           gestao.Cargo = (result["Cargo"] == null ? string.Empty : result["Cargo"].ToString());
                           gestao.UsuarioAtualizacao = (result["UsuarioAtualizacao"] == null ? string.Empty : result["UsuarioAtualizacao"].ToString());
                           gestao.DataCadastro = result["DataCadastro"] != DBNull.Value ? Convert.ToDateTime(result["DataCadastro"]) : VariavelDateNula;
                            
                            retorno.Add(gestao);
                        }
                        conn.Close();
                    }
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<GestaoObservacaoViewModel> Inserir(GestaoOcorrenciaObservacao domain)
        //-- Description:	Insere uma nova Observação em Gestão de Ocorrências.
        //PROC: [STP_INS_GESTAO_OCORRENCIA_OBSERVACAO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_OCORRENCIAS_OBSERVACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@gestaoOcorrenciaId", domain.GestaoOcorrenciaId));
                        command.Parameters.Add(new SqlParameter("@observacao", domain.Observacao));
                        command.Parameters.Add(new SqlParameter("@nome", domain.Nome));
                        command.Parameters.Add(new SqlParameter("@cargo", domain.Cargo));
                        command.Parameters.Add(new SqlParameter("@oco_obs_addPor", domain.UsuarioAtualizacao));
                        command.Parameters.Add(new SqlParameter("@dataCadastro", domain.DataCadastro));
                       
                        var result = command.ExecuteScalar();

                        conn.Close();
                        var value = GetByGestaoId(Convert.ToInt32(result));
                        return value;
                        //return Convert.ToInt32(result);
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