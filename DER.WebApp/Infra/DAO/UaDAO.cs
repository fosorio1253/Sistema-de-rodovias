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
    public class UaDAO : BaseDAO<Ua>
    {
        Logger logger;

        public UaDAO(DerContext context) : base(context)
        {
            logger = new Logger("Ua", context);
        }

        public List<Ua> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<Ua>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_UA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new Ua();
                            retorno.ua_id = result["ua_id"] is DBNull ? 0 : Convert.ToInt32(result["ua_id"]);
                            retorno.sigla = result["sigla"] is DBNull ? string.Empty : result["sigla"].ToString();
                            retorno.nome_ua = result["nome_ua"] is DBNull ? string.Empty : result["nome_ua"].ToString();
                            retorno.unidade = result["unidade"] is DBNull ? string.Empty : result["unidade"].ToString();
                            retorno.regional = result["regional"] is DBNull ? string.Empty : result["regional"].ToString();

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

        public bool Inserir(Ua domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_UA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@ua_id", domain.ua_id));
                        command.Parameters.Add(new SqlParameter("@sigla", domain.sigla));
                        command.Parameters.Add(new SqlParameter("@nome_ua", domain.nome_ua));
                        command.Parameters.Add(new SqlParameter("@unidade", domain.unidade));
                        command.Parameters.Add(new SqlParameter("@regional", domain.regional));
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

        public bool Update(Ua domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.ua_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_UA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@ua_id", domain.ua_id));
                        command.Parameters.Add(new SqlParameter("@sigla", domain.sigla));
                        command.Parameters.Add(new SqlParameter("@nome_ua", domain.nome_ua));
                        command.Parameters.Add(new SqlParameter("@unidade", domain.unidade));
                        command.Parameters.Add(new SqlParameter("@regional", domain.regional));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.ua_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.ua_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Ua GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new Ua();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_UA_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.ua_id = result["ua_id"] is DBNull ? 0 : Convert.ToInt32(result["ua_id"]);
                            retorno.sigla = result["sigla"] is DBNull ? string.Empty : result["sigla"].ToString();
                            retorno.nome_ua = result["nome_ua"] is DBNull ? string.Empty : result["nome_ua"].ToString();
                            retorno.unidade = result["unidade"] is DBNull ? string.Empty : result["unidade"].ToString();
                            retorno.regional = result["regional"] is DBNull ? string.Empty : result["regional"].ToString();
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

        public bool Delete(Ua model)
        {
            var oldValue = GetById(model.ua_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_UA", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ua_id", model.ua_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.ua_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}