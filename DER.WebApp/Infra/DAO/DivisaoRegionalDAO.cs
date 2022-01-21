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
    public class DivisaoRegionalDAO : BaseDAO<DivisaoRegional>
    {
        Logger logger;

        public DivisaoRegionalDAO(DerContext context) : base(context)
        {
            logger = new Logger("DivisaoRegional");
        }

        public List<DivisaoRegional> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<DivisaoRegional>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DIVISAOREGIONAL", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new DivisaoRegional();
                            retorno.divisao_regional_id = result["divisao_regional_id"] is DBNull ? 0 : Convert.ToInt32(result["divisao_regional_id"]);
                            retorno.sigla = result["sigla"] is DBNull ? string.Empty : result["sigla"].ToString();
                            retorno.descricao = result["descricao"] is DBNull ? string.Empty : result["descricao"].ToString();
                            retorno.fator_regional = result["fator_regional"] is DBNull ? 0 : Convert.ToDouble(result["fator_regional"]);

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

        public bool Inserir(DivisaoRegional domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_DIVISAOREGIONAL", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@divisao_regional_id", domain.divisao_regional_id));
                        command.Parameters.Add(new SqlParameter("@sigla", domain.sigla));
                        command.Parameters.Add(new SqlParameter("@descri��o", domain.descricao));
                        command.Parameters.Add(new SqlParameter("@fator_regional", domain.fator_regional));
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

        public bool Update(DivisaoRegional domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.divisao_regional_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_DIVISAOREGIONAL", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@divisao_regional_id", domain.divisao_regional_id));
                        command.Parameters.Add(new SqlParameter("@sigla", domain.sigla));
                        command.Parameters.Add(new SqlParameter("@descri��o", domain.descricao));
                        command.Parameters.Add(new SqlParameter("@fator_regional", domain.fator_regional));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.divisao_regional_id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DivisaoRegional GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new DivisaoRegional();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DIVISAOREGIONAL_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.divisao_regional_id = result["divisao_regional_id"] is DBNull ? 0 : Convert.ToInt32(result["divisao_regional_id"]);
                            retorno.sigla = result["sigla"] is DBNull ? string.Empty : result["sigla"].ToString();
                            retorno.descricao = result["descri��o"] is DBNull ? string.Empty : result["descricao"].ToString();
                            retorno.fator_regional = result["fator_regional"] is DBNull ? 0 : Convert.ToDouble(result["fator_regional"]);
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

        public bool Delete(DivisaoRegional model)
        {
            var oldValue = GetById(model.divisao_regional_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_DIVISAOREGIONAL", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@divisao_regional_id", model.divisao_regional_id));
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