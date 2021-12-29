import LocalizacaoModel from "./LocalizacaoModel";
import RodoviaModel from "./RodoviaModel";
import TipoImplantacaoModel from "./TipoImplantacaoModel";
import TipoPassagemModel from "./TipoPassagemModel";
import TipoOcupacaoModel from "./TipoOcupacaoModel";
import lado_model from './../lado_model';

var TrechoModel = {
    Localizacao: LocalizacaoModel.new(),
    Rodovia: RodoviaModel.new(),
    KmInicial: "",
    KmInicialMetragem: "",
    KmFinal: "",
    KmFinalMetragem: "",
    Extensao: "",
    TipoImplantacao: TipoImplantacaoModel.new(),
    TipoPassagem: TipoPassagemModel.new(),
    Lado: lado_model.new(),
    TipoOcupacao: TipoOcupacaoModel.new(),
    Altura: "",
    Profundidade: "",
    trecho_interferencias:[],
    trecho_interferencia_volume_total:0,
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate:function(trecho_interferencias){
        // let KmInicial = parseFloat($("#KmInicial").val().replace(",", "."));
        // let KmFinal = parseFloat($("#KmFinal").val().replace(",", "."));
        // let Extensao = parseFloat($("#Extensao").val().replace(",", "."));
        let KmInicialCompleto = $("#KmInicial").val().split('+');
        let KmInicial = KmInicialCompleto[0];
        let KmInicialMetragem = KmInicialCompleto[1];
        let KmFinalCompleto = $("#KmFinal").val().split('+');
        let KmFinal = KmFinalCompleto[0];
        let KmFinalMetragem = KmFinalCompleto[1];
        let Extensao = $("#Extensao").val();
        let Altura = parseFloat($("#Altura").val());
        let Profundidade = parseFloat($("#Profundidade").val());
        var TIPO_IMPLANTACAO_ID_PONTUAL = 229;

        var model = TrechoModel.new();
        model.trecho_interferencia_volume_total = TrechoModel.getInterferenciaVolumeTotal(trecho_interferencias);
        // model.trecho_interferencia_volume_total = trecho_interferencias.reduce((a, b) => a + b.volume_total, 0);
        // model.trecho_interferencia_volume_total = trecho_interferencias.reduce((a, b) => a.plus(b.volume_total), Big(0)).toFixed(3);
        model.Localizacao = LocalizacaoModel.getPopulate();
        model.Rodovia = RodoviaModel.getPopulate();
        model.KmInicial = KmInicial;
        model.KmInicialMetragem = KmInicialMetragem;
        model.KmFinal = KmFinal;
        model.KmFinalMetragem = KmFinalMetragem;
        model.TipoImplantacao = TipoImplantacaoModel.getPopulate();
        model.Extensao = Extensao;
        // if(model.TipoImplantacao.TipoImplantacaoId==TIPO_IMPLANTACAO_ID_PONTUAL) model.Extensao = Extensao+model.trecho_interferencia_volume_total;
        model.TipoPassagem = TipoPassagemModel.getPopulate();
        model.Lado = lado_model.getPopulate();
        model.TipoOcupacao = TipoOcupacaoModel.getPopulate();
        model.Altura = Altura;
        model.Profundidade = Profundidade;
        model.trecho_interferencias = trecho_interferencias;
        
        return model;
    },
    getInterferenciaVolumeTotal:function(trecho_interferencias){
        return trecho_interferencias.reduce((a, b) => a.plus(b.volume_total), Big(0)).toNumber();
        // return trecho_interferencias.reduce((a, b) => a + b.volume_total, 0);
    }
};
export default TrechoModel;
