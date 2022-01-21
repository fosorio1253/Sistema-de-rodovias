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
    public class SinalFaixaBordoLevantamentoDAO : BaseDAO<SinalFaixaBordoLevantamento>
    {
        Logger logger;

        public SinalFaixaBordoLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("SinalFaixaBordoLevantamento");
        }

        public List<SinalFaixaBordoLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<SinalFaixaBordoLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_SINALFAIXABORDOLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new SinalFaixaBordoLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.sfb_km_inicial = result["sfb_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["sfb_km_inicial"]);
                            retorno.sfb_km_final = result["sfb_km_final"] is DBNull ? 0 : Convert.ToDouble(result["sfb_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.sfb_data_levantamento = result["sfb_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["sfb_data_levantamento"]);
                            retorno.sfb_extensao = result["sfb_extensao"] is DBNull ? 0 : Convert.ToInt32(result["sfb_extensao"]);
                            retorno.sht_id = result["sht_id"] is DBNull ? 0 : Convert.ToInt32(result["sht_id"]);
                            retorno.sfb_largura_faixa = result["sfb_largura_faixa"] is DBNull ? 0 : Convert.ToInt32(result["sfb_largura_faixa"]);
                            retorno.sfb_data_criacao = result["sfb_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["sfb_data_criacao"]);
                            retorno.sfb_id_segmento = result["sfb_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["sfb_id_segmento"]);
                            retorno.sfb_dispositivo = result["sfb_dispositivo"] is DBNull ? false : false; //verificar fosorio
                            retorno.sfb_ext_geometria = result["sfb_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["sfb_ext_geometria"]);

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

        public bool Inserir(SinalFaixaBordoLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_SINALFAIXABORDOLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@sfb_km_inicial", domain.sfb_km_inicial));
                        command.Parameters.Add(new SqlParameter("@sfb_km_final", domain.sfb_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@sfb_data_levantamento", domain.sfb_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@sfb_extensao", domain.sfb_extensao));
                        command.Parameters.Add(new SqlParameter("@sht_id", domain.sht_id));
                        command.Parameters.Add(new SqlParameter("@sfb_largura_faixa", domain.sfb_largura_faixa));
                        command.Parameters.Add(new SqlParameter("@sfb_data_criacao", domain.sfb_data_criacao));
                        command.Parameters.Add(new SqlParameter("@sfb_id_segmento", domain.sfb_id_segmento));
                        command.Parameters.Add(new SqlParameter("@sfb_dispositivo", domain.sfb_dispositivo));
                        command.Parameters.Add(new SqlParameter("@sfb_ext_geometria", domain.sfb_ext_geometria));
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

        public bool Update(SinalFaixaBordoLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_SINALFAIXABORDOLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@sfb_km_inicial", domain.sfb_km_inicial));
                        command.Parameters.Add(new SqlParameter("@sfb_km_final", domain.sfb_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@sfb_data_levantamento", domain.sfb_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@sfb_extensao", domain.sfb_extensao));
                        command.Parameters.Add(new SqlParameter("@sht_id", domain.sht_id));
                        command.Parameters.Add(new SqlParameter("@sfb_largura_faixa", domain.sfb_largura_faixa));
                        command.Parameters.Add(new SqlParameter("@sfb_data_criacao", domain.sfb_data_criacao));
                        command.Parameters.Add(new SqlParameter("@sfb_id_segmento", domain.sfb_id_segmento));
                        command.Parameters.Add(new SqlParameter("@sfb_dispositivo", domain.sfb_dispositivo));
                        command.Parameters.Add(new SqlParameter("@sfb_ext_geometria", domain.sfb_ext_geometria));
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

        public SinalFaixaBordoLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new SinalFaixaBordoLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_SINALFAIXABORDOLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.sfb_km_inicial = result["sfb_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["sfb_km_inicial"]);
                            retorno.sfb_km_final = result["sfb_km_final"] is DBNull ? 0 : Convert.ToDouble(result["sfb_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.sfb_data_levantamento = result["sfb_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["sfb_data_levantamento"]);
                            retorno.sfb_extensao = result["sfb_extensao"] is DBNull ? 0 : Convert.ToInt32(result["sfb_extensao"]);
                            retorno.sht_id = result["sht_id"] is DBNull ? 0 : Convert.ToInt32(result["sht_id"]);
                            retorno.sfb_largura_faixa = result["sfb_largura_faixa"] is DBNull ? 0 : Convert.ToInt32(result["sfb_largura_faixa"]);
                            retorno.sfb_data_criacao = result["sfb_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["sfb_data_criacao"]);
                            retorno.sfb_id_segmento = result["sfb_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["sfb_id_segmento"]);
                            retorno.sfb_dispositivo = result["sfb_dispositivo"] is DBNull ? false : false; //verificar fosorio
                            retorno.sfb_ext_geometria = result["sfb_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["sfb_ext_geometria"]);
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

        public bool Delete(SinalFaixaBordoLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_SINALFAIXABORDOLEVANTAMENTO", conn))
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