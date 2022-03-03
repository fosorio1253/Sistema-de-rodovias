using DER.WebApp.Domain.Models;
using DER.WebApp.Helper;
using DER.WebApp.Infra.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DER.WebApp.Infra.DAO
{
    public class TipoDocumentoInteressadoDAO : BaseDAO<TipoDocumentoInteressado>
    {
        Logger logger;

        public TipoDocumentoInteressadoDAO(DerContext context) : base(context)
        {
            logger = new Logger("TipoDocumentoInteressado");
        }

        public List<TipoDocumentoInteressado> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<TipoDocumentoInteressado>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TIPO_DOCUMENTO_INTERESSADO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new TipoDocumentoInteressado();
                            retorno.tipo_documento_interessado_id = result["tipo_documento_interessado_id"] is DBNull ? 0 : Convert.ToInt32(result["tipo_documento_interessado_id"]);
                            retorno.descricao = result["descricao"] is DBNull ? string.Empty : result["descricao"].ToString();
                            retorno.tipo_interessado = result["tipo_interessado"] is DBNull ? 0 : Convert.ToInt32(result["tipo_interessado"]);

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

        public bool Inserir(TipoDocumentoInteressado domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_TIPO_DOCUMENTO_INTERESSADO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@tipo_documento_interessado_id", domain.tipo_documento_interessado_id));
                        command.Parameters.Add(new SqlParameter("@descricao", domain.descricao));
                        command.Parameters.Add(new SqlParameter("@tipo_interessado", domain.tipo_interessado));
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

        public bool Update(TipoDocumentoInteressado domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_TIPO_DOCUMENTO_INTERESSADO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@tipo_documento_interessado_id", domain.tipo_documento_interessado_id));
                        command.Parameters.Add(new SqlParameter("@descricao", domain.descricao));
                        command.Parameters.Add(new SqlParameter("@tipo_interessado", domain.tipo_interessado));
                        var result = command.ExecuteNonQuery();
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

        public bool Delete(TipoDocumentoInteressado model)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_TIPO_DOCUMENTO_INTERESSADO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@tipo_documento_interessado_id", model.tipo_documento_interessado_id));
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