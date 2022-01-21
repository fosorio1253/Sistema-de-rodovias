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
    public class CercasLevantamentoDAO : BaseDAO<CercasLevantamento>
    {
        Logger logger;

        public CercasLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("CercasLevantamento");
        }

        public List<CercasLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<CercasLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_CERCASLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new CercasLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.cer_km_inicial = result["cer_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["cer_km_inicial"]);
                            retorno.cer_km_final = result["cer_km_final"] is DBNull ? 0 : Convert.ToDouble(result["cer_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.cer_data_levantamento = result["cer_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["cer_data_levantamento"]);
                            retorno.cer_extensao = result["cer_extensao"] is DBNull ? 0 : Convert.ToDouble(result["cer_extensao"]);
                            retorno.cer_distancia_eixo = result["cer_distancia_eixo"] is DBNull ? 0 : Convert.ToDouble(result["cer_distancia_eixo"]);
                            retorno.cer_data_criacao = result["cer_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["cer_data_criacao"]);
                            retorno.cer_id_segmento = result["cer_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["cer_id_segmento"]);
                            retorno.cer_dispositivo = result["cer_dispositivo"] is DBNull ? false : false; //verificar fosorio
                            retorno.cer_ext_geometria = result["cer_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["cer_ext_geometria"]);

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

        public bool Inserir(CercasLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_CERCASLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@cer_km_inicial", domain.cer_km_inicial));
                        command.Parameters.Add(new SqlParameter("@cer_km_final", domain.cer_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@cer_data_levantamento", domain.cer_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@cer_extensao", domain.cer_extensao));
                        command.Parameters.Add(new SqlParameter("@cer_distancia_eixo", domain.cer_distancia_eixo));
                        command.Parameters.Add(new SqlParameter("@cer_data_criacao", domain.cer_data_criacao));
                        command.Parameters.Add(new SqlParameter("@cer_id_segmento", domain.cer_id_segmento));
                        command.Parameters.Add(new SqlParameter("@cer_dispositivo", domain.cer_dispositivo));
                        command.Parameters.Add(new SqlParameter("@cer_ext_geometria", domain.cer_ext_geometria));
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

        public bool Update(CercasLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_CERCASLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@cer_km_inicial", domain.cer_km_inicial));
                        command.Parameters.Add(new SqlParameter("@cer_km_final", domain.cer_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@cer_data_levantamento", domain.cer_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@cer_extensao", domain.cer_extensao));
                        command.Parameters.Add(new SqlParameter("@cer_distancia_eixo", domain.cer_distancia_eixo));
                        command.Parameters.Add(new SqlParameter("@cer_data_criacao", domain.cer_data_criacao));
                        command.Parameters.Add(new SqlParameter("@cer_id_segmento", domain.cer_id_segmento));
                        command.Parameters.Add(new SqlParameter("@cer_dispositivo", domain.cer_dispositivo));
                        command.Parameters.Add(new SqlParameter("@cer_ext_geometria", domain.cer_ext_geometria));
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

        public CercasLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new CercasLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_CERCASLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.cer_km_inicial = result["cer_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["cer_km_inicial"]);
                            retorno.cer_km_final = result["cer_km_final"] is DBNull ? 0 : Convert.ToDouble(result["cer_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.cer_data_levantamento = result["cer_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["cer_data_levantamento"]);
                            retorno.cer_extensao = result["cer_extensao"] is DBNull ? 0 : Convert.ToDouble(result["cer_extensao"]);
                            retorno.cer_distancia_eixo = result["cer_distancia_eixo"] is DBNull ? 0 : Convert.ToDouble(result["cer_distancia_eixo"]);
                            retorno.cer_data_criacao = result["cer_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["cer_data_criacao"]);
                            retorno.cer_id_segmento = result["cer_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["cer_id_segmento"]);
                            retorno.cer_dispositivo = result["cer_dispositivo"] is DBNull ? false : false; //verificar fosorio
                            retorno.cer_ext_geometria = result["cer_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["cer_ext_geometria"]);
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

        public bool Delete(CercasLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_CERCASLEVANTAMENTO", conn))
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