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
    public class BancoBrasilBoletoRespostaDAO : BaseDAO<BoletoResposta>
    {
        Logger logger;

        public BancoBrasilBoletoRespostaDAO(DerContext context) : base(context)
        {
            logger = new Logger("BancoBrasilBoletoResposta", context);
        }

        public List<BoletoResposta> ObtemTodosBoletosResposta()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new List<BoletoResposta>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_BANCO_BRASIL_BOLETO_RESPOSTA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var boleto = new BoletoResposta();
                            boleto.Boleto_Resposta_Id =                     (int)(result["Boleto_Resposta_Id"] is DBNull ? 0                            : result["Boleto_Resposta_Id"]);
                            boleto.siglaSistemaMensagem =                   (string)(result["siglaSistemaMensagem"] == null ? string.Empty              : result["siglaSistemaMensagem"]);
                            boleto.codigoRetornoPrograma =                  (short)(result["codigoRetornoPrograma"] is DBNull ? 0                       : result["codigoRetornoPrograma"]);
                            boleto.nomeProgramaErro =                       (string)(result["nomeProgramaErro"] == null ? string.Empty                  : result["nomeProgramaErro"]);
                            boleto.textoMensagemErro =                      (string)(result["textoMensagemErro"] == null ? string.Empty                 : result["textoMensagemErro"]);
                            boleto.numeroPosicaoErroPrograma =              (short)(result["numeroPosicaoErroPrograma"] is DBNull ? 0                   : result["numeroPosicaoErroPrograma"]);
                            boleto.codigoTipoRetornoPrograma =              (short)(result["codigoTipoRetornoPrograma"] is DBNull ? 0                   : result["codigoTipoRetornoPrograma"]);
                            boleto.textoNumeroTituloCobrancaBb =            (string)(result["textoNumeroTituloCobrancaBb"] == null ? string.Empty       : result["textoNumeroTituloCobrancaBb"]);
                            boleto.numeroCarteiraCobranca =                 (short)(result["numeroCarteiraCobranca"] is DBNull ? 0                      : result["numeroCarteiraCobranca"]);
                            boleto.numeroVariacaoCarteiraCobranca =         (short)(result["numeroVariacaoCarteiraCobranca"] is DBNull ? 0              : result["numeroVariacaoCarteiraCobranca"]);
                            boleto.codigoPrefixoDependenciaBeneficiario =   (short)(result["codigoPrefixoDependenciaBeneficiario"] is DBNull ? 0        : result["codigoPrefixoDependenciaBeneficiario"]);
                            boleto.numeroContaCorrenteBeneficiario =        (int)(result["numeroContaCorrenteBeneficiario"] is DBNull ? 0               : result["numeroContaCorrenteBeneficiario"]);
                            boleto.codigoCliente =                          (int)(result["codigoCliente"] is DBNull ? 0                                 : result["codigoCliente"]);
                            boleto.linhaDigitavel =                         (string)(result["linhaDigitavel"] == null ? string.Empty                    : result["linhaDigitavel"]);
                            boleto.codigoBarraNumerico =                    (string)(result["codigoBarraNumerico"] == null ? string.Empty               : result["codigoBarraNumerico"]);
                            boleto.codigoTipoEnderecoBeneficiario =         (short)(result["codigoTipoEnderecoBeneficiario"] is DBNull ? 0              : result["codigoTipoEnderecoBeneficiario"]);
                            boleto.nomeLogradouroBeneficiario =             (string)(result["nomeLogradouroBeneficiario"] == null ? string.Empty        : result["nomeLogradouroBeneficiario"]);
                            boleto.nomeBairroBeneficiario =                 (string)(result["nomeBairroBeneficiario"] == null ? string.Empty            : result["nomeBairroBeneficiario"]);
                            boleto.nomeMunicipioBeneficiario =              (string)(result["nomeMunicipioBeneficiario"] == null ? string.Empty         : result["nomeMunicipioBeneficiario"]);
                            boleto.codigoMunicipioBeneficiario =            (int)(result["codigoMunicipioBeneficiario"] is DBNull ? 0                   : result["codigoMunicipioBeneficiario"]);
                            boleto.siglaUfBeneficiario =                    (string)(result["siglaUfBeneficiario"] == null ? string.Empty               : result["siglaUfBeneficiario"]);
                            boleto.codigoCepBeneficiario =                  (int)(result["codigoCepBeneficiario"] is DBNull ? 0                         : result["codigoCepBeneficiario"]);
                            boleto.indicadorComprovacaoBeneficiario =       (string)(result["indicadorComprovacaoBeneficiario"] == null ? string.Empty  : result["indicadorComprovacaoBeneficiario"]);
                            boleto.numeroContratoCobranca =                 (int)(result["numeroContratoCobranca"] is DBNull ? 0                        : result["numeroContratoCobranca"]);

                            retorno.Add(boleto);
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

        public void Inserir(List<BoletoResposta> domains)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_BANCO_BRASIL_BOLETO_RESPOSTA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        foreach (var domain in domains)
                        {
                            var result = command.ExecuteScalar();

                            command.Parameters.Add(new SqlParameter("@codigoBarraNumerico",                     domain.codigoBarraNumerico));
                            command.Parameters.Add(new SqlParameter("@codigoCepBeneficiario",                   domain.codigoCepBeneficiario));
                            command.Parameters.Add(new SqlParameter("@codigoCliente",                           domain.codigoCliente));
                            command.Parameters.Add(new SqlParameter("@codigoMunicipioBeneficiario",             domain.codigoMunicipioBeneficiario));
                            command.Parameters.Add(new SqlParameter("@codigoPrefixoDependenciaBeneficiario",    domain.codigoPrefixoDependenciaBeneficiario));
                            command.Parameters.Add(new SqlParameter("@codigoRetornoPrograma",                   domain.codigoRetornoPrograma));
                            command.Parameters.Add(new SqlParameter("@codigoTipoEnderecoBeneficiario",          domain.codigoTipoEnderecoBeneficiario));
                            command.Parameters.Add(new SqlParameter("@codigoTipoRetornoPrograma",               domain.codigoTipoRetornoPrograma));
                            command.Parameters.Add(new SqlParameter("@indicadorComprovacaoBeneficiario",        domain.indicadorComprovacaoBeneficiario));
                            command.Parameters.Add(new SqlParameter("@linhaDigitavel",                          domain.linhaDigitavel));
                            command.Parameters.Add(new SqlParameter("@nomeBairroBeneficiario",                  domain.nomeBairroBeneficiario));
                            command.Parameters.Add(new SqlParameter("@nomeLogradouroBeneficiario",              domain.nomeLogradouroBeneficiario));
                            command.Parameters.Add(new SqlParameter("@nomeMunicipioBeneficiario",               domain.nomeMunicipioBeneficiario));
                            command.Parameters.Add(new SqlParameter("@nomeProgramaErro",                        domain.nomeProgramaErro));
                            command.Parameters.Add(new SqlParameter("@numeroCarteiraCobranca",                  domain.numeroCarteiraCobranca));
                            command.Parameters.Add(new SqlParameter("@numeroContaCorrenteBeneficiario",         domain.numeroContaCorrenteBeneficiario));
                            command.Parameters.Add(new SqlParameter("@numeroContratoCobranca",                  domain.numeroContratoCobranca));
                            command.Parameters.Add(new SqlParameter("@numeroPosicaoErroPrograma",               domain.numeroPosicaoErroPrograma));
                            command.Parameters.Add(new SqlParameter("@numeroVariacaoCarteiraCobranca",          domain.numeroVariacaoCarteiraCobranca));
                            command.Parameters.Add(new SqlParameter("@siglaSistemaMensagem",                    domain.siglaSistemaMensagem));
                            command.Parameters.Add(new SqlParameter("@siglaUfBeneficiario",                     domain.siglaUfBeneficiario));
                            command.Parameters.Add(new SqlParameter("@textoMensagemErro",                       domain.textoMensagemErro));
                            command.Parameters.Add(new SqlParameter("@textoNumeroTituloCobrancaBb",             domain.textoNumeroTituloCobrancaBb));

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

        public void Update(BoletoResposta domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.Boleto_Resposta_Id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_BANCO_BRASIL_BOLETO_RESPOSTA", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@Boleto_Resposta_Id",                      domain.Boleto_Resposta_Id));
                        command.Parameters.Add(new SqlParameter("@codigoBarraNumerico",                     domain.codigoBarraNumerico));
                        command.Parameters.Add(new SqlParameter("@codigoCepBeneficiario",                   domain.codigoCepBeneficiario));
                        command.Parameters.Add(new SqlParameter("@codigoCliente",                           domain.codigoCliente));
                        command.Parameters.Add(new SqlParameter("@codigoMunicipioBeneficiario",             domain.codigoMunicipioBeneficiario));
                        command.Parameters.Add(new SqlParameter("@codigoPrefixoDependenciaBeneficiario",    domain.codigoPrefixoDependenciaBeneficiario));
                        command.Parameters.Add(new SqlParameter("@codigoRetornoPrograma",                   domain.codigoRetornoPrograma));
                        command.Parameters.Add(new SqlParameter("@codigoTipoEnderecoBeneficiario",          domain.codigoTipoEnderecoBeneficiario));
                        command.Parameters.Add(new SqlParameter("@codigoTipoRetornoPrograma",               domain.codigoTipoRetornoPrograma));
                        command.Parameters.Add(new SqlParameter("@indicadorComprovacaoBeneficiario",        domain.indicadorComprovacaoBeneficiario));
                        command.Parameters.Add(new SqlParameter("@linhaDigitavel",                          domain.linhaDigitavel));
                        command.Parameters.Add(new SqlParameter("@nomeBairroBeneficiario",                  domain.nomeBairroBeneficiario));
                        command.Parameters.Add(new SqlParameter("@nomeLogradouroBeneficiario",              domain.nomeLogradouroBeneficiario));
                        command.Parameters.Add(new SqlParameter("@nomeMunicipioBeneficiario",               domain.nomeMunicipioBeneficiario));
                        command.Parameters.Add(new SqlParameter("@nomeProgramaErro",                        domain.nomeProgramaErro));
                        command.Parameters.Add(new SqlParameter("@numeroCarteiraCobranca",                  domain.numeroCarteiraCobranca));
                        command.Parameters.Add(new SqlParameter("@numeroContaCorrenteBeneficiario",         domain.numeroContaCorrenteBeneficiario));
                        command.Parameters.Add(new SqlParameter("@numeroContratoCobranca",                  domain.numeroContratoCobranca));
                        command.Parameters.Add(new SqlParameter("@numeroPosicaoErroPrograma",               domain.numeroPosicaoErroPrograma));
                        command.Parameters.Add(new SqlParameter("@numeroVariacaoCarteiraCobranca",          domain.numeroVariacaoCarteiraCobranca));
                        command.Parameters.Add(new SqlParameter("@siglaSistemaMensagem",                    domain.siglaSistemaMensagem));
                        command.Parameters.Add(new SqlParameter("@siglaUfBeneficiario",                     domain.siglaUfBeneficiario));
                        command.Parameters.Add(new SqlParameter("@textoMensagemErro",                       domain.textoMensagemErro));
                        command.Parameters.Add(new SqlParameter("@textoNumeroTituloCobrancaBb",             domain.textoNumeroTituloCobrancaBb));

                        var result = command.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                var value = GetById(domain.Boleto_Resposta_Id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.Boleto_Resposta_Id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BoletoResposta GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var boleto = new BoletoResposta();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_BANCO_BRASIL_BOLETO_RESPOSTA_BYID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@Boleto_Resposta_Id", id));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            boleto.Boleto_Resposta_Id =                     (int)(result["Boleto_Resposta_Id"] is DBNull ? 0                            : result["Boleto_Resposta_Id"]);
                            boleto.siglaSistemaMensagem =                   (string)(result["siglaSistemaMensagem"] == null ? string.Empty              : result["siglaSistemaMensagem"]);
                            boleto.codigoRetornoPrograma =                  (short)(result["codigoRetornoPrograma"] is DBNull ? 0                       : result["codigoRetornoPrograma"]);
                            boleto.nomeProgramaErro =                       (string)(result["nomeProgramaErro"] == null ? string.Empty                  : result["nomeProgramaErro"]);
                            boleto.textoMensagemErro =                      (string)(result["textoMensagemErro"] == null ? string.Empty                 : result["textoMensagemErro"]);
                            boleto.numeroPosicaoErroPrograma =              (short)(result["numeroPosicaoErroPrograma"] is DBNull ? 0                   : result["numeroPosicaoErroPrograma"]);
                            boleto.codigoTipoRetornoPrograma =              (short)(result["codigoTipoRetornoPrograma"] is DBNull ? 0                   : result["codigoTipoRetornoPrograma"]);
                            boleto.textoNumeroTituloCobrancaBb =            (string)(result["textoNumeroTituloCobrancaBb"] == null ? string.Empty       : result["textoNumeroTituloCobrancaBb"]);
                            boleto.numeroCarteiraCobranca =                 (short)(result["numeroCarteiraCobranca"] is DBNull ? 0                      : result["numeroCarteiraCobranca"]);
                            boleto.numeroVariacaoCarteiraCobranca =         (short)(result["numeroVariacaoCarteiraCobranca"] is DBNull ? 0              : result["numeroVariacaoCarteiraCobranca"]);
                            boleto.codigoPrefixoDependenciaBeneficiario =   (short)(result["codigoPrefixoDependenciaBeneficiario"] is DBNull ? 0        : result["codigoPrefixoDependenciaBeneficiario"]);
                            boleto.numeroContaCorrenteBeneficiario =        (int)(result["numeroContaCorrenteBeneficiario"] is DBNull ? 0               : result["numeroContaCorrenteBeneficiario"]);
                            boleto.codigoCliente =                          (int)(result["codigoCliente"] is DBNull ? 0                                 : result["codigoCliente"]);
                            boleto.linhaDigitavel =                         (string)(result["linhaDigitavel"] == null ? string.Empty                    : result["linhaDigitavel"]);
                            boleto.codigoBarraNumerico =                    (string)(result["codigoBarraNumerico"] == null ? string.Empty               : result["codigoBarraNumerico"]);
                            boleto.codigoTipoEnderecoBeneficiario =         (short)(result["codigoTipoEnderecoBeneficiario"] is DBNull ? 0              : result["codigoTipoEnderecoBeneficiario"]);
                            boleto.nomeLogradouroBeneficiario =             (string)(result["nomeLogradouroBeneficiario"] == null ? string.Empty        : result["nomeLogradouroBeneficiario"]);
                            boleto.nomeBairroBeneficiario =                 (string)(result["nomeBairroBeneficiario"] == null ? string.Empty            : result["nomeBairroBeneficiario"]);
                            boleto.nomeMunicipioBeneficiario =              (string)(result["nomeMunicipioBeneficiario"] == null ? string.Empty         : result["nomeMunicipioBeneficiario"]);
                            boleto.codigoMunicipioBeneficiario =            (int)(result["codigoMunicipioBeneficiario"] is DBNull ? 0                   : result["codigoMunicipioBeneficiario"]);
                            boleto.siglaUfBeneficiario =                    (string)(result["siglaUfBeneficiario"] == null ? string.Empty               : result["siglaUfBeneficiario"]);
                            boleto.codigoCepBeneficiario =                  (int)(result["codigoCepBeneficiario"] is DBNull ? 0                         : result["codigoCepBeneficiario"]);
                            boleto.indicadorComprovacaoBeneficiario =       (string)(result["indicadorComprovacaoBeneficiario"] == null ? string.Empty  : result["indicadorComprovacaoBeneficiario"]);
                            boleto.numeroContratoCobranca =                 (int)(result["numeroContratoCobranca"] is DBNull ? 0                        : result["numeroContratoCobranca"]);
                        }
                        conn.Close();
                    }
                }
                return boleto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}