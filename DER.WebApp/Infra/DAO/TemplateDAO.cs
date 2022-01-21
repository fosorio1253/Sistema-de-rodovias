
using DER.WebApp.Domain.Models;
using DER.WebApp.Helper;
using DER.WebApp.Infra.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace DER.WebApp.Infra.DAO
{
    public class TemplateDAO : BaseDAO<Template>
    {
        
        public TemplateDAO(DerContext context) : base(context)
        {
        
        }

        public List<Template> GetListTemplates()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            var retorno = new List<Template>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TEMPLATE_LISTA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var templates = new Template();
                            templates.Id = result["Id"] is DBNull ? 0 : Convert.ToInt32(result["Id"]);
                            templates.Assunto = result["Assunto"] is DBNull ? string.Empty : result["Assunto"].ToString();
                            templates.Conteudo = result["Conteudo"] is DBNull ? string.Empty : result["Conteudo"].ToString();
                            

                            retorno.Add(templates);
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

        internal bool DeleteTemplate(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_DEL_TEMPLATE", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@Id", id));

                        var result = command.ExecuteScalar();

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

        public int SaveTemplate(Template template)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_TEMPLATE", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@Assunto", template.Assunto));
                        command.Parameters.Add(new SqlParameter("@Conteudo", template.Conteudo));

                        var result = command.ExecuteScalar();

                        conn.Close();

                        var id = Convert.ToInt32(result);
                        return id;
                    }
                }

            }
            catch (Exception ex)
            {
                return 0;
                //throw new Exception(ex.Message);
            }
        }

        public bool UpdateTemplate(Template template)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_TEMPLATE", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@id", template.Id));
                        command.Parameters.Add(new SqlParameter("@Assunto", template.Assunto));
                        command.Parameters.Add(new SqlParameter("@Conteudo", template.Conteudo));
                        

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