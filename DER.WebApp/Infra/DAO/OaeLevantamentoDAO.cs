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
    public class OaeLevantamentoDAO : BaseDAO<OaeLevantamento>
    {
        Logger logger;

        public OaeLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("OaeLevantamento", context);
        }

        public List<OaeLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<OaeLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_OAELEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new OaeLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.oae_km_inicial = result["oae_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["oae_km_inicial"]);
                            retorno.oae_km_final = result["oae_km_final"] is DBNull ? 0 : Convert.ToDouble(result["oae_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.oae_data_levantamento = result["oae_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["oae_data_levantamento"]);
                            retorno.oae_extensao = result["oae_extensao"] is DBNull ? 0 : Convert.ToDouble(result["oae_extensao"]);
                            retorno.oat_id = result["oat_id"] is DBNull ? 0 : Convert.ToInt32(result["oat_id"]);
                            retorno.oae_data_criacao = result["oae_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["oae_data_criacao"]);
                            retorno.oae_id_segmento = result["oae_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["oae_id_segmento"]);
                            retorno.oae_ext_geometria = result["oae_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["oae_ext_geometria"]);

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

        public bool Inserir(OaeLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_OAELEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@oae_km_inicial", domain.oae_km_inicial));
                        command.Parameters.Add(new SqlParameter("@oae_km_final", domain.oae_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@oae_data_levantamento", domain.oae_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@oae_extensao", domain.oae_extensao));
                        command.Parameters.Add(new SqlParameter("@oat_id", domain.oat_id));
                        command.Parameters.Add(new SqlParameter("@oae_data_criacao", domain.oae_data_criacao));
                        command.Parameters.Add(new SqlParameter("@oae_id_segmento", domain.oae_id_segmento));
                        command.Parameters.Add(new SqlParameter("@oae_ext_geometria", domain.oae_ext_geometria));
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

        public bool Update(OaeLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_OAELEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@oae_km_inicial", domain.oae_km_inicial));
                        command.Parameters.Add(new SqlParameter("@oae_km_final", domain.oae_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@oae_data_levantamento", domain.oae_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@oae_extensao", domain.oae_extensao));
                        command.Parameters.Add(new SqlParameter("@oat_id", domain.oat_id));
                        command.Parameters.Add(new SqlParameter("@oae_data_criacao", domain.oae_data_criacao));
                        command.Parameters.Add(new SqlParameter("@oae_id_segmento", domain.oae_id_segmento));
                        command.Parameters.Add(new SqlParameter("@oae_ext_geometria", domain.oae_ext_geometria));
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

        public OaeLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new OaeLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_OAELEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.oae_km_inicial = result["oae_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["oae_km_inicial"]);
                            retorno.oae_km_final = result["oae_km_final"] is DBNull ? 0 : Convert.ToDouble(result["oae_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.oae_data_levantamento = result["oae_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["oae_data_levantamento"]);
                            retorno.oae_extensao = result["oae_extensao"] is DBNull ? 0 : Convert.ToDouble(result["oae_extensao"]);
                            retorno.oat_id = result["oat_id"] is DBNull ? 0 : Convert.ToInt32(result["oat_id"]);
                            retorno.oae_data_criacao = result["oae_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["oae_data_criacao"]);
                            retorno.oae_id_segmento = result["oae_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["oae_id_segmento"]);
                            retorno.oae_ext_geometria = result["oae_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["oae_ext_geometria"]);
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

        public bool Delete(OaeLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_OAELEVANTAMENTO", conn))
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