namespace DER.WebApp.Domain.Models
{
    public class Boleto
    {
        public int      Boleto_Id                               { get; set; }
        public int      Boleto_Resposta_Id                      { get; set; }
        public int      IdFaturamento                           { get; set; }
        public string   TipoFaturamento                         { get; set; }
        public string   CpfCnpj                                 { get; set; }
        public bool     pago                                    { get; set; }
        public bool     Producao                                { get; set; }
        public string   codigoAceiteTitulo                      { get; set; }
        public string   codigoChaveUsuario                      { get; set; }
        public int      codigoModalidadeTitulo                  { get; set; }
        public int      codigoTipoCanalSolicitacao              { get; set; }
        public int      codigoTipoContaCaucao                   { get; set; }
        public int      codigoTipoDesconto                      { get; set; }
        public int      codigoTipoInscricaoAvalista             { get; set; }
        public int      codigoTipoInscricaoPagador              { get; set; }
        public int      codigoTipoJuroMora                      { get; set; }
        public int      codigoTipoMulta                         { get; set; }
        public int      codigoTipoTitulo                        { get; set; }
        public string   dataDescontoTitulo                      { get; set; }
        public string   dataEmissaoTitulo                       { get; set; }
        public string   dataMultaTitulo                         { get; set; }
        public string   dataVencimentoTitulo                    { get; set; }
        public string   indicadorPermissaoRecebimentoParcial    { get; set; }
        public string   nomeAvalistaTitulo                      { get; set; }
        public string   nomeBairroPagador                       { get; set; }
        public string   nomeMunicipioPagador                    { get; set; }
        public string   nomePagador                             { get; set; }
        public int      numeroCarteira                          { get; set; }
        public int      numeroCepPagador                        { get; set; }
        public int      numeroConvenio                          { get; set; }
        public decimal  numeroInscricaoAvalista                 { get; set; }
        public decimal  numeroInscricaoPagador                  { get; set; }
        public int      numeroVariacaoCarteira                  { get; set; }
        public decimal  percentualDescontoTitulo                { get; set; }
        public decimal  percentualJuroMoraTitulo                { get; set; }
        public decimal  percentualMultaTitulo                   { get; set; }
        public int      quantidadeDiaProtesto                   { get; set; }
        public string   siglaUfPagador                          { get; set; }
        public string   textoCampoUtilizacaoBeneficiario        { get; set; }
        public string   textoDescricaoTipoTitulo                { get; set; }
        public string   textoEnderecoPagador                    { get; set; }
        public string   textoMensagemBloquetoOcorrencia         { get; set; }
        public string   textoNumeroTelefonePagador              { get; set; }
        public string   textoNumeroTituloBeneficiario           { get; set; }
        public string   textoNumeroTituloCliente                { get; set; }
        public decimal  valorAbatimentoTitulo                   { get; set; }
        public decimal  valorDescontoTitulo                     { get; set; }
        public decimal  valorJuroMoraTitulo                     { get; set; }
        public decimal  valorMultaTitulo                        { get; set; }
        public decimal  valorOriginalTitulo                     { get; set; }
    }
}