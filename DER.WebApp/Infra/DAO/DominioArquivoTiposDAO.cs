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
    public class DominioArquivoTiposDAO : BaseDAO<DominioArquivoTipos>
    {
        Logger logger;

        public DominioArquivoTiposDAO(DerContext context) : base(context)
        {
            logger = new Logger("DominioArquivoTipos", context);
        }

        public List<DominioArquivoTipos> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<DominioArquivoTipos>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOARQUIVOTIPOS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new DominioArquivoTipos();
                            retorno.arq_id = result["arq_id"] is DBNull ? 0 : Convert.ToInt32(result["arq_id"]);
                            retorno.arq_codigo = result["arq_codigo"] is DBNull ? string.Empty : result["arq_codigo"].ToString();
                            retorno.arq_descricao = result["arq_descricao"] is DBNull ? string.Empty : result["arq_descricao"].ToString();

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

        public bool Inserir(DominioArquivoTipos domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_DOMINIOARQUIVOTIPOS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@arq_id", domain.arq_id));
                        command.Parameters.Add(new SqlParameter("@arq_codigo", domain.arq_codigo));
                        command.Parameters.Add(new SqlParameter("@arq_descricao", domain.arq_descricao));
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

        public bool Update(DominioArquivoTipos domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.arq_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_DOMINIOARQUIVOTIPOS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@arq_id", domain.arq_id));
                        command.Parameters.Add(new SqlParameter("@arq_codigo", domain.arq_codigo));
                        command.Parameters.Add(new SqlParameter("@arq_descricao", domain.arq_descricao));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.arq_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.arq_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DominioArquivoTipos GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new DominioArquivoTipos();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOARQUIVOTIPOS_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.arq_id = result["arq_id"] is DBNull ? 0 : Convert.ToInt32(result["arq_id"]);
                            retorno.arq_codigo = result["arq_codigo"] is DBNull ? string.Empty : result["arq_codigo"].ToString();
                            retorno.arq_descricao = result["arq_descricao"] is DBNull ? string.Empty : result["arq_descricao"].ToString();
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

        public bool Delete(DominioArquivoTipos model)
        {
            var oldValue = GetById(model.arq_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_DOMINIOARQUIVOTIPOS", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@arq_id", model.arq_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.arq_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}