import UploadHelper from './../../Helpers/upload/UploadHelper';

var DeferimentoModel = {
    DataDespachoAutorizativo: "",
    NumeroProcesso: "",
    DataAssinatura: "",
    DataPublicacao: "",
    TermoAnexadoNome: "",
    TermoAnexadoArquivo: "",
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate: async function(){
        var model = DeferimentoModel.new();
        const TermoAnexado = await UploadHelper.getFileAndName("#TermoAnexadoDocumentoUpload");

        model.DataDespachoAutorizativo = $("#Deferimento_DataDespachoAutorizativo").val();
        model.NumeroProcesso = $("#Deferimento_NumeroProcesso").val();
        model.DataAssinatura = $("#Deferimento_DataAssinatura").val();
        model.DataPublicacao = $("#Deferimento_DataPublicacao").val();

        if(controller.modoEditar && !TermoAnexado.Nome && !TermoAnexado.Arquivo) {
            model.TermoAnexadoNome = DeferimentoTermoAnexadoNome;
            model.TermoAnexadoArquivo = null;
        } else {
            model.TermoAnexadoNome = TermoAnexado.Nome;
            model.TermoAnexadoArquivo = TermoAnexado.Arquivo;
        }
        // model.TermoAnexadoNome = TermoAnexado.Nome;
        // model.TermoAnexadoArquivo = TermoAnexado.Arquivo;

        return model;
    }
};
export default DeferimentoModel;