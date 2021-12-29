import DocumentosComponent from "../../Components/Documentos/DocumentosComponent";
import UploadHelper from "../../Helpers/upload/UploadHelper";
import ValidateHelper from "../../Helpers/validate/ValidateHelper";
import GestaoInteressadoModel from "../../Models/GestaoInteressado/GestaoInteressadoModel";

function GestaoInteressadoController(gestaoInteressadoModel, dataExtra){
    this.model = gestaoInteressadoModel;
    this.dataExtra = dataExtra;
    this.documentosComponent = new DocumentosComponent(this.model.Documentos, this.dataExtra.AdicionadoPor, this.dataExtra.DataAdicionado);    

    this.init = (function () {
        window.onload = this.start;
    }).bind(this);

    this.start = (function () {
        UploadHelper.addlistenerChangeInputFileAndApplyLock();
        this.documentosComponent.ConstruirListaDocumentos();
    }).bind(this);

    this.DownloadArquivo = (function(arquivo) {
        var link = document.createElement("a");
        link.href = "/GestaoInteressados/DownloadArquivo?caminhoArquivo="+arquivo;
        link.click();
    }).bind(this);

    this.validarEndereco = function(){
        return ValidateHelper.validarCampos(["#Endereco_Unidade", 
                                             "#Endereco_Logradouro", 
                                             "#Endereco_CEP",
                                             "#Endereco_Numero",
                                             "#Endereco_Complemento",
                                             "#Endereco_Bairro",
                                             "#Endereco_MunicipioId",
                                             "#Endereco_EstadoId",
                                             "#Endereco_NomeContato"]);
    }

    this.toString = function(){
        return 'GestaoInteressadoController';
    }
}

var dataExtra = {
    AdicionadoPor,
    DataAdicionado
}
var gestaoInteressadoController = new GestaoInteressadoController(GestaoInteressadoModel.newInit(ListaDocumentos), dataExtra);
gestaoInteressadoController.init();
window.controller = gestaoInteressadoController;