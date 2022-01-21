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
    public class TipoOcupacaoDAO : BaseDAO<TipoOcupacao>
    {
        Logger logger;

        public TipoOcupacaoDAO(DerContext context) : base(context)
        {
            logger = new Logger("TipoOcupacao");
        }

        public List<TipoOcupacao> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<TipoOcupacao>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TIPOOCUPACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new TipoOcupacao();
                            retorno.tipo_ocupacao_id = result["tipo_ocupacao_id"] is DBNull ? 0 : Convert.ToInt32(result["tipo_ocupacao_id"]);
                            retorno.nome = result["nome"] is DBNull ? string.Empty : result["nome"].ToString();
                            retorno.altura_minima = result["altura_minima"] is DBNull ? 0 : Convert.ToDouble(result["altura_minima"]);
                            retorno.profundidade_minima = result["profundidade_minima"] is DBNull ? 0 : Convert.ToDouble(result["profundidade_minima"]);

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

        public bool Inserir(TipoOcupacao domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_TIPOOCUPACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@tipo_ocupacao_id", domain.tipo_ocupacao_id));
                        command.Parameters.Add(new SqlParameter("@nome", domain.nome));
                        command.Parameters.Add(new SqlParameter("@altura_minima", domain.altura_minima));
                        command.Parameters.Add(new SqlParameter("@profundidade_minima", domain.profundidade_minima));
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

        public bool Update(TipoOcupacao domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.tipo_ocupacao_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_TIPOOCUPACAO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@tipo_ocupacao_id", domain.tipo_ocupacao_id));
                        command.Parameters.Add(new SqlParameter("@nome", domain.nome));
                        command.Parameters.Add(new SqlParameter("@altura_minima", domain.altura_minima));
                        command.Parameters.Add(new SqlParameter("@profundidade_minima", domain.profundidade_minima));
                        var result = command.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                var value = GetById(domain.tipo_ocupacao_id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TipoOcupacao GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new TipoOcupacao();
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_TIPOOCUPACAO_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        command.Parameters.Add(new SqlParameter("@{ Entidade.Campos.First().Nome }", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();
                        while (result.Read())
                        {
                            retorno.tipo_ocupacao_id = result["tipo_ocupacao_id"] is DBNull ? 0 : Convert.ToInt32(result["tipo_ocupacao_id"]);
                            retorno.nome = result["nome"] is DBNull ? string.Empty : result["nome"].ToString();
                            retorno.altura_minima = result["altura_minima"] is DBNull ? 0 : Convert.ToDouble(result["altura_minima"]);
                            retorno.profundidade_minima = result["profundidade_minima"] is DBNull ? 0 : Convert.ToDouble(result["profundidade_minima"]);
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

        public bool Delete(TipoOcupacao model)
        {
            var oldValue = GetById(model.tipo_ocupacao_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_TIPOOCUPACAO", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@tipo_ocupacao_id", model.tipo_ocupacao_id));
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