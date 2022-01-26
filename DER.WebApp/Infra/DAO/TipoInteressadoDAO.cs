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
    public class TipoInteressadoDAO : BaseDAO<TipoInteressado>
    {
        Logger logger;

        public TipoInteressadoDAO(DerContext context) : base(context)
        {
            logger = new Logger("TipoInteressado");
        }

        public List<TipoInteressado> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<TipoInteressado>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TIPO_INTERESSADO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new TipoInteressado();
                            retorno.tipo_interessado_id = result["tipo_interessado_id"] is DBNull ? 0 : Convert.ToInt32(result["tipo_interessado_id"]);
                            retorno.descricao = result["descricao"] is DBNull ? string.Empty : result["descricao"].ToString();
                            retorno.fator_interessado = result["fator_interessado"] is DBNull ? 0 : Convert.ToInt32(result["fator_interessado"]);

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

        public bool Inserir(TipoInteressado domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_TIPO_INTERESSADO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@tipo_interessado_id", domain.tipo_interessado_id));
                        command.Parameters.Add(new SqlParameter("@descricao", domain.descricao));
                        command.Parameters.Add(new SqlParameter("@fator_interessado", domain.fator_interessado));
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

        public bool Update(TipoInteressado domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.tipo_interessado_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_TIPO_INTERESSADO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@tipo_interessado_id", domain.tipo_interessado_id));
                        command.Parameters.Add(new SqlParameter("@descricao", domain.descricao));
                        command.Parameters.Add(new SqlParameter("@fator_interessado", domain.fator_interessado));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.tipo_interessado_id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TipoInteressado GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new TipoInteressado();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TIPO_INTERESSADO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.tipo_interessado_id = result["tipo_interessado_id"] is DBNull ? 0 : Convert.ToInt32(result["tipo_interessado_id"]);
                            retorno.descricao = result["descricao"] is DBNull ? string.Empty : result["descricao"].ToString();
                            retorno.fator_interessado = result["fator_interessado"] is DBNull ? 0 : Convert.ToInt32(result["fator_interessado"]);
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

        public bool Delete(TipoInteressado model)
        {
            var oldValue = GetById(model.tipo_interessado_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_TIPO_INTERESSADO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@tipo_interessado_id", model.tipo_interessado_id));
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