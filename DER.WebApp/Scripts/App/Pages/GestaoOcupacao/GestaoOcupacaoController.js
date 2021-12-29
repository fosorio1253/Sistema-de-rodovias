import BuscarInteressadosComponent from "./../../Components/Interessado/BuscarInteressadosComponent";
import TrechosComponent from "./TrechosComponent";
import OcorrenciasComponent from "./OcorrenciasComponent";
import DocumentosComponent from "../../Components/Documentos/DocumentosComponent";
import GestaoOcupacaoModel from "./../../Models/GestaoOcupacao/GestaoOcupacaoModel";
import GestaoOcupacaoService from "./../../Services/GestaoOcupacao/GestaoOcupacaoService";
import ValidateHelper from './../../Helpers/validate/ValidateHelper';
import UploadHelper from './../../Helpers/upload/UploadHelper';
import DocumentoModel from './../../Models/Documento/DocumentoModel';

function GestaoOcupacaoController(gestaoOcupacaoModel, dataExtra) {
    this.model = gestaoOcupacaoModel;
    this.dataExtra = dataExtra;
    this.modoCadastro = $(location).attr("href").toLocaleLowerCase().indexOf('visualizar') > 0 ? false : true;
    this.modoEditar = $(location).attr("href").toLocaleLowerCase().indexOf('editar') > 0 ? true : false;
    this.onUpdateInteressado = (function(interessado){
        this.updateTipoConcessoesSelect();
    }).bind(this);
    this.updateTipoConcessoesSelect = function(){
        const tipoConcessoes = controller.buscarInteressadosComponent.interessadoSelecionado && controller.buscarInteressadosComponent.interessadoSelecionado.TipoConcessoes ? 
                                controller.buscarInteressadosComponent.interessadoSelecionado.TipoConcessoes :
                                Model.InteressadoTipoDeConcessoes;

        if(tipoConcessoes){
            $('#TipoOcupacaoId').html("");
            $('#TipoOcupacaoId').append(new Option("Selecione"));
            
            tipoConcessoes.forEach(tipoConcessao=>{
                if(tipoConcessao.Nome){
                    $('#TipoOcupacaoId').append(new Option(tipoConcessao.Nome, tipoConcessao.TipoConcessaoId));
                }
            });
        }
    }

    this.buscarInteressadosComponent = new BuscarInteressadosComponent(dataExtra.InteressadoId, this.onUpdateInteressado);
    this.trechosComponent = new TrechosComponent(this.model.Trechos);
    this.ocorrenciasComponent = new OcorrenciasComponent(this.model.Ocorrencias, this.dataExtra.DataAdicionado, this.dataExtra.AdicionadoPor);
    this.documentosComponent = new DocumentosComponent(this.model.Documentos, this.dataExtra.AdicionadoPor, this.dataExtra.DataAdicionado);    

    var ORIGEM_SOLICITACAO = 'Solicitação de Implantação';
    var ORIGEM_SOLICITACAO_CANCELAMENTO = 'Solicitação de Cancelamento';
    var ORIGEM_SOLICITACAO_TRANSFERENCIA_TITULARIDADE = 'Transferência de Titularidade';
    var ORIGEM_SOLICITACAO_MANUTENCAO_ROTINA = 'Manutenção de Rotina';
    var ORIGEM_SOLICITACAO_RETIFICACAO = 'Retificação';
    var DOCUMENTO_COMPROVANTE_PAGAMENTO_PEP = 'Comprovante de Pagamento da Tarifa de Exame de Projeto(PEP)';
    var ORIGEM_CANCELAMENTO = 'cancelamento';
    var ORIGEM_AJUIZAMENTO = 'ajuizamento';
    var ORIGEM_MANUTENCAO = 'manutencao';
    var ORIGEM_TRANSFERENCIA = 'transferencia';
    var ORIGEM_RETIFICACAO = 'retificacao';

    const validaOcupacao = novaOrigem!=ORIGEM_CANCELAMENTO && novaOrigem!=ORIGEM_AJUIZAMENTO && novaOrigem!=ORIGEM_MANUTENCAO;
    const validaTrecho = novaOrigem!=ORIGEM_CANCELAMENTO && novaOrigem!=ORIGEM_AJUIZAMENTO && novaOrigem!=ORIGEM_MANUTENCAO && novaOrigem!=ORIGEM_TRANSFERENCIA;

    console.log("validaOcupacao:", validaOcupacao);
    console.log("validaOcupacao:", validaTrecho);

    const getOrigemSolicitacaoId = ()=>{
        const origem = OrigemSolicitacoes.find(o=>o.Text==ORIGEM_SOLICITACAO)
        if(origem) return origem.Value;
        return '0';
    }
    const getOrigemSolicitacaoCancelamentoId = ()=>{
        const origem = OrigemSolicitacoes.find(o=>o.Text==ORIGEM_SOLICITACAO_CANCELAMENTO)
        if(origem) return origem.Value;
        return '0';
    }
    const getOrigemSolicitacaoTransferenciaTitularidadeId = ()=>{
        const origem = OrigemSolicitacoes.find(o=>o.Text==ORIGEM_SOLICITACAO_TRANSFERENCIA_TITULARIDADE)
        if(origem) return origem.Value;
        return '0';
    }
    const getOrigemSolicitacaoManutencaoId = ()=>{
        const origem = OrigemSolicitacoes.find(o=>o.Text==ORIGEM_SOLICITACAO_MANUTENCAO_ROTINA)
        if(origem) return origem.Value;
        return '0';
    }
    const getOrigemSolicitacaoRetificacaoId = ()=>{
        const origem = OrigemSolicitacoes.find(o=>o.Text==ORIGEM_SOLICITACAO_RETIFICACAO)
        if(origem) return origem.Value;
        return '0';
    }
    const getDocumentoTipoComprovantePagamentoPEPId = ()=>{
        const tipo = TipoDocumentosOcupacoes.find(o=>o.Text==DOCUMENTO_COMPROVANTE_PAGAMENTO_PEP)
        if(tipo) return tipo.Value;
        return '0';
    }

    this.init = (function () {
        window.onload = this.start;
    }).bind(this);

    this.start = (function () {
        this.buscarInteressadosComponent.init();
        this.trechosComponent.init();
        this.documentosComponent.init();
        UploadHelper.addlistenerChangeInputFileAndApplyLock();
        this.configFields();
        // this.addVerificationOrigemSolicitacao();
        this.updateTipoConcessoesSelect();

        $('[data-toggle="tooltip"]').tooltip();

        if(ParecerRegionalId) {
            $("input:radio[name=ParecerRegionalId][value="+ParecerRegionalId+"]").attr('checked', true);
        }
        if(ParecerDiretoriaEngenhariaId) {
            $("input:radio[name=ParecerDiretoriaEngenhariaId][value="+ParecerDiretoriaEngenhariaId+"]").attr('checked', true);
        }
        if(ParecerCoordenadoriaOperacoesId) {
            $("input:radio[name=ParecerCoordenadoriaOperacoesId][value="+ParecerCoordenadoriaOperacoesId+"]").attr('checked', true);
        }
        if(ParecerFaixaDominioId) {
            $("input:radio[name=ParecerFaixaDominioId][value="+ParecerFaixaDominioId+"]").attr('checked', true);
        }

    }).bind(this);

    this.addVerificationOrigemSolicitacao = (function () {
        $("#OrigemSolicitacaoId").change(function () {
            var OrigemSolicitacaoId = $("#OrigemSolicitacaoId").val();

            if (this.modoEditar) {
                if ((OrigemSolicitacaoId == getOrigemSolicitacaoCancelamentoId()) || (OrigemSolicitacaoId == getOrigemSolicitacaoTransferenciaTitularidadeId())) {
                    $("#SituacaoSolicitacaoId").val(217).change();
                    $("#SituacaoSolicitacaoId").attr("disabled", "disabled");
                }

                if (OrigemSolicitacaoId == getOrigemSolicitacaoId()) {
                    $("#SituacaoSolicitacaoId").val('').change();
                    $("#SituacaoSolicitacaoId").attr("disabled", "disabled");
                }
            }
        });
    }).bind(this);

    this.configFields = (function () {
        $('#NumeroSPDOC').mask('0000/0000');
        $('#Deferimento_NumeroProcesso').mask('0000/0000');

        var QtdCpfCnpj = $("#CpfCNPJ").val().length;
        if (QtdCpfCnpj == 18) $("#CpfCNPJ").mask('00.000.000/0000-00');
        if (QtdCpfCnpj == 14) $('#CpfCNPJ').mask('000.000.000-00');        

        if ($(location).attr("href").toLocaleLowerCase().indexOf('visualizar') > 0) {
            $('[data-input]').attr('disabled', 'disabled');
            $('[data-check]').attr('disabled', 'disabled');
            $('.isSelect').multiselect('disable');
            $('#salvar').hide();
            $('#adicionarOcorrencia').hide();
            $('#adicionarTrecho').hide();
            $('#resumotrechorbt').attr('disabled', 'disabled');
            $('#btnBaixarTermo').removeClass("hide");
            // $('#ParecerRegionalFavoravel').attr('disabled', 'disabled');
            // $('#ParecerRegionalExcepcionalidade').attr('disabled', 'disabled');
            // $('#ParecerRegionalDesfavoravel').attr('disabled', 'disabled');
            $("input:radio[name=ParecerRegionalId]").attr("disabled", true);
            $("input:radio[name=ParecerDiretoriaEngenhariaId]").attr("disabled", true);
            $("input:radio[name=ParecerCoordenadoriaOperacoesId]").attr("disabled", true);
            $("input:radio[name=ParecerFaixaDominioId]").attr("disabled", true);
            $("#opcoesId").hide();
            $("#tdOpcoesId").hide();
            $(".DownloadArquivoId").show(); 

        } else {    
            $('.excluirTrecho').removeClass("hide");
            $('.excluirOcorrencia').removeClass("hide");
            $('.excluirDocumento').removeClass("hide");
            $('.editarOcorrencia').removeClass("hide");
            $('.editarTrecho').removeClass("hide");
            $('#informacoesColunaOpcoes').removeClass("hide");
            if (!this.modoEditar) $(".DownloadArquivoId").hide();
            // if (this.modoEditar) $("#SituacaoSolicitacaoId").attr('disabled', false);
            // if (!this.modoEditar) $("#SituacaoSolicitacaoId").attr('disabled', true);
        }
    }).bind(this);

    this.validarDatasParecer = function(){
        var DataAss = moment($("#Deferimento_DataAssinatura").val());
        var DataDes = moment($("#Deferimento_DataDespachoAutorizativo").val());
        if (DataAss > DataDes) {
            swal({
                type: 'error',
                title: 'Atenção',
                text: 'A data do despacho precisa ser maior do que a de assinatura.'
            })
            $("#Deferimento_DataDespachoAutorizativo").val('')
        }
    }

    this.showErrorDocumentosNecessarios = function(){
        let msg = "Deverá apresentar todos os documentos constantes no Regulamento e Norma vigentes";
        const documentosNome = [];
        const documentosInseridos = controller.documentosComponent.documentos.map(doc=>doc.TipoDocumentoId.toString()).sort();
        const concessaoDocumentos = this.getConcessoesDocumentos();
        const tipoDocumentosOcupacoes = Model.TipoDocumentosOcupacoes;

        concessaoDocumentos.forEach(documento=>{
            if(documentosInseridos.indexOf(documento)==-1){
                const nome = tipoDocumentosOcupacoes.find(doc=>doc.Value==documento).Text;
                documentosNome.push(nome);
            }
        });

        msg += '<br/><br/>'+documentosNome.join('<br/>');

        swal({
            type: 'error',
            title: 'Atenção',
            html: msg
        });
    }

    this.getConcessoesDocumentos = function(){
        let concessoesDocumentos = [];
        const trechos = controller.trechosComponent.trechos;
        const tipoConcessoes = controller.buscarInteressadosComponent.interessadoSelecionado && controller.buscarInteressadosComponent.interessadoSelecionado.TipoConcessoes ? 
                                controller.buscarInteressadosComponent.interessadoSelecionado.TipoConcessoes :
                                Model.InteressadoTipoDeConcessoes;
        trechos.forEach(trecho=>{
            const tipoOcupacaoId = trecho.TipoOcupacao.TipoOcupacaoId;
            const concessao = tipoConcessoes.find(c=>c.TipoConcessaoId==tipoOcupacaoId);
            if(concessao && concessao.Documentos){
                const concessaoDocumentos = concessao.Documentos.split(",").sort();
                concessoesDocumentos.push(...concessaoDocumentos);
            }
        });
        //Filter para retornar valores unicos e remove id documento '256:Comprovante de Pagamento da Tarifa de Exame de Projeto(PEP)'
        return concessoesDocumentos.filter((v, i, a) => a.indexOf(v) === i && v!=getDocumentoTipoComprovantePagamentoPEPId()).sort();
    }

    this.validate = (function () {
        const validarCampos = ["#Interessado", "#RegionalId", "#ResidenciaConservacaoId", "#NumeroSPDOC", "#NumeroProcesso",
        "#OrigemSolicitacaoId", "#DataCadastro"];
        if (validaOcupacao) validarCampos.push("#Assunto");
        if (!ValidateHelper.validarCampos(validarCampos) || 
            (validaTrecho && !this.trechosComponent.trechos.length) || 
            !this.documentosComponent.documentos.length) {
            if (validaOcupacao && !ValidateHelper.validarCampos(["#Assunto"])) $("#gestao-ocupacao-ocupacao-tab").addClass("text-danger");
            else $("#gestao-ocupacao-ocupacao-tab").removeClass("text-danger");

            if (validaTrecho && !this.trechosComponent.trechos.length) $("#gestao-ocupacao-trecho-tab").addClass("text-danger");
            else $("#gestao-ocupacao-trecho-tab").removeClass("text-danger");

            if (!this.documentosComponent.documentos.length) $("#gestao-ocupacao-documentos-tab").addClass("text-danger");
            else $("#gestao-ocupacao-documentos-tab").removeClass("text-danger");

            swal({
                type: 'error',
                title: 'Atenção',
                text: 'Por favor, preencha os campos obrigatórios!'
            })
            return false;
        }

        var OrigemSolicitacaoId = $("#OrigemSolicitacaoId").val();
        if ((OrigemSolicitacaoId == getOrigemSolicitacaoCancelamentoId()) || (OrigemSolicitacaoId == getOrigemSolicitacaoTransferenciaTitularidadeId())) {
            var documentos = this.documentosComponent.documentos;
            var documentoValido = false;
            documentos.forEach(function(documento){
                if((documento.TipoDocumentoId==222447 && (OrigemSolicitacaoId == getOrigemSolicitacaoTransferenciaTitularidadeId())) || 
                   (documento.TipoDocumentoId==222446 && (OrigemSolicitacaoId == getOrigemSolicitacaoCancelamentoId()))) {//222447-transferencia:Comprovante de titularidade de domínio / 222446-cancelamento:Certidão negativa de débitos federais emitida pela Receita Federal
                    documentoValido = true;
                }
            });
            if(!documentoValido) {
               var msg = "Por favor envie um documento!";
               if((OrigemSolicitacaoId == getOrigemSolicitacaoCancelamentoId())) {
                   msg = "Por favor envie um documento de solicitação de cancelamento! (Certidão negativa de débitos federais emitida pela Receita Federal)";
               }
               if((OrigemSolicitacaoId == getOrigemSolicitacaoTransferenciaTitularidadeId())) {
                   msg = "Por favor envie um documento de solicitação de transferência de titularidade! (Comprovante de titularidade de domínio)";
               }
               swal({
                   type: 'error',
                   title: 'Atenção',
                   text: msg
               });
               return;
            }
        }

        const documentosInseridos = controller.documentosComponent.documentos.map(doc=>doc.TipoDocumentoId.toString()).sort();
        const concessaoDocumentos = this.getConcessoesDocumentos();
        let todosDocumentosNecessario = true;
        concessaoDocumentos.forEach(documento=>{
            const documentoEncontrado = documentosInseridos.indexOf(documento);
            if(documentoEncontrado==-1) todosDocumentosNecessario = false;
        });
        // if(!todosDocumentosNecessario) {
        //     this.showErrorDocumentosNecessarios();
        //     return;
        // }
        
        // //ver como validar se pep foi gerada, dou um ex. Model.pepGerada, ai já funcionaria a validaçaõ
        //     if(Model.pepGerada && documentosInseridos.indexOf(getDocumentoTipoComprovantePagamentoPEPId())==-1){
        //         swal({
        //             type: 'warning',
        //             title: 'Atenção',
        //             html: 'Para análise do DER/SP, essa Empresa deverá recolher o valor de Preço de Exame e Projeto, conforme Regulamento em vigor'
        //         });
        //     }
        // 

        $("#gestao-ocupacao-ocupacao-tab").removeClass("text-danger");
        $("#gestao-ocupacao-trecho-tab").removeClass("text-danger");
        $("#gestao-ocupacao-documentos-tab").removeClass("text-danger");

        return true;
    }).bind(this);

    const showSaveErro = ()=>{
        swal({
            type: 'error',
            title: 'Erro',
            text: 'Erro no processamento dos dados no servidor, tente novamente mais tarde!'
        });
    };

    this.save = (async function () {
        if(!this.validate()) return;

        var data = await GestaoOcupacaoModel.getData();
        var OrigemSolicitacaoId = $("#OrigemSolicitacaoId").val();

        if(novaOrigem==ORIGEM_CANCELAMENTO || (OrigemSolicitacaoId == getOrigemSolicitacaoCancelamentoId()) || Model.Cancelamento) data.Cancelamento = {MotivoCancelamento:$("#Cancelamento_MotivoCancelamento").val()};
        // if(novaOrigem==ORIGEM_AJUIZAMENTO) data.Cancelamento = {MotivoCancelamento:$("#Cancelamento_MotivoCancelamento").val()};
        if(novaOrigem==ORIGEM_MANUTENCAO || (OrigemSolicitacaoId == getOrigemSolicitacaoManutencaoId()) || Model.Manutencao) {
            const Manutencao_ArquivoUpload = await UploadHelper.getFileAndName("#Manutencao_ArquivoUpload");
            let Manutencao_NomeArquivo = '';
            let Manutencao_Arquivo;
            
            if(this.modoEditar && !Manutencao_ArquivoUpload.Nome && !Manutencao_ArquivoUpload.Arquivo) {
                Manutencao_NomeArquivo = Model.Manutencao ? Model.Manutencao.NomeArquivo : '';
            } else {
                Manutencao_NomeArquivo = Manutencao_ArquivoUpload.Nome;
                Manutencao_Arquivo = Manutencao_ArquivoUpload.Arquivo;
            }
            data.Manutencao = {
                DataAssinatura:$("#Manutencao_DataAssinatura").val(),
                DataAprovacaoRegional:$("#Manutencao_DataAprovacaoRegional").val(),
                Observacao:$("#Manutencao_Observacao").val(),
                NomeArquivo:Manutencao_NomeArquivo,
                Arquivo:Manutencao_Arquivo,
            };
        }
        if(novaOrigem==ORIGEM_TRANSFERENCIA || (OrigemSolicitacaoId == getOrigemSolicitacaoTransferenciaTitularidadeId()) || Model.Transferencia) {
            data.Transferencia = {...Model.Transferencia};
            data.Transferencia.NumerospdocAntecessor = $("#Transferencia_NumerospdocAntecessor").val();
            data.Transferencia.NumeroProcessoAntecessor = $("#Transferencia_NumeroProcessoAntecessor").val();
            data.Transferencia.DataSolicitacao = $("#Transferencia_DataSolicitacao").val();
            data.Transferencia.AntecessorInteressado = $("#Transferencia_AntecessorInteressado").val();
            data.Transferencia.Observacao = $("#Transferencia_Observacao").val();
        }

        if(novaOrigem==ORIGEM_RETIFICACAO || (OrigemSolicitacaoId == getOrigemSolicitacaoRetificacaoId()) || Model.Retificacao) {
            data.Retificacao = {DataSolicitacao:$("#Retificacao_DataSolicitacao").val(),
                                ObjetoTermoRetificacao:$("#Retificacao_ObjetoTermoRetificacao").val()};
        }
    

        if (!validaOcupacao) data.Ocupacao = {Assunto:Model.Assunto, Observacao:Model.Observacao};
        // if (!validaTrecho) data.Trechos = Model.ListaTrecho;

        GestaoOcupacaoService.save(data).
            then(response => {
                console.log("response:", response);
                if(response.valid){
                    //response
                    swal({
                        type: 'success',
                        title: 'Sucesso',
                        text: 'Projeto salvo com sucesso!'
                    }).then((result) => {
                        if (result.value) {
                            window.location.href = "/GestaoOcupacoes/List";
                        }
                    })
                } else {
                    showSaveErro();
                }
            }).
            catch(response=>{
                showSaveErro();
            });
    }).bind(this);

    this.saveHandler = (function () {

    }).bind(this);

    this.DownloadArquivo = (function(arquivo) {
        var link = document.createElement("a");
        link.href = "/GestaoOcupacoes/DownloadArquivo?caminhoArquivo="+arquivo;
        link.click();
    }).bind(this);

    this.toString = function(){
        return 'GestaoOcupacaoController';
    }

    return this;
}

var dataExtra = {
    AdicionadoPor:AdicionadoPor,
    DataAdicionado:DataAdicionado,
    InteressadoId: InteressadoId
}
window.controller = new GestaoOcupacaoController(GestaoOcupacaoModel.newInit(ListaTrecho, Ocorrencias, ListaDocumentos), dataExtra);
window.controller.init();

