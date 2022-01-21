using DER.WebApp.Domain.Models;
using DER.WebApp.Helper;
using DER.WebApp.Infra.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DER.WebApp.Infra.DAO
{
    public class OcorrenciaTrechoDAO : BaseDAO<OcorrenciaTrecho>
    {
        Logger logger;

        public OcorrenciaTrechoDAO(DerContext context) : base(context)
        {
            logger = new Logger("OcorrenciaTrecho");
        }

        public List<OcorrenciaTrecho> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<OcorrenciaTrecho>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_OCORRENCIA_TRECHO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new OcorrenciaTrecho();
                            retorno.ocorrencia_trecho_id = result["ocorrencia_trecho_id"] is DBNull ? 0 : Convert.ToInt32(result["ocorrencia_trecho_id"]);
                            retorno.nome = result["nome"] is DBNull ? string.Empty : result["nome"].ToString();

                            lretorno.Add(retorno);
                        }
                        conn.Close();
                    }
                }
                return lretorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Inserir(OcorrenciaTrecho domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_OCORRENCIA_TRECHO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@ocorrencia_trecho_id", domain.ocorrencia_trecho_id));
                        command.Parameters.Add(new SqlParameter("@nome", domain.nome));
                        var result = command.ExecuteScalar();
                        command.Parameters.Clear();
                        conn.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(OcorrenciaTrecho domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.ocorrencia_trecho_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_OCORRENCIA_TRECHO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@ocorrencia_trecho_id", domain.ocorrencia_trecho_id));
                        command.Parameters.Add(new SqlParameter("@nome", domain.nome));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.ocorrencia_trecho_id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OcorrenciaTrecho GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new OcorrenciaTrecho();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_OCORRENCIA_TRECHO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.ocorrencia_trecho_id = result["ocorrencia_trecho_id"] is DBNull ? 0 : Convert.ToInt32(result["ocorrencia_trecho_id"]);
                            retorno.nome = result["nome"] is DBNull ? string.Empty : result["nome"].ToString();
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

        public bool Delete(OcorrenciaTrecho model)
        {
            var oldValue = GetById(model.ocorrencia_trecho_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_OCORRENCIA_TRECHO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ocorrencia_trecho_id", model.ocorrencia_trecho_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                }
            }
            return true;
        }
    }
}