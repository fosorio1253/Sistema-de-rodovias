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
    public class ResidenciaConservacaoDAO : BaseDAO<ResidenciaConservacao>
    {
        Logger logger;

        public ResidenciaConservacaoDAO(DerContext context) : base(context)
        {
            logger = new Logger("ResidenciaConservacao");
        }

        public List<ResidenciaConservacao> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<ResidenciaConservacao>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_RESIDENCIA_CONSERVACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new ResidenciaConservacao();
                            retorno.residencia_conservacao_id = result["residencia_conservacao_id"] is DBNull ? 0 : Convert.ToInt32(result["residencia_conservacao_id"]);
                            retorno.Nome = result["Nome"] is DBNull ? string.Empty : result["Nome"].ToString();
                            retorno.Sigla = result["Sigla"] is DBNull ? string.Empty : result["Sigla"].ToString();

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

        public bool Inserir(ResidenciaConservacao domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_RESIDENCIA_CONSERVACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@residencia_conservacao_id", domain.residencia_conservacao_id));
                        command.Parameters.Add(new SqlParameter("@Nome", domain.Nome));
                        command.Parameters.Add(new SqlParameter("@Sigla", domain.Sigla));
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

        public bool Update(ResidenciaConservacao domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_RESIDENCIA_CONSERVACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@residencia_conservacao_id", domain.residencia_conservacao_id));
                        command.Parameters.Add(new SqlParameter("@Nome", domain.Nome));
                        command.Parameters.Add(new SqlParameter("@Sigla", domain.Sigla));
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

        public bool Delete(ResidenciaConservacao model)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_RESIDENCIA_CONSERVACAO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@residencia_conservacao_id", model.residencia_conservacao_id));
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