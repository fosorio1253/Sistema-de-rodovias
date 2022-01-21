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
    public class InadimplentesDAO : BaseDAO<Inadimplentes>
    {
        Logger logger;

        public InadimplentesDAO(DerContext context) : base(context)
        {
            logger = new Logger("Inadimplentes");
        }

        public List<Inadimplentes> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<Inadimplentes>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_INADIMPLENTES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new Inadimplentes();
                            retorno.ina_id                  = result["ina_id"]                  is DBNull ? 0               : Convert.ToInt32(      result["ina_id"]);
                            retorno.ina_dias                = result["ina_dias"]                is DBNull ? 0               : Convert.ToInt32(      result["ina_dias"]);
                            retorno.ina_cpfcnpj             = result["ina_cpfcnpj"]             is DBNull ? 0               : Convert.ToInt64(      result["ina_cpfcnpj"]);
                            retorno.ina_protocolo           = result["ina_protocolo"]           is DBNull ? 0               : Convert.ToInt64(      result["ina_protocolo"]);
                            retorno.ina_processo            = result["ina_processo"]            is DBNull ? 0               : Convert.ToInt64(      result["ina_processo"]);
                            retorno.ina_interessadoid       = result["ina_interessadoid"]       is DBNull ? 0               : Convert.ToInt32(      result["ina_interessadoid"]);
                            retorno.ina_tipoocupacaoid      = result["ina_tipoocupacaoid"]      is DBNull ? 0               : Convert.ToInt32(      result["ina_tipoocupacaoid"]);
                            retorno.ina_valortotal          = result["ina_valortotal"]          is DBNull ? 0               : Convert.ToDecimal(    result["ina_valortotal"]);
                            retorno.ina_valorprevisto       = result["ina_valorprevisto"]       is DBNull ? 0               : Convert.ToDecimal(    result["ina_valorprevisto"]);
                            retorno.ina_statusboleto        = result["ina_statusboleto"]        is DBNull ? string.Empty    :                       result["ina_statusboleto"].ToString();
                            retorno.ina_tipofaturamento     = result["ina_tipofaturamento"]     is DBNull ? string.Empty    :                       result["ina_tipofaturamento"].ToString();
                            retorno.ina_ativo               = result["ina_ativo"]               is DBNull ? false           : Convert.ToBoolean(    result["ina_ativo"]);
                            retorno.ina_periodo             = result["ina_periodo"]             is DBNull ? dtnull          : Convert.ToDateTime(   result["ina_periodo"]);
                            retorno.ina_datavenciemntoprimeiro  = result["ina_datavenciemntoprimeiro"]  is DBNull ? dtnull  : Convert.ToDateTime(   result["ina_datavenciemntoprimeiro"]);
                            retorno.ina_datavenciemntosegundo   = result["ina_datavenciemntosegundo"]   is DBNull ? dtnull  : Convert.ToDateTime(   result["ina_datavenciemntosegundo"]);

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

        public bool Inserir(Inadimplentes domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_INADIMPLENTES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@ina_id"               , domain.ina_id));
                        command.Parameters.Add(new SqlParameter("@ina_cpfcnpj"          , domain.ina_cpfcnpj));
                        command.Parameters.Add(new SqlParameter("@ina_protocolo"        , domain.ina_protocolo));
                        command.Parameters.Add(new SqlParameter("@ina_processo"         , domain.ina_processo));
                        command.Parameters.Add(new SqlParameter("@ina_interessadoid"    , domain.ina_interessadoid));
                        command.Parameters.Add(new SqlParameter("@ina_tipoocupacaoid"   , domain.ina_tipoocupacaoid));
                        command.Parameters.Add(new SqlParameter("@ina_dias"             , domain.ina_dias));
                        command.Parameters.Add(new SqlParameter("@ina_tipofaturamento"  , domain.ina_tipofaturamento));
                        command.Parameters.Add(new SqlParameter("@ina_statusboleto"     , domain.ina_statusboleto));
                        command.Parameters.Add(new SqlParameter("@ina_valortotal"       , domain.ina_valortotal));
                        command.Parameters.Add(new SqlParameter("@ina_valorprevisto"    , domain.ina_valorprevisto));
                        command.Parameters.Add(new SqlParameter("@ina_ativo"            , domain.ina_ativo));
                        command.Parameters.Add(new SqlParameter("@ina_periodo"          , domain.ina_periodo));
                        command.Parameters.Add(new SqlParameter("@ina_datavenciemntoprimeiro"   , domain.ina_datavenciemntoprimeiro));
                        command.Parameters.Add(new SqlParameter("@ina_datavenciemntosegundo"    , domain.ina_datavenciemntosegundo));

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

        public bool Update(Inadimplentes domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.ina_id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_INADIMPLENTES", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@ina_id"               , domain.ina_id));
                        command.Parameters.Add(new SqlParameter("@ina_cpfcnpj"          , domain.ina_cpfcnpj));
                        command.Parameters.Add(new SqlParameter("@ina_protocolo"        , domain.ina_protocolo));
                        command.Parameters.Add(new SqlParameter("@ina_processo"         , domain.ina_processo));
                        command.Parameters.Add(new SqlParameter("@ina_interessadoid"    , domain.ina_interessadoid));
                        command.Parameters.Add(new SqlParameter("@ina_tipoocupacaoid"   , domain.ina_tipoocupacaoid));
                        command.Parameters.Add(new SqlParameter("@ina_dias"             , domain.ina_dias));
                        command.Parameters.Add(new SqlParameter("@ina_tipofaturamento"  , domain.ina_tipofaturamento));
                        command.Parameters.Add(new SqlParameter("@ina_statusboleto"     , domain.ina_statusboleto));
                        command.Parameters.Add(new SqlParameter("@ina_valortotal"       , domain.ina_valortotal));
                        command.Parameters.Add(new SqlParameter("@ina_valorprevisto"    , domain.ina_valorprevisto));
                        command.Parameters.Add(new SqlParameter("@ina_ativo"            , domain.ina_ativo));
                        command.Parameters.Add(new SqlParameter("@ina_periodo"          , domain.ina_periodo));
                        command.Parameters.Add(new SqlParameter("@ina_datavenciemntoprimeiro"   , domain.ina_datavenciemntoprimeiro));
                        command.Parameters.Add(new SqlParameter("@ina_datavenciemntosegundo"    , domain.ina_datavenciemntosegundo));

                        var result = command.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                var value = GetById(domain.ina_id);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Inadimplentes GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new Inadimplentes();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_INADIMPLENTES_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@ina_id", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            retorno.ina_id                  = result["ina_id"]              is DBNull ? 0               : Convert.ToInt32(      result["ina_id"]);
                            retorno.ina_dias                = result["ina_dias"]            is DBNull ? 0               : Convert.ToInt32(      result["ina_dias"]);
                            retorno.ina_cpfcnpj             = result["ina_cpfcnpj"]         is DBNull ? 0               : Convert.ToInt64(      result["ina_cpfcnpj"]);
                            retorno.ina_protocolo           = result["ina_protocolo"]       is DBNull ? 0               : Convert.ToInt64(      result["ina_protocolo"]);
                            retorno.ina_processo            = result["ina_processo"]        is DBNull ? 0               : Convert.ToInt64(      result["ina_processo"]);
                            retorno.ina_interessadoid       = result["ina_interessadoid"]   is DBNull ? 0               : Convert.ToInt32(      result["ina_interessadoid"]);
                            retorno.ina_tipoocupacaoid      = result["ina_tipoocupacaoid"]  is DBNull ? 0               : Convert.ToInt32(      result["ina_tipoocupacaoid"]);
                            retorno.ina_valortotal          = result["ina_valortotal"]      is DBNull ? 0               : Convert.ToDecimal(    result["ina_valortotal"]);
                            retorno.ina_valorprevisto       = result["ina_valorprevisto"]   is DBNull ? 0               : Convert.ToDecimal(    result["ina_valorprevisto"]);
                            retorno.ina_statusboleto        = result["ina_statusboleto"]    is DBNull ? string.Empty    :                       result["ina_statusboleto"].ToString();
                            retorno.ina_tipofaturamento     = result["ina_tipofaturamento"] is DBNull ? string.Empty    :                       result["ina_tipofaturamento"].ToString();
                            retorno.ina_ativo               = result["ina_ativo"]           is DBNull ? false           : Convert.ToBoolean(    result["ina_ativo"]);
                            retorno.ina_periodo             = result["ina_periodo"]         is DBNull ? dtnull          : Convert.ToDateTime(   result["ina_periodo"]);
                            retorno.ina_datavenciemntoprimeiro  = result["ina_datavenciemntoprimeiro"]  is DBNull ? dtnull : Convert.ToDateTime(result["ina_datavenciemntoprimeiro"]);
                            retorno.ina_datavenciemntosegundo   = result["ina_datavenciemntosegundo"]   is DBNull ? dtnull : Convert.ToDateTime(result["ina_datavenciemntosegundo"]);
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

        public bool Delete(Inadimplentes model)
        {
            var oldValue = GetById(model.ina_id);
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("STP_DEL_INADIMPLENTES", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ina_id", model.ina_id));
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