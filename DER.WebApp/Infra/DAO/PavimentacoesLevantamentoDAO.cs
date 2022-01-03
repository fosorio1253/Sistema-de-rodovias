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
    public class PavimentacoesLevantamentoDAO : BaseDAO<PavimentacoesLevantamento>
    {
        Logger logger;

        public PavimentacoesLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("PavimentacoesLevantamento", context);
        }

        public List<PavimentacoesLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<PavimentacoesLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PAVIMENTACOESLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new PavimentacoesLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.rpv_km_inicial = result["rpv_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["rpv_km_inicial"]);
                            retorno.rpv_km_final = result["rpv_km_final"] is DBNull ? 0 : Convert.ToDouble(result["rpv_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.rpv_data_levantamento = result["rpv_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["rpv_data_levantamento"]);
                            retorno.rev_id = result["rev_id"] is DBNull ? 0 : Convert.ToInt32(result["rev_id"]);
                            retorno.rpv_extensao = result["rpv_extensao"] is DBNull ? 0 : Convert.ToDouble(result["rpv_extensao"]);
                            retorno.rpv_data_criacao = result["rpv_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["rpv_data_criacao"]);
                            retorno.rpv_id_segmento = result["rpv_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["rpv_id_segmento"]);
                            retorno.rpv_dispositivo = result["rpv_dispositivo"] is DBNull ? false : false; //verificar fosorio
                            retorno.rpv_ext_geometria = result["rpv_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["rpv_ext_geometria"]);

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

        public bool Inserir(PavimentacoesLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_PAVIMENTACOESLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@rpv_km_inicial", domain.rpv_km_inicial));
                        command.Parameters.Add(new SqlParameter("@rpv_km_final", domain.rpv_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@rpv_data_levantamento", domain.rpv_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@rev_id", domain.rev_id));
                        command.Parameters.Add(new SqlParameter("@rpv_extensao", domain.rpv_extensao));
                        command.Parameters.Add(new SqlParameter("@rpv_data_criacao", domain.rpv_data_criacao));
                        command.Parameters.Add(new SqlParameter("@rpv_id_segmento", domain.rpv_id_segmento));
                        command.Parameters.Add(new SqlParameter("@rpv_dispositivo", domain.rpv_dispositivo));
                        command.Parameters.Add(new SqlParameter("@rpv_ext_geometria", domain.rpv_ext_geometria));
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

        public bool Update(PavimentacoesLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_PAVIMENTACOESLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@rpv_km_inicial", domain.rpv_km_inicial));
                        command.Parameters.Add(new SqlParameter("@rpv_km_final", domain.rpv_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@rpv_data_levantamento", domain.rpv_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@rev_id", domain.rev_id));
                        command.Parameters.Add(new SqlParameter("@rpv_extensao", domain.rpv_extensao));
                        command.Parameters.Add(new SqlParameter("@rpv_data_criacao", domain.rpv_data_criacao));
                        command.Parameters.Add(new SqlParameter("@rpv_id_segmento", domain.rpv_id_segmento));
                        command.Parameters.Add(new SqlParameter("@rpv_dispositivo", domain.rpv_dispositivo));
                        command.Parameters.Add(new SqlParameter("@rpv_ext_geometria", domain.rpv_ext_geometria));
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

        public PavimentacoesLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new PavimentacoesLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_PAVIMENTACOESLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.rpv_km_inicial = result["rpv_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["rpv_km_inicial"]);
                            retorno.rpv_km_final = result["rpv_km_final"] is DBNull ? 0 : Convert.ToDouble(result["rpv_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.rpv_data_levantamento = result["rpv_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["rpv_data_levantamento"]);
                            retorno.rev_id = result["rev_id"] is DBNull ? 0 : Convert.ToInt32(result["rev_id"]);
                            retorno.rpv_extensao = result["rpv_extensao"] is DBNull ? 0 : Convert.ToDouble(result["rpv_extensao"]);
                            retorno.rpv_data_criacao = result["rpv_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["rpv_data_criacao"]);
                            retorno.rpv_id_segmento = result["rpv_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["rpv_id_segmento"]);
                            retorno.rpv_dispositivo = result["rpv_dispositivo"] is DBNull ? false : false; //verificar fosorio
                            retorno.rpv_ext_geometria = result["rpv_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["rpv_ext_geometria"]);
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

        public bool Delete(PavimentacoesLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_PAVIMENTACOESLEVANTAMENTO", conn))
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