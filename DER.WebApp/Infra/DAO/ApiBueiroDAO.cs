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
    public class ApiBueiroDAO : BaseDAO<ApiBueiro>
    {
        Logger logger;

        public ApiBueiroDAO(DerContext context) : base(context)
        {
            logger = new Logger("ApiBueiro", context);
        }

        public List<ApiBueiro> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<ApiBueiro>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_APIBUEIRO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new ApiBueiro();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.dis_id = result["dis_id"] is DBNull ? 0 : Convert.ToInt32(result["dis_id"]);
                            retorno.rtr_id = result["rtr_id"] is DBNull ? 0 : Convert.ToInt32(result["rtr_id"]);
                            retorno.ace_km = result["ace_km"] is DBNull ? 0 : Convert.ToDouble(result["ace_km"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.ace_latitude = result["ace_latitude"] is DBNull ? 0 : Convert.ToDouble(result["ace_latitude"]);
                            retorno.ace_longitude = result["ace_longitude"] is DBNull ? 0 : Convert.ToDouble(result["ace_longitude"]);
                            retorno.ace_foto = result["ace_foto"] is DBNull ? string.Empty : result["ace_foto"].ToString();
                            retorno.ace_data_levantamento = result["ace_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["ace_data_levantamento"]);
                            retorno.stp_id = result["stp_id"] is DBNull ? 0 : Convert.ToInt32(result["stp_id"]);
                            retorno.ace_largura = result["ace_largura"] is DBNull ? 0 : Convert.ToDouble(result["ace_largura"]);
                            retorno.ace_data_criacao = result["ace_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["ace_data_criacao"]);

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

        public bool Inserir(ApiBueiro domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_APIBUEIRO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@dis_id", domain.dis_id));
                        command.Parameters.Add(new SqlParameter("@rtr_id", domain.rtr_id));
                        command.Parameters.Add(new SqlParameter("@ace_km", domain.ace_km));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@ace_latitude", domain.ace_latitude));
                        command.Parameters.Add(new SqlParameter("@ace_longitude", domain.ace_longitude));
                        command.Parameters.Add(new SqlParameter("@ace_foto", domain.ace_foto));
                        command.Parameters.Add(new SqlParameter("@ace_data_levantamento", domain.ace_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@stp_id", domain.stp_id));
                        command.Parameters.Add(new SqlParameter("@ace_largura", domain.ace_largura));
                        command.Parameters.Add(new SqlParameter("@ace_data_criacao", domain.ace_data_criacao));
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

        public bool Update(ApiBueiro domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_APIBUEIRO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@dis_id", domain.dis_id));
                        command.Parameters.Add(new SqlParameter("@rtr_id", domain.rtr_id));
                        command.Parameters.Add(new SqlParameter("@ace_km", domain.ace_km));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@ace_latitude", domain.ace_latitude));
                        command.Parameters.Add(new SqlParameter("@ace_longitude", domain.ace_longitude));
                        command.Parameters.Add(new SqlParameter("@ace_foto", domain.ace_foto));
                        command.Parameters.Add(new SqlParameter("@ace_data_levantamento", domain.ace_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@stp_id", domain.stp_id));
                        command.Parameters.Add(new SqlParameter("@ace_largura", domain.ace_largura));
                        command.Parameters.Add(new SqlParameter("@ace_data_criacao", domain.ace_data_criacao));
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

        public ApiBueiro GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new ApiBueiro();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_APIBUEIRO_ID", conn))
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
                            retorno.ace_km = result["ace_km"] is DBNull ? 0 : Convert.ToDouble(result["ace_km"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.ace_latitude = result["ace_latitude"] is DBNull ? 0 : Convert.ToDouble(result["ace_latitude"]);
                            retorno.ace_longitude = result["ace_longitude"] is DBNull ? 0 : Convert.ToDouble(result["ace_longitude"]);
                            retorno.ace_foto = result["ace_foto"] is DBNull ? string.Empty : result["ace_foto"].ToString();
                            retorno.ace_data_levantamento = result["ace_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["ace_data_levantamento"]);
                            retorno.stp_id = result["stp_id"] is DBNull ? 0 : Convert.ToInt32(result["stp_id"]);
                            retorno.ace_largura = result["ace_largura"] is DBNull ? 0 : Convert.ToDouble(result["ace_largura"]);
                            retorno.ace_data_criacao = result["ace_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["ace_data_criacao"]);
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

        public bool Delete(ApiBueiro model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_APIBUEIRO", conn))
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