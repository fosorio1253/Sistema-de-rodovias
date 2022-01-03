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
    public class ApiDispositivoDAO : BaseDAO<ApiDispositivo>
    {
        Logger logger;

        public ApiDispositivoDAO(DerContext context) : base(context)
        {
            logger = new Logger("ApiDispositivo", context);
        }

        public List<ApiDispositivo> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<ApiDispositivo>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_APIDISPOSITIVO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new ApiDispositivo();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.dis_id = result["dis_id"] is DBNull ? 0 : Convert.ToInt32(result["dis_id"]);
                            retorno.rtr_id = result["rtr_id"] is DBNull ? 0 : Convert.ToInt32(result["rtr_id"]);
                            retorno.dis_km = result["dis_km"] is DBNull ? 0 : Convert.ToDouble(result["dis_km"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.dis_latitude = result["dis_latitude"] is DBNull ? 0 : Convert.ToDouble(result["dis_latitude"]);
                            retorno.dis_longitude = result["dis_longitude"] is DBNull ? 0 : Convert.ToDouble(result["dis_longitude"]);
                            retorno.dis_foto = result["dis_foto"] is DBNull ? string.Empty : result["dis_foto"].ToString();
                            retorno.dis_data_levantamento = result["dis_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["dis_data_levantamento"]);
                            retorno.dit_id = result["dit_id"] is DBNull ? 0 : Convert.ToInt32(result["dit_id"]);
                            retorno.dis_data_criacao = result["dis_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["dis_data_criacao"]);

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

        public bool Inserir(ApiDispositivo domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_APIDISPOSITIVO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@dis_id", domain.dis_id));
                        command.Parameters.Add(new SqlParameter("@rtr_id", domain.rtr_id));
                        command.Parameters.Add(new SqlParameter("@dis_km", domain.dis_km));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@dis_latitude", domain.dis_latitude));
                        command.Parameters.Add(new SqlParameter("@dis_longitude", domain.dis_longitude));
                        command.Parameters.Add(new SqlParameter("@dis_foto", domain.dis_foto));
                        command.Parameters.Add(new SqlParameter("@dis_data_levantamento", domain.dis_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@dit_id", domain.dit_id));
                        command.Parameters.Add(new SqlParameter("@dis_data_criacao", domain.dis_data_criacao));
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

        public bool Update(ApiDispositivo domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_APIDISPOSITIVO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@dis_id", domain.dis_id));
                        command.Parameters.Add(new SqlParameter("@rtr_id", domain.rtr_id));
                        command.Parameters.Add(new SqlParameter("@dis_km", domain.dis_km));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@dis_latitude", domain.dis_latitude));
                        command.Parameters.Add(new SqlParameter("@dis_longitude", domain.dis_longitude));
                        command.Parameters.Add(new SqlParameter("@dis_foto", domain.dis_foto));
                        command.Parameters.Add(new SqlParameter("@dis_data_levantamento", domain.dis_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@dit_id", domain.dit_id));
                        command.Parameters.Add(new SqlParameter("@dis_data_criacao", domain.dis_data_criacao));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.rod_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.rod_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ApiDispositivo GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new ApiDispositivo();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_APIDISPOSITIVO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.dis_id = result["dis_id"] is DBNull ? 0 : Convert.ToInt32(result["dis_id"]);
                            retorno.rtr_id = result["rtr_id"] is DBNull ? 0 : Convert.ToInt32(result["rtr_id"]);
                            retorno.dis_km = result["dis_km"] is DBNull ? 0 : Convert.ToDouble(result["dis_km"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.dis_latitude = result["dis_latitude"] is DBNull ? 0 : Convert.ToDouble(result["dis_latitude"]);
                            retorno.dis_longitude = result["dis_longitude"] is DBNull ? 0 : Convert.ToDouble(result["dis_longitude"]);
                            retorno.dis_foto = result["dis_foto"] is DBNull ? string.Empty : result["dis_foto"].ToString();
                            retorno.dis_data_levantamento = result["dis_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["dis_data_levantamento"]);
                            retorno.dit_id = result["dit_id"] is DBNull ? 0 : Convert.ToInt32(result["dit_id"]);
                            retorno.dis_data_criacao = result["dis_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["dis_data_criacao"]);
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

        public bool Delete(ApiDispositivo model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_APIDISPOSITIVO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@rod_id", model.rod_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.rod_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}