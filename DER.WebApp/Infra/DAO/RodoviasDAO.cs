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
    public class RodoviasDAO : BaseDAO<Rodovia>
    {
        Logger logger;

        public RodoviasDAO(DerContext context) : base(context)
        {
            logger = new Logger("Rodovia");
        }

        public List<Rodovia> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<Rodovia>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_RODOVIA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new Rodovia();
                            retorno.rodovia_id = result["rodovia_id"] is DBNull ? 0 : Convert.ToInt32(result["rodovia_id"]);
                            retorno.rod_codigo = result["rod_codigo"] is DBNull ? string.Empty : result["rod_codigo"].ToString();
                            retorno.Nome = result["Nome"] is DBNull ? string.Empty : result["Nome"].ToString();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.jur_id_origem = result["jur_id_origem"] is DBNull ? 0 : Convert.ToInt32(result["jur_id_origem"]);
                            retorno.rte_id = result["rte_id"] is DBNull ? 0 : Convert.ToInt32(result["rte_id"]);
                            retorno.ror_id = result["ror_id"] is DBNull ? 0 : Convert.ToInt32(result["ror_id"]);
                            retorno.rod_km_inicial = result["rod_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["rod_km_inicial"]);
                            retorno.rod_km_final = result["rod_km_final"] is DBNull ? 0 : Convert.ToDouble(result["rod_km_final"]);
                            retorno.rod_km_extensao = result["rod_km_extensao"] is DBNull ? 0 : Convert.ToDouble(result["rod_km_extensao"]);

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

        public bool Inserir(Rodovia domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_RODOVIA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rodovia_id", domain.rodovia_id));
                        command.Parameters.Add(new SqlParameter("@rod_codigo", domain.rod_codigo));
                        command.Parameters.Add(new SqlParameter("@Nome", domain.Nome));
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@jur_id_origem", domain.jur_id_origem));
                        command.Parameters.Add(new SqlParameter("@rte_id", domain.rte_id));
                        command.Parameters.Add(new SqlParameter("@ror_id", domain.ror_id));
                        command.Parameters.Add(new SqlParameter("@rod_km_inicial", domain.rod_km_inicial));
                        command.Parameters.Add(new SqlParameter("@rod_km_final", domain.rod_km_final));
                        command.Parameters.Add(new SqlParameter("@rod_km_extensao", domain.rod_km_extensao));
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

        public bool Update(Rodovia domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_RODOVIA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rodovia_id", domain.rodovia_id));
                        command.Parameters.Add(new SqlParameter("@rod_codigo", domain.rod_codigo));
                        command.Parameters.Add(new SqlParameter("@Nome", domain.Nome));
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@jur_id_origem", domain.jur_id_origem));
                        command.Parameters.Add(new SqlParameter("@rte_id", domain.rte_id));
                        command.Parameters.Add(new SqlParameter("@ror_id", domain.ror_id));
                        command.Parameters.Add(new SqlParameter("@rod_km_inicial", domain.rod_km_inicial));
                        command.Parameters.Add(new SqlParameter("@rod_km_final", domain.rod_km_final));
                        command.Parameters.Add(new SqlParameter("@rod_km_extensao", domain.rod_km_extensao));
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

        public bool Delete(Rodovia model)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_RODOVIA", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@rodovia_id", model.rodovia_id));
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