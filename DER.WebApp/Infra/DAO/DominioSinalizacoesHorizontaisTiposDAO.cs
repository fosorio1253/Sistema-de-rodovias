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
    public class DominioSinalizacoesHorizontaisTiposDAO : BaseDAO<DominioSinalizacoesHorizontaisTipos>
    {
        Logger logger;

        public DominioSinalizacoesHorizontaisTiposDAO(DerContext context) : base(context)
        {
            logger = new Logger("DominioSinalizacoesHorizontaisTipos");
        }

        public List<DominioSinalizacoesHorizontaisTipos> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<DominioSinalizacoesHorizontaisTipos>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOSINALIZACOESHORIZONTAISTIPOS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new DominioSinalizacoesHorizontaisTipos();
                            retorno.sht_id = result["sht_id"] is DBNull ? 0 : Convert.ToInt32(result["sht_id"]);
                            retorno.sht_tipo = result["sht_tipo"] is DBNull ? string.Empty : result["sht_tipo"].ToString();
                            retorno.sht_descricao = result["sht_descricao"] is DBNull ? string.Empty : result["sht_descricao"].ToString();

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

        public bool Inserir(DominioSinalizacoesHorizontaisTipos domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_DOMINIOSINALIZACOESHORIZONTAISTIPOS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@sht_id", domain.sht_id));
                        command.Parameters.Add(new SqlParameter("@sht_tipo", domain.sht_tipo));
                        command.Parameters.Add(new SqlParameter("@sht_descricao", domain.sht_descricao));
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

        public bool Update(DominioSinalizacoesHorizontaisTipos domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.sht_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_DOMINIOSINALIZACOESHORIZONTAISTIPOS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@sht_id", domain.sht_id));
                        command.Parameters.Add(new SqlParameter("@sht_tipo", domain.sht_tipo));
                        command.Parameters.Add(new SqlParameter("@sht_descricao", domain.sht_descricao));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.sht_id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DominioSinalizacoesHorizontaisTipos GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new DominioSinalizacoesHorizontaisTipos();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOSINALIZACOESHORIZONTAISTIPOS_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.sht_id = result["sht_id"] is DBNull ? 0 : Convert.ToInt32(result["sht_id"]);
                            retorno.sht_tipo = result["sht_tipo"] is DBNull ? string.Empty : result["sht_tipo"].ToString();
                            retorno.sht_descricao = result["sht_descricao"] is DBNull ? string.Empty : result["sht_descricao"].ToString();
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

        public bool Delete(DominioSinalizacoesHorizontaisTipos model)
        {
            var oldValue = GetById(model.sht_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_DOMINIOSINALIZACOESHORIZONTAISTIPOS", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@sht_id", model.sht_id));
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