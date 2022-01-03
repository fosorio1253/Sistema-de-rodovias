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
    public class ApiDrenagemDAO : BaseDAO<ApiDrenagem>
    {
        Logger logger;

        public ApiDrenagemDAO(DerContext context) : base(context)
        {
            logger = new Logger("ApiDrenagem", context);
        }

        public List<ApiDrenagem> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<ApiDrenagem>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_APIDRENAGEM", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new ApiDrenagem();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.dis_id = result["dis_id"] is DBNull ? 0 : Convert.ToInt32(result["dis_id"]);
                            retorno.rtr_id = result["rtr_id"] is DBNull ? 0 : Convert.ToInt32(result["rtr_id"]);
                            retorno.drp_km = result["drp_km"] is DBNull ? 0 : Convert.ToDouble(result["drp_km"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.drp_latitude = result["drp_latitude"] is DBNull ? 0 : Convert.ToDouble(result["drp_latitude"]);
                            retorno.drp_longitude = result["drp_longitude"] is DBNull ? 0 : Convert.ToDouble(result["drp_longitude"]);
                            retorno.drp_foto = result["drp_foto"] is DBNull ? string.Empty : result["drp_foto"].ToString();
                            retorno.drp_data_levantamento = result["drp_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["drp_data_levantamento"]);
                            retorno.drt_id = result["drt_id"] is DBNull ? 0 : Convert.ToInt32(result["drt_id"]);
                            retorno.drp_data_criacao = result["drp_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["drp_data_criacao"]);

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

        public bool Inserir(ApiDrenagem domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_APIDRENAGEM", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@dis_id", domain.dis_id));
                        command.Parameters.Add(new SqlParameter("@rtr_id", domain.rtr_id));
                        command.Parameters.Add(new SqlParameter("@drp_km", domain.drp_km));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@drp_latitude", domain.drp_latitude));
                        command.Parameters.Add(new SqlParameter("@drp_longitude", domain.drp_longitude));
                        command.Parameters.Add(new SqlParameter("@drp_foto", domain.drp_foto));
                        command.Parameters.Add(new SqlParameter("@drp_data_levantamento", domain.drp_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@drt_id", domain.drt_id));
                        command.Parameters.Add(new SqlParameter("@drp_data_criacao", domain.drp_data_criacao));
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

        public bool Update(ApiDrenagem domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_APIDRENAGEM", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@dis_id", domain.dis_id));
                        command.Parameters.Add(new SqlParameter("@rtr_id", domain.rtr_id));
                        command.Parameters.Add(new SqlParameter("@drp_km", domain.drp_km));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@drp_latitude", domain.drp_latitude));
                        command.Parameters.Add(new SqlParameter("@drp_longitude", domain.drp_longitude));
                        command.Parameters.Add(new SqlParameter("@drp_foto", domain.drp_foto));
                        command.Parameters.Add(new SqlParameter("@drp_data_levantamento", domain.drp_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@drt_id", domain.drt_id));
                        command.Parameters.Add(new SqlParameter("@drp_data_criacao", domain.drp_data_criacao));
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

        public ApiDrenagem GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new ApiDrenagem();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_APIDRENAGEM_ID", conn))
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
                            retorno.drp_km = result["drp_km"] is DBNull ? 0 : Convert.ToDouble(result["drp_km"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.drp_latitude = result["drp_latitude"] is DBNull ? 0 : Convert.ToDouble(result["drp_latitude"]);
                            retorno.drp_longitude = result["drp_longitude"] is DBNull ? 0 : Convert.ToDouble(result["drp_longitude"]);
                            retorno.drp_foto = result["drp_foto"] is DBNull ? string.Empty : result["drp_foto"].ToString();
                            retorno.drp_data_levantamento = result["drp_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["drp_data_levantamento"]);
                            retorno.drt_id = result["drt_id"] is DBNull ? 0 : Convert.ToInt32(result["drt_id"]);
                            retorno.drp_data_criacao = result["drp_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["drp_data_criacao"]);
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

        public bool Delete(ApiDrenagem model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_APIDRENAGEM", conn))
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