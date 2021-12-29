import ValidateHelper from '../../Helpers/validate/ValidateHelper';
import TrechoModel from '../../Models/GestaoOcupacao/TrechoModel';
import trechos_interferencias_component from './trechos_interferencias_component';
import GestaoOcupacaoService from './../../Services/GestaoOcupacao/GestaoOcupacaoService';

function TrechosComponent(trechos){
    this.trechos = trechos;
    this.trechoAtual = null;
    var TIPO_IMPLANTACAO_ID_PONTUAL = 229;
    var TIPO_IMPLANTACAO_ID_TRAVESSIA = 231;
    var TIPOPASSAGEM_SUBTERRENEA_ID=227;
    var TIPOPASSAGEM_AEREA_ID=228;
    
    this.trechosInterferenciasComponent = new trechos_interferencias_component([]);

    this.cad_trecho_interferencias = (function(){
        this.trechosInterferenciasComponent.cad_trecho_interferencias();
    }).bind(this);

    this.exc_trecho_interferencia = (function(index){
        this.trechosInterferenciasComponent.exc_trecho_interferencia(index);
    }).bind(this);


    this.init = (function(){
        $("#TipoImplantacaoId").change(function () {
            var TipoImplantacaoId = $("#TipoImplantacaoId").val();
            var disableKmFinal = false;
            var extensaoLabelMText = "Extensão(m) * ";
            var extensaoLabelM2Text = "Extensão(m²) * ";
            var extensaoLabelText = extensaoLabelMText;
            if (TIPO_IMPLANTACAO_ID_PONTUAL == TipoImplantacaoId ||
                TIPO_IMPLANTACAO_ID_TRAVESSIA == TipoImplantacaoId) {
                disableKmFinal = true;
                extensaoLabelText = extensaoLabelM2Text;
                $("#KmFinal, #Extensao").val("");
            }
            $("#ExtensaoLabel").text(extensaoLabelText);
            $("#KmFinal").attr("disabled", disableKmFinal);
        });

        $("#TipoPassagemId").change(function () {
            var TipoPassagemId = $("#TipoPassagemId").val();
            if(TipoPassagemId==TIPOPASSAGEM_SUBTERRENEA_ID){//Subterrânea
                $("#Profundidade").attr("disabled", false);
                $("#Altura").attr("disabled", true);
                $("#Altura").val("");
            } else if(TipoPassagemId==TIPOPASSAGEM_AEREA_ID){//Aérea
                $("#Altura").attr("disabled", false);
                $("#Profundidade").attr("disabled", true);
                $("#Profundidade").val("");
            }
        });

        $("#TipoOcupacaoId").change(function(){
            let tipoOcupacaoId = $("#TipoOcupacaoId").val();
            const tipoConcessoes = controller.buscarInteressadosComponent.interessadoSelecionado.TipoConcessoes ? 
                                controller.buscarInteressadosComponent.interessadoSelecionado.TipoConcessoes :
                                Model.InteressadoTipoDeConcessoes;
            let tipoOcupacao = tipoConcessoes.find(t => t.TipoOcupacaoId==tipoOcupacaoId);
            if(tipoOcupacao){
                const alturaMsg = `O valor para Altura deve ser no mínimo ${tipoOcupacao.AlturaMinima}.`;
                const profundidadeMsg = `O valor para Profundidade deve ser no mínimo ${tipoOcupacao.ProfundidadeMinima}.`;
                $("#Altura").attr("data-val-range-min", tipoOcupacao.AlturaMinima);                
                $("#Altura").attr("data-val-range", alturaMsg);
                $("#Profundidade").attr("data-val-range-min", tipoOcupacao.ProfundidadeMinima);                
                $("#Profundidade").attr("data-val-range", profundidadeMsg);

                $('form').validate().settings.rules.Altura.range = [tipoOcupacao.AlturaMinima, 'Infinity'];
                $('form').validate().settings.messages.Altura.range = alturaMsg;
                $('form').validate().settings.rules.Profundidade.range = [tipoOcupacao.ProfundidadeMinima, 'Infinity'];
                $('form').validate().settings.messages.Profundidade.range = profundidadeMsg;
            }
        });
        
        $("#KmInicial").blur(this.extensaoCalculo);
        $("#KmInicial").keyup(this.extensaoCalculo);
        $("#KmFinal").blur(this.extensaoCalculo);
        $("#KmFinal").keyup(this.extensaoCalculo);

        $("#KmInicial").mask("999,999+999");
        $("#KmFinal").mask("999,999+999");
        $("#Extensao").mask("#.##9,999", {reverse: true});

        this.atualizarTrechosInterferenciasVolumeTotal();
        this.trechosInterferenciasComponent.init();

        this.extensoesCalculoTotal();
    }).bind(this);

    this.atualizarTrechosInterferenciasVolumeTotal = (function() {
        this.trechos.forEach(trecho=>{
            trecho.trecho_interferencia_volume_total = TrechoModel.getInterferenciaVolumeTotal(trecho.trecho_interferencias);
        });
    }).bind(this);

    this.extensaoCalculo = (function() {
        var KmInicial = this.convertToNumber($("#KmInicial").val()) || 0;
        var KmFinal = this.convertToNumber($("#KmFinal").val());
        var TipoImplantacaoId = $("#TipoImplantacaoId").val();
    
        if (!KmFinal || !TipoImplantacaoId || 
            TipoImplantacaoId == TIPO_IMPLANTACAO_ID_PONTUAL || 
            TipoImplantacaoId == TIPO_IMPLANTACAO_ID_TRAVESSIA) return;
    
        var extensao = Big(KmFinal).minus(KmInicial);
        if (extensao <= 0) extensao = extensao.times(-1);
        extensao = extensao.times(1000).toNumber();

        $("#Extensao").val(extensao.toLocaleString('pt-BR', { minimumFractionDigits:3, maximumFractionDigits:3}));
    }).bind(this);

    this.AdicionarTrecho = (async function(){
        $("span[data-valmsg-for=Altura]").hide();
        $("span[data-valmsg-for=Profundidade]").hide();
        
        if (!ValidateHelper.validarCampos(["#TipoOcupacaoId", "#RodoviaId", "#TipoImplantacaoId", "#TipoPassagemId", 
                                           "#KmInicial", "#Extensao", "#LadoId"])) {
            $("#gestao-ocupacao-tab-modal-trecho-adicionar").tab('show');
            return;
        } else if ($("#TipoImplantacaoId").val() != TIPO_IMPLANTACAO_ID_PONTUAL && 
                   $("#TipoImplantacaoId").val() != TIPO_IMPLANTACAO_ID_TRAVESSIA && 
                   !ValidateHelper.validarCampos(["#KmFinal"])) {
            return;
        } else if ($("#TipoPassagemId").val() == TIPOPASSAGEM_SUBTERRENEA_ID && !ValidateHelper.validarCampos(["#Profundidade"])) {;
            $("span[data-valmsg-for=Profundidade]").show();
            $("#gestao-ocupacao-tab-modal-trecho-adicionar").tab('show');
            return;
        } else if ($("#TipoPassagemId").val() == TIPOPASSAGEM_AEREA_ID && !ValidateHelper.validarCampos(["#Altura"])) {
            $("span[data-valmsg-for=Altura]").show();
            $("#gestao-ocupacao-tab-modal-trecho-adicionar").tab('show');
            return;
        }

        var trecho = TrechoModel.getPopulate(this.trechosInterferenciasComponent.trecho_interferencias.slice());
        var dataValidacao = {
            KmInicial: this.convertToNumber(trecho.KmInicial),
            KmFinal: this.convertToNumber(trecho.KmFinal),
            // KmInicial: trecho.KmInicial,
            // KmFinal: trecho.KmFinal,
            Lado: parseInt(trecho.Lado.LadoId),
            RodoviaId: trecho.Rodovia.RodoviaId
        };
        var validacaoProjetoMelhorias = null;
        await GestaoOcupacaoService.ValidacaoTrechoProjetoMelhoria(dataValidacao).then(function(response){
            validacaoProjetoMelhorias = response;
        });
        
        if(validacaoProjetoMelhorias.length) {
            swal({
                title: "Aviso",
                type: 'info',
                text: 'Existem projetos de melhorias na rodovia e trecho solicitado. Sugerimos entrar em contato com a Divisão Regional responsável pelo trecho, para verificações.'
            });
        }
    
        this.trechos.push(trecho);
    
        this.ConstruirListaTrecho();
        this.modalHide();
    }).bind(this);

    this.EditarTrecho = (function(index) {
        var trecho = this.trechos[index];
        if (trecho) {
            this.trechoAtual = trecho;
            this.populateForm(this.trechoAtual);
        }
    
        this.ModalTrechoEditar();
    }).bind(this);

    this.ExcluirTrecho = (function(linhaExclusao) {
        this.trechos.splice(linhaExclusao, 1);
    
        this.ConstruirListaTrecho();
    }).bind(this);

    this.VisualizarTrecho = (function(index) {
        var trecho = this.trechos[index];
        if (trecho) {
            this.trechoAtual = trecho;
            this.populateForm(this.trechoAtual);
        }
    
        this.ModalTrechoVisualizar();
    }).bind(this);

    this.getKmMetragem = (function(km, metragem){
        return km+(metragem ? `+${metragem}` : '');
    }).bind(this);

    this.populateForm = (function(trecho) {
        $("input[name=resumotrechorbt][value=" + trecho.Localizacao.LocalizacaoId + "]").prop('checked', true);
        $("#RodoviaId").val(trecho.Rodovia.RodoviaId).change();
        $("#KmInicial").val(this.getKmMetragem(trecho.KmInicial, trecho.KmInicialMetragem));
        $("#KmFinal").val(this.getKmMetragem(trecho.KmFinal, trecho.KmFinalMetragem));
        $("#Extensao").val(trecho.Extensao);
        $("#TipoImplantacaoId").val(trecho.TipoImplantacao.TipoImplantacaoId).change();
        $("#TipoPassagemId").val(trecho.TipoPassagem.TipoPassagemId).change();
        $("#LadoId").val(trecho.Lado.LadoId).change();
        $("#TipoOcupacaoId").val(trecho.TipoOcupacao.TipoOcupacaoId).change();
        $("#Altura").val(trecho.Altura);
        $("#Profundidade").val(trecho.Profundidade);
        this.trechosInterferenciasComponent.set_trecho_interferencias(trecho.trecho_interferencias);
    }).bind(this);

    this.ConstruirListaTrecho = (function(){
        $("#bodyTrecho").empty();
    
        var newContent = "";
    
        this.trechos.forEach((trecho, i) => {
            newContent = newContent + "<tr>";
            newContent = newContent + "<td class='leftText'><span id='Trecho" + i + "' value='" + i + "'>" + (i + 1) + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='TipoImplantacao" + i + "' value='" + trecho.TipoImplantacao.TipoImplantacaoId + "'>" + trecho.TipoImplantacao.Nome + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='TipoPassagem" + i + "' value='" + trecho.TipoPassagem.TipoPassagemId + "'>" + trecho.TipoPassagem.Nome + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='lado" + i + "' value='" + trecho.Lado.LadoId + "'>" + trecho.Lado.Nome + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='Rodovia" + i + "' value='" + trecho.Rodovia.RodoviaId + "'>" + trecho.Rodovia.Nome + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='KmInicial" + i + "' value='" + trecho.KmInicial + "'>" + this.getKmMetragem(trecho.KmInicial, trecho.KmInicialMetragem) + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='KmFinal" + i + "' value='" + trecho.KmFinal + "'>" + this.getKmMetragem(trecho.KmFinal, trecho.KmFinalMetragem) + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='Extensao" + i + "' value='" + trecho.Extensao + "'>" + trecho.Extensao + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='localizacao" + i + "' value='" + trecho.Localizacao.LocalizacaoId + "'>" + trecho.Localizacao.Nome + "</span></td>";
            newContent = newContent + "<td><button type='button' onclick='controller.trechosComponent.VisualizarTrecho(" + i + ");' class='btn btn-link'><i class='fa fa-search' title='Visualizar'></i></button>";
            newContent = newContent + "<button type='button' onclick='controller.trechosComponent.EditarTrecho(" + i + ");' class='btn btn-link'><i class='fa fa-pencil' title='Editar'></i></button>";
            newContent = newContent + "<button type='button' onclick='controller.trechosComponent.ExcluirTrecho(" + i + ");' class='btn btn-link' id='excluirTrecho'><i class='fa fa-trash' title='Excluir'></i></button></td>";
            newContent = newContent + "</tr>";
        });
    
        $("#bodyTrecho").append(newContent);

        this.extensoesCalculoTotal();
    }).bind(this);

    this.extensoesCalculoTotal = (function(){
        var trechosDominioLongitudinalTotal = this.getExtensaoTotalByLocalizaoEImplantacao("faixadominio", 230);
        var trechosDominioTransversalTotal = this.getExtensaoTotalByLocalizaoEImplantacao("faixadominio", 231);
        var trechosNonAedificandiLongitudinalTotal = this.getExtensaoTotalByLocalizaoEImplantacao("nonaedificandi", 230);
        var trechosNonAedificandiTransversalTotal = this.getExtensaoTotalByLocalizaoEImplantacao("nonaedificandi", 231);
        var trechosDominioTotal = Big(trechosDominioLongitudinalTotal).plus(trechosDominioTransversalTotal).toNumber();
        var trechosNonAedificandiTotal = Big(trechosNonAedificandiLongitudinalTotal).plus(trechosNonAedificandiTransversalTotal).toNumber();
        
        var trechosDominioPontualTotal = this.getExtensaoTotalByLocalizaoEImplantacao("faixadominio", 229);
        var trechosNonAedificandiPontualTotal = this.getExtensaoTotalByLocalizaoEImplantacao("nonaedificandi", 229);

        var trechosDominioPontualInterferenciaTotal = this.getAreaTotalInterferenciasByLocalizaoEImplantacao("faixadominio", 229);
        var trechosDominioLongitudinalInterferenciaTotal = this.getAreaTotalInterferenciasByLocalizaoEImplantacao("faixadominio", 230);        
        var trechosDominioTransversalInterferenciaTotal = this.getAreaTotalInterferenciasByLocalizaoEImplantacao("faixadominio", 231);

        var trechosNonAedificandiPontualInterferenciaTotal = this.getAreaTotalInterferenciasByLocalizaoEImplantacao("nonaedificandi", 229);
        var trechosNonAedificandiLongitudinalInterferenciaTotal = this.getAreaTotalInterferenciasByLocalizaoEImplantacao("nonaedificandi", 230);
        var trechosNonAedificandiTransversalInterferenciaTotal = this.getAreaTotalInterferenciasByLocalizaoEImplantacao("nonaedificandi", 231);

        var trechosDominioInterferenciaTotal = Big(trechosDominioPontualInterferenciaTotal).plus(trechosDominioLongitudinalInterferenciaTotal).plus(trechosDominioTransversalInterferenciaTotal).toNumber();
        var trechosNonAedificandiInterferenciaTotal = Big(trechosNonAedificandiPontualInterferenciaTotal).plus(trechosNonAedificandiLongitudinalInterferenciaTotal).plus(trechosNonAedificandiTransversalInterferenciaTotal).toNumber();

        var trechosDominioPontualExtInterferenciaTotal = Big(trechosDominioPontualTotal).plus(trechosDominioInterferenciaTotal).toNumber();
        var trechosNonAedificandiPontualExtInterferenciaTotal = Big(trechosNonAedificandiPontualTotal).plus(trechosNonAedificandiInterferenciaTotal).toNumber();

        $("#extTotalDominioLongitudinal").text(trechosDominioLongitudinalTotal);
        $("#extTotalDominioTransversal").text(trechosDominioTransversalTotal);
        $("#extTotalNonAedificandiLongitudinal").text(trechosNonAedificandiLongitudinalTotal);
        $("#extTotalNonAedificandiTransversal").text(trechosNonAedificandiTransversalTotal);
        $("#extTotalDominio").text(trechosDominioTotal);
        $("#extTotalNonAedificandi").text(trechosNonAedificandiTotal);

        $("#extTotalDominioPontual").text(trechosDominioPontualTotal);
        $("#extTotalNonAedificandiPontual").text(trechosNonAedificandiPontualTotal);

        $("#extTotalDominioInterferencia").text(trechosDominioInterferenciaTotal);
        $("#extTotalNonAedificandiInterferencia").text(trechosNonAedificandiInterferenciaTotal);

        $("#extTotalDominioPontualInterferencia").text(trechosDominioPontualExtInterferenciaTotal);
        $("#extTotalNonAedificandiPontualInterferencia").text(trechosNonAedificandiPontualExtInterferenciaTotal);
    }).bind(this);

    this.getTrechosByLocalizaoEImplantacao = (function(localizaocaoNome, tipoImplantacaoId) {
        return this.trechos.filter(trecho => { return trecho.Localizacao.Nome == localizaocaoNome && trecho.TipoImplantacao.TipoImplantacaoId == tipoImplantacaoId });
    }).bind(this);

    this.getExtensaoTotalByTrechos = (function(trechos) {
        return trechos.length <= 1 ?
               trechos.length == 0 ? 0 : this.convertToNumberExtensao(trechos[0].Extensao) :
               trechos.reduce((a, b) => a.plus(this.convertToNumberExtensao(b.Extensao)), Big(0)).toNumber();
    }).bind(this);

    this.convertToNumber = (function(str) {
        const kmMetragem = str.split("+");
        return parseFloat(kmMetragem[0].replace(",", "."));
    }).bind(this);
    
    this.convertToNumberExtensao = (function(value) {
        return parseFloat( isNaN(value) ? value.replace(",", ".") : value );
    }).bind(this);
    
    this.getAreaTotalInterferenciasByTrechos = (function(trechos) {
        return trechos.length <= 1 ?
               trechos.length == 0 ? 0 : trechos[0].trecho_interferencia_volume_total :
               trechos.reduce((a, b) => a.plus(b.trecho_interferencia_volume_total), Big(0)).toNumber();
    }).bind(this);

    this.getExtensaoTotalByLocalizaoEImplantacao = (function(localizaocaoNome, tipoImplantacaoId) {
        var trechos = this.getTrechosByLocalizaoEImplantacao(localizaocaoNome, tipoImplantacaoId);
        return this.getExtensaoTotalByTrechos(trechos);
    }).bind(this);
    
    this.getAreaTotalInterferenciasByLocalizaoEImplantacao = (function(localizaocaoNome, tipoImplantacaoId) {
        var trechos = this.getTrechosByLocalizaoEImplantacao(localizaocaoNome, tipoImplantacaoId);
        return this.getAreaTotalInterferenciasByTrechos(trechos);
    }).bind(this);

    this.modalHide = (function(){
        $("#modalTrecho").modal("hide");
    }).bind(this);

    this.modalShow = (function(){
        $('#TipoOcupacaoId').prop('selectedIndex', 0);
        $("#modalTrecho").modal("show");
    }).bind(this);

    this.ModalTrechoShowAddOuEditar = (function(showAdd) {
        $("#gestao-ocupacao-tab-modal-trecho-adicionar").tab('show');
        if (showAdd) {
            $("#btnAdicionarTrecho").show();
            $("#btnAlterarTrecho").hide();
        } else {
            $("#btnAdicionarTrecho").hide();
            $("#btnAlterarTrecho").show();
        }
        this.formElementsDisabled(false);
        $("#Altura").attr("disabled", true);
        $("#Profundidade").attr("disabled", true);
    }).bind(this);

    this.ModalTrechoAdd = (function() {
        $("input[name=resumotrechorbt][value=faixadominio]").prop('checked', true);
        $("#RodoviaId").val("").change();
        $("#KmInicial").val("");
        $("#KmFinal").val("");
        $("#Extensao").val("");
        $("#TipoImplantacaoId").val("").change();
        $("#TipoPassagemId").val("").change();
        $("#LadoId").val("").change();
        $("#TipoOcupacaoId").val("").change();
        $("#Altura").val("");
        $("#Profundidade").val("");
        this.modalShow();
        this.ModalTrechoShowAddOuEditar(true);
        this.trechosInterferenciasComponent.clear();
        $("#btnAdicionarTrechoInterferencia").show();
    }).bind(this);

    this.ModalTrechoEditar = (function() {
        $("#modalTrecho").modal('show');
        this.ModalTrechoShowAddOuEditar(false);
        $("#btnAdicionarTrechoInterferencia").show();
    }).bind(this);

    this.ModalTrechoVisualizar = (function() {
        $("#gestao-ocupacao-tab-modal-trecho-adicionar").tab('show');
        $("#btnAdicionarTrecho").hide();
        $("#btnAlterarTrecho").hide();
        this.formElementsDisabled(true);
        $("#modalTrecho").modal('show');
        $("#btnAdicionarTrechoInterferencia").hide();
    }).bind(this);

    this.formElementsDisabled = (function(disabled) {
        $("#input[name='resumotrechorbt']").attr('disabled', disabled);
        $("#RodoviaId").attr('disabled', disabled);
        $("#KmInicial").attr('disabled', disabled);
        $("#KmFinal").attr('disabled', disabled);
        $("#Extensao").attr('disabled', disabled);
        $("#TipoImplantacaoId").attr('disabled', disabled);
        $("#TipoPassagemId").attr('disabled', disabled);
        $("#LadoId").attr('disabled', disabled);
        $("#TipoOcupacaoId").attr('disabled', disabled);
        $("#Altura").attr('disabled', disabled);
        $("#Profundidade").attr('disabled', disabled);
        this.trechosInterferenciasComponent.disabled(disabled);
    }).bind(this);

    this.EditarTrechoSalvar = (function() {
        var trecho = TrechoModel.getPopulate(this.trechosInterferenciasComponent.trecho_interferencias.slice());
    
        this.trechoAtual = {...trecho};
    
        this.ConstruirListaTrecho();
        $("#modalTrecho").modal('hide');
    }).bind(this);

    this.AdicionarTrechoInterferencia = (function () {
        $("#gestao-ocupacao-tab-modal-interferencia-adicionar").tab('show');
    }).bind(this);

    return this;
}

export default TrechosComponent;