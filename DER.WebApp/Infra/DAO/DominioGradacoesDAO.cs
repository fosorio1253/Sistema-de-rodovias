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
    public class DominioGradacoesDAO : BaseDAO<DominioGradacoes>
    {
        Logger logger;

        public DominioGradacoesDAO(DerContext context) : base(context)
        {
            logger = new Logger("DominioGradacoes", context);
        }

        public List<DominioGradacoes> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<DominioGradacoes>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOGRADACOES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new DominioGradacoes();
                            retorno.gra_id = result["gra_id"] is DBNull ? 0 : Convert.ToInt32(result["gra_id"]);
                            retorno.gra_objeto = result["gra_objeto"] is DBNull ? string.Empty : result["gra_objeto"].ToString();
                            retorno.gra_descricao = result["gra_descricao"] is DBNull ? string.Empty : result["gra_descricao"].ToString();

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

        public bool Inserir(DominioGradacoes domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_DOMINIOGRADACOES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@gra_id", domain.gra_id));
                        command.Parameters.Add(new SqlParameter("@gra_objeto", domain.gra_objeto));
                        command.Parameters.Add(new SqlParameter("@gra_descricao", domain.gra_descricao));
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

        public bool Update(DominioGradacoes domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.gra_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_DOMINIOGRADACOES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@gra_id", domain.gra_id));
                        command.Parameters.Add(new SqlParameter("@gra_objeto", domain.gra_objeto));
                        command.Parameters.Add(new SqlParameter("@gra_descricao", domain.gra_descricao));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.gra_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.gra_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DominioGradacoes GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new DominioGradacoes();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOGRADACOES_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.gra_id = result["gra_id"] is DBNull ? 0 : Convert.ToInt32(result["gra_id"]);
                            retorno.gra_objeto = result["gra_objeto"] is DBNull ? string.Empty : result["gra_objeto"].ToString();
                            retorno.gra_descricao = result["gra_descricao"] is DBNull ? string.Empty : result["gra_descricao"].ToString();
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

        public bool Delete(DominioGradacoes model)
        {
            var oldValue = GetById(model.gra_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_DOMINIOGRADACOES", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@gra_id", model.gra_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.gra_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}