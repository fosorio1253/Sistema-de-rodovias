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
    public class SegurancaGuardaCorpoEvantamentoDAO : BaseDAO<SegurancaGuardaCorpoEvantamento>
    {
        Logger logger;

        public SegurancaGuardaCorpoEvantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("SegurancaGuardaCorpoEvantamento", context);
        }

        public List<SegurancaGuardaCorpoEvantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<SegurancaGuardaCorpoEvantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_SEGURANCAGUARDACORPOEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new SegurancaGuardaCorpoEvantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.sgc_km_inicial = result["sgc_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["sgc_km_inicial"]);
                            retorno.sgc_km_final = result["sgc_km_final"] is DBNull ? 0 : Convert.ToDouble(result["sgc_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.sgc_data_levantamento = result["sgc_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["sgc_data_levantamento"]);
                            retorno.sgc_extensao = result["sgc_extensao"] is DBNull ? 0 : Convert.ToDouble(result["sgc_extensao"]);
                            retorno.mat_id = result["mat_id"] is DBNull ? 0 : Convert.ToInt32(result["mat_id"]);
                            retorno.sgc_data_criacao = result["sgc_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["sgc_data_criacao"]);
                            retorno.sgc_id_segmento = result["sgc_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["sgc_id_segmento"]);
                            retorno.sgc_dispositivo = result["sgc_dispositivo"] is DBNull ? string.Empty : result["sgc_dispositivo"].ToString();
                            retorno.sgc_ext_geometria = result["sgc_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["sgc_ext_geometria"]);

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

        public bool Inserir(SegurancaGuardaCorpoEvantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_SEGURANCAGUARDACORPOEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@sgc_km_inicial", domain.sgc_km_inicial));
                        command.Parameters.Add(new SqlParameter("@sgc_km_final", domain.sgc_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@sgc_data_levantamento", domain.sgc_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@sgc_extensao", domain.sgc_extensao));
                        command.Parameters.Add(new SqlParameter("@mat_id", domain.mat_id));
                        command.Parameters.Add(new SqlParameter("@sgc_data_criacao", domain.sgc_data_criacao));
                        command.Parameters.Add(new SqlParameter("@sgc_id_segmento", domain.sgc_id_segmento));
                        command.Parameters.Add(new SqlParameter("@sgc_dispositivo", domain.sgc_dispositivo));
                        command.Parameters.Add(new SqlParameter("@sgc_ext_geometria", domain.sgc_ext_geometria));
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

        public bool Update(SegurancaGuardaCorpoEvantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_SEGURANCAGUARDACORPOEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@sgc_km_inicial", domain.sgc_km_inicial));
                        command.Parameters.Add(new SqlParameter("@sgc_km_final", domain.sgc_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@sgc_data_levantamento", domain.sgc_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@sgc_extensao", domain.sgc_extensao));
                        command.Parameters.Add(new SqlParameter("@mat_id", domain.mat_id));
                        command.Parameters.Add(new SqlParameter("@sgc_data_criacao", domain.sgc_data_criacao));
                        command.Parameters.Add(new SqlParameter("@sgc_id_segmento", domain.sgc_id_segmento));
                        command.Parameters.Add(new SqlParameter("@sgc_dispositivo", domain.sgc_dispositivo));
                        command.Parameters.Add(new SqlParameter("@sgc_ext_geometria", domain.sgc_ext_geometria));
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

        public SegurancaGuardaCorpoEvantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new SegurancaGuardaCorpoEvantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_SEGURANCAGUARDACORPOEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.sgc_km_inicial = result["sgc_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["sgc_km_inicial"]);
                            retorno.sgc_km_final = result["sgc_km_final"] is DBNull ? 0 : Convert.ToDouble(result["sgc_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.sgc_data_levantamento = result["sgc_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["sgc_data_levantamento"]);
                            retorno.sgc_extensao = result["sgc_extensao"] is DBNull ? 0 : Convert.ToDouble(result["sgc_extensao"]);
                            retorno.mat_id = result["mat_id"] is DBNull ? 0 : Convert.ToInt32(result["mat_id"]);
                            retorno.sgc_data_criacao = result["sgc_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["sgc_data_criacao"]);
                            retorno.sgc_id_segmento = result["sgc_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["sgc_id_segmento"]);
                            retorno.sgc_dispositivo = result["sgc_dispositivo"] is DBNull ? string.Empty : result["sgc_dispositivo"].ToString();
                            retorno.sgc_ext_geometria = result["sgc_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["sgc_ext_geometria"]);
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

        public bool Delete(SegurancaGuardaCorpoEvantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_SEGURANCAGUARDACORPOEVANTAMENTO", conn))
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