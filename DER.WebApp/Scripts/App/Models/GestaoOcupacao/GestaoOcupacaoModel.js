
import OcupacaoModel from "../../Models/GestaoOcupacao/OcupacaoModel";
import ParecerModel from "../../Models/GestaoOcupacao/ParecerModel";
import DeferimentoModel from "../../Models/GestaoOcupacao/DeferimentoModel";
import UploadHelper from './../../Helpers/upload/UploadHelper';

var GestaoOcupacaoModel = {
    Id: "",
    InteressadoId: "",
    RegionalId: "",
    ResidenciaConservacaoId: "",
    NumeroSPDOC: "",
    NumeroProcesso: "",
    OrigemSolicitacaoId: "",
    SituacaoSolicitacaoId: "",
    SituacaoOcupacaoId: "",
    DataImplantacao: "",
    DataCadastro: "",
    CriarNovaOcupacao: false,
    Ocupacao: OcupacaoModel.new(),
    Trechos: [],
    Ocorrencias: [],
    Documentos: [],
    Parecer: ParecerModel.new(),
    Deferimento: DeferimentoModel.new(),
    new:function(){
        return Object.assign({}, this);
    },
    newInit:function(ListaTrecho, Ocorrencias, ListaDocumentos){
        var model = GestaoOcupacaoModel.new();
        model.Trechos = ListaTrecho;
        model.Ocorrencias = Ocorrencias;
        model.Documentos = ListaDocumentos;
        return model;        
    },
    getPopulate: async function(){
        var model = GestaoOcupacaoModel.new();
        var controller = window.controller;

        model.Id = $("#Id").val();
        model.InteressadoId = controller.buscarInteressadosComponent.interessadoSelecionado.IdInteressado;
        model.RegionalId = parseInt($("#RegionalId").val());
        model.ResidenciaConservacaoId = parseInt($("#ResidenciaConservacaoId").val());
        model.NumeroSPDOC = $("#NumeroSPDOC").val();
        model.NumeroProcesso = $("#NumeroProcesso").val();
        model.OrigemSolicitacaoId = parseInt($("#OrigemSolicitacaoId").val());
        model.SituacaoSolicitacaoId = $("#SituacaoSolicitacaoId").val();
        model.SituacaoOcupacaoId = $("#SituacaoOcupacaoId").val();
        model.DataImplantacao = $("#DataImplantacao").val();
        model.DataCadastro = $("#DataCadastro").val();
        model.CriarNovaOcupacao = CriarNovaOcupacao;
        model.Ocupacao = OcupacaoModel.getPopulate();
        model.Trechos = controller.trechosComponent.trechos;
        model.Ocorrencias = controller.ocorrenciasComponent.ocorrencias;
        model.Documentos = controller.documentosComponent.documentos;
        await ParecerModel.getPopulate().then(function(parecerModel){
            model.Parecer = parecerModel;
        });
        await DeferimentoModel.getPopulate().then(function(deferimentoModel){
            model.Deferimento = deferimentoModel;
        });
        return model;
    },
    getData: async function(){
        var model = await GestaoOcupacaoModel.getPopulate();
        return JSON.parse(JSON.stringify(model));
    }
};
export default GestaoOcupacaoModel;