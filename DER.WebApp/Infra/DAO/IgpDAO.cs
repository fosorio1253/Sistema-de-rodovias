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
    public class IgpDAO : BaseDAO<Igp>
    {
        Logger logger;

        public IgpDAO(DerContext context) : base(context)
        {
            logger = new Logger("Igp");
        }

        public List<Igp> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<Igp>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_IGP", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new Igp();
                            retorno.IGP_id = result["IGP_id"] is DBNull ? 0 : Convert.ToInt32(result["IGP_id"]);
                            retorno.mes_ano = result["mes_ano"] is DBNull ? dtnull : Convert.ToDateTime(result["mes_ano"]);
                            retorno.valor = result["valor"] is DBNull ? 0 : Convert.ToDouble(result["valor"]);

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

        public bool Inserir(Igp domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_IGP", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@IGP_id", domain.IGP_id));
                        command.Parameters.Add(new SqlParameter("@mes_ano", domain.mes_ano));
                        command.Parameters.Add(new SqlParameter("@valor", domain.valor));
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

        public bool Update(Igp domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_IGP", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@IGP_id", domain.IGP_id));
                        command.Parameters.Add(new SqlParameter("@mes_ano", domain.mes_ano));
                        command.Parameters.Add(new SqlParameter("@valor", domain.valor));
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

        public bool Delete(Igp model)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_IGP", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IGP_id", model.IGP_id));
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