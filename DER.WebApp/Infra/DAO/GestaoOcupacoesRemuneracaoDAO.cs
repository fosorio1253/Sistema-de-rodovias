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
    public class GestaoOcupacoesRemuneracaoDAO : BaseDAO<GestaoOcupacoesRemuneracao>
    {
        Logger logger;

        public GestaoOcupacoesRemuneracaoDAO(DerContext context) : base(context)
        {
            logger = new Logger("GestaoOcupacoesRemuneracao", context);
        }

        public List<GestaoOcupacoesRemuneracao> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new List<GestaoOcupacoesRemuneracao>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACAO_REMUNERACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var domain = new GestaoOcupacoesRemuneracao();
                            domain.IdGestaoOcupacoesRemuneracao =   result["IdGestaoOcupacoesRemuneracao"] is DBNull    ? 0                 : Convert.ToInt32(result["IdGestaoOcupacoesRemuneracao"]);
                            domain.IdOcupacao =                     result["IdOcupacao"] is DBNull                      ? 0                 : Convert.ToInt32(result["IdOcupacao"]);
                            domain.DataRemuneracao =                result["DataRemuneracao"] is DBNull                 ? DateTime.MinValue : Convert.ToDateTime(result["DataRemuneracao"]);
                            domain.ValorRemuneracao =               result["ValorRemuneracao"] is DBNull                ? 0                 : Convert.ToDecimal(result["ValorRemuneracao"]);
                            domain.Descricao =                      result["Descricao"] is DBNull                       ? ""                : result["Descricao"].ToString();
                            domain.Status =                         result["Status"] is DBNull                          ? ""                : result["Status"].ToString();
                            domain.Liberado =                       result["Liberado"] is DBNull                        ? false             : (bool)result["Liberado"];

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

        public bool Inserir(GestaoOcupacoesRemuneracao domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_OCUPACAO_REMUNERACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@IdOcupacao", domain.IdOcupacao));
                        command.Parameters.Add(new SqlParameter("@DataRemuneracao", domain.DataRemuneracao));
                        command.Parameters.Add(new SqlParameter("@ValorRemuneracao", domain.ValorRemuneracao));
                        command.Parameters.Add(new SqlParameter("@Descricao", domain.Descricao));
                        command.Parameters.Add(new SqlParameter("@Status", domain.Status));
                        command.Parameters.Add(new SqlParameter("@Liberado", domain.Liberado));

                        var result = command.ExecuteScalar();

                        command.Parameters.Clear();
                        
                        conn.Close();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Update(GestaoOcupacoesRemuneracao domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.IdGestaoOcupacoesRemuneracao);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_GESTAO_OCUPACAO_REMUNERACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@IdGestaoOcupacoesRemuneracao", domain.IdGestaoOcupacoesRemuneracao));
                        command.Parameters.Add(new SqlParameter("@IdOcupacao", domain.IdOcupacao));
                        command.Parameters.Add(new SqlParameter("@DataRemuneracao", domain.DataRemuneracao));
                        command.Parameters.Add(new SqlParameter("@ValorRemuneracao", domain.ValorRemuneracao));
                        command.Parameters.Add(new SqlParameter("@Descricao", domain.Descricao));
                        command.Parameters.Add(new SqlParameter("@Status", domain.Status));
                        command.Parameters.Add(new SqlParameter("@Liberado", domain.Liberado));

                        var result = command.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                var value = GetById(domain.IdGestaoOcupacoesRemuneracao);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.IdGestaoOcupacoesRemuneracao.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GestaoOcupacoesRemuneracao GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var domain = new GestaoOcupacoesRemuneracao();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACAO_REMUNERACAO_BYID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@IdGestaoOcupacoesRemuneracao", id));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            domain.IdGestaoOcupacoesRemuneracao = result["IdGestaoOcupacoesRemuneracao"] is DBNull ? 0 : Convert.ToInt32(result["IdGestaoOcupacoesRemuneracao"]);
                            domain.IdOcupacao = result["IdOcupacao"] is DBNull ? 0 : Convert.ToInt32(result["IdOcupacao"]);
                            domain.DataRemuneracao = result["DataRemuneracao"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(result["DataRemuneracao"]);
                            domain.ValorRemuneracao = result["ValorRemuneracao"] is DBNull ? 0 : Convert.ToDecimal(result["ValorRemuneracao"]);
                            domain.Descricao = result["Descricao"] is DBNull ? "" : result["Descricao"].ToString();
                            domain.Status = result["Status"] is DBNull ? "" : result["Status"].ToString();
                            domain.Liberado = result["Liberado"] is DBNull ? false : (bool)result["Liberado"];
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