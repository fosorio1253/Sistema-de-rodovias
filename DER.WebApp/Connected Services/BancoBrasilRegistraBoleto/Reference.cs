﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DER.WebApp.BancoBrasilRegistraBoleto {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd")]
    public partial class erro : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string mensagemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Mensagem {
            get {
                return this.mensagemField;
            }
            set {
                this.mensagemField = value;
                this.RaisePropertyChanged("Mensagem");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://xmlns.example.com/1466775928160", ConfigurationName="BancoBrasilRegistraBoleto.portType")]
    public interface portType {
        
        [System.ServiceModel.OperationContractAttribute(Action="registrarBoleto", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(DER.WebApp.BancoBrasilRegistraBoleto.erro), Action="registrarBoleto", Name="erro", Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        DER.WebApp.BancoBrasilRegistraBoleto.RegistroTituloCobrancaResponse RegistroTituloCobranca(DER.WebApp.BancoBrasilRegistraBoleto.RegistroTituloCobrancaRequest request);
        
        // CODEGEN: Gerando contrato de mensagem porque a operação tem vários valores de retorno.
        [System.ServiceModel.OperationContractAttribute(Action="registrarBoleto", ReplyAction="*")]
        System.Threading.Tasks.Task<DER.WebApp.BancoBrasilRegistraBoleto.RegistroTituloCobrancaResponse> RegistroTituloCobrancaAsync(DER.WebApp.BancoBrasilRegistraBoleto.RegistroTituloCobrancaRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="requisicao", WrapperNamespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", IsWrapped=true)]
    public partial class RegistroTituloCobrancaRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=0)]
        public string codigoAceiteTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=1)]
        public string codigoChaveUsuario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=2)]
        public short codigoModalidadeTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=3)]
        [System.ComponentModel.DefaultValueAttribute(typeof(short), "5")]
        public short codigoTipoCanalSolicitacao;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=4)]
        [System.ComponentModel.DefaultValueAttribute(typeof(short), "0")]
        public short codigoTipoContaCaucao;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=5)]
        public short codigoTipoDesconto;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=6)]
        [System.ComponentModel.DefaultValueAttribute(typeof(short), "0")]
        public short codigoTipoInscricaoAvalista;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=7)]
        [System.ComponentModel.DefaultValueAttribute(typeof(short), "0")]
        public short codigoTipoInscricaoPagador;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=8)]
        public short codigoTipoJuroMora;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=9)]
        public short codigoTipoMulta;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=10)]
        [System.ComponentModel.DefaultValueAttribute(typeof(short), "0")]
        public short codigoTipoTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=11)]
        public string dataDescontoTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=12)]
        public string dataEmissaoTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=13)]
        public string dataMultaTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=14)]
        public string dataVencimentoTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=15)]
        public string indicadorPermissaoRecebimentoParcial;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=16)]
        public string nomeAvalistaTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=17)]
        public string nomeBairroPagador;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=18)]
        public string nomeMunicipioPagador;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=19)]
        public string nomePagador;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=20)]
        public short numeroCarteira;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=21)]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int numeroCepPagador;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=22)]
        public int numeroConvenio;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=23)]
        [System.ComponentModel.DefaultValueAttribute(typeof(long), "0")]
        public long numeroInscricaoAvalista;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=24)]
        [System.ComponentModel.DefaultValueAttribute(typeof(long), "0")]
        public long numeroInscricaoPagador;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=25)]
        public short numeroVariacaoCarteira;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=26)]
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.0")]
        public decimal percentualDescontoTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=27)]
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.0")]
        public decimal percentualJuroMoraTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=28)]
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.0")]
        public decimal percentualMultaTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=29)]
        [System.ComponentModel.DefaultValueAttribute(typeof(short), "0")]
        public short quantidadeDiaProtesto;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=30)]
        public string siglaUfPagador;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=31)]
        public string textoCampoUtilizacaoBeneficiario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=32)]
        public string textoDescricaoTipoTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=33)]
        public string textoEnderecoPagador;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=34)]
        public string textoMensagemBloquetoOcorrencia;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=35)]
        public string textoNumeroTelefonePagador;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=36)]
        public string textoNumeroTituloBeneficiario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=37)]
        public string textoNumeroTituloCliente;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=38)]
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.0")]
        public decimal valorAbatimentoTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=39)]
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.0")]
        public decimal valorDescontoTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=40)]
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.0")]
        public decimal valorJuroMoraTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=41)]
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.0")]
        public decimal valorMultaTitulo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=42)]
        [System.ComponentModel.DefaultValueAttribute(typeof(decimal), "0.0")]
        public decimal valorOriginalTitulo;
        
        public RegistroTituloCobrancaRequest() {
        }
        
        public RegistroTituloCobrancaRequest(
                    string codigoAceiteTitulo, 
                    string codigoChaveUsuario, 
                    short codigoModalidadeTitulo, 
                    short codigoTipoCanalSolicitacao, 
                    short codigoTipoContaCaucao, 
                    short codigoTipoDesconto, 
                    short codigoTipoInscricaoAvalista, 
                    short codigoTipoInscricaoPagador, 
                    short codigoTipoJuroMora, 
                    short codigoTipoMulta, 
                    short codigoTipoTitulo, 
                    string dataDescontoTitulo, 
                    string dataEmissaoTitulo, 
                    string dataMultaTitulo, 
                    string dataVencimentoTitulo, 
                    string indicadorPermissaoRecebimentoParcial, 
                    string nomeAvalistaTitulo, 
                    string nomeBairroPagador, 
                    string nomeMunicipioPagador, 
                    string nomePagador, 
                    short numeroCarteira, 
                    int numeroCepPagador, 
                    int numeroConvenio, 
                    long numeroInscricaoAvalista, 
                    long numeroInscricaoPagador, 
                    short numeroVariacaoCarteira, 
                    decimal percentualDescontoTitulo, 
                    decimal percentualJuroMoraTitulo, 
                    decimal percentualMultaTitulo, 
                    short quantidadeDiaProtesto, 
                    string siglaUfPagador, 
                    string textoCampoUtilizacaoBeneficiario, 
                    string textoDescricaoTipoTitulo, 
                    string textoEnderecoPagador, 
                    string textoMensagemBloquetoOcorrencia, 
                    string textoNumeroTelefonePagador, 
                    string textoNumeroTituloBeneficiario, 
                    string textoNumeroTituloCliente, 
                    decimal valorAbatimentoTitulo, 
                    decimal valorDescontoTitulo, 
                    decimal valorJuroMoraTitulo, 
                    decimal valorMultaTitulo, 
                    decimal valorOriginalTitulo) {
            this.codigoAceiteTitulo = codigoAceiteTitulo;
            this.codigoChaveUsuario = codigoChaveUsuario;
            this.codigoModalidadeTitulo = codigoModalidadeTitulo;
            this.codigoTipoCanalSolicitacao = codigoTipoCanalSolicitacao;
            this.codigoTipoContaCaucao = codigoTipoContaCaucao;
            this.codigoTipoDesconto = codigoTipoDesconto;
            this.codigoTipoInscricaoAvalista = codigoTipoInscricaoAvalista;
            this.codigoTipoInscricaoPagador = codigoTipoInscricaoPagador;
            this.codigoTipoJuroMora = codigoTipoJuroMora;
            this.codigoTipoMulta = codigoTipoMulta;
            this.codigoTipoTitulo = codigoTipoTitulo;
            this.dataDescontoTitulo = dataDescontoTitulo;
            this.dataEmissaoTitulo = dataEmissaoTitulo;
            this.dataMultaTitulo = dataMultaTitulo;
            this.dataVencimentoTitulo = dataVencimentoTitulo;
            this.indicadorPermissaoRecebimentoParcial = indicadorPermissaoRecebimentoParcial;
            this.nomeAvalistaTitulo = nomeAvalistaTitulo;
            this.nomeBairroPagador = nomeBairroPagador;
            this.nomeMunicipioPagador = nomeMunicipioPagador;
            this.nomePagador = nomePagador;
            this.numeroCarteira = numeroCarteira;
            this.numeroCepPagador = numeroCepPagador;
            this.numeroConvenio = numeroConvenio;
            this.numeroInscricaoAvalista = numeroInscricaoAvalista;
            this.numeroInscricaoPagador = numeroInscricaoPagador;
            this.numeroVariacaoCarteira = numeroVariacaoCarteira;
            this.percentualDescontoTitulo = percentualDescontoTitulo;
            this.percentualJuroMoraTitulo = percentualJuroMoraTitulo;
            this.percentualMultaTitulo = percentualMultaTitulo;
            this.quantidadeDiaProtesto = quantidadeDiaProtesto;
            this.siglaUfPagador = siglaUfPagador;
            this.textoCampoUtilizacaoBeneficiario = textoCampoUtilizacaoBeneficiario;
            this.textoDescricaoTipoTitulo = textoDescricaoTipoTitulo;
            this.textoEnderecoPagador = textoEnderecoPagador;
            this.textoMensagemBloquetoOcorrencia = textoMensagemBloquetoOcorrencia;
            this.textoNumeroTelefonePagador = textoNumeroTelefonePagador;
            this.textoNumeroTituloBeneficiario = textoNumeroTituloBeneficiario;
            this.textoNumeroTituloCliente = textoNumeroTituloCliente;
            this.valorAbatimentoTitulo = valorAbatimentoTitulo;
            this.valorDescontoTitulo = valorDescontoTitulo;
            this.valorJuroMoraTitulo = valorJuroMoraTitulo;
            this.valorMultaTitulo = valorMultaTitulo;
            this.valorOriginalTitulo = valorOriginalTitulo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="resposta", WrapperNamespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", IsWrapped=true)]
    public partial class RegistroTituloCobrancaResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=0)]
        public string siglaSistemaMensagem;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=1)]
        public short codigoRetornoPrograma;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=2)]
        public string nomeProgramaErro;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=3)]
        public string textoMensagemErro;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=4)]
        public short numeroPosicaoErroPrograma;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=5)]
        public short codigoTipoRetornoPrograma;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=6)]
        public string textoNumeroTituloCobrancaBb;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=7)]
        public short numeroCarteiraCobranca;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=8)]
        public short numeroVariacaoCarteiraCobranca;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=9)]
        public short codigoPrefixoDependenciaBeneficiario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=10)]
        public int numeroContaCorrenteBeneficiario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=11)]
        public int codigoCliente;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=12)]
        public string linhaDigitavel;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=13)]
        public string codigoBarraNumerico;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=14)]
        public short codigoTipoEnderecoBeneficiario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=15)]
        public string nomeLogradouroBeneficiario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=16)]
        public string nomeBairroBeneficiario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=17)]
        public string nomeMunicipioBeneficiario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=18)]
        public int codigoMunicipioBeneficiario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=19)]
        public string siglaUfBeneficiario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=20)]
        public int codigoCepBeneficiario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=21)]
        public string indicadorComprovacaoBeneficiario;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.tibco.com/schemas/bws_registro_cbr/Recursos/XSD/Schema.xsd", Order=22)]
        public int numeroContratoCobranca;
        
        public RegistroTituloCobrancaResponse() {
        }
        
        public RegistroTituloCobrancaResponse(
                    string siglaSistemaMensagem, 
                    short codigoRetornoPrograma, 
                    string nomeProgramaErro, 
                    string textoMensagemErro, 
                    short numeroPosicaoErroPrograma, 
                    short codigoTipoRetornoPrograma, 
                    string textoNumeroTituloCobrancaBb, 
                    short numeroCarteiraCobranca, 
                    short numeroVariacaoCarteiraCobranca, 
                    short codigoPrefixoDependenciaBeneficiario, 
                    int numeroContaCorrenteBeneficiario, 
                    int codigoCliente, 
                    string linhaDigitavel, 
                    string codigoBarraNumerico, 
                    short codigoTipoEnderecoBeneficiario, 
                    string nomeLogradouroBeneficiario, 
                    string nomeBairroBeneficiario, 
                    string nomeMunicipioBeneficiario, 
                    int codigoMunicipioBeneficiario, 
                    string siglaUfBeneficiario, 
                    int codigoCepBeneficiario, 
                    string indicadorComprovacaoBeneficiario, 
                    int numeroContratoCobranca) {
            this.siglaSistemaMensagem = siglaSistemaMensagem;
            this.codigoRetornoPrograma = codigoRetornoPrograma;
            this.nomeProgramaErro = nomeProgramaErro;
            this.textoMensagemErro = textoMensagemErro;
            this.numeroPosicaoErroPrograma = numeroPosicaoErroPrograma;
            this.codigoTipoRetornoPrograma = codigoTipoRetornoPrograma;
            this.textoNumeroTituloCobrancaBb = textoNumeroTituloCobrancaBb;
            this.numeroCarteiraCobranca = numeroCarteiraCobranca;
            this.numeroVariacaoCarteiraCobranca = numeroVariacaoCarteiraCobranca;
            this.codigoPrefixoDependenciaBeneficiario = codigoPrefixoDependenciaBeneficiario;
            this.numeroContaCorrenteBeneficiario = numeroContaCorrenteBeneficiario;
            this.codigoCliente = codigoCliente;
            this.linhaDigitavel = linhaDigitavel;
            this.codigoBarraNumerico = codigoBarraNumerico;
            this.codigoTipoEnderecoBeneficiario = codigoTipoEnderecoBeneficiario;
            this.nomeLogradouroBeneficiario = nomeLogradouroBeneficiario;
            this.nomeBairroBeneficiario = nomeBairroBeneficiario;
            this.nomeMunicipioBeneficiario = nomeMunicipioBeneficiario;
            this.codigoMunicipioBeneficiario = codigoMunicipioBeneficiario;
            this.siglaUfBeneficiario = siglaUfBeneficiario;
            this.codigoCepBeneficiario = codigoCepBeneficiario;
            this.indicadorComprovacaoBeneficiario = indicadorComprovacaoBeneficiario;
            this.numeroContratoCobranca = numeroContratoCobranca;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface portTypeChannel : DER.WebApp.BancoBrasilRegistraBoleto.portType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class portTypeClient : System.ServiceModel.ClientBase<DER.WebApp.BancoBrasilRegistraBoleto.portType>, DER.WebApp.BancoBrasilRegistraBoleto.portType {
        
        public portTypeClient() {
        }
        
        public portTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public portTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public portTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public portTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DER.WebApp.BancoBrasilRegistraBoleto.RegistroTituloCobrancaResponse DER.WebApp.BancoBrasilRegistraBoleto.portType.RegistroTituloCobranca(DER.WebApp.BancoBrasilRegistraBoleto.RegistroTituloCobrancaRequest request) {
            return base.Channel.RegistroTituloCobranca(request);
        }
        
        public string RegistroTituloCobranca(
                    string codigoAceiteTitulo, 
                    string codigoChaveUsuario, 
                    short codigoModalidadeTitulo, 
                    short codigoTipoCanalSolicitacao, 
                    short codigoTipoContaCaucao, 
                    short codigoTipoDesconto, 
                    short codigoTipoInscricaoAvalista, 
                    short codigoTipoInscricaoPagador, 
                    short codigoTipoJuroMora, 
                    short codigoTipoMulta, 
                    short codigoTipoTitulo, 
                    string dataDescontoTitulo, 
                    string dataEmissaoTitulo, 
                    string dataMultaTitulo, 
                    string dataVencimentoTitulo, 
                    string indicadorPermissaoRecebimentoParcial, 
                    string nomeAvalistaTitulo, 
                    string nomeBairroPagador, 
                    string nomeMunicipioPagador, 
                    string nomePagador, 
                    short numeroCarteira, 
                    int numeroCepPagador, 
                    int numeroConvenio, 
                    long numeroInscricaoAvalista, 
                    long numeroInscricaoPagador, 
                    short numeroVariacaoCarteira, 
                    decimal percentualDescontoTitulo, 
                    decimal percentualJuroMoraTitulo, 
                    decimal percentualMultaTitulo, 
                    short quantidadeDiaProtesto, 
                    string siglaUfPagador, 
                    string textoCampoUtilizacaoBeneficiario, 
                    string textoDescricaoTipoTitulo, 
                    string textoEnderecoPagador, 
                    string textoMensagemBloquetoOcorrencia, 
                    string textoNumeroTelefonePagador, 
                    string textoNumeroTituloBeneficiario, 
                    string textoNumeroTituloCliente, 
                    decimal valorAbatimentoTitulo, 
                    decimal valorDescontoTitulo, 
                    decimal valorJuroMoraTitulo, 
                    decimal valorMultaTitulo, 
                    decimal valorOriginalTitulo, 
                    out short codigoRetornoPrograma, 
                    out string nomeProgramaErro, 
                    out string textoMensagemErro, 
                    out short numeroPosicaoErroPrograma, 
                    out short codigoTipoRetornoPrograma, 
                    out string textoNumeroTituloCobrancaBb, 
                    out short numeroCarteiraCobranca, 
                    out short numeroVariacaoCarteiraCobranca, 
                    out short codigoPrefixoDependenciaBeneficiario, 
                    out int numeroContaCorrenteBeneficiario, 
                    out int codigoCliente, 
                    out string linhaDigitavel, 
                    out string codigoBarraNumerico, 
                    out short codigoTipoEnderecoBeneficiario, 
                    out string nomeLogradouroBeneficiario, 
                    out string nomeBairroBeneficiario, 
                    out string nomeMunicipioBeneficiario, 
                    out int codigoMunicipioBeneficiario, 
                    out string siglaUfBeneficiario, 
                    out int codigoCepBeneficiario, 
                    out string indicadorComprovacaoBeneficiario, 
                    out int numeroContratoCobranca) {
            DER.WebApp.BancoBrasilRegistraBoleto.RegistroTituloCobrancaRequest inValue = new DER.WebApp.BancoBrasilRegistraBoleto.RegistroTituloCobrancaRequest();
            inValue.codigoAceiteTitulo = codigoAceiteTitulo;
            inValue.codigoChaveUsuario = codigoChaveUsuario;
            inValue.codigoModalidadeTitulo = codigoModalidadeTitulo;
            inValue.codigoTipoCanalSolicitacao = codigoTipoCanalSolicitacao;
            inValue.codigoTipoContaCaucao = codigoTipoContaCaucao;
            inValue.codigoTipoDesconto = codigoTipoDesconto;
            inValue.codigoTipoInscricaoAvalista = codigoTipoInscricaoAvalista;
            inValue.codigoTipoInscricaoPagador = codigoTipoInscricaoPagador;
            inValue.codigoTipoJuroMora = codigoTipoJuroMora;
            inValue.codigoTipoMulta = codigoTipoMulta;
            inValue.codigoTipoTitulo = codigoTipoTitulo;
            inValue.dataDescontoTitulo = dataDescontoTitulo;
            inValue.dataEmissaoTitulo = dataEmissaoTitulo;
            inValue.dataMultaTitulo = dataMultaTitulo;
            inValue.dataVencimentoTitulo = dataVencimentoTitulo;
            inValue.indicadorPermissaoRecebimentoParcial = indicadorPermissaoRecebimentoParcial;
            inValue.nomeAvalistaTitulo = nomeAvalistaTitulo;
            inValue.nomeBairroPagador = nomeBairroPagador;
            inValue.nomeMunicipioPagador = nomeMunicipioPagador;
            inValue.nomePagador = nomePagador;
            inValue.numeroCarteira = numeroCarteira;
            inValue.numeroCepPagador = numeroCepPagador;
            inValue.numeroConvenio = numeroConvenio;
            inValue.numeroInscricaoAvalista = numeroInscricaoAvalista;
            inValue.numeroInscricaoPagador = numeroInscricaoPagador;
            inValue.numeroVariacaoCarteira = numeroVariacaoCarteira;
            inValue.percentualDescontoTitulo = percentualDescontoTitulo;
            inValue.percentualJuroMoraTitulo = percentualJuroMoraTitulo;
            inValue.percentualMultaTitulo = percentualMultaTitulo;
            inValue.quantidadeDiaProtesto = quantidadeDiaProtesto;
            inValue.siglaUfPagador = siglaUfPagador;
            inValue.textoCampoUtilizacaoBeneficiario = textoCampoUtilizacaoBeneficiario;
            inValue.textoDescricaoTipoTitulo = textoDescricaoTipoTitulo;
            inValue.textoEnderecoPagador = textoEnderecoPagador;
            inValue.textoMensagemBloquetoOcorrencia = textoMensagemBloquetoOcorrencia;
            inValue.textoNumeroTelefonePagador = textoNumeroTelefonePagador;
            inValue.textoNumeroTituloBeneficiario = textoNumeroTituloBeneficiario;
            inValue.textoNumeroTituloCliente = textoNumeroTituloCliente;
            inValue.valorAbatimentoTitulo = valorAbatimentoTitulo;
            inValue.valorDescontoTitulo = valorDescontoTitulo;
            inValue.valorJuroMoraTitulo = valorJuroMoraTitulo;
            inValue.valorMultaTitulo = valorMultaTitulo;
            inValue.valorOriginalTitulo = valorOriginalTitulo;
            DER.WebApp.BancoBrasilRegistraBoleto.RegistroTituloCobrancaResponse retVal = ((DER.WebApp.BancoBrasilRegistraBoleto.portType)(this)).RegistroTituloCobranca(inValue);
            codigoRetornoPrograma = retVal.codigoRetornoPrograma;
            nomeProgramaErro = retVal.nomeProgramaErro;
            textoMensagemErro = retVal.textoMensagemErro;
            numeroPosicaoErroPrograma = retVal.numeroPosicaoErroPrograma;
            codigoTipoRetornoPrograma = retVal.codigoTipoRetornoPrograma;
            textoNumeroTituloCobrancaBb = retVal.textoNumeroTituloCobrancaBb;
            numeroCarteiraCobranca = retVal.numeroCarteiraCobranca;
            numeroVariacaoCarteiraCobranca = retVal.numeroVariacaoCarteiraCobranca;
            codigoPrefixoDependenciaBeneficiario = retVal.codigoPrefixoDependenciaBeneficiario;
            numeroContaCorrenteBeneficiario = retVal.numeroContaCorrenteBeneficiario;
            codigoCliente = retVal.codigoCliente;
            linhaDigitavel = retVal.linhaDigitavel;
            codigoBarraNumerico = retVal.codigoBarraNumerico;
            codigoTipoEnderecoBeneficiario = retVal.codigoTipoEnderecoBeneficiario;
            nomeLogradouroBeneficiario = retVal.nomeLogradouroBeneficiario;
            nomeBairroBeneficiario = retVal.nomeBairroBeneficiario;
            nomeMunicipioBeneficiario = retVal.nomeMunicipioBeneficiario;
            codigoMunicipioBeneficiario = retVal.codigoMunicipioBeneficiario;
            siglaUfBeneficiario = retVal.siglaUfBeneficiario;
            codigoCepBeneficiario = retVal.codigoCepBeneficiario;
            indicadorComprovacaoBeneficiario = retVal.indicadorComprovacaoBeneficiario;
            numeroContratoCobranca = retVal.numeroContratoCobranca;
            return retVal.siglaSistemaMensagem;
        }
        
        public System.Threading.Tasks.Task<DER.WebApp.BancoBrasilRegistraBoleto.RegistroTituloCobrancaResponse> RegistroTituloCobrancaAsync(DER.WebApp.BancoBrasilRegistraBoleto.RegistroTituloCobrancaRequest request) {
            return base.Channel.RegistroTituloCobrancaAsync(request);
        }
    }
}
