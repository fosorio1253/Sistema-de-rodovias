using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Helper;
using DER.WebApp.Infra.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using DER.WebApp.Common.Helper;

namespace DER.WebApp.Infra.DAO
{
    public class EmailDAO : BaseDAO<Emails>
    {
        private Logger _logger;
        public EmailDAO(DerContext context) : base(context)
        {
            _logger = new Logger("Email", context);
        }

        public List<Emails> GetListEmails()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<Emails>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_EMAIL_LISTA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var emails = new Emails();
                            emails.Id = result["Id"] is DBNull ? 0 : Convert.ToInt32(result["Id"]);
                            emails.Assunto = result["Assunto"] is DBNull ? string.Empty : result["Assunto"].ToString();
                            emails.CorpoEmail = result["CorpoEmail"] is DBNull ? string.Empty : result["CorpoEmail"].ToString();
                            emails.Codigo = result["Codigo"] is DBNull ? string.Empty : result["Codigo"].ToString();
                            emails.CC = result["CC"] is DBNull ? string.Empty : result["CC"].ToString();
                            emails.Destinatario = result["Destinatario"] is DBNull ? string.Empty : result["Destinatario"].ToString();
                            emails.DataEnvio = result["DataEnvio"] is DBNull ? DateTime.Now : Convert.ToDateTime(result["DataEnvio"].ToString());

                            retorno.Add(emails);
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

        public Emails GetEmail(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var emails = new Emails();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_EMAIL_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@Id", id));

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            emails.Id = result["Id"] is DBNull ? 0 : Convert.ToInt32(result["Id"]);
                            emails.Assunto = result["Assunto"] is DBNull ? string.Empty : result["Assunto"].ToString();
                            emails.CorpoEmail = result["CorpoEmail"] is DBNull ? string.Empty : result["CorpoEmail"].ToString();
                            emails.Codigo = result["Codigo"] is DBNull ? string.Empty : result["Codigo"].ToString();
                            emails.CC = result["CC"] is DBNull ? string.Empty : result["CC"].ToString();
                            emails.Destinatario = result["Destinatario"] is DBNull ? string.Empty : result["Destinatario"].ToString();
                            emails.DataEnvio = result["DataEnvio"] is DBNull ? DateTime.Now : Convert.ToDateTime(result["DataEnvio"].ToString());
                        }
                        conn.Close();
                    }
                }
                return emails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool SaveEmail(Emails email)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_EMAIL", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@Assunto", email.Assunto));
                        command.Parameters.Add(new SqlParameter("@CorpoEmail", email.CorpoEmail));
                        command.Parameters.Add(new SqlParameter("@Codigo", email.Codigo == null ? String.Empty : email.Codigo));
                        command.Parameters.Add(new SqlParameter("@CC", email.CC == null ? String.Empty : email.CC));
                        command.Parameters.Add(new SqlParameter("@Destinatario", email.Destinatario));
                        command.Parameters.Add(new SqlParameter("@DataEnvio", DateTime.Now));

                        var result = command.ExecuteScalar();

                        conn.Close();

                        var id = Convert.ToInt32(result);
                        _logger.salvarLog(TipoAlteracao.Criacao, id.ToString(), "", _logger.serializer.Serialize(email));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw new Exception(ex.Message);
            }
        }

        public bool UpdateEmail(Emails email)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_EMAIL", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@id", email.Id));
                        command.Parameters.Add(new SqlParameter("@Assunto", email.Assunto));
                        command.Parameters.Add(new SqlParameter("@CorpoEmail", email.CorpoEmail));
                        command.Parameters.Add(new SqlParameter("@Codigo", email.Codigo));
                        command.Parameters.Add(new SqlParameter("@CC", email.CC));
                        command.Parameters.Add(new SqlParameter("@Destinatario", email.Destinatario));
                        command.Parameters.Add(new SqlParameter("@DataEnvio", DateTime.Now));

                        var result = command.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw new Exception(ex.Message);
            }
        }
    }
}