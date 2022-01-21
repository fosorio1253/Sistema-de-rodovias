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
    public class GestaoOcupacaoAcoesJudiciaisDAO : BaseDAO<AcoesJudiciais>
    {
        

        public GestaoOcupacaoAcoesJudiciaisDAO(DerContext context) : base(context)
        {
        
        }

        public List<AcoesJudiciais> ObtemTodos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var lretorno = new List<AcoesJudiciais>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACACAO_ACOES_JUDICIAIS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            var retorno = new AcoesJudiciais();
                            retorno.ocu_acoesjud_id                     = result["ocu_acoesjud_id"]                     is DBNull ? 0               : Convert.ToInt32(      result["ocu_acoesjud_id"]);
                            retorno.ocu_acoesjud_idinteressado          = result["ocu_acoesjud_idinteressado"]          is DBNull ? 0               : Convert.ToInt32(      result["ocu_acoesjud_idinteressado"]);
                            retorno.ocu_acoesjud_idocupacao             = result["ocu_acoesjud_idocupacao"]             is DBNull ? 0               : Convert.ToInt32(      result["ocu_acoesjud_idocupacao"]);
                            retorno.ocu_acoesjud_idrodovia              = result["ocu_acoesjud_idrodovia"]              is DBNull ? 0               : Convert.ToInt32(      result["ocu_acoesjud_idrodovia"]);
                            retorno.ocu_acoesjud_idtipocupacao          = result["ocu_acoesjud_idtipocupacao"]          is DBNull ? 0               : Convert.ToInt32(      result["ocu_acoesjud_idtipocupacao"]);
                            retorno.ocu_acoesjud_idsituacaoprocessual   = result["ocu_acoesjud_idsituacaoprocessual"]   is DBNull ? 0               : Convert.ToInt32(      result["ocu_acoesjud_situacaoprocessual"]);
                            retorno.ocu_acoesjud_kminicial              = result["ocu_acoesjud_kminicial"]              is DBNull ? Double.MinValue : Convert.ToDouble(     result["ocu_acoesjud_kminicial"]);
                            retorno.ocu_acoesjud_kmfinal                = result["ocu_acoesjud_kmfinal"]                is DBNull ? Double.MaxValue : Convert.ToDouble(     result["ocu_acoesjud_kmfinal"]);
                            retorno.ocu_acoesjud_cobrancapep            = result["ocu_acoesjud_cobrancapep"]            is DBNull ? false           : Convert.ToBoolean(    result["ocu_acoesjud_cobrancapep"]);
                            retorno.ocu_acoesjud_cobrancaregularizacao  = result["ocu_acoesjud_cobrancaregularizacao"]  is DBNull ? false           : Convert.ToBoolean(    result["ocu_acoesjud_cobrancaregularizacao"]);
                            retorno.ocu_acoesjud_cobrancaanuidade       = result["ocu_acoesjud_cobrancaanuidade"]       is DBNull ? false           : Convert.ToBoolean(    result["ocu_acoesjud_cobrancaanuidade"]);
                            retorno.ocu_acoesjud_cobrancalevantamento   = result["ocu_acoesjud_cobrancalevantamento"]   is DBNull ? false           : Convert.ToBoolean(    result["ocu_acoesjud_cobrancalevantamento"]);
                            retorno.ocu_acoesjud_assinatura             = result["ocu_acoesjud_assinatura"]             is DBNull ? false           : Convert.ToBoolean(    result["ocu_acoesjud_assinatura"]);
                            retorno.ocu_acoesjud_datadespacho           = result["ocu_acoesjud_datadespacho"]           is DBNull ? dtnull          : Convert.ToDateTime(   result["ocu_acoesjud_datadespacho"]);
                            retorno.ocu_acoesjud_cnpj                   = result["ocu_acoesjud_cnpj"]                   is DBNull ? string.Empty    :                       result["ocu_acoesjud_cnpj"].ToString();
                            retorno.ocu_acoesjud_protocolo              = result["ocu_acoesjud_protocolo"]              is DBNull ? string.Empty    :                       result["ocu_acoesjud_protocolo"].ToString();
                            retorno.ocu_acoesjud_processojudicial       = result["ocu_acoesjud_processojudicial"]       is DBNull ? string.Empty    :                       result["ocu_acoesjud_processojudicial"].ToString();
                            retorno.ocu_acoesjud_historicoresumido      = result["ocu_acoesjud_historicoresumido"]      is DBNull ? string.Empty    :                       result["ocu_acoesjud_historicoresumido"].ToString();
                            retorno.ocu_acoesjud_motivoassinatura       = result["ocu_acoesjud_motivoassinatura"]       is DBNull ? string.Empty    :                       result["ocu_acoesjud_motivoassinatura"].ToString();
                            retorno.ocu_acoesjud_observacao             = result["ocu_acoesjud_observacao"]             is DBNull ? string.Empty    :                       result["ocu_acoesjud_observacao"].ToString();

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

        public bool Inserir(AcoesJudiciais domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_GESTAO_OCUPACACAO_ACOES_JUDICIAIS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_id",                     domain.ocu_acoesjud_id));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_idinteressado",          domain.ocu_acoesjud_idinteressado));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_idocupacao",             domain.ocu_acoesjud_idocupacao));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_idrodovia",              domain.ocu_acoesjud_idrodovia));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_idtipocupacao",          domain.ocu_acoesjud_idtipocupacao));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_kminicial",              domain.ocu_acoesjud_kminicial));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_kmfinal",                domain.ocu_acoesjud_kmfinal));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_cobrancapep",            domain.ocu_acoesjud_cobrancapep));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_cobrancaregularizacao",  domain.ocu_acoesjud_cobrancaregularizacao));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_cobrancaanuidade",       domain.ocu_acoesjud_cobrancaanuidade));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_cobrancalevantamento",   domain.ocu_acoesjud_cobrancalevantamento));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_assinatura",             domain.ocu_acoesjud_assinatura));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_datadespacho",           domain.ocu_acoesjud_datadespacho));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_cnpj",                   domain.ocu_acoesjud_cnpj));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_protocolo",              domain.ocu_acoesjud_protocolo));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_processojudicial",       domain.ocu_acoesjud_processojudicial));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_historicoresumido",      domain.ocu_acoesjud_historicoresumido));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_idsituacaoprocessual",   domain.ocu_acoesjud_idsituacaoprocessual));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_motivoassinatura",       domain.ocu_acoesjud_motivoassinatura));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_observacao",             domain.ocu_acoesjud_observacao));

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

        public bool Update(AcoesJudiciais domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_GESTAO_OCUPACACAO_ACOES_JUDICIAIS", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_id",                     domain.ocu_acoesjud_id));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_idinteressado",          domain.ocu_acoesjud_idinteressado));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_idocupacao",             domain.ocu_acoesjud_idocupacao));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_idrodovia",              domain.ocu_acoesjud_idrodovia));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_idtipocupacao",          domain.ocu_acoesjud_idtipocupacao));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_kminicial",              domain.ocu_acoesjud_kminicial));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_kmfinal",                domain.ocu_acoesjud_kmfinal));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_cobrancapep",            domain.ocu_acoesjud_cobrancapep));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_cobrancaregularizacao",  domain.ocu_acoesjud_cobrancaregularizacao));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_cobrancaanuidade",       domain.ocu_acoesjud_cobrancaanuidade));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_cobrancalevantamento",   domain.ocu_acoesjud_cobrancalevantamento));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_assinatura",             domain.ocu_acoesjud_assinatura));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_datadespacho",           domain.ocu_acoesjud_datadespacho));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_cnpj",                   domain.ocu_acoesjud_cnpj));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_protocolo",              domain.ocu_acoesjud_protocolo));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_processojudicial",       domain.ocu_acoesjud_processojudicial));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_historicoresumido",      domain.ocu_acoesjud_historicoresumido));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_idsituacaoprocessual",   domain.ocu_acoesjud_idsituacaoprocessual));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_motivoassinatura",       domain.ocu_acoesjud_motivoassinatura));
                        command.Parameters.Add(new SqlParameter("@ocu_acoesjud_observacao",             domain.ocu_acoesjud_observacao));

                        var result = command.ExecuteNonQuery();

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

        public AcoesJudiciais GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new AcoesJudiciais();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_GESTAO_OCUPACACAO_ACOES_JUDICIAIS_ID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@IdAcoesJudiciais", id));
                        SqlDataReader result = command.ExecuteReader();

                        var dtnull = new DateTime();

                        while (result.Read())
                        {
                            retorno.ocu_acoesjud_id                     = result["ocu_acoesjud_id"]                     is DBNull ? 0               : Convert.ToInt32(      result["ocu_acoesjud_id"]);
                            retorno.ocu_acoesjud_idinteressado          = result["ocu_acoesjud_idinteressado"]          is DBNull ? 0               : Convert.ToInt32(      result["ocu_acoesjud_idinteressado"]);
                            retorno.ocu_acoesjud_idocupacao             = result["ocu_acoesjud_idocupacao"]             is DBNull ? 0               : Convert.ToInt32(      result["ocu_acoesjud_idocupacao"]);
                            retorno.ocu_acoesjud_idrodovia              = result["ocu_acoesjud_idrodovia"]              is DBNull ? 0               : Convert.ToInt32(      result["ocu_acoesjud_idrodovia"]);
                            retorno.ocu_acoesjud_idtipocupacao          = result["ocu_acoesjud_idtipocupacao"]          is DBNull ? 0               : Convert.ToInt32(      result["ocu_acoesjud_idtipocupacao"]);
                            retorno.ocu_acoesjud_idsituacaoprocessual   = result["ocu_acoesjud_idsituacaoprocessual"]   is DBNull ? 0               : Convert.ToInt32(      result["ocu_acoesjud_situacaoprocessual"]);
                            retorno.ocu_acoesjud_kminicial              = result["ocu_acoesjud_kminicial"]              is DBNull ? Double.MinValue : Convert.ToDouble(     result["ocu_acoesjud_kminicial"]);
                            retorno.ocu_acoesjud_kmfinal                = result["ocu_acoesjud_kmfinal"]                is DBNull ? Double.MaxValue : Convert.ToDouble(     result["ocu_acoesjud_kmfinal"]);
                            retorno.ocu_acoesjud_cobrancapep            = result["ocu_acoesjud_cobrancapep"]            is DBNull ? false           : Convert.ToBoolean(    result["ocu_acoesjud_cobrancapep"]);
                            retorno.ocu_acoesjud_cobrancaregularizacao  = result["ocu_acoesjud_cobrancaregularizacao"]  is DBNull ? false           : Convert.ToBoolean(    result["ocu_acoesjud_cobrancaregularizacao"]);
                            retorno.ocu_acoesjud_cobrancaanuidade       = result["ocu_acoesjud_cobrancaanuidade"]       is DBNull ? false           : Convert.ToBoolean(    result["ocu_acoesjud_cobrancaanuidade"]);
                            retorno.ocu_acoesjud_cobrancalevantamento   = result["ocu_acoesjud_cobrancalevantamento"]   is DBNull ? false           : Convert.ToBoolean(    result["ocu_acoesjud_cobrancalevantamento"]);
                            retorno.ocu_acoesjud_assinatura             = result["ocu_acoesjud_assinatura"]             is DBNull ? false           : Convert.ToBoolean(    result["ocu_acoesjud_assinatura"]);
                            retorno.ocu_acoesjud_datadespacho           = result["ocu_acoesjud_datadespacho"]           is DBNull ? dtnull          : Convert.ToDateTime(   result["ocu_acoesjud_datadespacho"]);
                            retorno.ocu_acoesjud_cnpj                   = result["ocu_acoesjud_cnpj"]                   is DBNull ? string.Empty    :                       result["ocu_acoesjud_cnpj"].ToString();
                            retorno.ocu_acoesjud_protocolo              = result["ocu_acoesjud_protocolo"]              is DBNull ? string.Empty    :                       result["ocu_acoesjud_protocolo"].ToString();
                            retorno.ocu_acoesjud_processojudicial       = result["ocu_acoesjud_processojudicial"]       is DBNull ? string.Empty    :                       result["ocu_acoesjud_processojudicial"].ToString();
                            retorno.ocu_acoesjud_historicoresumido      = result["ocu_acoesjud_historicoresumido"]      is DBNull ? string.Empty    :                       result["ocu_acoesjud_historicoresumido"].ToString();
                            retorno.ocu_acoesjud_motivoassinatura       = result["ocu_acoesjud_motivoassinatura"]       is DBNull ? string.Empty    :                       result["ocu_acoesjud_motivoassinatura"].ToString();
                            retorno.ocu_acoesjud_observacao             = result["ocu_acoesjud_observacao"]             is DBNull ? string.Empty    :                       result["ocu_acoesjud_observacao"].ToString();
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
    }
}