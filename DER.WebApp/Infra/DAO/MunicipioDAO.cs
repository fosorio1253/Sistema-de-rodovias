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
    public class MunicipioDAO : BaseDAO<Municipio>
    {
        Logger logger;

        public MunicipioDAO(DerContext context) : base(context)
        {
            logger = new Logger("Municipio");
        }

        public List<Municipio> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<Municipio>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_MUNICIPIO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new Municipio();
                            retorno.municipio_id = result["municipio_id"] is DBNull ? 0 : Convert.ToInt32(result["municipio_id"]);
                            retorno.codigo = result["codigo"] is DBNull ? string.Empty : result["codigo"].ToString();
                            retorno.municipio = result["municipio"] is DBNull ? string.Empty : result["municipio"].ToString();
                            retorno.regional = result["regional"] is DBNull ? string.Empty : result["regional"].ToString();

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

        public bool Inserir(Municipio domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_MUNICIPIO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@municipio_id", domain.municipio_id));
                        command.Parameters.Add(new SqlParameter("@codigo", domain.codigo));
                        command.Parameters.Add(new SqlParameter("@municipio", domain.municipio));
                        command.Parameters.Add(new SqlParameter("@regional", domain.regional));
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

        public bool Update(Municipio domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_MUNICIPIO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@municipio_id", domain.municipio_id));
                        command.Parameters.Add(new SqlParameter("@codigo", domain.codigo));
                        command.Parameters.Add(new SqlParameter("@municipio", domain.municipio));
                        command.Parameters.Add(new SqlParameter("@regional", domain.regional));
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

        public bool Delete(Municipio model)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_MUNICIPIO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@municipio_id", model.municipio_id));
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