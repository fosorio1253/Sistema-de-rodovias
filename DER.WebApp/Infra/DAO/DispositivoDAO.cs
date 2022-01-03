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
    public class DispositivoDAO : BaseDAO<Dispositivo>
    {
        Logger logger;

        public DispositivoDAO(DerContext context) : base(context)
        {
            logger = new Logger("Dispositivo", context);
        }

        public List<Dispositivo> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<Dispositivo>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DISPOSITIVO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new Dispositivo();
                            retorno.dis_id = result["dis_id"] is DBNull ? 0 : Convert.ToInt32(result["dis_id"]);
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.dis_codigo = result["dis_codigo"] is DBNull ? string.Empty : result["dis_codigo"].ToString();
                            retorno.dit_id = result["dit_id"] is DBNull ? 0 : Convert.ToInt32(result["dit_id"]);
                            retorno.dis_km_localizacao = result["dis_km_localizacao"] is DBNull ? 0 : Convert.ToDouble(result["dis_km_localizacao"]);
                            retorno.dis_extensao = result["dis_extensao"] is DBNull ? 0 : Convert.ToDouble(result["dis_extensao"]);
                            retorno.dis_descricao1 = result["dis_descricao1"] is DBNull ? string.Empty : result["dis_descricao1"].ToString();
                            retorno.dis_descricao2 = result["dis_descricao2"] is DBNull ? string.Empty : result["dis_descricao2"].ToString();
                            retorno.mun_ibge_id = result["mun_ibge_id"] is DBNull ? 0 : Convert.ToInt32(result["mun_ibge_id"]);
                            retorno.jur_id = result["jur_id"] is DBNull ? 0 : Convert.ToInt32(result["jur_id"]);
                            retorno.adm_id = result["adm_id"] is DBNull ? 0 : Convert.ToInt32(result["adm_id"]);
                            retorno.con_id = result["con_id"] is DBNull ? 0 : Convert.ToInt32(result["con_id"]);
                            retorno.stp_id = result["stp_id"] is DBNull ? 0 : Convert.ToInt32(result["stp_id"]);
                            retorno.dis_perimetro_urbano = result["dis_perimetro_urbano"] is DBNull ? string.Empty : result["dis_perimetro_urbano"].ToString();
                            retorno.dis_denominacao = result["dis_denominacao"] is DBNull ? string.Empty : result["dis_denominacao"].ToString();
                            retorno.dis_legislacao = result["dis_legislacao"] is DBNull ? string.Empty : result["dis_legislacao"].ToString();
                            retorno.dis_TPUso = result["dis_TPUso"] is DBNull ? string.Empty : result["dis_TPUso"].ToString();
                            retorno.dis_transf_mun = result["dis_transf_mun"] is DBNull ? string.Empty : result["dis_transf_mun"].ToString();
                            retorno.dis_observacao = result["dis_observacao"] is DBNull ? string.Empty : result["dis_observacao"].ToString();
                            retorno.dis_subtrecho = result["dis_subtrecho"] is DBNull ? string.Empty : result["dis_subtrecho"].ToString();
                            retorno.dis_ano_implantacao = result["dis_ano_implantacao"] is DBNull ? dtnull : Convert.ToDateTime(result["dis_ano_implantacao"]);
                            retorno.dis_data_atualizacao = result["dis_data_atualizacao"] is DBNull ? dtnull : Convert.ToDateTime(result["dis_data_atualizacao"]);
                           // retorno.nome = result["nome"] is DBNull ? string.Empty : result["nome"].ToString(); verificar fosorio

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

        public bool Inserir(Dispositivo domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_DISPOSITIVO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@dis_id", domain.dis_id));
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@dis_codigo", domain.dis_codigo));
                        command.Parameters.Add(new SqlParameter("@dit_id", domain.dit_id));
                        command.Parameters.Add(new SqlParameter("@dis_km_localizacao", domain.dis_km_localizacao));
                        command.Parameters.Add(new SqlParameter("@dis_extensao", domain.dis_extensao));
                        command.Parameters.Add(new SqlParameter("@dis_descricao1", domain.dis_descricao1));
                        command.Parameters.Add(new SqlParameter("@dis_descricao2", domain.dis_descricao2));
                        command.Parameters.Add(new SqlParameter("@mun_ibge_id", domain.mun_ibge_id));
                        command.Parameters.Add(new SqlParameter("@jur_id", domain.jur_id));
                        command.Parameters.Add(new SqlParameter("@adm_id", domain.adm_id));
                        command.Parameters.Add(new SqlParameter("@con_id", domain.con_id));
                        command.Parameters.Add(new SqlParameter("@stp_id", domain.stp_id));
                        command.Parameters.Add(new SqlParameter("@dis_perimetro_urbano", domain.dis_perimetro_urbano));
                        command.Parameters.Add(new SqlParameter("@dis_denominacao", domain.dis_denominacao));
                        command.Parameters.Add(new SqlParameter("@dis_legislacao", domain.dis_legislacao));
                        command.Parameters.Add(new SqlParameter("@dis_TPUso", domain.dis_TPUso));
                        command.Parameters.Add(new SqlParameter("@dis_transf_mun", domain.dis_transf_mun));
                        command.Parameters.Add(new SqlParameter("@dis_observacao", domain.dis_observacao));
                        command.Parameters.Add(new SqlParameter("@dis_subtrecho", domain.dis_subtrecho));
                        command.Parameters.Add(new SqlParameter("@dis_ano_implantacao", domain.dis_ano_implantacao));
                        command.Parameters.Add(new SqlParameter("@dis_data_atualizacao", domain.dis_data_atualizacao));
                        //command.Parameters.Add(new SqlParameter("@nome", domain.nome)); verificar fosorio
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

        public bool Update(Dispositivo domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.dis_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_DISPOSITIVO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@dis_id", domain.dis_id));
                        command.Parameters.Add(new SqlParameter("@rod_id", domain.rod_id));
                        command.Parameters.Add(new SqlParameter("@dis_codigo", domain.dis_codigo));
                        command.Parameters.Add(new SqlParameter("@dit_id", domain.dit_id));
                        command.Parameters.Add(new SqlParameter("@dis_km_localizacao", domain.dis_km_localizacao));
                        command.Parameters.Add(new SqlParameter("@dis_extensao", domain.dis_extensao));
                        command.Parameters.Add(new SqlParameter("@dis_descricao1", domain.dis_descricao1));
                        command.Parameters.Add(new SqlParameter("@dis_descricao2", domain.dis_descricao2));
                        command.Parameters.Add(new SqlParameter("@mun_ibge_id", domain.mun_ibge_id));
                        command.Parameters.Add(new SqlParameter("@jur_id", domain.jur_id));
                        command.Parameters.Add(new SqlParameter("@adm_id", domain.adm_id));
                        command.Parameters.Add(new SqlParameter("@con_id", domain.con_id));
                        command.Parameters.Add(new SqlParameter("@stp_id", domain.stp_id));
                        command.Parameters.Add(new SqlParameter("@dis_perimetro_urbano", domain.dis_perimetro_urbano));
                        command.Parameters.Add(new SqlParameter("@dis_denominacao", domain.dis_denominacao));
                        command.Parameters.Add(new SqlParameter("@dis_legislacao", domain.dis_legislacao));
                        command.Parameters.Add(new SqlParameter("@dis_TPUso", domain.dis_TPUso));
                        command.Parameters.Add(new SqlParameter("@dis_transf_mun", domain.dis_transf_mun));
                        command.Parameters.Add(new SqlParameter("@dis_observacao", domain.dis_observacao));
                        command.Parameters.Add(new SqlParameter("@dis_subtrecho", domain.dis_subtrecho));
                        command.Parameters.Add(new SqlParameter("@dis_ano_implantacao", domain.dis_ano_implantacao));
                        command.Parameters.Add(new SqlParameter("@dis_data_atualizacao", domain.dis_data_atualizacao));
                        // command.Parameters.Add(new SqlParameter("@nome", domain.nome));verificar fosorio
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.dis_id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.dis_id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Dispositivo GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new Dispositivo();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_DISPOSITIVO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.dis_id = result["dis_id"] is DBNull ? 0 : Convert.ToInt32(result["dis_id"]);
                            retorno.rod_id = result["rod_id"] is DBNull ? 0 : Convert.ToInt32(result["rod_id"]);
                            retorno.dis_codigo = result["dis_codigo"] is DBNull ? string.Empty : result["dis_codigo"].ToString();
                            retorno.dit_id = result["dit_id"] is DBNull ? 0 : Convert.ToInt32(result["dit_id"]);
                            retorno.dis_km_localizacao = result["dis_km_localizacao"] is DBNull ? 0 : Convert.ToDouble(result["dis_km_localizacao"]);
                            retorno.dis_extensao = result["dis_extensao"] is DBNull ? 0 : Convert.ToDouble(result["dis_extensao"]);
                            retorno.dis_descricao1 = result["dis_descricao1"] is DBNull ? string.Empty : result["dis_descricao1"].ToString();
                            retorno.dis_descricao2 = result["dis_descricao2"] is DBNull ? string.Empty : result["dis_descricao2"].ToString();
                            retorno.mun_ibge_id = result["mun_ibge_id"] is DBNull ? 0 : Convert.ToInt32(result["mun_ibge_id"]);
                            retorno.jur_id = result["jur_id"] is DBNull ? 0 : Convert.ToInt32(result["jur_id"]);
                            retorno.adm_id = result["adm_id"] is DBNull ? 0 : Convert.ToInt32(result["adm_id"]);
                            retorno.con_id = result["con_id"] is DBNull ? 0 : Convert.ToInt32(result["con_id"]);
                            retorno.stp_id = result["stp_id"] is DBNull ? 0 : Convert.ToInt32(result["stp_id"]);
                            retorno.dis_perimetro_urbano = result["dis_perimetro_urbano"] is DBNull ? string.Empty : result["dis_perimetro_urbano"].ToString();
                            retorno.dis_denominacao = result["dis_denominacao"] is DBNull ? string.Empty : result["dis_denominacao"].ToString();
                            retorno.dis_legislacao = result["dis_legislacao"] is DBNull ? string.Empty : result["dis_legislacao"].ToString();
                            retorno.dis_TPUso = result["dis_TPUso"] is DBNull ? string.Empty : result["dis_TPUso"].ToString();
                            retorno.dis_transf_mun = result["dis_transf_mun"] is DBNull ? string.Empty : result["dis_transf_mun"].ToString();
                            retorno.dis_observacao = result["dis_observacao"] is DBNull ? string.Empty : result["dis_observacao"].ToString();
                            retorno.dis_subtrecho = result["dis_subtrecho"] is DBNull ? string.Empty : result["dis_subtrecho"].ToString();
                            retorno.dis_ano_implantacao = result["dis_ano_implantacao"] is DBNull ? dtnull : Convert.ToDateTime(result["dis_ano_implantacao"]);
                            retorno.dis_data_atualizacao = result["dis_data_atualizacao"] is DBNull ? dtnull : Convert.ToDateTime(result["dis_data_atualizacao"]);
                            //retorno.nome = result["nome"] is DBNull ? string.Empty : result["nome"].ToString();verificar fosorio
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

        public bool Delete(Dispositivo model)
        {
            var oldValue = GetById(model.dis_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_DISPOSITIVO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@dis_id", model.dis_id));
                    conn.Open();
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    conn.Close();
                    logger.salvarLog(TipoAlteracao.Exclusao, model.dis_id.ToString(), logger.serializer.Serialize(oldValue), "");
                }
            }
            return true;
        }
    }


}