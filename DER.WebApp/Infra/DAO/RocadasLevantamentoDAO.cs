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
    public class RocadasLevantamentoDAO : BaseDAO<RocadasLevantamento>
    {
        Logger logger;

        public RocadasLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("RocadasLevantamento", context);
        }

        public List<RocadasLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<RocadasLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_ROCADASLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new RocadasLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.rcd_km_inicial = result["rcd_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["rcd_km_inicial"]);
                            retorno.rcd_km_final = result["rcd_km_final"] is DBNull ? 0 : Convert.ToDouble(result["rcd_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.rcd_data_levantamento = result["rcd_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["rcd_data_levantamento"]);
                            retorno.rcd_extensao = result["rcd_extensao"] is DBNull ? 0 : Convert.ToDouble(result["rcd_extensao"]);
                            retorno.rcd_data_criacao = result["rcd_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["rcd_data_criacao"]);
                            retorno.rcd_id_segmento = result["rcd_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["rcd_id_segmento"]);
                            retorno.rcd_dispositivo = result["rcd_dispositivo"] is DBNull ? false : false;//verificar fosorio
                            retorno.rcd_ext_geometria = result["rcd_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["rcd_ext_geometria"]);

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

        public bool Inserir(RocadasLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_ROCADASLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@rcd_km_inicial", domain.rcd_km_inicial));
                        command.Parameters.Add(new SqlParameter("@rcd_km_final", domain.rcd_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@rcd_data_levantamento", domain.rcd_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@rcd_extensao", domain.rcd_extensao));
                        command.Parameters.Add(new SqlParameter("@rcd_data_criacao", domain.rcd_data_criacao));
                        command.Parameters.Add(new SqlParameter("@rcd_id_segmento", domain.rcd_id_segmento));
                        command.Parameters.Add(new SqlParameter("@rcd_dispositivo", domain.rcd_dispositivo));
                        command.Parameters.Add(new SqlParameter("@rcd_ext_geometria", domain.rcd_ext_geometria));
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

        public bool Update(RocadasLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_ROCADASLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@rcd_km_inicial", domain.rcd_km_inicial));
                        command.Parameters.Add(new SqlParameter("@rcd_km_final", domain.rcd_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@rcd_data_levantamento", domain.rcd_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@rcd_extensao", domain.rcd_extensao));
                        command.Parameters.Add(new SqlParameter("@rcd_data_criacao", domain.rcd_data_criacao));
                        command.Parameters.Add(new SqlParameter("@rcd_id_segmento", domain.rcd_id_segmento));
                        command.Parameters.Add(new SqlParameter("@rcd_dispositivo", domain.rcd_dispositivo));
                        command.Parameters.Add(new SqlParameter("@rcd_ext_geometria", domain.rcd_ext_geometria));
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

        public RocadasLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new RocadasLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_ROCADASLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.rcd_km_inicial = result["rcd_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["rcd_km_inicial"]);
                            retorno.rcd_km_final = result["rcd_km_final"] is DBNull ? 0 : Convert.ToDouble(result["rcd_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.rcd_data_levantamento = result["rcd_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["rcd_data_levantamento"]);
                            retorno.rcd_extensao = result["rcd_extensao"] is DBNull ? 0 : Convert.ToDouble(result["rcd_extensao"]);
                            retorno.rcd_data_criacao = result["rcd_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["rcd_data_criacao"]);
                            retorno.rcd_id_segmento = result["rcd_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["rcd_id_segmento"]);
                            retorno.rcd_dispositivo = result["rcd_dispositivo"] is DBNull ? false : false;//verificar fosorio
                            retorno.rcd_ext_geometria = result["rcd_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["rcd_ext_geometria"]);
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

        public bool Delete(RocadasLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_ROCADASLEVANTAMENTO", conn))
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