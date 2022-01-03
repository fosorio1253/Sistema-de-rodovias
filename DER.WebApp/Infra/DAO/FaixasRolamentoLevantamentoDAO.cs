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
    public class FaixasRolamentoLevantamentoDAO : BaseDAO<FaixasRolamentoLevantamento>
    {
        Logger logger;

        public FaixasRolamentoLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("FaixasRolamentoLevantamento", context);
        }

        public List<FaixasRolamentoLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<FaixasRolamentoLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_FAIXASROLAMENTOLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new FaixasRolamentoLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.frl_km_inicial = result["frl_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["frl_km_inicial"]);
                            retorno.frl_km_final = result["frl_km_final"] is DBNull ? 0 : Convert.ToDouble(result["frl_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.frl_data_levantamento = result["frl_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["frl_data_levantamento"]);
                            retorno.frl_extensao = result["frl_extensao"] is DBNull ? 0 : Convert.ToDouble(result["frl_extensao"]);
                            retorno.frl_num_faixas = result["frl_num_faixas"] is DBNull ? 0 : Convert.ToDouble(result["frl_num_faixas"]);
                            retorno.frl_data_criacao = result["frl_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["frl_data_criacao"]);
                            retorno.frl_id_segmento = result["frl_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["frl_id_segmento"]);
                            retorno.frl_dispositivo = result["frl_dispositivo"] is DBNull ? false : false;//verificar fosorio
                            retorno.frl_ext_geometria = result["frl_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["frl_ext_geometria"]);

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

        public bool Inserir(FaixasRolamentoLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_FAIXASROLAMENTOLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@frl_km_inicial", domain.frl_km_inicial));
                        command.Parameters.Add(new SqlParameter("@frl_km_final", domain.frl_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@frl_data_levantamento", domain.frl_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@frl_extensao", domain.frl_extensao));
                        command.Parameters.Add(new SqlParameter("@frl_num_faixas", domain.frl_num_faixas));
                        command.Parameters.Add(new SqlParameter("@frl_data_criacao", domain.frl_data_criacao));
                        command.Parameters.Add(new SqlParameter("@frl_id_segmento", domain.frl_id_segmento));
                        command.Parameters.Add(new SqlParameter("@frl_dispositivo", domain.frl_dispositivo));
                        command.Parameters.Add(new SqlParameter("@frl_ext_geometria", domain.frl_ext_geometria));
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

        public bool Update(FaixasRolamentoLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_FAIXASROLAMENTOLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@frl_km_inicial", domain.frl_km_inicial));
                        command.Parameters.Add(new SqlParameter("@frl_km_final", domain.frl_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@frl_data_levantamento", domain.frl_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@frl_extensao", domain.frl_extensao));
                        command.Parameters.Add(new SqlParameter("@frl_num_faixas", domain.frl_num_faixas));
                        command.Parameters.Add(new SqlParameter("@frl_data_criacao", domain.frl_data_criacao));
                        command.Parameters.Add(new SqlParameter("@frl_id_segmento", domain.frl_id_segmento));
                        command.Parameters.Add(new SqlParameter("@frl_dispositivo", domain.frl_dispositivo));
                        command.Parameters.Add(new SqlParameter("@frl_ext_geometria", domain.frl_ext_geometria));
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

        public FaixasRolamentoLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new FaixasRolamentoLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_FAIXASROLAMENTOLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.frl_km_inicial = result["frl_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["frl_km_inicial"]);
                            retorno.frl_km_final = result["frl_km_final"] is DBNull ? 0 : Convert.ToDouble(result["frl_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.frl_data_levantamento = result["frl_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["frl_data_levantamento"]);
                            retorno.frl_extensao = result["frl_extensao"] is DBNull ? 0 : Convert.ToDouble(result["frl_extensao"]);
                            retorno.frl_num_faixas = result["frl_num_faixas"] is DBNull ? 0 : Convert.ToDouble(result["frl_num_faixas"]);
                            retorno.frl_data_criacao = result["frl_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["frl_data_criacao"]);
                            retorno.frl_id_segmento = result["frl_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["frl_id_segmento"]);
                            retorno.frl_dispositivo = result["frl_dispositivo"] is DBNull ? false : false;//verificar fosorio
                            retorno.frl_ext_geometria = result["frl_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["frl_ext_geometria"]);
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

        public bool Delete(FaixasRolamentoLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_FAIXASROLAMENTOLEVANTAMENTO", conn))
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