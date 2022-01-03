using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Infra.DAO
{
    public class AcostamentosLevantamentoDAO : BaseDAO<AcostamentosLevantamento>
    {
        Logger logger;

        public AcostamentosLevantamentoDAO(DerContext context) : base(context)
        {
            logger = new Logger("AcostamentosLevantamento", context);
        }

        public List<AcostamentosLevantamento> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<AcostamentosLevantamento>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_ACOSTAMENTOSLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new AcostamentosLevantamento();
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.aco_km_inicial = result["aco_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["aco_km_inicial"]);
                            retorno.aco_km_final = result["aco_km_final"] is DBNull ? 0 : Convert.ToDouble(result["aco_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.aco_data_levantamento = result["aco_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["aco_data_levantamento"]);
                            retorno.aco_extensao = result["aco_extensao"] is DBNull ? 0 : Convert.ToDouble(result["aco_extensao"]);
                            retorno.rev_id = result["rev_id"] is DBNull ? 0 : Convert.ToInt32(result["rev_id"]);
                            retorno.aco_largura = result["aco_largura"] is DBNull ? 0 : Convert.ToDouble(result["aco_largura"]);
                            retorno.aco_data_criacao = result["aco_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["aco_data_criacao"]);
                            retorno.aco_id_segmento = result["aco_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["aco_id_segmento"]);
                            retorno.aco_dispositivo = result["aco_dispositivo"] is DBNull ? string.Empty : result["aco_dispositivo").ToString();
                            retorno.aco_ext_geometria = result["aco_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["aco_ext_geometria"]);

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

        public bool Inserir(AcostamentosLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_ACOSTAMENTOSLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@aco_km_inicial", domain.aco_km_inicial));
                        command.Parameters.Add(new SqlParameter("@aco_km_final", domain.aco_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@aco_data_levantamento", domain.aco_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@aco_extensao", domain.aco_extensao));
                        command.Parameters.Add(new SqlParameter("@rev_id", domain.rev_id));
                        command.Parameters.Add(new SqlParameter("@aco_largura", domain.aco_largura));
                        command.Parameters.Add(new SqlParameter("@aco_data_criacao", domain.aco_data_criacao));
                        command.Parameters.Add(new SqlParameter("@aco_id_segmento", domain.aco_id_segmento));
                        command.Parameters.Add(new SqlParameter("@aco_dispositivo", domain.aco_dispositivo));
                        command.Parameters.Add(new SqlParameter("@aco_ext_geometria", domain.aco_ext_geometria));
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

        public bool Update(AcostamentosLevantamento domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.rod_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_ACOSTAMENTOSLEVANTAMENTO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@aco_km_inicial", domain.aco_km_inicial));
                        command.Parameters.Add(new SqlParameter("@aco_km_final", domain.aco_km_final));
                        command.Parameters.Add(new SqlParameter("@sen_id", domain.sen_id));
                        command.Parameters.Add(new SqlParameter("@reg_id", domain.reg_id));
                        command.Parameters.Add(new SqlParameter("@aco_data_levantamento", domain.aco_data_levantamento));
                        command.Parameters.Add(new SqlParameter("@aco_extensao", domain.aco_extensao));
                        command.Parameters.Add(new SqlParameter("@rev_id", domain.rev_id));
                        command.Parameters.Add(new SqlParameter("@aco_largura", domain.aco_largura));
                        command.Parameters.Add(new SqlParameter("@aco_data_criacao", domain.aco_data_criacao));
                        command.Parameters.Add(new SqlParameter("@aco_id_segmento", domain.aco_id_segmento));
                        command.Parameters.Add(new SqlParameter("@aco_dispositivo", domain.aco_dispositivo));
                        command.Parameters.Add(new SqlParameter("@aco_ext_geometria", domain.aco_ext_geometria));
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

        public AcostamentosLevantamento GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new AcostamentosLevantamento();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_ACOSTAMENTOSLEVANTAMENTO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.aco_km_inicial = result["aco_km_inicial"] is DBNull ? 0 : Convert.ToDouble(result["aco_km_inicial"]);
                            retorno.aco_km_final = result["aco_km_final"] is DBNull ? 0 : Convert.ToDouble(result["aco_km_final"]);
                            retorno.sen_id = result["sen_id"] is DBNull ? 0 : Convert.ToInt32(result["sen_id"]);
                            retorno.reg_id = result["reg_id"] is DBNull ? 0 : Convert.ToInt32(result["reg_id"]);
                            retorno.aco_data_levantamento = result["aco_data_levantamento"] is DBNull ? dtnull : Convert.ToDateTime(result["aco_data_levantamento"]);
                            retorno.aco_extensao = result["aco_extensao"] is DBNull ? 0 : Convert.ToDouble(result["aco_extensao"]);
                            retorno.rev_id = result["rev_id"] is DBNull ? 0 : Convert.ToInt32(result["rev_id"]);
                            retorno.aco_largura = result["aco_largura"] is DBNull ? 0 : Convert.ToDouble(result["aco_largura"]);
                            retorno.aco_data_criacao = result["aco_data_criacao"] is DBNull ? dtnull : Convert.ToDateTime(result["aco_data_criacao"]);
                            retorno.aco_id_segmento = result["aco_id_segmento"] is DBNull ? 0 : Convert.ToInt32(result["aco_id_segmento"]);
                            retorno.aco_dispositivo = result["aco_dispositivo"] is DBNull ? string.Empty : result["aco_dispositivo").ToString();
                            retorno.aco_ext_geometria = result["aco_ext_geometria"] is DBNull ? 0 : Convert.ToDouble(result["aco_ext_geometria"]);
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

        public bool Delete(AcostamentosLevantamento model)
        {
            var oldValue = GetById(model.rod_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_ACOSTAMENTOSLEVANTAMENTO", conn))
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