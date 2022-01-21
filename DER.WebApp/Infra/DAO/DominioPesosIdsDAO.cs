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
    public class DominioPesosIdsDAO : BaseDAO<DominioPesosIds>
    {
        Logger logger;

        public DominioPesosIdsDAO(DerContext context) : base(context)
        {
            logger = new Logger("DominioPesosIds");
        }

        public List<DominioPesosIds> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<DominioPesosIds>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOPESOSIDS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new DominioPesosIds();
                            retorno.dominio_pesos_id = result["dominio_pesos_id"] is DBNull ? 0 : Convert.ToInt32(result["dominio_pesos_id"]);
                            retorno.pes_anomalia = result["pes_anomalia"] is DBNull ? string.Empty : result["pes_anomalia"].ToString();
                            retorno.pes_severidade = result["pes_severidade"] is DBNull ? string.Empty : result["pes_severidade"].ToString();
                            retorno.pes_nota = result["pes_nota"] is DBNull ? 0 : Convert.ToDouble(result["pes_nota"]);

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

        public bool Inserir(DominioPesosIds domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_DOMINIOPESOSIDS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@dominio_pesos_id", domain.dominio_pesos_id));
                        command.Parameters.Add(new SqlParameter("@pes_anomalia", domain.pes_anomalia));
                        command.Parameters.Add(new SqlParameter("@pes_severidade", domain.pes_severidade));
                        command.Parameters.Add(new SqlParameter("@pes_nota", domain.pes_nota));
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

        public bool Update(DominioPesosIds domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.dominio_pesos_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_DOMINIOPESOSIDS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@dominio_pesos_id", domain.dominio_pesos_id));
                        command.Parameters.Add(new SqlParameter("@pes_anomalia", domain.pes_anomalia));
                        command.Parameters.Add(new SqlParameter("@pes_severidade", domain.pes_severidade));
                        command.Parameters.Add(new SqlParameter("@pes_nota", domain.pes_nota));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.dominio_pesos_id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DominioPesosIds GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new DominioPesosIds();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOPESOSIDS_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.dominio_pesos_id = result["dominio_pesos_id"] is DBNull ? 0 : Convert.ToInt32(result["dominio_pesos_id"]);
                            retorno.pes_anomalia = result["pes_anomalia"] is DBNull ? string.Empty : result["pes_anomalia"].ToString();
                            retorno.pes_severidade = result["pes_severidade"] is DBNull ? string.Empty : result["pes_severidade"].ToString();
                            retorno.pes_nota = result["pes_nota"] is DBNull ? 0 : Convert.ToDouble(result["pes_nota"]);
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

        public bool Delete(DominioPesosIds model)
        {
            var oldValue = GetById(model.dominio_pesos_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_DOMINIOPESOSIDS", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@dominio_pesos_id", model.dominio_pesos_id));
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