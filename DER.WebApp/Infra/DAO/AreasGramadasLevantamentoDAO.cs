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
    public class AreasGramadasLevantamentoDAO : BaseDAO<AreasGramadasLevantamento>
    {
        Logger logger;

        public AreasGramadasLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("AreasGramadasLevantamento", context);
        }

        public List<AreasGramadasLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<AreasGramadasLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_AREASGRAMADASLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new AreasGramadasLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.agr_km_inicial = result["agr_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["agr_km_inicial"]);
                            retorno.agr_km_final = result["agr_km_final"] is DBNull ? 0 : Convert.ToDouble(result["agr_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.agr_data_levantamento = result["agr_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["agr_data_levantamento"]);
                            retorno.agr_extensao = result["agr_extensao"] is DBNull ? 0 : Convert.ToDouble(result["agr_extensao"]);
                            retorno.agr_largura = result["agr_largura"] is DBNull ? 0 : Convert.ToDouble(result["agr_largura"]);
                            retorno.agr_id_segmento = result["agr_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["agr_id_segmento"]);
                            retorno.agr_dispositivo = result["agr_dispositivo"] is DBNull ? false : false;// verifificar fosorio
                            retorno.agr_ext_geometria = result["agr_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["agr_ext_geometria"]);
                            retorno.agr_data_criacao = result["agr_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["agr_data_criacao"]);

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

        public bool Inserir(AreasGramadasLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_AREASGRAMADASLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@agr_km_inicial", domain.agr_km_inicial));
                        command.Parameters.Add(new SqlParameter("@agr_km_final", domain.agr_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@agr_data_levantamento", domain.agr_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@agr_extensao", domain.agr_extensao));
                        command.Parameters.Add(new SqlParameter("@agr_largura", domain.agr_largura));
                        command.Parameters.Add(new SqlParameter("@agr_id_segmento", domain.agr_id_segmento));
                        command.Parameters.Add(new SqlParameter("@agr_dispositivo", domain.agr_dispositivo));
                        command.Parameters.Add(new SqlParameter("@agr_ext_geometria", domain.agr_ext_geometria));
                        command.Parameters.Add(new SqlParameter("@agr_data_criacao", domain.agr_data_criacao));
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

        public bool Update(AreasGramadasLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_AREASGRAMADASLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@agr_km_inicial", domain.agr_km_inicial));
                        command.Parameters.Add(new SqlParameter("@agr_km_final", domain.agr_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@agr_data_levantamento", domain.agr_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@agr_extensao", domain.agr_extensao));
                        command.Parameters.Add(new SqlParameter("@agr_largura", domain.agr_largura));
                        command.Parameters.Add(new SqlParameter("@agr_id_segmento", domain.agr_id_segmento));
                        command.Parameters.Add(new SqlParameter("@agr_dispositivo", domain.agr_dispositivo));
                        command.Parameters.Add(new SqlParameter("@agr_ext_geometria", domain.agr_ext_geometria));
                        command.Parameters.Add(new SqlParameter("@agr_data_criacao", domain.agr_data_criacao));
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

        public AreasGramadasLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new AreasGramadasLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_AREASGRAMADASLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.agr_km_inicial = result["agr_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["agr_km_inicial"]);
                            retorno.agr_km_final = result["agr_km_final"] is DBNull ? 0 : Convert.ToDouble(result["agr_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.agr_data_levantamento = result["agr_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["agr_data_levantamento"]);
                            retorno.agr_extensao = result["agr_extensao"] is DBNull ? 0 : Convert.ToDouble(result["agr_extensao"]);
                            retorno.agr_largura = result["agr_largura"] is DBNull ? 0 : Convert.ToDouble(result["agr_largura"]);
                            retorno.agr_id_segmento = result["agr_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["agr_id_segmento"]);
                            retorno.agr_dispositivo = result["agr_dispositivo"] is DBNull ? false : false;// verifificar fosorio
                            retorno.agr_ext_geometria = result["agr_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["agr_ext_geometria"]);
                            retorno.agr_data_criacao = result["agr_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["agr_data_criacao"]);
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

        public bool Delete(AreasGramadasLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_AREASGRAMADASLEVANTAMENTO", conn))
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