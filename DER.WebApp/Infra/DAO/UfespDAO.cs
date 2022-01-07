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
    public class UfespDAO : BaseDAO<Ufesp>
    {
        Logger logger;

        public UfespDAO(DerContext context) : base(context)
        {
            logger = new Logger("Ufesp", context);
        }

        public List<Ufesp> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<Ufesp>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_UFESP", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new Ufesp();
                            retorno.ufesp_id = result["ufesp_id"] is DBNull ? 0 : Convert.ToInt32(result["ufesp_id"]);
                            retorno.mes_ano = result["mes_ano"] is DBNull ? dtnull : Convert.ToDateTime(result["mes_ano"]);
                            retorno.valor = result["valor"] is DBNull ? 0 : Convert.ToDouble(result["valor"]);
                            retorno.p_calculado = result["p_calculado"] is DBNull ? 0 : Convert.ToDouble(result["p_calculado"]);

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

        public bool Inserir(Ufesp domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_UFESP", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@ufesp_id", domain.ufesp_id));
                        command.Parameters.Add(new SqlParameter("@mes_ano", domain.mes_ano));
                        command.Parameters.Add(new SqlParameter("@valor", domain.valor));
                        command.Parameters.Add(new SqlParameter("@p_calculado", domain.p_calculado));
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

        public bool Update(Ufesp domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.ufesp_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_UFESP", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@ufesp_id", domain.ufesp_id));
                        command.Parameters.Add(new SqlParameter("@mes_ano", domain.mes_ano));
                        command.Parameters.Add(new SqlParameter("@valor", domain.valor));
                        command.Parameters.Add(new SqlParameter("@p_calculado", domain.p_calculado));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.ufesp_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.ufesp_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Ufesp GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new Ufesp();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_UFESP_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.ufesp_id = result["ufesp_id"] is DBNull ? 0 : Convert.ToInt32(result["ufesp_id"]);
                            retorno.mes_ano = result["mes_ano"] is DBNull ? dtnull : Convert.ToDateTime(result["mes_ano"]);
                            retorno.valor = result["valor"] is DBNull ? 0 : Convert.ToDouble(result["valor"]);
                            retorno.p_calculado = result["p_calculado"] is DBNull ? 0 : Convert.ToDouble(result["p_calculado"]);
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

        public bool Delete(Ufesp model)
        {
            var oldValue = GetById(model.ufesp_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_UFESP", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ufesp_id", model.ufesp_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.ufesp_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}