import UploadHelper from '../../Helpers/upload/UploadHelper';

var DocumentoModel = {
    Id:"",
    Documento:"",
    TipoDocumentoId:"",
    Arquivo:"",
    AdicionadoPor:"",
    DataAdicionado:"",
    Novo:false,
    new:function(){
        return Object.assign({}, this);
    },
    getTipoDocumentoIdDom:function(){
        return controller.toString()=='GestaoOcupacaoController' ? '#TipoDeDocumentoOcupacaoId' : '#TipoDeDocumentoId';
    },
    getPopulate: async function (AdicionadoPor, DataAdicionado) {
        
        var model = DocumentoModel.new();
        const Arquivo = await UploadHelper.getFileAndName("#DocumentoUpload");
        
        model.Documento = $(DocumentoModel.getTipoDocumentoIdDom()+" option:selected").text();
        model.TipoDocumentoId = $(DocumentoModel.getTipoDocumentoIdDom()).val();
        model.ArquivoNome = Arquivo.Nome;
        model.Arquivo = Arquivo.Arquivo;
        model.AdicionadoPor = AdicionadoPor;
        model.DataAdicionado = DataAdicionado;
        return model;
    }
};
export default DocumentoModel;