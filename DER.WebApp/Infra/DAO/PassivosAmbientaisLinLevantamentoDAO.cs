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
    public class PassivosAmbientaisLinLevantamentoDAO : BaseDAO<PassivosAmbientaisLinLevantamento>
    {
        Logger logger;

        public PassivosAmbientaisLinLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("PassivosAmbientaisLinLevantamento", context);
        }

        public List<PassivosAmbientaisLinLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<PassivosAmbientaisLinLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PASSIVOSAMBIENTAISLINLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new PassivosAmbientaisLinLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.pal_km_inicial = result["pal_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["pal_km_inicial"]);
                            retorno.pal_km_final = result["pal_km_final"] is DBNull ? 0 : Convert.ToDouble(result["pal_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.pal_data_levantamento = result["pal_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["pal_data_levantamento"]);
                            retorno.pal_extensao = result["pal_extensao"] is DBNull ? 0 : Convert.ToDouble(result["pal_extensao"]);
                            retorno.pat_id = result["pat_id"] is DBNull ? 0 : Convert.ToInt32(result["pat_id"]);
                            retorno.pal_data_criacao = result["pal_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["pal_data_criacao"]);
                            retorno.pal_id_segmento = result["pal_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["pal_id_segmento"]);
                            retorno.pal_dispositivo = result["pal_dispositivo"] is DBNull ? false : false;//verificar fosorio
                            retorno.pal_ext_geometria = result["pal_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["pal_ext_geometria"]);

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

        public bool Inserir(PassivosAmbientaisLinLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_PASSIVOSAMBIENTAISLINLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@pal_km_inicial", domain.pal_km_inicial));
                        command.Parameters.Add(new SqlParameter("@pal_km_final", domain.pal_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@pal_data_levantamento", domain.pal_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@pal_extensao", domain.pal_extensao));
                        command.Parameters.Add(new SqlParameter("@pat_id", domain.pat_id));
                        command.Parameters.Add(new SqlParameter("@pal_data_criacao", domain.pal_data_criacao));
                        command.Parameters.Add(new SqlParameter("@pal_id_segmento", domain.pal_id_segmento));
                        command.Parameters.Add(new SqlParameter("@pal_dispositivo", domain.pal_dispositivo));
                        command.Parameters.Add(new SqlParameter("@pal_ext_geometria", domain.pal_ext_geometria));
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

        public bool Update(PassivosAmbientaisLinLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_PASSIVOSAMBIENTAISLINLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@pal_km_inicial", domain.pal_km_inicial));
                        command.Parameters.Add(new SqlParameter("@pal_km_final", domain.pal_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@pal_data_levantamento", domain.pal_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@pal_extensao", domain.pal_extensao));
                        command.Parameters.Add(new SqlParameter("@pat_id", domain.pat_id));
                        command.Parameters.Add(new SqlParameter("@pal_data_criacao", domain.pal_data_criacao));
                        command.Parameters.Add(new SqlParameter("@pal_id_segmento", domain.pal_id_segmento));
                        command.Parameters.Add(new SqlParameter("@pal_dispositivo", domain.pal_dispositivo));
                        command.Parameters.Add(new SqlParameter("@pal_ext_geometria", domain.pal_ext_geometria));
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

        public PassivosAmbientaisLinLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new PassivosAmbientaisLinLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PASSIVOSAMBIENTAISLINLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.pal_km_inicial = result["pal_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["pal_km_inicial"]);
                            retorno.pal_km_final = result["pal_km_final"] is DBNull ? 0 : Convert.ToDouble(result["pal_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.pal_data_levantamento = result["pal_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["pal_data_levantamento"]);
                            retorno.pal_extensao = result["pal_extensao"] is DBNull ? 0 : Convert.ToDouble(result["pal_extensao"]);
                            retorno.pat_id = result["pat_id"] is DBNull ? 0 : Convert.ToInt32(result["pat_id"]);
                            retorno.pal_data_criacao = result["pal_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["pal_data_criacao"]);
                            retorno.pal_id_segmento = result["pal_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["pal_id_segmento"]);
                            retorno.pal_dispositivo = result["pal_dispositivo"] is DBNull ? false : false;//verificar fosorio
                            retorno.pal_ext_geometria = result["pal_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["pal_ext_geometria"]);
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

        public bool Delete(PassivosAmbientaisLinLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_PASSIVOSAMBIENTAISLINLEVANTAMENTO", conn))
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