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
    public class SegurancaCanteiroLevantamentoDAO : BaseDAO<SegurancaCanteiroLevantamento>
    {
        Logger logger;

        public SegurancaCanteiroLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("SegurancaCanteiroLevantamento", context);
        }

        public List<SegurancaCanteiroLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<SegurancaCanteiroLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_SEGURANCACANTEIROLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new SegurancaCanteiroLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.scc_km_inicial = result["scc_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["scc_km_inicial"]);
                            retorno.scc_km_final = result["scc_km_final"] is DBNull ? 0 : Convert.ToDouble(result["scc_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.scc_data_levantamento = result["scc_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["scc_data_levantamento"]);
                            retorno.scc_extensao = result["scc_extensao"] is DBNull ? 0 : Convert.ToDouble(result["scc_extensao"]);
                            retorno.est_id = result["est_id"] is DBNull ? 0 : Convert.ToInt32(result["est_id"]);
                            retorno.scc_data_criacao = result["scc_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["scc_data_criacao"]);
                            retorno.scc_id_segmento = result["scc_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["scc_id_segmento"]);
                            retorno.scc_dispositivo = result["scc_dispositivo"] is DBNull ? false : false;//verificar boll
                            retorno.scc_ext_geometria = result["scc_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["scc_ext_geometria"]);

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

        public bool Inserir(SegurancaCanteiroLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_SEGURANCACANTEIROLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@scc_km_inicial", domain.scc_km_inicial));
                        command.Parameters.Add(new SqlParameter("@scc_km_final", domain.scc_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@scc_data_levantamento", domain.scc_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@scc_extensao", domain.scc_extensao));
                        command.Parameters.Add(new SqlParameter("@est_id", domain.est_id));
                        command.Parameters.Add(new SqlParameter("@scc_data_criacao", domain.scc_data_criacao));
                        command.Parameters.Add(new SqlParameter("@scc_id_segmento", domain.scc_id_segmento));
                        command.Parameters.Add(new SqlParameter("@scc_dispositivo", domain.scc_dispositivo));
                        command.Parameters.Add(new SqlParameter("@scc_ext_geometria", domain.scc_ext_geometria));
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

        public bool Update(SegurancaCanteiroLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_SEGURANCACANTEIROLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@scc_km_inicial", domain.scc_km_inicial));
                        command.Parameters.Add(new SqlParameter("@scc_km_final", domain.scc_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@scc_data_levantamento", domain.scc_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@scc_extensao", domain.scc_extensao));
                        command.Parameters.Add(new SqlParameter("@est_id", domain.est_id));
                        command.Parameters.Add(new SqlParameter("@scc_data_criacao", domain.scc_data_criacao));
                        command.Parameters.Add(new SqlParameter("@scc_id_segmento", domain.scc_id_segmento));
                        command.Parameters.Add(new SqlParameter("@scc_dispositivo", domain.scc_dispositivo));
                        command.Parameters.Add(new SqlParameter("@scc_ext_geometria", domain.scc_ext_geometria));
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

        public SegurancaCanteiroLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new SegurancaCanteiroLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_SEGURANCACANTEIROLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.scc_km_inicial = result["scc_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["scc_km_inicial"]);
                            retorno.scc_km_final = result["scc_km_final"] is DBNull ? 0 : Convert.ToDouble(result["scc_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.scc_data_levantamento = result["scc_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["scc_data_levantamento"]);
                            retorno.scc_extensao = result["scc_extensao"] is DBNull ? 0 : Convert.ToDouble(result["scc_extensao"]);
                            retorno.est_id = result["est_id"] is DBNull ? 0 : Convert.ToInt32(result["est_id"]);
                            retorno.scc_data_criacao = result["scc_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["scc_data_criacao"]);
                            retorno.scc_id_segmento = result["scc_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["scc_id_segmento"]);
                            retorno.scc_dispositivo = result["scc_dispositivo"] is DBNull ? false : false;//verificar boll
                            retorno.scc_ext_geometria = result["scc_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["scc_ext_geometria"]);
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

        public bool Delete(SegurancaCanteiroLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_SEGURANCACANTEIROLEVANTAMENTO", conn))
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