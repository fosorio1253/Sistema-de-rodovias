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
    public class SinalFaixaCentralLevantamentoDAO : BaseDAO<SinalFaixaCentralLevantamento>
    {
        Logger logger;

        public SinalFaixaCentralLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("SinalFaixaCentralLevantamento");
        }

        public List<SinalFaixaCentralLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<SinalFaixaCentralLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_SINALFAIXACENTRALLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new SinalFaixaCentralLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.sfc_km_inicial = result["sfc_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["sfc_km_inicial"]);
                            retorno.sfc_km_final = result["sfc_km_final"] is DBNull ? 0 : Convert.ToDouble(result["sfc_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.sfc_data_levantamento = result["sfc_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["sfc_data_levantamento"]);
                            retorno.sfc_extensao = result["sfc_extensao"] is DBNull ? 0 : Convert.ToDouble(result["sfc_extensao"]);
                            retorno.sht_id = result["sht_id"] is DBNull ? 0 : Convert.ToInt32(result["sht_id"]);
                            retorno.sfc_largura_faixa = result["sfc_largura_faixa"] is DBNull ? 0 : Convert.ToDouble(result["sfc_largura_faixa"]);
                            retorno.sfc_data_criacao = result["sfc_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["sfc_data_criacao"]);
                            retorno.sfc_id_segmento = result["sfc_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["sfc_id_segmento"]);
                            retorno.sfc_dispositivo = result["sfc_dispositivo"] is DBNull ? false : false; //verificar fosorio
                            retorno.sfc_ext_geometria = result["sfc_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["sfc_ext_geometria"]);

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

        public bool Inserir(SinalFaixaCentralLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_SINALFAIXACENTRALLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@sfc_km_inicial", domain.sfc_km_inicial));
                        command.Parameters.Add(new SqlParameter("@sfc_km_final", domain.sfc_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@sfc_data_levantamento", domain.sfc_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@sfc_extensao", domain.sfc_extensao));
                        command.Parameters.Add(new SqlParameter("@sht_id", domain.sht_id));
                        command.Parameters.Add(new SqlParameter("@sfc_largura_faixa", domain.sfc_largura_faixa));
                        command.Parameters.Add(new SqlParameter("@sfc_data_criacao", domain.sfc_data_criacao));
                        command.Parameters.Add(new SqlParameter("@sfc_id_segmento", domain.sfc_id_segmento));
                        command.Parameters.Add(new SqlParameter("@sfc_dispositivo", domain.sfc_dispositivo));
                        command.Parameters.Add(new SqlParameter("@sfc_ext_geometria", domain.sfc_ext_geometria));
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

        public bool Update(SinalFaixaCentralLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_SINALFAIXACENTRALLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@sfc_km_inicial", domain.sfc_km_inicial));
                        command.Parameters.Add(new SqlParameter("@sfc_km_final", domain.sfc_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@sfc_data_levantamento", domain.sfc_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@sfc_extensao", domain.sfc_extensao));
                        command.Parameters.Add(new SqlParameter("@sht_id", domain.sht_id));
                        command.Parameters.Add(new SqlParameter("@sfc_largura_faixa", domain.sfc_largura_faixa));
                        command.Parameters.Add(new SqlParameter("@sfc_data_criacao", domain.sfc_data_criacao));
                        command.Parameters.Add(new SqlParameter("@sfc_id_segmento", domain.sfc_id_segmento));
                        command.Parameters.Add(new SqlParameter("@sfc_dispositivo", domain.sfc_dispositivo));
                        command.Parameters.Add(new SqlParameter("@sfc_ext_geometria", domain.sfc_ext_geometria));
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

        public SinalFaixaCentralLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new SinalFaixaCentralLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_SINALFAIXACENTRALLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.sfc_km_inicial = result["sfc_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["sfc_km_inicial"]);
                            retorno.sfc_km_final = result["sfc_km_final"] is DBNull ? 0 : Convert.ToDouble(result["sfc_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.sfc_data_levantamento = result["sfc_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["sfc_data_levantamento"]);
                            retorno.sfc_extensao = result["sfc_extensao"] is DBNull ? 0 : Convert.ToDouble(result["sfc_extensao"]);
                            retorno.sht_id = result["sht_id"] is DBNull ? 0 : Convert.ToInt32(result["sht_id"]);
                            retorno.sfc_largura_faixa = result["sfc_largura_faixa"] is DBNull ? 0 : Convert.ToDouble(result["sfc_largura_faixa"]);
                            retorno.sfc_data_criacao = result["sfc_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["sfc_data_criacao"]);
                            retorno.sfc_id_segmento = result["sfc_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["sfc_id_segmento"]);
                            retorno.sfc_dispositivo = result["sfc_dispositivo"] is DBNull ? false : false; //verificar fosorio
                            retorno.sfc_ext_geometria = result["sfc_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["sfc_ext_geometria"]);
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

        public bool Delete(SinalFaixaCentralLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_SINALFAIXACENTRALLEVANTAMENTO", conn))
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