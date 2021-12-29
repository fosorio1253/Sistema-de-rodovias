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
    public class BancoBrasilBoletoDAO : BaseDAO<Boleto>
	{
        Logger logger;

        public BancoBrasilBoletoDAO(DerContext context) : base(context)
        {
            logger = new Logger("BancoBrasilBoleto", context);
        }

        public List<Boleto> ObtemTodosBoletos()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var retorno = new List<Boleto>();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_BANCO_BRASIL_BOLETO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            var boleto = new Boleto();
                            boleto.Boleto_Id =                              result["Boleto_Id"] is DBNull ? 0                                       : Convert.ToInt32(      result["Boleto_Id"]);
                            boleto.Boleto_Resposta_Id =                     result["Boleto_Resposta_Id"] is DBNull ? 0                              : Convert.ToInt32(      result["Boleto_Resposta_Id"]);
                            boleto.CpfCnpj =                                result["CpfCnpj"] == null ? string.Empty                                :                       result["CpfCnpj"].ToString();
                            boleto.IdFaturamento =                          result["IdFaturamento"] is DBNull ? 0                                   : Convert.ToInt32(      result["IdFaturamento"]);
                            boleto.TipoFaturamento =                        result["TipoFaturamento"] == null ? string.Empty                        :                       result["TipoFaturamento"].ToString();
                            boleto.pago =                                   result["pago"] == null || result["pago"].ToString() == "0" ? false      :                       true;
                            boleto.codigoAceiteTitulo =                     result["codigoAceiteTitulo"] == null ? string.Empty                     :                       result["codigoAceiteTitulo"].ToString();
                            boleto.codigoChaveUsuario =                     result["codigoChaveUsuario"] == null ? string.Empty                     :                       result["codigoChaveUsuario"].ToString();
                            boleto.codigoModalidadeTitulo =                 result["codigoModalidadeTitulo"] is DBNull ? 0                          : Convert.ToInt32(      result["codigoModalidadeTitulo"]);
                            boleto.codigoTipoCanalSolicitacao =             result["codigoTipoCanalSolicitacao"] is DBNull ? 0                      : Convert.ToInt32(      result["codigoTipoCanalSolicitacao"]);
                            boleto.codigoTipoContaCaucao =                  result["codigoTipoContaCaucao"] is DBNull ? 0                           : Convert.ToInt32(      result["codigoTipoContaCaucao"]);
                            boleto.codigoTipoDesconto =                     result["codigoTipoDesconto"] is DBNull ? 0                              : Convert.ToInt32(      result["codigoTipoDesconto"]);
                            boleto.codigoTipoInscricaoAvalista =            result["codigoTipoInscricaoAvalista"] is DBNull ? 0                     : Convert.ToInt32(      result["codigoTipoInscricaoAvalista"]);
                            boleto.codigoTipoInscricaoPagador =             result["codigoTipoInscricaoPagador"] is DBNull ? 0                      : Convert.ToInt32(      result["codigoTipoInscricaoPagador"]);
                            boleto.codigoTipoJuroMora =                     result["codigoTipoJuroMora"] is DBNull ? 0                              : Convert.ToInt32(      result["codigoTipoJuroMora"]);
                            boleto.codigoTipoMulta =                        result["codigoTipoMulta"] is DBNull ? 0                                 : Convert.ToInt32(      result["codigoTipoMulta"]);
                            boleto.codigoTipoTitulo =                       result["codigoTipoTitulo"] is DBNull ? 0                                : Convert.ToInt32(      result["codigoTipoTitulo"]);
                            boleto.dataDescontoTitulo =                     result["dataDescontoTitulo"] == null ? string.Empty                     :                       result["dataDescontoTitulo"].ToString();
                            boleto.dataEmissaoTitulo =                      result["dataEmissaoTitulo"] == null ? string.Empty                      :                       result["dataEmissaoTitulo"].ToString();
                            boleto.dataMultaTitulo =                        result["dataMultaTitulo"] is DBNull ? string.Empty                      :                       result["dataMultaTitulo"].ToString();
                            boleto.dataVencimentoTitulo =                   result["dataVencimentoTitulo"] is DBNull ? string.Empty                 :                       result["dataVencimentoTitulo"].ToString();
                            boleto.indicadorPermissaoRecebimentoParcial =   result["indicadorPermissaoRecebimentoParcial"] is DBNull ? string.Empty :                       result["indicadorPermissaoRecebimentoParcial"].ToString();
                            boleto.nomeAvalistaTitulo =                     result["nomeAvalistaTitulo"] == null ? string.Empty                     :                       result["nomeAvalistaTitulo"].ToString();
                            boleto.nomeBairroPagador =                      result["nomeBairroPagador"] is DBNull ? string.Empty                    :                       result["nomeBairroPagador"].ToString();
                            boleto.nomeMunicipioPagador =                   result["nomeMunicipioPagador"] is DBNull ? string.Empty                 :                       result["nomeMunicipioPagador"].ToString();
                            boleto.nomePagador =                            result["nomePagador"] == null ? string.Empty                            :                       result["nomePagador"].ToString();
                            boleto.numeroCarteira =                         result["numeroCarteira"] is DBNull ? 0                                  : Convert.ToInt32(      result["numeroCarteira"]);
                            boleto.numeroCepPagador =                       result["numeroCepPagador"] is DBNull ? 0                                : Convert.ToInt32(      result["numeroCepPagador"]);
                            boleto.numeroConvenio =                         result["numeroConvenio"] is DBNull ? 0                                  : Convert.ToInt32(      result["numeroConvenio"]);
                            boleto.numeroInscricaoAvalista =                result["numeroInscricaoAvalista"] is DBNull ? 0                         : Convert.ToDecimal(    result["numeroInscricaoAvalista"]);
                            boleto.numeroInscricaoPagador =                 result["numeroInscricaoPagador"] is DBNull ? 0                          : Convert.ToDecimal(    result["numeroInscricaoPagador"]);
                            boleto.numeroVariacaoCarteira =                 result["numeroVariacaoCarteira"] is DBNull ? 0                          : Convert.ToInt32(      result["numeroVariacaoCarteira"]);
                            boleto.percentualDescontoTitulo =               result["percentualDescontoTitulo"] is DBNull ? 0                        : Convert.ToDecimal(    result["percentualDescontoTitulo"]);
                            boleto.percentualJuroMoraTitulo =               result["percentualJuroMoraTitulo"] is DBNull ? 0                        : Convert.ToDecimal(    result["percentualJuroMoraTitulo"]);
                            boleto.percentualMultaTitulo =                  result["percentualMultaTitulo"] is DBNull ? 0                           : Convert.ToDecimal(    result["percentualMultaTitulo"]);
                            boleto.quantidadeDiaProtesto =                  result["quantidadeDiaProtesto"] is DBNull ? 0                           : Convert.ToInt32(      result["quantidadeDiaProtesto"]);
                            boleto.siglaUfPagador =                         result["siglaUfPagador"] == null ? string.Empty                         :                       result["siglaUfPagador"].ToString();
                            boleto.textoCampoUtilizacaoBeneficiario =       result["textoCampoUtilizacaoBeneficiario"] == null ? string.Empty       :                       result["textoCampoUtilizacaoBeneficiario"].ToString();
                            boleto.textoDescricaoTipoTitulo =               result["textoDescricaoTipoTitulo"] == null ? string.Empty               :                       result["textoDescricaoTipoTitulo"].ToString();
                            boleto.textoEnderecoPagador =                   result["textoEnderecoPagador"] == null ? string.Empty                   :                       result["textoEnderecoPagador"].ToString();
                            boleto.textoMensagemBloquetoOcorrencia =        result["textoMensagemBloquetoOcorrencia"] == null ? string.Empty        :                       result["textoMensagemBloquetoOcorrencia"].ToString();
                            boleto.textoNumeroTelefonePagador =             result["textoNumeroTelefonePagador"] == null ? string.Empty             :                       result["textoNumeroTelefonePagador"].ToString();
                            boleto.textoNumeroTituloBeneficiario =          result["textoNumeroTituloBeneficiario"] == null ? string.Empty          :                       result["textoNumeroTituloBeneficiario"].ToString();
                            boleto.textoNumeroTituloCliente =               result["textoNumeroTituloCliente"] == null ? string.Empty               :                       result["textoNumeroTituloCliente"].ToString();
                            boleto.valorAbatimentoTitulo =                  result["valorAbatimentoTitulo"] is DBNull ? 0                           : Convert.ToDecimal(    result["valorAbatimentoTitulo"]);
                            boleto.valorDescontoTitulo =                    result["valorDescontoTitulo"] is DBNull ? 0                             : Convert.ToDecimal(    result["valorDescontoTitulo"]);
                            boleto.valorJuroMoraTitulo =                    result["valorJuroMoraTitulo"] is DBNull ? 0                             : Convert.ToDecimal(    result["valorJuroMoraTitulo"]);
                            boleto.valorMultaTitulo =                       result["valorMultaTitulo"] is DBNull ? 0                                : Convert.ToDecimal(    result["valorMultaTitulo"]);
                            boleto.valorOriginalTitulo =                    result["valorOriginalTitulo"] is DBNull ? 0                             : Convert.ToDecimal(    result["valorOriginalTitulo"]);

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

        public void Inserir(List<Boleto> domains)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_INS_BANCO_BRASIL_BOLETO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        foreach (var domain in domains)
                        {
                            command.Parameters.Add(new SqlParameter("@Boleto_Resposta_Id",                      domain.Boleto_Resposta_Id));
                            command.Parameters.Add(new SqlParameter("@CpfCnpj",                                 domain.CpfCnpj));
                            command.Parameters.Add(new SqlParameter("@IdFaturamento",                           domain.IdFaturamento));
                            command.Parameters.Add(new SqlParameter("@TipoFaturamento",                         domain.TipoFaturamento));
                            command.Parameters.Add(new SqlParameter("@pago",                                    domain.pago == null || domain.pago == false ? 0 : 1));
                            command.Parameters.Add(new SqlParameter("@codigoAceiteTitulo",                      domain.codigoAceiteTitulo));
							command.Parameters.Add(new SqlParameter("@codigoChaveUsuario",                      domain.codigoChaveUsuario));
							command.Parameters.Add(new SqlParameter("@codigoModalidadeTitulo",                  domain.codigoModalidadeTitulo));
							command.Parameters.Add(new SqlParameter("@codigoTipoCanalSolicitacao",              domain.codigoTipoCanalSolicitacao));
							command.Parameters.Add(new SqlParameter("@codigoTipoContaCaucao",                   domain.codigoTipoContaCaucao));
							command.Parameters.Add(new SqlParameter("@codigoTipoDesconto",                      domain.codigoTipoDesconto));
							command.Parameters.Add(new SqlParameter("@codigoTipoInscricaoAvalista",             domain.codigoTipoInscricaoAvalista));
							command.Parameters.Add(new SqlParameter("@codigoTipoInscricaoPagador",              domain.codigoTipoInscricaoPagador));
							command.Parameters.Add(new SqlParameter("@codigoTipoJuroMora",                      domain.codigoTipoJuroMora));
							command.Parameters.Add(new SqlParameter("@codigoTipoMulta",                         domain.codigoTipoMulta));
							command.Parameters.Add(new SqlParameter("@codigoTipoTitulo",                        domain.codigoTipoTitulo));
							command.Parameters.Add(new SqlParameter("@dataDescontoTitulo",                      domain.dataDescontoTitulo));
							command.Parameters.Add(new SqlParameter("@dataEmissaoTitulo",                       domain.dataEmissaoTitulo));
							command.Parameters.Add(new SqlParameter("@dataMultaTitulo",                         domain.dataMultaTitulo));
							command.Parameters.Add(new SqlParameter("@dataVencimentoTitulo",                    domain.dataVencimentoTitulo));
							command.Parameters.Add(new SqlParameter("@indicadorPermissaoRecebimentoParcial",    domain.indicadorPermissaoRecebimentoParcial));
							command.Parameters.Add(new SqlParameter("@nomeAvalistaTitulo",                      domain.nomeAvalistaTitulo));
							command.Parameters.Add(new SqlParameter("@nomeBairroPagador",                       domain.nomeBairroPagador));
							command.Parameters.Add(new SqlParameter("@nomeMunicipioPagador",                    domain.nomeMunicipioPagador));
							command.Parameters.Add(new SqlParameter("@nomePagador",                             domain.nomePagador));
							command.Parameters.Add(new SqlParameter("@numeroCarteira",                          domain.numeroCarteira));
							command.Parameters.Add(new SqlParameter("@numeroCepPagador",                        domain.numeroCepPagador));
							command.Parameters.Add(new SqlParameter("@numeroConvenio",                          domain.numeroConvenio));
							command.Parameters.Add(new SqlParameter("@numeroInscricaoAvalista",                 domain.numeroInscricaoAvalista));
							command.Parameters.Add(new SqlParameter("@numeroInscricaoPagador",                  domain.numeroInscricaoPagador));
							command.Parameters.Add(new SqlParameter("@numeroVariacaoCarteira",                  domain.numeroVariacaoCarteira));
							command.Parameters.Add(new SqlParameter("@percentualDescontoTitulo",                domain.percentualDescontoTitulo));
							command.Parameters.Add(new SqlParameter("@percentualJuroMoraTitulo",                domain.percentualJuroMoraTitulo));
							command.Parameters.Add(new SqlParameter("@percentualMultaTitulo",                   domain.percentualMultaTitulo));
							command.Parameters.Add(new SqlParameter("@quantidadeDiaProtesto",                   domain.quantidadeDiaProtesto));
							command.Parameters.Add(new SqlParameter("@siglaUfPagador",                          domain.siglaUfPagador));
							command.Parameters.Add(new SqlParameter("@textoCampoUtilizacaoBeneficiario",        domain.textoCampoUtilizacaoBeneficiario));
							command.Parameters.Add(new SqlParameter("@textoDescricaoTipoTitulo",                domain.textoDescricaoTipoTitulo));
							command.Parameters.Add(new SqlParameter("@textoEnderecoPagador",                    domain.textoEnderecoPagador));
							command.Parameters.Add(new SqlParameter("@textoMensagemBloquetoOcorrencia",         domain.textoMensagemBloquetoOcorrencia));
							command.Parameters.Add(new SqlParameter("@textoNumeroTelefonePagador",              domain.textoNumeroTelefonePagador));
							command.Parameters.Add(new SqlParameter("@textoNumeroTituloBeneficiario",           domain.textoNumeroTituloBeneficiario));
							command.Parameters.Add(new SqlParameter("@textoNumeroTituloCliente",                domain.textoNumeroTituloCliente));
							command.Parameters.Add(new SqlParameter("@valorAbatimentoTitulo",                   domain.valorAbatimentoTitulo));
							command.Parameters.Add(new SqlParameter("@valorDescontoTitulo",                     domain.valorDescontoTitulo));
							command.Parameters.Add(new SqlParameter("@valorJuroMoraTitulo",                     domain.valorJuroMoraTitulo));
							command.Parameters.Add(new SqlParameter("@valorMultaTitulo",                        domain.valorMultaTitulo));
							command.Parameters.Add(new SqlParameter("@valorOriginalTitulo",                     domain.valorOriginalTitulo));

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

        public void Update(Boleto domain)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var oldValue = GetById(domain.Boleto_Id);
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_UPD_BANCO_BRASIL_BOLETO", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@Boleto_Id",                               domain.Boleto_Id));
                        command.Parameters.Add(new SqlParameter("@Boleto_Resposta_Id",                      domain.Boleto_Resposta_Id));
                        command.Parameters.Add(new SqlParameter("@CpfCnpj",                                 domain.CpfCnpj));
                        command.Parameters.Add(new SqlParameter("@IdFaturamento",                           domain.IdFaturamento));
                        command.Parameters.Add(new SqlParameter("@TipoFaturamento",                         domain.TipoFaturamento));
                        command.Parameters.Add(new SqlParameter("@pago",                                    domain.pago == null || domain.pago == false ? 0 : 1));
                        command.Parameters.Add(new SqlParameter("@codigoAceiteTitulo",                      domain.codigoAceiteTitulo));
                        command.Parameters.Add(new SqlParameter("@codigoChaveUsuario",                      domain.codigoChaveUsuario));
                        command.Parameters.Add(new SqlParameter("@codigoModalidadeTitulo",                  domain.codigoModalidadeTitulo));
                        command.Parameters.Add(new SqlParameter("@codigoTipoCanalSolicitacao",              domain.codigoTipoCanalSolicitacao));
                        command.Parameters.Add(new SqlParameter("@codigoTipoContaCaucao",                   domain.codigoTipoContaCaucao));
                        command.Parameters.Add(new SqlParameter("@codigoTipoDesconto",                      domain.codigoTipoDesconto));
                        command.Parameters.Add(new SqlParameter("@codigoTipoInscricaoAvalista",             domain.codigoTipoInscricaoAvalista));
                        command.Parameters.Add(new SqlParameter("@codigoTipoInscricaoPagador",              domain.codigoTipoInscricaoPagador));
                        command.Parameters.Add(new SqlParameter("@codigoTipoJuroMora",                      domain.codigoTipoJuroMora));
                        command.Parameters.Add(new SqlParameter("@codigoTipoMulta",                         domain.codigoTipoMulta));
                        command.Parameters.Add(new SqlParameter("@codigoTipoTitulo",                        domain.codigoTipoTitulo));
                        command.Parameters.Add(new SqlParameter("@dataDescontoTitulo",                      domain.dataDescontoTitulo));
                        command.Parameters.Add(new SqlParameter("@dataEmissaoTitulo",                       domain.dataEmissaoTitulo));
                        command.Parameters.Add(new SqlParameter("@dataMultaTitulo",                         domain.dataMultaTitulo));
                        command.Parameters.Add(new SqlParameter("@dataVencimentoTitulo",                    domain.dataVencimentoTitulo));
                        command.Parameters.Add(new SqlParameter("@indicadorPermissaoRecebimentoParcial",    domain.indicadorPermissaoRecebimentoParcial));
                        command.Parameters.Add(new SqlParameter("@nomeAvalistaTitulo",                      domain.nomeAvalistaTitulo));
                        command.Parameters.Add(new SqlParameter("@nomeBairroPagador",                       domain.nomeBairroPagador));
                        command.Parameters.Add(new SqlParameter("@nomeMunicipioPagador",                    domain.nomeMunicipioPagador));
                        command.Parameters.Add(new SqlParameter("@nomePagador",                             domain.nomePagador));
                        command.Parameters.Add(new SqlParameter("@numeroCarteira",                          domain.numeroCarteira));
                        command.Parameters.Add(new SqlParameter("@numeroCepPagador",                        domain.numeroCepPagador));
                        command.Parameters.Add(new SqlParameter("@numeroConvenio",                          domain.numeroConvenio));
                        command.Parameters.Add(new SqlParameter("@numeroInscricaoAvalista",                 domain.numeroInscricaoAvalista));
                        command.Parameters.Add(new SqlParameter("@numeroInscricaoPagador",                  domain.numeroInscricaoPagador));
                        command.Parameters.Add(new SqlParameter("@numeroVariacaoCarteira",                  domain.numeroVariacaoCarteira));
                        command.Parameters.Add(new SqlParameter("@percentualDescontoTitulo",                domain.percentualDescontoTitulo));
                        command.Parameters.Add(new SqlParameter("@percentualJuroMoraTitulo",                domain.percentualJuroMoraTitulo));
                        command.Parameters.Add(new SqlParameter("@percentualMultaTitulo",                   domain.percentualMultaTitulo));
                        command.Parameters.Add(new SqlParameter("@quantidadeDiaProtesto",                   domain.quantidadeDiaProtesto));
                        command.Parameters.Add(new SqlParameter("@siglaUfPagador",                          domain.siglaUfPagador));
                        command.Parameters.Add(new SqlParameter("@textoCampoUtilizacaoBeneficiario",        domain.textoCampoUtilizacaoBeneficiario));
                        command.Parameters.Add(new SqlParameter("@textoDescricaoTipoTitulo",                domain.textoDescricaoTipoTitulo));
                        command.Parameters.Add(new SqlParameter("@textoEnderecoPagador",                    domain.textoEnderecoPagador));
                        command.Parameters.Add(new SqlParameter("@textoMensagemBloquetoOcorrencia",         domain.textoMensagemBloquetoOcorrencia));
                        command.Parameters.Add(new SqlParameter("@textoNumeroTelefonePagador",              domain.textoNumeroTelefonePagador));
                        command.Parameters.Add(new SqlParameter("@textoNumeroTituloBeneficiario",           domain.textoNumeroTituloBeneficiario));
                        command.Parameters.Add(new SqlParameter("@textoNumeroTituloCliente",                domain.textoNumeroTituloCliente));
                        command.Parameters.Add(new SqlParameter("@valorAbatimentoTitulo",                   domain.valorAbatimentoTitulo));
                        command.Parameters.Add(new SqlParameter("@valorDescontoTitulo",                     domain.valorDescontoTitulo));
                        command.Parameters.Add(new SqlParameter("@valorJuroMoraTitulo",                     domain.valorJuroMoraTitulo));
                        command.Parameters.Add(new SqlParameter("@valorMultaTitulo",                        domain.valorMultaTitulo));
                        command.Parameters.Add(new SqlParameter("@valorOriginalTitulo",                     domain.valorOriginalTitulo));

                        var result = command.ExecuteNonQuery();

                        conn.Close();
                    }
                }
                var value = GetById(domain.Boleto_Id);
                if (!value.Equals(oldValue))
                    logger.salvarLog(TipoAlteracao.Edicao, domain.Boleto_Id.ToString(), logger.serializer.Serialize(oldValue), logger.serializer.Serialize(value));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boleto GetById(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString;
            var boleto = new Boleto();

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("STP_SEL_BANCO_BRASIL_BOLETO_BYID", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        conn.Open();

                        command.Parameters.Add(new SqlParameter("@Boleto_Id", id));
                        SqlDataReader result = command.ExecuteReader();

                        while (result.Read())
                        {
                            boleto.Boleto_Id =                              result["Boleto_Id"] is DBNull ? 0                                       : Convert.ToInt32(      result["Boleto_Id"]);
                            boleto.Boleto_Resposta_Id =                     result["Boleto_Resposta_Id"] is DBNull ? 0                              : Convert.ToInt32(      result["Boleto_Resposta_Id"]);
                            boleto.CpfCnpj =                                result["CpfCnpj"] == null ? string.Empty                                :                       result["CpfCnpj"].ToString();
                            boleto.IdFaturamento =                          result["IdFaturamento"] is DBNull ? 0                                   : Convert.ToInt32(      result["IdFaturamento"]);
                            boleto.TipoFaturamento =                        result["TipoFaturamento"] == null ? string.Empty                        :                       result["TipoFaturamento"].ToString();
                            boleto.pago =                                   result["pago"] == null || result["pago"].ToString() == "0" ? false      :                       true;
                            boleto.codigoAceiteTitulo =                     result["codigoAceiteTitulo"] == null ? string.Empty                     :                       result["codigoAceiteTitulo"].ToString();
                            boleto.codigoChaveUsuario =                     result["codigoChaveUsuario"] == null ? string.Empty                     :                       result["codigoChaveUsuario"].ToString();
                            boleto.codigoModalidadeTitulo =                 result["codigoModalidadeTitulo"] is DBNull ? 0                          : Convert.ToInt32(      result["codigoModalidadeTitulo"]);
                            boleto.codigoTipoCanalSolicitacao =             result["codigoTipoCanalSolicitacao"] is DBNull ? 0                      : Convert.ToInt32(      result["codigoTipoCanalSolicitacao"]);
                            boleto.codigoTipoContaCaucao =                  result["codigoTipoContaCaucao"] is DBNull ? 0                           : Convert.ToInt32(      result["codigoTipoContaCaucao"]);
                            boleto.codigoTipoDesconto =                     result["codigoTipoDesconto"] is DBNull ? 0                              : Convert.ToInt32(      result["codigoTipoDesconto"]);
                            boleto.codigoTipoInscricaoAvalista =            result["codigoTipoInscricaoAvalista"] is DBNull ? 0                     : Convert.ToInt32(      result["codigoTipoInscricaoAvalista"]);
                            boleto.codigoTipoInscricaoPagador =             result["codigoTipoInscricaoPagador"] is DBNull ? 0                      : Convert.ToInt32(      result["codigoTipoInscricaoPagador"]);
                            boleto.codigoTipoJuroMora =                     result["codigoTipoJuroMora"] is DBNull ? 0                              : Convert.ToInt32(      result["codigoTipoJuroMora"]);
                            boleto.codigoTipoMulta =                        result["codigoTipoMulta"] is DBNull ? 0                                 : Convert.ToInt32(      result["codigoTipoMulta"]);
                            boleto.codigoTipoTitulo =                       result["codigoTipoTitulo"] is DBNull ? 0                                : Convert.ToInt32(      result["codigoTipoTitulo"]);
                            boleto.dataDescontoTitulo =                     result["dataDescontoTitulo"] == null ? string.Empty                     :                       result["dataDescontoTitulo"].ToString();
                            boleto.dataEmissaoTitulo =                      result["dataEmissaoTitulo"] == null ? string.Empty                      :                       result["dataEmissaoTitulo"].ToString();
                            boleto.dataMultaTitulo =                        result["dataMultaTitulo"] is DBNull ? string.Empty                      :                       result["dataMultaTitulo"].ToString();
                            boleto.dataVencimentoTitulo =                   result["dataVencimentoTitulo"] is DBNull ? string.Empty                 :                       result["dataVencimentoTitulo"].ToString();
                            boleto.indicadorPermissaoRecebimentoParcial =   result["indicadorPermissaoRecebimentoParcial"] is DBNull ? string.Empty :                       result["indicadorPermissaoRecebimentoParcial"].ToString();
                            boleto.nomeAvalistaTitulo =                     result["nomeAvalistaTitulo"] == null ? string.Empty                     :                       result["nomeAvalistaTitulo"].ToString();
                            boleto.nomeBairroPagador =                      result["nomeBairroPagador"] is DBNull ? string.Empty                    :                       result["nomeBairroPagador"].ToString();
                            boleto.nomeMunicipioPagador =                   result["nomeMunicipioPagador"] is DBNull ? string.Empty                 :                       result["nomeMunicipioPagador"].ToString();
                            boleto.nomePagador =                            result["nomePagador"] == null ? string.Empty                            :                       result["nomePagador"].ToString();
                            boleto.numeroCarteira =                         result["numeroCarteira"] is DBNull ? 0                                  : Convert.ToInt32(      result["numeroCarteira"]);
                            boleto.numeroCepPagador =                       result["numeroCepPagador"] is DBNull ? 0                                : Convert.ToInt32(      result["numeroCepPagador"]);
                            boleto.numeroConvenio =                         result["numeroConvenio"] is DBNull ? 0                                  : Convert.ToInt32(      result["numeroConvenio"]);
                            boleto.numeroInscricaoAvalista =                result["numeroInscricaoAvalista"] is DBNull ? 0                         : Convert.ToDecimal(    result["numeroInscricaoAvalista"]);
                            boleto.numeroInscricaoPagador =                 result["numeroInscricaoPagador"] is DBNull ? 0                          : Convert.ToDecimal(    result["numeroInscricaoPagador"]);
                            boleto.numeroVariacaoCarteira =                 result["numeroVariacaoCarteira"] is DBNull ? 0                          : Convert.ToInt32(      result["numeroVariacaoCarteira"]);
                            boleto.percentualDescontoTitulo =               result["percentualDescontoTitulo"] is DBNull ? 0                        : Convert.ToDecimal(    result["percentualDescontoTitulo"]);
                            boleto.percentualJuroMoraTitulo =               result["percentualJuroMoraTitulo"] is DBNull ? 0                        : Convert.ToDecimal(    result["percentualJuroMoraTitulo"]);
                            boleto.percentualMultaTitulo =                  result["percentualMultaTitulo"] is DBNull ? 0                           : Convert.ToDecimal(    result["percentualMultaTitulo"]);
                            boleto.quantidadeDiaProtesto =                  result["quantidadeDiaProtesto"] is DBNull ? 0                           : Convert.ToInt32(      result["quantidadeDiaProtesto"]);
                            boleto.siglaUfPagador =                         result["siglaUfPagador"] == null ? string.Empty                         :                       result["siglaUfPagador"].ToString();
                            boleto.textoCampoUtilizacaoBeneficiario =       result["textoCampoUtilizacaoBeneficiario"] == null ? string.Empty       :                       result["textoCampoUtilizacaoBeneficiario"].ToString();
                            boleto.textoDescricaoTipoTitulo =               result["textoDescricaoTipoTitulo"] == null ? string.Empty               :                       result["textoDescricaoTipoTitulo"].ToString();
                            boleto.textoEnderecoPagador =                   result["textoEnderecoPagador"] == null ? string.Empty                   :                       result["textoEnderecoPagador"].ToString();
                            boleto.textoMensagemBloquetoOcorrencia =        result["textoMensagemBloquetoOcorrencia"] == null ? string.Empty        :                       result["textoMensagemBloquetoOcorrencia"].ToString();
                            boleto.textoNumeroTelefonePagador =             result["textoNumeroTelefonePagador"] == null ? string.Empty             :                       result["textoNumeroTelefonePagador"].ToString();
                            boleto.textoNumeroTituloBeneficiario =          result["textoNumeroTituloBeneficiario"] == null ? string.Empty          :                       result["textoNumeroTituloBeneficiario"].ToString();
                            boleto.textoNumeroTituloCliente =               result["textoNumeroTituloCliente"] == null ? string.Empty               :                       result["textoNumeroTituloCliente"].ToString();
                            boleto.valorAbatimentoTitulo =                  result["valorAbatimentoTitulo"] is DBNull ? 0                           : Convert.ToDecimal(    result["valorAbatimentoTitulo"]);
                            boleto.valorDescontoTitulo =                    result["valorDescontoTitulo"] is DBNull ? 0                             : Convert.ToDecimal(    result["valorDescontoTitulo"]);
                            boleto.valorJuroMoraTitulo =                    result["valorJuroMoraTitulo"] is DBNull ? 0                             : Convert.ToDecimal(    result["valorJuroMoraTitulo"]);
                            boleto.valorMultaTitulo =                       result["valorMultaTitulo"] is DBNull ? 0                                : Convert.ToDecimal(    result["valorMultaTitulo"]);
                            boleto.valorOriginalTitulo =                    result["valorOriginalTitulo"] is DBNull ? 0                             : Convert.ToDecimal(    result["valorOriginalTitulo"]);

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