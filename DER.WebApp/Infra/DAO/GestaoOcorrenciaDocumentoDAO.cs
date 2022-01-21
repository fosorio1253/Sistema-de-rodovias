using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Helper;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoOcorrencias;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoOcorrenciaDocumentoDAO : BaseDAO<GestaoOcorrenciaDocumento>
    {
        
        public GestaoOcorrenciaDocumentoDAO(DerContext context) : base(context)
        {

        }

        public List<GestaoOcorrenciaDocumentoViewModel> GetByGestaoId(int idGestao)
        //-- Description:	Busca uma Observação em Gestão de Ocôrrências.
        //PROC: [STP_SEL_GESTAO_OCORRENCIAS_DOCUMENTO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoOcorrenciaDocumentoViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCORRENCIAS_DOCUMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@idGestao", idGestao));

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {

                            var gestao = new GestaoOcorrenciaDocumentoViewModel();
                            //gestao.Id = result["Id"] == null ? 0 : Convert.ToInt32(result["Id"]);
                            gestao.Documento = (result["Documento"] == null ? string.Empty : result["Documento"].ToString());
                            gestao.Arquivo = (result["Arquivo"] == null ? string.Empty : result["Arquivo"].ToString());
                            gestao.AdicionadoPor = (result["AdicionadoPor"] == null ? string.Empty : result["AdicionadoPor"].ToString());
                            gestao.DataCadastro =  Convert.ToDateTime(result["DataCadastro"]);

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

        public List<GestaoOcorrenciaDocumentoViewModel> DocumentoExistente(GestaoOcorrenciaDocumento documento)
        //-- Description:	Verifica se um Documento já está cadastrado em Gestão de Ocorrências.
        //PROC: [STP_SEL_GESTAO_OCORRENCIAS_DOCUMENTO_EXISTENTE]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoOcorrenciaDocumentoViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCORRENCIAS_DOCUMENTO_EXISTENTE", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@idGestao", documento.GestaoOcorrenciaId));
                        command.Parameters.Add(new SqlParameter("@documento", documento.Documento));
                        command.Parameters.Add(new SqlParameter("@arquivo", documento.Arquivo));
                        command.Parameters.Add(new SqlParameter("@oco_doc_addPor", documento.AdicionadoPor));
                        //command.Parameters.Add(new SqlParameter("@dataCadastro", documento.DataCadastro));

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var gestao = new GestaoOcorrenciaDocumentoViewModel();
                            gestao.Id = Convert.ToInt32(result["Id"]);
                            gestao.Documento = (result["Documento"] == null ? string.Empty : result["Documento"].ToString());
                            gestao.Arquivo = (result["Arquivo"] == null ? string.Empty : result["Arquivo"].ToString());
                            gestao.AdicionadoPor = (result["AdicionadoPor"] == null ? string.Empty : result["AdicionadoPor"].ToString());
                            //gestao.DataCadastro =  Convert.ToDateTime(result["DataCadastro"]);

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

        public void Inserir(GestaoOcorrenciaDocumento domain)
        //-- Description:	Insere uma novo documento em Gestão de Ocorrências.
        //PROC: [STP_INS_GESTAO_OCORRENCIAS_DOCUMENTO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_OCORRENCIAS_DOCUMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@gestaoOcorrenciaId", domain.GestaoOcorrenciaId));
                        command.Parameters.Add(new SqlParameter("@documento", domain.Documento));
                        command.Parameters.Add(new SqlParameter("@arquivo", domain.Arquivo));
                        command.Parameters.Add(new SqlParameter("@oco_doc_addPor", domain.AdicionadoPor));
                        command.Parameters.Add(new SqlParameter("@dataCadastro", DateTime.Now));

                        var result = command.ExecuteNonQuery();
 
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