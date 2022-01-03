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
    public class DominioRegionaisDAO : BaseDAO<DominioRegionais>
    {
        Logger logger;

        public DominioRegionaisDAO(DerContext context) : base(context)
        {
            logger = new Logger("DominioRegionais", context);
        }

        public List<DominioRegionais> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<DominioRegionais>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOREGIONAIS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new DominioRegionais();
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.reg_codigo = result["reg_codigo"] is DBNull ? string.Empty : result["reg_codigo"].ToString();
                            retorno.mun_ibge_id = result["mun_ibge_id"] is DBNull ? 0 : Convert.ToInt32(result["mun_ibge_id"]);
                            retorno.reg_descricao = result["reg_descricao"] is DBNull ? string.Empty : result["reg_descricao"].ToString();
                            retorno.reg_endereco = result["reg_endereco"] is DBNull ? string.Empty : result["reg_endereco"].ToString();
                            retorno.reg_bairro = result["reg_bairro"] is DBNull ? string.Empty : result["reg_bairro"].ToString();
                            retorno.reg_cep = result["reg_cep"] is DBNull ? string.Empty : result["reg_cep"].ToString();
                            retorno.reg_ddd_telefone = result["reg_ddd_telefone"] is DBNull ? string.Empty : result["reg_ddd_telefone"].ToString();
                            retorno.reg_telefone = result["reg_telefone"] is DBNull ? string.Empty : result["reg_telefone"].ToString();
                            retorno.reg_email = result["reg_email"] is DBNull ? string.Empty : result["reg_email"].ToString();
                            retorno.reg_diretor = result["reg_diretor"] is DBNull ? string.Empty : result["reg_diretor"].ToString();
                            retorno.reg_email_diretor = result["reg_email_diretor"] is DBNull ? string.Empty : result["reg_email_diretor"].ToString();
                            retorno.reg_ddd_telefone_cco = result["reg_ddd_telefone_cco"] is DBNull ? string.Empty : result["reg_ddd_telefone_cco"].ToString();
                            retorno.reg_telefone_cco = result["reg_telefone_cco"] is DBNull ? string.Empty : result["reg_telefone_cco"].ToString();

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

        public bool Inserir(DominioRegionais domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_DOMINIOREGIONAIS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@reg_codigo", domain.reg_codigo));
                        command.Parameters.Add(new SqlParameter("@mun_ibge_id", domain.mun_ibge_id));
                        command.Parameters.Add(new SqlParameter("@reg_descricao", domain.reg_descricao));
                        command.Parameters.Add(new SqlParameter("@reg_endereco", domain.reg_endereco));
                        command.Parameters.Add(new SqlParameter("@reg_bairro", domain.reg_bairro));
                        command.Parameters.Add(new SqlParameter("@reg_cep", domain.reg_cep));
                        command.Parameters.Add(new SqlParameter("@reg_ddd_telefone", domain.reg_ddd_telefone));
                        command.Parameters.Add(new SqlParameter("@reg_telefone", domain.reg_telefone));
                        command.Parameters.Add(new SqlParameter("@reg_email", domain.reg_email));
                        command.Parameters.Add(new SqlParameter("@reg_diretor", domain.reg_diretor));
                        command.Parameters.Add(new SqlParameter("@reg_email_diretor", domain.reg_email_diretor));
                        command.Parameters.Add(new SqlParameter("@reg_ddd_telefone_cco", domain.reg_ddd_telefone_cco));
                        command.Parameters.Add(new SqlParameter("@reg_telefone_cco", domain.reg_telefone_cco));
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

        public bool Update(DominioRegionais domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.reg_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_DOMINIOREGIONAIS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@reg_codigo", domain.reg_codigo));
                        command.Parameters.Add(new SqlParameter("@mun_ibge_id", domain.mun_ibge_id));
                        command.Parameters.Add(new SqlParameter("@reg_descricao", domain.reg_descricao));
                        command.Parameters.Add(new SqlParameter("@reg_endereco", domain.reg_endereco));
                        command.Parameters.Add(new SqlParameter("@reg_bairro", domain.reg_bairro));
                        command.Parameters.Add(new SqlParameter("@reg_cep", domain.reg_cep));
                        command.Parameters.Add(new SqlParameter("@reg_ddd_telefone", domain.reg_ddd_telefone));
                        command.Parameters.Add(new SqlParameter("@reg_telefone", domain.reg_telefone));
                        command.Parameters.Add(new SqlParameter("@reg_email", domain.reg_email));
                        command.Parameters.Add(new SqlParameter("@reg_diretor", domain.reg_diretor));
                        command.Parameters.Add(new SqlParameter("@reg_email_diretor", domain.reg_email_diretor));
                        command.Parameters.Add(new SqlParameter("@reg_ddd_telefone_cco", domain.reg_ddd_telefone_cco));
                        command.Parameters.Add(new SqlParameter("@reg_telefone_cco", domain.reg_telefone_cco));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.reg_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.reg_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DominioRegionais GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new DominioRegionais();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOREGIONAIS_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.reg_codigo = result["reg_codigo"] is DBNull ? string.Empty : result["reg_codigo"].ToString();
                            retorno.mun_ibge_id = result["mun_ibge_id"] is DBNull ? 0 : Convert.ToInt32(result["mun_ibge_id"]);
                            retorno.reg_descricao = result["reg_descricao"] is DBNull ? string.Empty : result["reg_descricao"].ToString();
                            retorno.reg_endereco = result["reg_endereco"] is DBNull ? string.Empty : result["reg_endereco"].ToString();
                            retorno.reg_bairro = result["reg_bairro"] is DBNull ? string.Empty : result["reg_bairro"].ToString();
                            retorno.reg_cep = result["reg_cep"] is DBNull ? string.Empty : result["reg_cep"].ToString();
                            retorno.reg_ddd_telefone = result["reg_ddd_telefone"] is DBNull ? string.Empty : result["reg_ddd_telefone"].ToString();
                            retorno.reg_telefone = result["reg_telefone"] is DBNull ? string.Empty : result["reg_telefone"].ToString();
                            retorno.reg_email = result["reg_email"] is DBNull ? string.Empty : result["reg_email"].ToString();
                            retorno.reg_diretor = result["reg_diretor"] is DBNull ? string.Empty : result["reg_diretor"].ToString();
                            retorno.reg_email_diretor = result["reg_email_diretor"] is DBNull ? string.Empty : result["reg_email_diretor"].ToString();
                            retorno.reg_ddd_telefone_cco = result["reg_ddd_telefone_cco"] is DBNull ? string.Empty : result["reg_ddd_telefone_cco"].ToString();
                            retorno.reg_telefone_cco = result["reg_telefone_cco"] is DBNull ? string.Empty : result["reg_telefone_cco"].ToString();
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

        public bool Delete(DominioRegionais model)
        {
            var oldValue = GetById(model.reg_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_DOMINIOREGIONAIS", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@reg_id", model.reg_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.reg_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}