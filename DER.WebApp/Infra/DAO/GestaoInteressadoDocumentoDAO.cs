using Dapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DER.WebApp.Helper;
using System;

namespace DER.WebApp.Infra.DAO
{
    public class GestaoInteressadoDocumentoDAO : BaseDAO<GestaoInteressadoDocumento>
    {
        
        public GestaoInteressadoDocumentoDAO(DerContext context) : base(context)
        {
        
        }

        public List<GestaoDocumentoViewModel> GetByGestaoId(int idGestao)
        //-- Description:	Busca um Documento em Gestão de Interessados.
        //PROC: [STP_SEL_GESTAO_INTERESSADO_DOCUMENTO_ID]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoDocumentoViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_INTERESSADO_DOCUMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@idGestao", idGestao));
                      
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            DateTime? VariavelDateNula = null;

                            var gestao = new GestaoDocumentoViewModel();
                            gestao.Id = Convert.ToInt32(result["Id"]);
                            gestao.Documento = (result["Documento"] == null ? string.Empty : result["Documento"].ToString());
                            gestao.TipoDocumentoId = Convert.ToInt32(result["TipoDocumentoId"]);
                            gestao.Arquivo = (result["Arquivo"] == null ? string.Empty : result["Arquivo"].ToString());
                            gestao.DataCadastro = result["DataCadastro"] != DBNull.Value ? Convert.ToDateTime(result["DataCadastro"]) : VariavelDateNula;
                            gestao.AdicionadoPor = result["AdicionadoPor"] is DBNull ? string.Empty : result["AdicionadoPor"].ToString();
                           
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

        public List<GestaoDocumentoViewModel> DocumentoExistente(GestaoInteressadoDocumento documento)
        //-- Description:	Verifica se um Documento já está cadastrado em Gestão de Interessado.
        //PROC: [STP_SEL_GESTAO_INTERESSADO_DOCUMENTO_EXISTENTE]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<GestaoDocumentoViewModel>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_INTERESSADO_DOCUMENTO_EXISTENTE", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@idGestao", documento.GestaoInteressadoId));
                        command.Parameters.Add(new SqlParameter("@documento", documento.Documento));
                        command.Parameters.Add(new SqlParameter("@arquivo", documento.Arquivo));
                        command.Parameters.Add(new SqlParameter("@int_doc_addPor", documento.AdicionadoPor));
                        //command.Parameters.Add(new SqlParameter("@dataCadastro", documento.DataCadastro));

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var gestao = new GestaoDocumentoViewModel();
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
        public void Inserir(GestaoInteressadoDocumento domain)
        //-- Description:	Insere um novo documento em Gestão de Interessados.
        //PROC: [STP_INS_GESTAO_INTERESSADO_DOCUMENTO]
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_INTERESSADO_DOCUMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@GestaoInteressadoId", domain.GestaoInteressadoId));
                        command.Parameters.Add(new SqlParameter("@documento", domain.Documento));
                        command.Parameters.Add(new SqlParameter("@arquivo", domain.Arquivo));
                        command.Parameters.Add(new SqlParameter("@int_doc_addPor", domain.AdicionadoPor));
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