﻿using DER.WebApp.Domain.Models;
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
    public class PiDAO : BaseDAO<Pi>
    {
        Logger logger;

        public PiDAO(DerContext context) : base(context)
        {
            logger = new Logger("Pi");
        }

        public List<Pi> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<Pi>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PI", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new Pi();
                            retorno.pi_id = result["pi_id"] is DBNull ? 0 : Convert.ToInt32(result["pi_id"]);
                            retorno.Mes_Ano = result["Mes_Ano"] is DBNull ? dtnull : Convert.ToDateTime(result["Mes_Ano"]);
                            retorno.Valor_PI = result["Valor_PI"] is DBNull ? 0 : Convert.ToDouble(result["Valor_PI"]);

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

        public bool Inserir(Pi domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_PI", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@pi_id", domain.pi_id));
                        command.Parameters.Add(new SqlParameter("@Mes_Ano", domain.Mes_Ano));
                        command.Parameters.Add(new SqlParameter("@Valor_PI", domain.Valor_PI));
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

        public bool Update(Pi domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_PI", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@pi_id", domain.pi_id));
                        command.Parameters.Add(new SqlParameter("@Mes_Ano", domain.Mes_Ano));
                        command.Parameters.Add(new SqlParameter("@Valor_PI", domain.Valor_PI));
                        var result = command.ExecuteNonQuery();
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

        public bool Delete(Pi model)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_PI", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@pi_id", model.pi_id));
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