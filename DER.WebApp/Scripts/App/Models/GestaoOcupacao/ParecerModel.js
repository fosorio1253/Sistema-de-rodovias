import UploadHelper from './../../Helpers/upload/UploadHelper';

var ParecerModel = {
    ParecerRegionalId: "",
    ParecerRegionalObservacao: "",
    ParecerRegionalData: "",
    ParecerRegionalDocumentoNome: "",
    ParecerRegionalDocumentoArquivo: "",
    ParecerDiretoriaEngenhariaId: "",
    ParecerDiretoriaEngenhariaObservacao: "",
    ParecerDiretoriaEngenhariaData: "",
    ParecerDiretoriaDocumentoNome: "",
    ParecerDiretoriaDocumentoArquivo: "",
    ParecerCoordenadoriaOperacoesId: "",
    ParecerCoordenadoriaOperacoesObservacao: "",
    ParecerCoordenadoriaOperacoesData: "",
    ParecerCoordenadoriaDocumentoNome: "",
    ParecerCoordenadoriaDocumentoArquivo: "",
    ParecerFaixaDominioId: "",
    ParecerFaixaDominioObservacao: "",
    ParecerFaixaDominioData: "",
    ParecerFaixaDominioDocumentoNome: "",
    ParecerFaixaDominioDocumentoArquivo: "",
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate: async function(){
        var model = ParecerModel.new();
        const ParecerRegionalDocumento = await UploadHelper.getFileAndName("#ParecerRegionalDocumentoUpload");
        const ParecerDiretoriaEngenhariaDocumento = await UploadHelper.getFileAndName("#ParecerDiretoriaEngenhariaDocumentoUpload");
        const ParecerCoordenadoriaDocumento = await UploadHelper.getFileAndName("#ParecerCoordenadoriaDocumentoUpload");
        const ParecerFaixaDominioDocumento = await UploadHelper.getFileAndName("#ParecerFaixaDominioDocumentoUpload");

        model.ParecerRegionalId = $('input[name=ParecerRegionalId]:checked').val();
        model.ParecerRegionalObservacao = $("#ParecerRegionalObservacao").val();
        model.ParecerRegionalData = $("#ParecerRegionalData").val();
        if(controller.modoEditar && !ParecerRegionalDocumento.Nome && !ParecerRegionalDocumento.Arquivo) {
            model.ParecerRegionalDocumentoNome = ParecerRegionalDocumentoNome;
            model.ParecerRegionalDocumentoArquivo = null;
        } else {
            model.ParecerRegionalDocumentoNome = ParecerRegionalDocumento.Nome;
            model.ParecerRegionalDocumentoArquivo = ParecerRegionalDocumento.Arquivo;
        }
        // model.ParecerRegionalDocumentoNome = ParecerRegionalDocumento.Nome;
        // model.ParecerRegionalDocumentoArquivo = ParecerRegionalDocumento.Arquivo;

        model.ParecerDiretoriaEngenhariaId = $('input[name=ParecerDiretoriaEngenhariaId]:checked').val();
        model.ParecerDiretoriaEngenhariaObservacao = $("#ParecerDiretoriaEngenhariaObservacao").val();
        model.ParecerDiretoriaEngenhariaData = $("#ParecerDiretoriaEngenhariaData").val();
        if(controller.modoEditar && !ParecerDiretoriaEngenhariaDocumento.Nome && !ParecerDiretoriaEngenhariaDocumento.Arquivo) {
            model.ParecerDiretoriaDocumentoNome = ParecerDiretoriaDocumentoNome;
            model.ParecerDiretoriaDocumentoArquivo = null;
        } else {
            model.ParecerDiretoriaDocumentoNome = ParecerDiretoriaEngenhariaDocumento.Nome;
            model.ParecerDiretoriaDocumentoArquivo = ParecerDiretoriaEngenhariaDocumento.Arquivo;
        }
        // model.ParecerDiretoriaDocumentoNome = ParecerDiretoriaEngenhariaDocumento.Nome;
        // model.ParecerDiretoriaDocumentoArquivo = ParecerDiretoriaEngenhariaDocumento.Arquivo;

        model.ParecerCoordenadoriaOperacoesId = $('input[name=ParecerCoordenadoriaOperacoesId]:checked').val();
        model.ParecerCoordenadoriaOperacoesObservacao = $("#ParecerCoordenadoriaOperacoesObservacao").val();
        model.ParecerCoordenadoriaOperacoesData = $("#ParecerCoordenadoriaOperacoesData").val();
        if(controller.modoEditar && !ParecerCoordenadoriaDocumento.Nome && !ParecerCoordenadoriaDocumento.Arquivo) {
            model.ParecerCoordenadoriaDocumentoNome = ParecerCoordenadoriaDocumentoNome;
            model.ParecerCoordenadoriaDocumentoArquivo = null;
        } else {
            model.ParecerCoordenadoriaDocumentoNome = ParecerCoordenadoriaDocumento.Nome;
            model.ParecerCoordenadoriaDocumentoArquivo = ParecerCoordenadoriaDocumento.Arquivo;
        }
        // model.ParecerCoordenadoriaDocumentoNome = ParecerCoordenadoriaDocumento.Nome;
        // model.ParecerCoordenadoriaDocumentoArquivo = ParecerCoordenadoriaDocumento.Arquivo;

        model.ParecerFaixaDominioId = $('input[name=ParecerFaixaDominioId]:checked').val();
        model.ParecerFaixaDominioObservacao = $("#ParecerFaixaDominioObservacao").val();
        model.ParecerFaixaDominioData = $("#ParecerFaixaDominioData").val();
        if(controller.modoEditar && !ParecerFaixaDominioDocumento.Nome && !ParecerFaixaDominioDocumento.Arquivo) {
            model.ParecerFaixaDominioDocumentoNome = ParecerFaixaDominioDocumentoNome;
            model.ParecerFaixaDominioDocumentoArquivo = null;
        } else {
            model.ParecerFaixaDominioDocumentoNome = ParecerFaixaDominioDocumento.Nome;
            model.ParecerFaixaDominioDocumentoArquivo = ParecerFaixaDominioDocumento.Arquivo;
        }
        // model.ParecerFaixaDominioDocumentoNome = ParecerFaixaDominioDocumento.Nome;
        // model.ParecerFaixaDominioDocumentoArquivo = ParecerFaixaDominioDocumento.Arquivo;
        return model;
    }
};
export default ParecerModel;