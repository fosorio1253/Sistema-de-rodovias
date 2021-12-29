namespace DER.WebApp.Domain.Models
{
    public class BoletoResposta
    {
        public int Boleto_Resposta_Id { get; set; }
        public string siglaSistemaMensagem { get; set; }
        public short codigoRetornoPrograma { get; set; }
        public string nomeProgramaErro { get; set; }
        public string textoMensagemErro { get; set; }
        public short numeroPosicaoErroPrograma { get; set; }
        public short codigoTipoRetornoPrograma { get; set; }
        public string textoNumeroTituloCobrancaBb { get; set; }
        public short numeroCarteiraCobranca { get; set; }
        public short numeroVariacaoCarteiraCobranca { get; set; }
        public short codigoPrefixoDependenciaBeneficiario { get; set; }
        public int numeroContaCorrenteBeneficiario { get; set; }
        public int codigoCliente { get; set; }
        public string linhaDigitavel { get; set; }
        public string codigoBarraNumerico { get; set; }
        public short codigoTipoEnderecoBeneficiario { get; set; }
        public string nomeLogradouroBeneficiario { get; set; }
        public string nomeBairroBeneficiario { get; set; }
        public string nomeMunicipioBeneficiario { get; set; }
        public int codigoMunicipioBeneficiario { get; set; }
        public string siglaUfBeneficiario { get; set; }
        public int codigoCepBeneficiario { get; set; }
        public string indicadorComprovacaoBeneficiario { get; set; }
        public int numeroContratoCobranca { get; set; }
    }
}