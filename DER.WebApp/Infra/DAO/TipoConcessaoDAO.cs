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
    public class TipoConcessaoDAO : BaseDAO<TipoConcessao>
    {
        Logger logger;

        public TipoConcessaoDAO(DerContext context) : base(context)
        {
            logger = new Logger("TipoConcessao", context);
        }

        public List<TipoConcessao> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<TipoConcessao>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TIPOCONCESSAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new TipoConcessao();
                            retorno.tipo_concessao_id = result["tipo_concessao_id"] is DBNull ? 0 : Convert.ToInt32(result["tipo_concessao_id"]);
                            retorno.Descricao = result["Descricao"] is DBNull ? string.Empty : result["Descricao").ToString();
                            retorno.Documentos = result["Documentos"] is DBNull ? string.Empty : result["Documentos").ToString();
                            retorno.profundidade_minima = result["profundidade_minima"] is DBNull ? 0 : Convert.ToDouble(result["profundidade_minima"]);
                            retorno. = result[""] is DBNull ? 0 : Convert.ToDouble(result[""]);

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

        public bool Inserir(TipoConcessao domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_TIPOCONCESSAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@tipo_concessao_id", domain.tipo_concessao_id));
                        command.Parameters.Add(new SqlParameter("@Descricao", domain.Descricao));
                        command.Parameters.Add(new SqlParameter("@Documentos", domain.Documentos));
                        command.Parameters.Add(new SqlParameter("@profundidade_minima", domain.profundidade_minima));
                        command.Parameters.Add(new SqlParameter("@", domain.));
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

        public bool Update(TipoConcessao domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.tipo_concessao_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_TIPOCONCESSAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@tipo_concessao_id", domain.tipo_concessao_id));
                        command.Parameters.Add(new SqlParameter("@Descricao", domain.Descricao));
                        command.Parameters.Add(new SqlParameter("@Documentos", domain.Documentos));
                        command.Parameters.Add(new SqlParameter("@profundidade_minima", domain.profundidade_minima));
                        command.Parameters.Add(new SqlParameter("@", domain.));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.tipo_concessao_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.tipo_concessao_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TipoConcessao GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new TipoConcessao();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TIPOCONCESSAO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.tipo_concessao_id = result["tipo_concessao_id"] is DBNull ? 0 : Convert.ToInt32(result["tipo_concessao_id"]);
                            retorno.Descricao = result["Descricao"] is DBNull ? string.Empty : result["Descricao").ToString();
                            retorno.Documentos = result["Documentos"] is DBNull ? string.Empty : result["Documentos").ToString();
                            retorno.profundidade_minima = result["profundidade_minima"] is DBNull ? 0 : Convert.ToDouble(result["profundidade_minima"]);
                            retorno. = result[""] is DBNull ? 0 : Convert.ToDouble(result[""]);
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

        public bool Delete(TipoConcessao model)
        {
            var oldValue = GetById(model.tipo_concessao_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_TIPOCONCESSAO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@tipo_concessao_id", model.tipo_concessao_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.tipo_concessao_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}