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
    public class TiposPistaLevantamentoDAO : BaseDAO<TiposPistaLevantamento>
    {
        Logger logger;

        public TiposPistaLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("TiposPistaLevantamento");
        }

        public List<TiposPistaLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<TiposPistaLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TIPOSPISTALEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new TiposPistaLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.rpt_km_inicial = result["rpt_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["rpt_km_inicial"]);
                            retorno.rpt_km_final = result["rpt_km_final"] is DBNull ? 0 : Convert.ToDouble(result["rpt_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.rpt_data_levantamento = result["rpt_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["rpt_data_levantamento"]);
                            retorno.rpt_extensao = result["rpt_extensao"] is DBNull ? 0 : Convert.ToDouble(result["rpt_extensao"]);
                            retorno.ptp_id = result["ptp_id"] is DBNull ? 0 : Convert.ToInt32(result["ptp_id"]);
                            retorno.rpt_data_criacao = result["rpt_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["rpt_data_criacao"]);
                            retorno.rpt_id_segmento = result["rpt_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["rpt_id_segmento"]);
                            retorno.rpt_dispositivo = result["rpt_dispositivo"] is DBNull ? false : false;// verificar fosorio
                            retorno.rpt_ext_geometria = result["rpt_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["rpt_ext_geometria"]);

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

        public bool Inserir(TiposPistaLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_TIPOSPISTALEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@rpt_km_inicial", domain.rpt_km_inicial));
                        command.Parameters.Add(new SqlParameter("@rpt_km_final", domain.rpt_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@rpt_data_levantamento", domain.rpt_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@rpt_extensao", domain.rpt_extensao));
                        command.Parameters.Add(new SqlParameter("@ptp_id", domain.ptp_id));
                        command.Parameters.Add(new SqlParameter("@rpt_data_criacao", domain.rpt_data_criacao));
                        command.Parameters.Add(new SqlParameter("@rpt_id_segmento", domain.rpt_id_segmento));
                        command.Parameters.Add(new SqlParameter("@rpt_dispositivo", domain.rpt_dispositivo));
                        command.Parameters.Add(new SqlParameter("@rpt_ext_geometria", domain.rpt_ext_geometria));
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

        public bool Update(TiposPistaLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_TIPOSPISTALEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@rpt_km_inicial", domain.rpt_km_inicial));
                        command.Parameters.Add(new SqlParameter("@rpt_km_final", domain.rpt_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@rpt_data_levantamento", domain.rpt_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@rpt_extensao", domain.rpt_extensao));
                        command.Parameters.Add(new SqlParameter("@ptp_id", domain.ptp_id));
                        command.Parameters.Add(new SqlParameter("@rpt_data_criacao", domain.rpt_data_criacao));
                        command.Parameters.Add(new SqlParameter("@rpt_id_segmento", domain.rpt_id_segmento));
                        command.Parameters.Add(new SqlParameter("@rpt_dispositivo", domain.rpt_dispositivo));
                        command.Parameters.Add(new SqlParameter("@rpt_ext_geometria", domain.rpt_ext_geometria));
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

        public TiposPistaLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new TiposPistaLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TIPOSPISTALEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.rpt_km_inicial = result["rpt_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["rpt_km_inicial"]);
                            retorno.rpt_km_final = result["rpt_km_final"] is DBNull ? 0 : Convert.ToDouble(result["rpt_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.rpt_data_levantamento = result["rpt_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["rpt_data_levantamento"]);
                            retorno.rpt_extensao = result["rpt_extensao"] is DBNull ? 0 : Convert.ToDouble(result["rpt_extensao"]);
                            retorno.ptp_id = result["ptp_id"] is DBNull ? 0 : Convert.ToInt32(result["ptp_id"]);
                            retorno.rpt_data_criacao = result["rpt_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["rpt_data_criacao"]);
                            retorno.rpt_id_segmento = result["rpt_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["rpt_id_segmento"]);
                            retorno.rpt_dispositivo = result["rpt_dispositivo"] is DBNull ? false : false;// verificar fosorio
                            retorno.rpt_ext_geometria = result["rpt_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["rpt_ext_geometria"]);
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

        public bool Delete(TiposPistaLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_TIPOSPISTALEVANTAMENTO", conn))
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