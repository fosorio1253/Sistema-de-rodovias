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
    public class TachaFaixaBordoLevantamentoDAO : BaseDAO<TachaFaixaBordoLevantamento>
    {
        Logger logger;

        public TachaFaixaBordoLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("TachaFaixaBordoLevantamento", context);
        }

        public List<TachaFaixaBordoLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<TachaFaixaBordoLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TACHAFAIXABORDOLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new TachaFaixaBordoLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.tfb_km_inicial = result["tfb_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["tfb_km_inicial"]);
                            retorno.tfb_km_final = result["tfb_km_final"] is DBNull ? 0 : Convert.ToDouble(result["tfb_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.tfb_data_levantamento = result["tfb_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["tfb_data_levantamento"]);
                            retorno.tfb_extensao = result["tfb_extensao"] is DBNull ? 0 : Convert.ToDouble(result["tfb_extensao"]);
                            retorno.sht_id = result["sht_id"] is DBNull ? 0 : Convert.ToInt32(result["sht_id"]);
                            retorno.tfb_quantidade = result["tfb_quantidade"] is DBNull ? 0 : Convert.ToDouble(result["tfb_quantidade"]);
                            retorno.tfb_data_criacao = result["tfb_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["tfb_data_criacao"]);
                            retorno.tfb_id_segmento = result["tfb_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["tfb_id_segmento"]);
                            retorno.tfb_dispositivo = result["tfb_dispositivo"] is DBNull ? false : false;//verificar fosorio
                            retorno.tfb_ext_geometria = result["tfb_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["tfb_ext_geometria"]);

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

        public bool Inserir(TachaFaixaBordoLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_TACHAFAIXABORDOLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@tfb_km_inicial", domain.tfb_km_inicial));
                        command.Parameters.Add(new SqlParameter("@tfb_km_final", domain.tfb_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@tfb_data_levantamento", domain.tfb_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@tfb_extensao", domain.tfb_extensao));
                        command.Parameters.Add(new SqlParameter("@sht_id", domain.sht_id));
                        command.Parameters.Add(new SqlParameter("@tfb_quantidade", domain.tfb_quantidade));
                        command.Parameters.Add(new SqlParameter("@tfb_data_criacao", domain.tfb_data_criacao));
                        command.Parameters.Add(new SqlParameter("@tfb_id_segmento", domain.tfb_id_segmento));
                        command.Parameters.Add(new SqlParameter("@tfb_dispositivo", domain.tfb_dispositivo));
                        command.Parameters.Add(new SqlParameter("@tfb_ext_geometria", domain.tfb_ext_geometria));
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

        public bool Update(TachaFaixaBordoLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_TACHAFAIXABORDOLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@tfb_km_inicial", domain.tfb_km_inicial));
                        command.Parameters.Add(new SqlParameter("@tfb_km_final", domain.tfb_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@tfb_data_levantamento", domain.tfb_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@tfb_extensao", domain.tfb_extensao));
                        command.Parameters.Add(new SqlParameter("@sht_id", domain.sht_id));
                        command.Parameters.Add(new SqlParameter("@tfb_quantidade", domain.tfb_quantidade));
                        command.Parameters.Add(new SqlParameter("@tfb_data_criacao", domain.tfb_data_criacao));
                        command.Parameters.Add(new SqlParameter("@tfb_id_segmento", domain.tfb_id_segmento));
                        command.Parameters.Add(new SqlParameter("@tfb_dispositivo", domain.tfb_dispositivo));
                        command.Parameters.Add(new SqlParameter("@tfb_ext_geometria", domain.tfb_ext_geometria));
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

        public TachaFaixaBordoLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new TachaFaixaBordoLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TACHAFAIXABORDOLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.tfb_km_inicial = result["tfb_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["tfb_km_inicial"]);
                            retorno.tfb_km_final = result["tfb_km_final"] is DBNull ? 0 : Convert.ToDouble(result["tfb_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.tfb_data_levantamento = result["tfb_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["tfb_data_levantamento"]);
                            retorno.tfb_extensao = result["tfb_extensao"] is DBNull ? 0 : Convert.ToDouble(result["tfb_extensao"]);
                            retorno.sht_id = result["sht_id"] is DBNull ? 0 : Convert.ToInt32(result["sht_id"]);
                            retorno.tfb_quantidade = result["tfb_quantidade"] is DBNull ? 0 : Convert.ToDouble(result["tfb_quantidade"]);
                            retorno.tfb_data_criacao = result["tfb_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["tfb_data_criacao"]);
                            retorno.tfb_id_segmento = result["tfb_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["tfb_id_segmento"]);
                            retorno.tfb_dispositivo = result["tfb_dispositivo"] is DBNull ? false : false;//verificar fosorio
                            retorno.tfb_ext_geometria = result["tfb_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["tfb_ext_geometria"]);
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

        public bool Delete(TachaFaixaBordoLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_TACHAFAIXABORDOLEVANTAMENTO", conn))
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