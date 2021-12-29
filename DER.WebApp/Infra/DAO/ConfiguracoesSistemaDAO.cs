using DER.WebApp.Domain.Models;
using DER.WebApp.Helper;
using DER.WebApp.Infra.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DER.WebApp.Infra.DAO
{
    public class ConfiguracoesSistemaDAO : BaseDAO<ConfiguracoesSistema>
    {
        Logger logger;

        public ConfiguracoesSistemaDAO(DerContext context) : base(context)
        {
            logger = new Logger("ConfiguracoesSistema", context);
        }

        public List<ConfiguracoesSistema> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new List<ConfiguracoesSistema>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACAO_REMUNERACAO", conn))//alterar aqui
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var domain = new ConfiguracoesSistema();
                            domain.Configuracoes_Sistema_Id =   result["Configuracoes_Sistema_Id"] is DBNull    ? 0 : Convert.ToInt32(result["Configuracoes_Sistema_Id"]);
                            domain.Producao =                   result["Producao"] is DBNull                    ? false : Convert.ToBoolean(result["Producao"]);

                            retorno.Add(domain);
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

        public void Inserir(List<ConfiguracoesSistema> domains)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_OCUPACAO_REMUNERACAO", conn))//aqui tbm
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        foreach (var domain in domains)
                        {
                            command.Parameters.Add(new SqlParameter("@Producao", domain.Producao));

                            var result = command.ExecuteScalar();

                            command.Parameters.Clear();
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ConfiguracoesSistema domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.Configuracoes_Sistema_Id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_GESTAO_OCUPACAO_REMUNERACAO", conn))//aqui tbm
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@Configuracoes_Sistema_Id", domain.Configuracoes_Sistema_Id));
                        command.Parameters.Add(new SqlParameter("@Producao", domain.Producao));

                        var result = command.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                var value = GetById(domain.Configuracoes_Sistema_Id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.Configuracoes_Sistema_Id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ConfiguracoesSistema GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var domain = new ConfiguracoesSistema();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACAO_REMUNERACAO_BYID", conn))//aqui tbm
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@Configuracoes_Sistema_Id", id));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            domain.Configuracoes_Sistema_Id =   result["Configuracoes_Sistema_Id"] is DBNull    ? 0 : Convert.ToInt32(result["Configuracoes_Sistema_Id"]);
                            domain.Producao =                   result["Producao"] is DBNull                    ? false : Convert.ToBoolean(result["Producao"]);

                        }
                        conn.Close();
                    }
                }
                return domain;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}