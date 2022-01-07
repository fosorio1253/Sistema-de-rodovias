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
    public class TerceiraFaixaLevantamentoDAO : BaseDAO<TerceiraFaixaLevantamento>
    {
        Logger logger;

        public TerceiraFaixaLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("TerceiraFaixaLevantamento", context);
        }

        public List<TerceiraFaixaLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<TerceiraFaixaLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TERCEIRAFAIXALEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new TerceiraFaixaLevantamento();
                            retorno.terceira_faixa_levantamento_id = result["terceira_faixa_levantamento_id"] is DBNull ? 0 : Convert.ToInt32(result["terceira_faixa_levantamento_id"]);
                            retorno.tfx_km_inicial = result["tfx_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["tfx_km_inicial"]);
                            retorno.tfx_km_final = result["tfx_km_final"] is DBNull ? 0 : Convert.ToDouble(result["tfx_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.tfx_data_levantamento = result["tfx_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["tfx_data_levantamento"]);
                            retorno.tfx_extensao = result["tfx_extensao"] is DBNull ? 0 : Convert.ToDouble(result["tfx_extensao"]);
                            retorno.tfx_data_criacao = result["tfx_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["tfx_data_criacao"]);
                            retorno.tfx_id_segmento = result["tfx_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["tfx_id_segmento"]);
                            retorno.tfx_dispositivo = result["tfx_dispositivo"] is DBNull ? false : false;//verificar fosorio
                            retorno.tfx_ext_geometria = result["tfx_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["tfx_ext_geometria"]);

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

        public bool Inserir(TerceiraFaixaLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_TERCEIRAFAIXALEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@terceira_faixa_levantamento_id", domain.terceira_faixa_levantamento_id));
                        command.Parameters.Add(new SqlParameter("@tfx_km_inicial", domain.tfx_km_inicial));
                        command.Parameters.Add(new SqlParameter("@tfx_km_final", domain.tfx_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@tfx_data_levantamento", domain.tfx_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@tfx_extensao", domain.tfx_extensao));
                        command.Parameters.Add(new SqlParameter("@tfx_data_criacao", domain.tfx_data_criacao));
                        command.Parameters.Add(new SqlParameter("@tfx_id_segmento", domain.tfx_id_segmento));
                        command.Parameters.Add(new SqlParameter("@tfx_dispositivo", domain.tfx_dispositivo));
                        command.Parameters.Add(new SqlParameter("@tfx_ext_geometria", domain.tfx_ext_geometria));
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

        public bool Update(TerceiraFaixaLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.terceira_faixa_levantamento_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_TERCEIRAFAIXALEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@terceira_faixa_levantamento_id", domain.terceira_faixa_levantamento_id));
                        command.Parameters.Add(new SqlParameter("@tfx_km_inicial", domain.tfx_km_inicial));
                        command.Parameters.Add(new SqlParameter("@tfx_km_final", domain.tfx_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@tfx_data_levantamento", domain.tfx_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@tfx_extensao", domain.tfx_extensao));
                        command.Parameters.Add(new SqlParameter("@tfx_data_criacao", domain.tfx_data_criacao));
                        command.Parameters.Add(new SqlParameter("@tfx_id_segmento", domain.tfx_id_segmento));
                        command.Parameters.Add(new SqlParameter("@tfx_dispositivo", domain.tfx_dispositivo));
                        command.Parameters.Add(new SqlParameter("@tfx_ext_geometria", domain.tfx_ext_geometria));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.terceira_faixa_levantamento_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.terceira_faixa_levantamento_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TerceiraFaixaLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new TerceiraFaixaLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TERCEIRAFAIXALEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.terceira_faixa_levantamento_id = result["terceira_faixa_levantamento_id"] is DBNull ? 0 : Convert.ToInt32(result["terceira_faixa_levantamento_id"]);
                            retorno.tfx_km_inicial = result["tfx_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["tfx_km_inicial"]);
                            retorno.tfx_km_final = result["tfx_km_final"] is DBNull ? 0 : Convert.ToDouble(result["tfx_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.tfx_data_levantamento = result["tfx_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["tfx_data_levantamento"]);
                            retorno.tfx_extensao = result["tfx_extensao"] is DBNull ? 0 : Convert.ToDouble(result["tfx_extensao"]);
                            retorno.tfx_data_criacao = result["tfx_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["tfx_data_criacao"]);
                            retorno.tfx_id_segmento = result["tfx_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["tfx_id_segmento"]);
                            retorno.tfx_dispositivo = result["tfx_dispositivo"] is DBNull ? false : false;//verificar fosorio
                            retorno.tfx_ext_geometria = result["tfx_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["tfx_ext_geometria"]);
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

        public bool Delete(TerceiraFaixaLevantamento model)
        {
            var oldValue = GetById(model.terceira_faixa_levantamento_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_TERCEIRAFAIXALEVANTAMENTO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@terceira_faixa_levantamento_id", model.terceira_faixa_levantamento_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.terceira_faixa_levantamento_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}