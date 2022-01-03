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
    public class ApiEdificacoesDAO : BaseDAO<ApiEdificacoes>
    {
        Logger logger;

        public ApiEdificacoesDAO(DerContext context) : base(context)
        {
            logger = new Logger("ApiEdificacoes", context);
        }

        public List<ApiEdificacoes> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<ApiEdificacoes>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_APIEDIFICACOES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new ApiEdificacoes();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.dis_id = result["dis_id"] is DBNull ? 0 : Convert.ToInt32(result["dis_id"]);
                            retorno.rtr_id = result["rtr_id"] is DBNull ? 0 : Convert.ToInt32(result["rtr_id"]);
                            retorno.edi_km = result["edi_km"] is DBNull ? 0 : Convert.ToDouble(result["edi_km"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.edi_latitude = result["edi_latitude"] is DBNull ? 0 : Convert.ToDouble(result["edi_latitude"]);
                            retorno.edi_longitude = result["edi_longitude"] is DBNull ? 0 : Convert.ToDouble(result["edi_longitude"]);
                            retorno.edi_foto = result["edi_foto"] is DBNull ? string.Empty : result["edi_foto"].ToString();
                            retorno.edi_data_levantamento = result["edi_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["edi_data_levantamento"]);
                            retorno.edt_id = result["edt_id"] is DBNull ? 0 : Convert.ToInt32(result["edt_id"]);
                            retorno.edi_data_criacao = result["edi_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["edi_data_criacao"]);

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

        public bool Inserir(ApiEdificacoes domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_APIEDIFICACOES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@dis_id", domain.dis_id));
                        command.Parameters.Add(new SqlParameter("@rtr_id", domain.rtr_id));
                        command.Parameters.Add(new SqlParameter("@edi_km", domain.edi_km));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@edi_latitude", domain.edi_latitude));
                        command.Parameters.Add(new SqlParameter("@edi_longitude", domain.edi_longitude));
                        command.Parameters.Add(new SqlParameter("@edi_foto", domain.edi_foto));
                        command.Parameters.Add(new SqlParameter("@edi_data_levantamento", domain.edi_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@edt_id", domain.edt_id));
                        command.Parameters.Add(new SqlParameter("@edi_data_criacao", domain.edi_data_criacao));
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

        public bool Update(ApiEdificacoes domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_APIEDIFICACOES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@dis_id", domain.dis_id));
                        command.Parameters.Add(new SqlParameter("@rtr_id", domain.rtr_id));
                        command.Parameters.Add(new SqlParameter("@edi_km", domain.edi_km));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@edi_latitude", domain.edi_latitude));
                        command.Parameters.Add(new SqlParameter("@edi_longitude", domain.edi_longitude));
                        command.Parameters.Add(new SqlParameter("@edi_foto", domain.edi_foto));
                        command.Parameters.Add(new SqlParameter("@edi_data_levantamento", domain.edi_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@edt_id", domain.edt_id));
                        command.Parameters.Add(new SqlParameter("@edi_data_criacao", domain.edi_data_criacao));
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

        public ApiEdificacoes GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new ApiEdificacoes();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_APIEDIFICACOES_ID", conn))
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
                            retorno.edi_km = result["edi_km"] is DBNull ? 0 : Convert.ToDouble(result["edi_km"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.edi_latitude = result["edi_latitude"] is DBNull ? 0 : Convert.ToDouble(result["edi_latitude"]);
                            retorno.edi_longitude = result["edi_longitude"] is DBNull ? 0 : Convert.ToDouble(result["edi_longitude"]);
                            retorno.edi_foto = result["edi_foto"] is DBNull ? string.Empty : result["edi_foto"].ToString();
                            retorno.edi_data_levantamento = result["edi_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["edi_data_levantamento"]);
                            retorno.edt_id = result["edt_id"] is DBNull ? 0 : Convert.ToInt32(result["edt_id"]);
                            retorno.edi_data_criacao = result["edi_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["edi_data_criacao"]);
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

        public bool Delete(ApiEdificacoes model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_APIEDIFICACOES", conn))
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