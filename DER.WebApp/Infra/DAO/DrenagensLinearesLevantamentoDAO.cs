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
    public class DrenagensLinearesLevantamentoDAO : BaseDAO<DrenagensLinearesLevantamento>
    {
        Logger logger;

        public DrenagensLinearesLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("DrenagensLinearesLevantamento");
        }

        public List<DrenagensLinearesLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<DrenagensLinearesLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DRENAGENSLINEARESLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new DrenagensLinearesLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.drl_km_inicial = result["drl_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["drl_km_inicial"]);
                            retorno.drl_km_final = result["drl_km_final"] is DBNull ? 0 : Convert.ToDouble(result["drl_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.drl_data_levantamento = result["drl_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["drl_data_levantamento"]);
                            retorno.drl_extensao = result["drl_extensao"] is DBNull ? 0 : Convert.ToDouble(result["drl_extensao"]);
                            retorno.drt_id = result["drt_id"] is DBNull ? 0 : Convert.ToInt32(result["drt_id"]);
                            retorno.drl_data_criacao = result["drl_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["drl_data_criacao"]);
                            retorno.drl_id_segmento = result["drl_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["drl_id_segmento"]);
                            retorno.drl_dispositivo = result["drl_dispositivo"] is DBNull ? false : false; // verificar fabio
                            retorno.drl_ext_geometria = result["drl_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["drl_ext_geometria"]);

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

        public bool Inserir(DrenagensLinearesLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_DRENAGENSLINEARESLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@drl_km_inicial", domain.drl_km_inicial));
                        command.Parameters.Add(new SqlParameter("@drl_km_final", domain.drl_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@drl_data_levantamento", domain.drl_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@drl_extensao", domain.drl_extensao));
                        command.Parameters.Add(new SqlParameter("@drt_id", domain.drt_id));
                        command.Parameters.Add(new SqlParameter("@drl_data_criacao", domain.drl_data_criacao));
                        command.Parameters.Add(new SqlParameter("@drl_id_segmento", domain.drl_id_segmento));
                        command.Parameters.Add(new SqlParameter("@drl_dispositivo", domain.drl_dispositivo));
                        command.Parameters.Add(new SqlParameter("@drl_ext_geometria", domain.drl_ext_geometria));
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

        public bool Update(DrenagensLinearesLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_DRENAGENSLINEARESLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@drl_km_inicial", domain.drl_km_inicial));
                        command.Parameters.Add(new SqlParameter("@drl_km_final", domain.drl_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@drl_data_levantamento", domain.drl_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@drl_extensao", domain.drl_extensao));
                        command.Parameters.Add(new SqlParameter("@drt_id", domain.drt_id));
                        command.Parameters.Add(new SqlParameter("@drl_data_criacao", domain.drl_data_criacao));
                        command.Parameters.Add(new SqlParameter("@drl_id_segmento", domain.drl_id_segmento));
                        command.Parameters.Add(new SqlParameter("@drl_dispositivo", domain.drl_dispositivo));
                        command.Parameters.Add(new SqlParameter("@drl_ext_geometria", domain.drl_ext_geometria));
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

        public DrenagensLinearesLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new DrenagensLinearesLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DRENAGENSLINEARESLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.drl_km_inicial = result["drl_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["drl_km_inicial"]);
                            retorno.drl_km_final = result["drl_km_final"] is DBNull ? 0 : Convert.ToDouble(result["drl_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.drl_data_levantamento = result["drl_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["drl_data_levantamento"]);
                            retorno.drl_extensao = result["drl_extensao"] is DBNull ? 0 : Convert.ToDouble(result["drl_extensao"]);
                            retorno.drt_id = result["drt_id"] is DBNull ? 0 : Convert.ToInt32(result["drt_id"]);
                            retorno.drl_data_criacao = result["drl_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["drl_data_criacao"]);
                            retorno.drl_id_segmento = result["drl_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["drl_id_segmento"]);
                            retorno.drl_dispositivo = result["drl_dispositivo"] is DBNull ? false : false; // verificar fabio
                            retorno.drl_ext_geometria = result["drl_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["drl_ext_geometria"]);
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

        public bool Delete(DrenagensLinearesLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_DRENAGENSLINEARESLEVANTAMENTO", conn))
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