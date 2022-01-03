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
    public class DominioRevestimentosDAO : BaseDAO<DominioRevestimentos>
    {
        Logger logger;

        public DominioRevestimentosDAO(DerContext context) : base(context)
        {
            logger = new Logger("DominioRevestimentos", context);
        }

        public List<DominioRevestimentos> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<DominioRevestimentos>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOREVESTIMENTOS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new DominioRevestimentos();
                            retorno.rev_id = result["rev_id"] is DBNull ? 0 : Convert.ToInt32(result["rev_id"]);
                            retorno.rev_objeto = result["rev_objeto"] is DBNull ? string.Empty : result["rev_objeto"].ToString();
                            retorno.rev_sigla = result["rev_sigla"] is DBNull ? string.Empty : result["rev_sigla"].ToString();
                            retorno.rev_descricao = result["rev_descricao"] is DBNull ? string.Empty : result["rev_descricao"].ToString();

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

        public bool Inserir(DominioRevestimentos domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_DOMINIOREVESTIMENTOS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rev_id", domain.rev_id));
                        command.Parameters.Add(new SqlParameter("@rev_objeto", domain.rev_objeto));
                        command.Parameters.Add(new SqlParameter("@rev_sigla", domain.rev_sigla));
                        command.Parameters.Add(new SqlParameter("@rev_descricao", domain.rev_descricao));
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

        public bool Update(DominioRevestimentos domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rev_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_DOMINIOREVESTIMENTOS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rev_id", domain.rev_id));
                        command.Parameters.Add(new SqlParameter("@rev_objeto", domain.rev_objeto));
                        command.Parameters.Add(new SqlParameter("@rev_sigla", domain.rev_sigla));
                        command.Parameters.Add(new SqlParameter("@rev_descricao", domain.rev_descricao));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.rev_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.rev_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DominioRevestimentos GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new DominioRevestimentos();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOREVESTIMENTOS_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rev_id = result["rev_id"] is DBNull ? 0 : Convert.ToInt32(result["rev_id"]);
                            retorno.rev_objeto = result["rev_objeto"] is DBNull ? string.Empty : result["rev_objeto"].ToString();
                            retorno.rev_sigla = result["rev_sigla"] is DBNull ? string.Empty : result["rev_sigla"].ToString();
                            retorno.rev_descricao = result["rev_descricao"] is DBNull ? string.Empty : result["rev_descricao"].ToString();
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

        public bool Delete(DominioRevestimentos model)
        {
            var oldValue = GetById(model.rev_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_DOMINIOREVESTIMENTOS", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@rev_id", model.rev_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.rev_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}