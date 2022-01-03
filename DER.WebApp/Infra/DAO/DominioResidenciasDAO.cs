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
    public class DominioResidenciasDAO : BaseDAO<DominioResidencias>
    {
        Logger logger;

        public DominioResidenciasDAO(DerContext context) : base(context)
        {
            logger = new Logger("DominioResidencias", context);
        }

        public List<DominioResidencias> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<DominioResidencias>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIORESIDENCIAS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new DominioResidencias();
                            retorno.res_id = result["res_id"] is DBNull ? 0 : Convert.ToInt32(result["res_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.res_codigo = result["res_codigo"] is DBNull ? string.Empty : result["res_codigo"].ToString();
                            retorno.mun_ibge_id = result["mun_ibge_id"] is DBNull ? 0 : Convert.ToInt32(result["mun_ibge_id"]);
                            retorno.res_descricao = result["res_descricao"] is DBNull ? string.Empty : result["res_descricao"].ToString();
                            retorno.res_endereco = result["res_endereco"] is DBNull ? string.Empty : result["res_endereco"].ToString();
                            retorno.res_bairro = result["res_bairro"] is DBNull ? string.Empty : result["res_bairro"].ToString();
                            retorno.res_cep = result["res_cep"] is DBNull ? string.Empty : result["res_cep"].ToString();
                            retorno.res_ddd_telefone = result["res_ddd_telefone"] is DBNull ? string.Empty : result["res_ddd_telefone"].ToString();
                            retorno.res_telefone = result["res_telefone"] is DBNull ? string.Empty : result["res_telefone"].ToString();
                            retorno.res_ddd_telefone_cco = result["res_ddd_telefone_cco"] is DBNull ? string.Empty : result["res_ddd_telefone_cco"].ToString();
                            retorno.res_telefone_cco = result["res_telefone_cco"] is DBNull ? string.Empty : result["res_telefone_cco"].ToString();
                            retorno.res_email = result["res_email"] is DBNull ? string.Empty : result["res_email"].ToString();
                            retorno.res_eng_responsavel = result["res_eng_responsavel"] is DBNull ? string.Empty : result["res_eng_responsavel"].ToString();
                            retorno.res_email_eng_responsavel = result["res_email_eng_responsavel"] is DBNull ? string.Empty : result["res_email_eng_responsavel"].ToString();
                            retorno.res_ddd_celular_eng = result["res_ddd_celular_eng"] is DBNull ? string.Empty : result["res_ddd_celular_eng"].ToString();
                            retorno.res_celular_eng = result["res_celular_eng"] is DBNull ? string.Empty : result["res_celular_eng"].ToString();

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

        public bool Inserir(DominioResidencias domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_DOMINIORESIDENCIAS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@res_id", domain.res_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@res_codigo", domain.res_codigo));
                        command.Parameters.Add(new SqlParameter("@mun_ibge_id", domain.mun_ibge_id));
                        command.Parameters.Add(new SqlParameter("@res_descricao", domain.res_descricao));
                        command.Parameters.Add(new SqlParameter("@res_endereco", domain.res_endereco));
                        command.Parameters.Add(new SqlParameter("@res_bairro", domain.res_bairro));
                        command.Parameters.Add(new SqlParameter("@res_cep", domain.res_cep));
                        command.Parameters.Add(new SqlParameter("@res_ddd_telefone", domain.res_ddd_telefone));
                        command.Parameters.Add(new SqlParameter("@res_telefone", domain.res_telefone));
                        command.Parameters.Add(new SqlParameter("@res_ddd_telefone_cco", domain.res_ddd_telefone_cco));
                        command.Parameters.Add(new SqlParameter("@res_telefone_cco", domain.res_telefone_cco));
                        command.Parameters.Add(new SqlParameter("@res_email", domain.res_email));
                        command.Parameters.Add(new SqlParameter("@res_eng_responsavel", domain.res_eng_responsavel));
                        command.Parameters.Add(new SqlParameter("@res_email_eng_responsavel", domain.res_email_eng_responsavel));
                        command.Parameters.Add(new SqlParameter("@res_ddd_celular_eng", domain.res_ddd_celular_eng));
                        command.Parameters.Add(new SqlParameter("@res_celular_eng", domain.res_celular_eng));
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

        public bool Update(DominioResidencias domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.res_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_DOMINIORESIDENCIAS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@res_id", domain.res_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@res_codigo", domain.res_codigo));
                        command.Parameters.Add(new SqlParameter("@mun_ibge_id", domain.mun_ibge_id));
                        command.Parameters.Add(new SqlParameter("@res_descricao", domain.res_descricao));
                        command.Parameters.Add(new SqlParameter("@res_endereco", domain.res_endereco));
                        command.Parameters.Add(new SqlParameter("@res_bairro", domain.res_bairro));
                        command.Parameters.Add(new SqlParameter("@res_cep", domain.res_cep));
                        command.Parameters.Add(new SqlParameter("@res_ddd_telefone", domain.res_ddd_telefone));
                        command.Parameters.Add(new SqlParameter("@res_telefone", domain.res_telefone));
                        command.Parameters.Add(new SqlParameter("@res_ddd_telefone_cco", domain.res_ddd_telefone_cco));
                        command.Parameters.Add(new SqlParameter("@res_telefone_cco", domain.res_telefone_cco));
                        command.Parameters.Add(new SqlParameter("@res_email", domain.res_email));
                        command.Parameters.Add(new SqlParameter("@res_eng_responsavel", domain.res_eng_responsavel));
                        command.Parameters.Add(new SqlParameter("@res_email_eng_responsavel", domain.res_email_eng_responsavel));
                        command.Parameters.Add(new SqlParameter("@res_ddd_celular_eng", domain.res_ddd_celular_eng));
                        command.Parameters.Add(new SqlParameter("@res_celular_eng", domain.res_celular_eng));
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

        public DominioResidencias GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new DominioResidencias();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIORESIDENCIAS_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.res_id = result["res_id"] is DBNull ? 0 : Convert.ToInt32(result["res_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.res_codigo = result["res_codigo"] is DBNull ? string.Empty : result["res_codigo"].ToString();
                            retorno.mun_ibge_id = result["mun_ibge_id"] is DBNull ? 0 : Convert.ToInt32(result["mun_ibge_id"]);
                            retorno.res_descricao = result["res_descricao"] is DBNull ? string.Empty : result["res_descricao"].ToString();
                            retorno.res_endereco = result["res_endereco"] is DBNull ? string.Empty : result["res_endereco"].ToString();
                            retorno.res_bairro = result["res_bairro"] is DBNull ? string.Empty : result["res_bairro"].ToString();
                            retorno.res_cep = result["res_cep"] is DBNull ? string.Empty : result["res_cep"].ToString();
                            retorno.res_ddd_telefone = result["res_ddd_telefone"] is DBNull ? string.Empty : result["res_ddd_telefone"].ToString();
                            retorno.res_telefone = result["res_telefone"] is DBNull ? string.Empty : result["res_telefone"].ToString();
                            retorno.res_ddd_telefone_cco = result["res_ddd_telefone_cco"] is DBNull ? string.Empty : result["res_ddd_telefone_cco"].ToString();
                            retorno.res_telefone_cco = result["res_telefone_cco"] is DBNull ? string.Empty : result["res_telefone_cco"].ToString();
                            retorno.res_email = result["res_email"] is DBNull ? string.Empty : result["res_email"].ToString();
                            retorno.res_eng_responsavel = result["res_eng_responsavel"] is DBNull ? string.Empty : result["res_eng_responsavel"].ToString();
                            retorno.res_email_eng_responsavel = result["res_email_eng_responsavel"] is DBNull ? string.Empty : result["res_email_eng_responsavel"].ToString();
                            retorno.res_ddd_celular_eng = result["res_ddd_celular_eng"] is DBNull ? string.Empty : result["res_ddd_celular_eng"].ToString();
                            retorno.res_celular_eng = result["res_celular_eng"] is DBNull ? string.Empty : result["res_celular_eng"].ToString();
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

        public bool Delete(DominioResidencias model)
        {
            var oldValue = GetById(model.res_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_DOMINIORESIDENCIAS", conn))
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