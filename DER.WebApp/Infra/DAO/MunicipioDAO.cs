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
    public class MunicipioDAO : BaseDAO<Municipio>
    {
        Logger logger;

        public MunicipioDAO(DerContext context) : base(context)
        {
            logger = new Logger("Municipio", context);
        }

        public List<Municipio> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<Municipio>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_MUNICIPIO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new Municipio();
                            retorno.municipio_id = result["municipio_id"] is DBNull ? 0 : Convert.ToInt32(result["municipio_id"]);
                            retorno.codigo = result["codigo"] is DBNull ? string.Empty : result["codigo").ToString();
                            retorno.municipio = result["municipio"] is DBNull ? string.Empty : result["municipio").ToString();
                            retorno.regional = result["regional"] is DBNull ? string.Empty : result["regional").ToString();

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

        public bool Inserir(Municipio domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_MUNICIPIO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@municipio_id", domain.municipio_id));
                        command.Parameters.Add(new SqlParameter("@codigo", domain.codigo));
                        command.Parameters.Add(new SqlParameter("@municipio", domain.municipio));
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

        public bool Update(Municipio domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.municipio_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_MUNICIPIO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@municipio_id", domain.municipio_id));
                        command.Parameters.Add(new SqlParameter("@codigo", domain.codigo));
                        command.Parameters.Add(new SqlParameter("@municipio", domain.municipio));
                        command.Parameters.Add(new SqlParameter("@regional", domain.regional));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.municipio_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.municipio_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Municipio GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new Municipio();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_MUNICIPIO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.municipio_id = result["municipio_id"] is DBNull ? 0 : Convert.ToInt32(result["municipio_id"]);
                            retorno.codigo = result["codigo"] is DBNull ? string.Empty : result["codigo"].ToString();
                            retorno.municipio = result["municipio"] is DBNull ? string.Empty : result["municipio"].ToString();
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

        public bool Delete(Municipio model)
        {
            var oldValue = GetById(model.municipio_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_MUNICIPIO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@municipio_id", model.municipio_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.municipio_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}