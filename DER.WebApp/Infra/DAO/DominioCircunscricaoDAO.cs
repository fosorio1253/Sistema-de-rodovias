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
    public class DominioCircunscricaoDAO : BaseDAO<DominioCircunscricao>
    {
        Logger logger;

        public DominioCircunscricaoDAO(DerContext context) : base(context)
        {
            logger = new Logger("DominioCircunscricao");
        }

        public List<DominioCircunscricao> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<DominioCircunscricao>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOCIRCUNSCRICAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new DominioCircunscricao();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.cer_km_inicial = result["cer_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["cer_km_inicial"]);
                            retorno.cer_km_final = result["cer_km_final"] is DBNull ? 0 : Convert.ToDouble(result["cer_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.cer_data_levantamento = result["cer_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["cer_data_levantamento"]);
                            retorno.cer_extensao = result["cer_extensao"] is DBNull ? 0 : Convert.ToDouble(result["cer_extensao"]);
                            retorno.cer_distancia_eixo = result["cer_distancia_eixo"] is DBNull ? 0 : Convert.ToDouble(result["cer_distancia_eixo"]);
                            retorno.cer_data_criacao = result["cer_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["cer_data_criacao"]);
                            retorno.cer_id_segmento = result["cer_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["cer_id_segmento"]);
                            retorno.cer_dispositivo = result["cer_dispositivo"] is DBNull ? 0 : Convert.ToDouble(result["cer_dispositivo"]);

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

        public bool Inserir(DominioCircunscricao domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_DOMINIOCIRCUNSCRICAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@cer_km_inicial", domain.cer_km_inicial));
                        command.Parameters.Add(new SqlParameter("@cer_km_final", domain.cer_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@cer_data_levantamento", domain.cer_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@cer_extensao", domain.cer_extensao));
                        command.Parameters.Add(new SqlParameter("@cer_distancia_eixo", domain.cer_distancia_eixo));
                        command.Parameters.Add(new SqlParameter("@cer_data_criacao", domain.cer_data_criacao));
                        command.Parameters.Add(new SqlParameter("@cer_id_segmento", domain.cer_id_segmento));
                        command.Parameters.Add(new SqlParameter("@cer_dispositivo", domain.cer_dispositivo));
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

        public bool Update(DominioCircunscricao domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_DOMINIOCIRCUNSCRICAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@cer_km_inicial", domain.cer_km_inicial));
                        command.Parameters.Add(new SqlParameter("@cer_km_final", domain.cer_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@cer_data_levantamento", domain.cer_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@cer_extensao", domain.cer_extensao));
                        command.Parameters.Add(new SqlParameter("@cer_distancia_eixo", domain.cer_distancia_eixo));
                        command.Parameters.Add(new SqlParameter("@cer_data_criacao", domain.cer_data_criacao));
                        command.Parameters.Add(new SqlParameter("@cer_id_segmento", domain.cer_id_segmento));
                        command.Parameters.Add(new SqlParameter("@cer_dispositivo", domain.cer_dispositivo));
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

        public DominioCircunscricao GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new DominioCircunscricao();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DOMINIOCIRCUNSCRICAO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.cer_km_inicial = result["cer_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["cer_km_inicial"]);
                            retorno.cer_km_final = result["cer_km_final"] is DBNull ? 0 : Convert.ToDouble(result["cer_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.cer_data_levantamento = result["cer_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["cer_data_levantamento"]);
                            retorno.cer_extensao = result["cer_extensao"] is DBNull ? 0 : Convert.ToDouble(result["cer_extensao"]);
                            retorno.cer_distancia_eixo = result["cer_distancia_eixo"] is DBNull ? 0 : Convert.ToDouble(result["cer_distancia_eixo"]);
                            retorno.cer_data_criacao = result["cer_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["cer_data_criacao"]);
                            retorno.cer_id_segmento = result["cer_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["cer_id_segmento"]);
                            retorno.cer_dispositivo = result["cer_dispositivo"] is DBNull ? 0 : Convert.ToDouble(result["cer_dispositivo"]);
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

        public bool Delete(DominioCircunscricao model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_DOMINIOCIRCUNSCRICAO", conn))
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