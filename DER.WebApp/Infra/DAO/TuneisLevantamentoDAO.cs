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
    public class TuneisLevantamentoDAO : BaseDAO<TuneisLevantamento>
    {
        Logger logger;

        public TuneisLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("TuneisLevantamento");
        }

        public List<TuneisLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<TuneisLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TUNEISLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new TuneisLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.tun_km_inicial = result["tun_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["tun_km_inicial"]);
                            retorno.tun_km_final = result["tun_km_final"] is DBNull ? 0 : Convert.ToDouble(result["tun_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.tun_data_levantamento = result["tun_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["tun_data_levantamento"]);
                            retorno.tun_extensao = result["tun_extensao"] is DBNull ? 0 : Convert.ToDouble(result["tun_extensao"]);
                            retorno.tun_data_criacao = result["tun_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["tun_data_criacao"]);
                            retorno.tun_id_segmento = result["tun_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["tun_id_segmento"]);
                            retorno.tun_dispositivo = result["tun_dispositivo"] is DBNull ? false : false; // verificar fosorio
                            retorno.tun_ext_geometria = result["tun_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["tun_ext_geometria"]);

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

        public bool Inserir(TuneisLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_TUNEISLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@tun_km_inicial", domain.tun_km_inicial));
                        command.Parameters.Add(new SqlParameter("@tun_km_final", domain.tun_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@tun_data_levantamento", domain.tun_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@tun_extensao", domain.tun_extensao));
                        command.Parameters.Add(new SqlParameter("@tun_data_criacao", domain.tun_data_criacao));
                        command.Parameters.Add(new SqlParameter("@tun_id_segmento", domain.tun_id_segmento));
                        command.Parameters.Add(new SqlParameter("@tun_dispositivo", domain.tun_dispositivo));
                        command.Parameters.Add(new SqlParameter("@tun_ext_geometria", domain.tun_ext_geometria));
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

        public bool Update(TuneisLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_TUNEISLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@tun_km_inicial", domain.tun_km_inicial));
                        command.Parameters.Add(new SqlParameter("@tun_km_final", domain.tun_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@tun_data_levantamento", domain.tun_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@tun_extensao", domain.tun_extensao));
                        command.Parameters.Add(new SqlParameter("@tun_data_criacao", domain.tun_data_criacao));
                        command.Parameters.Add(new SqlParameter("@tun_id_segmento", domain.tun_id_segmento));
                        command.Parameters.Add(new SqlParameter("@tun_dispositivo", domain.tun_dispositivo));
                        command.Parameters.Add(new SqlParameter("@tun_ext_geometria", domain.tun_ext_geometria));
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

        public TuneisLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new TuneisLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TUNEISLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.tun_km_inicial = result["tun_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["tun_km_inicial"]);
                            retorno.tun_km_final = result["tun_km_final"] is DBNull ? 0 : Convert.ToDouble(result["tun_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.tun_data_levantamento = result["tun_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["tun_data_levantamento"]);
                            retorno.tun_extensao = result["tun_extensao"] is DBNull ? 0 : Convert.ToDouble(result["tun_extensao"]);
                            retorno.tun_data_criacao = result["tun_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["tun_data_criacao"]);
                            retorno.tun_id_segmento = result["tun_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["tun_id_segmento"]);
                            retorno.tun_dispositivo = result["tun_dispositivo"] is DBNull ? false : false; // verificar fosorio
                            retorno.tun_ext_geometria = result["tun_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["tun_ext_geometria"]);
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

        public bool Delete(TuneisLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_TUNEISLEVANTAMENTO", conn))
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