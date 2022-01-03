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
            logger = new Logger("TipoDocumentoInteressado", context);
        }

        public List<TipoDocumentoInteressado> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<TipoDocumentoInteressado>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TIPODOCUMENTOINTERESSADO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new TipoDocumentoInteressado();
                            retorno.tipo_documento_interessado_id = result["tipo_documento_interessado_id"] is DBNull ? 0 : Convert.ToInt32(result["tipo_documento_interessado_id"]);
                            retorno.descricao = result["descri��o"] is DBNull ? string.Empty : result["descri��o"].ToString();
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
                    using (var command = new SqlCommand("STP_INS_TIPODOCUMENTOINTERESSADO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@tipo_documento_interessado_id", domain.tipo_documento_interessado_id));
                        command.Parameters.Add(new SqlParameter("@descri��o", domain.descricao));
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
            var oldValue = GetById(domain.tipo_documento_interessado_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_TIPODOCUMENTOINTERESSADO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@tipo_documento_interessado_id", domain.tipo_documento_interessado_id));
                        command.Parameters.Add(new SqlParameter("@descri��o", domain.descricao));
                        command.Parameters.Add(new SqlParameter("@tipo_interessado", domain.tipo_interessado));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.tipo_documento_interessado_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.tipo_documento_interessado_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TipoDocumentoInteressado GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new TipoDocumentoInteressado();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TIPODOCUMENTOINTERESSADO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.tipo_documento_interessado_id = result["tipo_documento_interessado_id"] is DBNull ? 0 : Convert.ToInt32(result["tipo_documento_interessado_id"]);
                            retorno.descricao = result["descri��o"] is DBNull ? string.Empty : result["descricao"].ToString();
                            retorno.tipo_interessado = result["tipo_interessado"] is DBNull ? 0 : Convert.ToInt32(result["tipo_interessado"]);
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

        public bool Delete(TipoDocumentoInteressado model)
        {
            var oldValue = GetById(model.tipo_documento_interessado_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_TIPODOCUMENTOINTERESSADO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@tipo_documento_interessado_id", model.tipo_documento_interessado_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.tipo_documento_interessado_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}