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
    public class TachaFaixaCentralLevantamentoDAO : BaseDAO<TachaFaixaCentralLevantamento>
    {
        Logger logger;

        public TachaFaixaCentralLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("TachaFaixaCentralLevantamento");
        }

        public List<TachaFaixaCentralLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<TachaFaixaCentralLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TACHAFAIXACENTRALLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new TachaFaixaCentralLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.tfc_km_inicial = result["tfc_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["tfc_km_inicial"]);
                            retorno.tfc_km_final = result["tfc_km_final"] is DBNull ? 0 : Convert.ToDouble(result["tfc_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.tfc_data_levantamento = result["tfc_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["tfc_data_levantamento"]);
                            retorno.tfc_extensao = result["tfc_extensao"] is DBNull ? 0 : Convert.ToDouble(result["tfc_extensao"]);
                            retorno.sht_id = result["sht_id"] is DBNull ? 0 : Convert.ToInt32(result["sht_id"]);
                            retorno.tfc_quantidade = result["tfc_quantidade"] is DBNull ? 0 : Convert.ToInt32(result["tfc_quantidade"]);
                            retorno.tfc_data_criacao = result["tfc_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["tfc_data_criacao"]);
                            retorno.tfc_id_segmento = result["tfc_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["tfc_id_segmento"]);
                            retorno.tfc_dispositivo = result["tfc_dispositivo"] is DBNull ? false : false;// verificar fosorio
                            retorno.tfc_ext_geometria = result["tfc_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["tfc_ext_geometria"]);

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

        public bool Inserir(TachaFaixaCentralLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_TACHAFAIXACENTRALLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@tfc_km_inicial", domain.tfc_km_inicial));
                        command.Parameters.Add(new SqlParameter("@tfc_km_final", domain.tfc_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@tfc_data_levantamento", domain.tfc_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@tfc_extensao", domain.tfc_extensao));
                        command.Parameters.Add(new SqlParameter("@sht_id", domain.sht_id));
                        command.Parameters.Add(new SqlParameter("@tfc_quantidade", domain.tfc_quantidade));
                        command.Parameters.Add(new SqlParameter("@tfc_data_criacao", domain.tfc_data_criacao));
                        command.Parameters.Add(new SqlParameter("@tfc_id_segmento", domain.tfc_id_segmento));
                        command.Parameters.Add(new SqlParameter("@tfc_dispositivo", domain.tfc_dispositivo));
                        command.Parameters.Add(new SqlParameter("@tfc_ext_geometria", domain.tfc_ext_geometria));
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

        public bool Update(TachaFaixaCentralLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_TACHAFAIXACENTRALLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@tfc_km_inicial", domain.tfc_km_inicial));
                        command.Parameters.Add(new SqlParameter("@tfc_km_final", domain.tfc_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@tfc_data_levantamento", domain.tfc_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@tfc_extensao", domain.tfc_extensao));
                        command.Parameters.Add(new SqlParameter("@sht_id", domain.sht_id));
                        command.Parameters.Add(new SqlParameter("@tfc_quantidade", domain.tfc_quantidade));
                        command.Parameters.Add(new SqlParameter("@tfc_data_criacao", domain.tfc_data_criacao));
                        command.Parameters.Add(new SqlParameter("@tfc_id_segmento", domain.tfc_id_segmento));
                        command.Parameters.Add(new SqlParameter("@tfc_dispositivo", domain.tfc_dispositivo));
                        command.Parameters.Add(new SqlParameter("@tfc_ext_geometria", domain.tfc_ext_geometria));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.rod_id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TachaFaixaCentralLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new TachaFaixaCentralLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TACHAFAIXACENTRALLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.tfc_km_inicial = result["tfc_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["tfc_km_inicial"]);
                            retorno.tfc_km_final = result["tfc_km_final"] is DBNull ? 0 : Convert.ToDouble(result["tfc_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.tfc_data_levantamento = result["tfc_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["tfc_data_levantamento"]);
                            retorno.tfc_extensao = result["tfc_extensao"] is DBNull ? 0 : Convert.ToDouble(result["tfc_extensao"]);
                            retorno.sht_id = result["sht_id"] is DBNull ? 0 : Convert.ToInt32(result["sht_id"]);
                            retorno.tfc_quantidade = result["tfc_quantidade"] is DBNull ? 0 : Convert.ToInt32(result["tfc_quantidade"]);
                            retorno.tfc_data_criacao = result["tfc_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["tfc_data_criacao"]);
                            retorno.tfc_id_segmento = result["tfc_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["tfc_id_segmento"]);
                            retorno.tfc_dispositivo = result["tfc_dispositivo"] is DBNull ? false : false;// verificar fosorio
                            retorno.tfc_ext_geometria = result["tfc_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["tfc_ext_geometria"]);
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

        public bool Delete(TachaFaixaCentralLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_TACHAFAIXACENTRALLEVANTAMENTO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@rod_id", model.rod_id));
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