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
    public class SegurancaBordoLevantamentoDAO : BaseDAO<SegurancaBordoLevantamento>
    {
        Logger logger;

        public SegurancaBordoLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("SegurancaBordoLevantamento", context);
        }

        public List<SegurancaBordoLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<SegurancaBordoLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_SEGURANCABORDOLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new SegurancaBordoLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.sbd_km_inicial = result["sbd_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["sbd_km_inicial"]);
                            retorno.sbd_km_final = result["sbd_km_final"] is DBNull ? 0 : Convert.ToDouble(result["sbd_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.sbd_data_levantamento = result["sbd_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["sbd_data_levantamento"]);
                            retorno.sbd_extensao = result["sbd_extensao"] is DBNull ? 0 : Convert.ToDouble(result["sbd_extensao"]);
                            retorno.est_id = result["est_id"] is DBNull ? 0 : Convert.ToInt32(result["est_id"]);
                            retorno.sbd_data_criacao = result["sbd_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["sbd_data_criacao"]);
                            retorno.sbd_id_segmento = result["sbd_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["sbd_id_segmento"]);
                            retorno.sbd_dispositivo = result["sbd_dispositivo"] is DBNull ? false : false;//verificar fosorio
                            retorno.sbd_ext_geometria = result["sbd_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["sbd_ext_geometria"]);

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

        public bool Inserir(SegurancaBordoLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_SEGURANCABORDOLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@sbd_km_inicial", domain.sbd_km_inicial));
                        command.Parameters.Add(new SqlParameter("@sbd_km_final", domain.sbd_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@sbd_data_levantamento", domain.sbd_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@sbd_extensao", domain.sbd_extensao));
                        command.Parameters.Add(new SqlParameter("@est_id", domain.est_id));
                        command.Parameters.Add(new SqlParameter("@sbd_data_criacao", domain.sbd_data_criacao));
                        command.Parameters.Add(new SqlParameter("@sbd_id_segmento", domain.sbd_id_segmento));
                        command.Parameters.Add(new SqlParameter("@sbd_dispositivo", domain.sbd_dispositivo));
                        command.Parameters.Add(new SqlParameter("@sbd_ext_geometria", domain.sbd_ext_geometria));
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

        public bool Update(SegurancaBordoLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_SEGURANCABORDOLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@sbd_km_inicial", domain.sbd_km_inicial));
                        command.Parameters.Add(new SqlParameter("@sbd_km_final", domain.sbd_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@sbd_data_levantamento", domain.sbd_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@sbd_extensao", domain.sbd_extensao));
                        command.Parameters.Add(new SqlParameter("@est_id", domain.est_id));
                        command.Parameters.Add(new SqlParameter("@sbd_data_criacao", domain.sbd_data_criacao));
                        command.Parameters.Add(new SqlParameter("@sbd_id_segmento", domain.sbd_id_segmento));
                        command.Parameters.Add(new SqlParameter("@sbd_dispositivo", domain.sbd_dispositivo));
                        command.Parameters.Add(new SqlParameter("@sbd_ext_geometria", domain.sbd_ext_geometria));
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

        public SegurancaBordoLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new SegurancaBordoLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_SEGURANCABORDOLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.sbd_km_inicial = result["sbd_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["sbd_km_inicial"]);
                            retorno.sbd_km_final = result["sbd_km_final"] is DBNull ? 0 : Convert.ToDouble(result["sbd_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.sbd_data_levantamento = result["sbd_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["sbd_data_levantamento"]);
                            retorno.sbd_extensao = result["sbd_extensao"] is DBNull ? 0 : Convert.ToDouble(result["sbd_extensao"]);
                            retorno.est_id = result["est_id"] is DBNull ? 0 : Convert.ToInt32(result["est_id"]);
                            retorno.sbd_data_criacao = result["sbd_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["sbd_data_criacao"]);
                            retorno.sbd_id_segmento = result["sbd_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["sbd_id_segmento"]);
                            retorno.sbd_dispositivo = result["sbd_dispositivo"] is DBNull ? false : false;//verificar fosorio
                            retorno.sbd_ext_geometria = result["sbd_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["sbd_ext_geometria"]);
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

        public bool Delete(SegurancaBordoLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_SEGURANCABORDOLEVANTAMENTO", conn))
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