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
    public class DominioConservadoresDAO : BaseDAO<DominioConservadores>
    {
        Logger logger;

        public DominioConservadoresDAO(DerContext context) : base(context)
        {
            logger = new Logger("DominioConservadores", context);
        }

        public List<DominioConservadores> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<DominioConservadores>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOCONSERVADORES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new DominioConservadores();
                            retorno.res_id = result["res_id"] is DBNull ? 0 : Convert.ToInt32(result["res_id"]);
                            retorno.res_codigo = result["res_codigo"] is DBNull ? string.Empty : result["res_codigo"].ToString();

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

        public bool Inserir(DominioConservadores domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_DOMINIOCONSERVADORES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@res_id", domain.res_id));
                        command.Parameters.Add(new SqlParameter("@res_codigo", domain.res_codigo));
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

        public bool Update(DominioConservadores domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.res_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_DOMINIOCONSERVADORES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@res_id", domain.res_id));
                        command.Parameters.Add(new SqlParameter("@res_codigo", domain.res_codigo));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.res_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.res_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DominioConservadores GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new DominioConservadores();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOCONSERVADORES_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.res_id = result["res_id"] is DBNull ? 0 : Convert.ToInt32(result["res_id"]);
                            retorno.res_codigo = result["res_codigo"] is DBNull ? string.Empty : result["res_codigo"].ToString();
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

        public bool Delete(DominioConservadores model)
        {
            var oldValue = GetById(model.res_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_DOMINIOCONSERVADORES", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@res_id", model.res_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.res_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}