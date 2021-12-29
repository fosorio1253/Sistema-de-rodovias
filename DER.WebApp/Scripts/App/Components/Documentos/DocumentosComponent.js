import DocumentoModel from '../../Models/Documento/DocumentoModel';
import ValidateHelper from '../../Helpers/validate/ValidateHelper';

function DocumentosComponent(documentos, AdicionadoPor, DataAdicionado) {
    
    this.documentos = documentos;
    this.AdicionadoPor = AdicionadoPor;
    this.DataAdicionado = DataAdicionado;

    this.documentos.forEach(documento=>{
        documento.ArquivoNome = documento.Arquivo;
        documento.Arquivo = null;
    });

    this.init = (function() {
        $(DocumentoModel.getTipoDocumentoIdDom()).prepend(new Option("Selecione"));
        $(DocumentoModel.getTipoDocumentoIdDom()).val('Selecione').change();        
    }).bind(this);

    this.ModalDocumento = (function() {
        $("#modalDocumento").modal('show');
        // let id = $("#NaturezaJuridicaId").val();
    
        // $.ajax({
        //     url: '/GestaoOcupacoes/RetornaNaturezaJuridica',
        //     processData: true,
        //     data: { id: id },
        //     type: 'POST',
        //     dataType: 'json',
        //     success: function (response) {
        //         $(DocumentoModel.getTipoDocumentoIdDom()).html("");
        //         $(DocumentoModel.getTipoDocumentoIdDom()).append(new Option("Selecione"));
        //         response.lista.forEach(function (item, i) {
        //             $(DocumentoModel.getTipoDocumentoIdDom()).append(new Option(item.Nome, item.TipoDeDocumentoId));
        //         });
        //         $("#modalDocumento").modal('show');
        //     },
        //     error: function (response) {
        //         console.log(response);
        //     }
        // })
    }).bind(this);

    this.AdicionarDocumento = (async function () {
       
        const tipoDocumentoId = DocumentoModel.getTipoDocumentoIdDom();

        if (!ValidateHelper.validarCampos([tipoDocumentoId, "#DocumentoUpload"]) ) return;

        
        var documento =  null;
        await DocumentoModel.getPopulate(this.AdicionadoPor, this.DataAdicionado).then(function(documentoModel){
            documentoModel.Novo = true;
            documento = documentoModel;
        });
        this.documentos.push(documento);
    
        $(tipoDocumentoId).val('');
        $("#DocumentoUpload").val('');

        $.ajax({
            type: "POST",
            url: "/GestaoOcupacoes/SalvarArquivo",
            processData: false,
            data: {
                viewModel: documento
            },
            cache: false,
            dataType: "json",
            success: function (data) { }
        });
    
        $("#modalDocumento").modal('hide');
        this.ConstruirListaDocumentos();
    }).bind(this);

    this.ExcluirDocumento = (function (linhaExclusao) {
        this.documentos.splice(linhaExclusao, 1);    
        this.ConstruirListaDocumentos();
    }).bind(this);

    this.ConstruirListaDocumentos = (function() {
        $("#bodyDocumentos").empty();
        
        var newContent = "";
        
        this.documentos.forEach((documento, i) => {
            newContent += "<tr>";
            newContent += "<td class='leftText hide'><span id='id" + i + "' value='" + documento.Id + "'>" + documento.Id + "</span></td>";
            newContent += "<td class='leftText'><span id='documento" + i + "' value='" + documento.Documento + "'>" + documento.Documento + "</span></td>";
            newContent += "<td class='leftText'><span id='arquivo" + i + "' value='" + documento.ArquivoNome + "'>" + documento.ArquivoNome + "</span></td>";
            newContent += "<td class='leftText'><span id='adicionadoPor" + i + "' value='" + documento.AdicionadoPor + "'>" + documento.AdicionadoPor + "</span></td>";
            newContent += "<td class='leftText hide'><span id='tipoDocumentoId" + i + "' value='" + documento.TipoDocumentoId + "'>" + documento.TipoDocumentoId + "</span></td>";
            newContent += "<td><button type='button' onclick='controller.documentosComponent.ExcluirDocumento(" + i + ");' class='btn btn-link' id='excluirDocumento'><i class='fa fa-trash' title='Excluir'></i></button>";
            newContent += "<button type='button' onclick='controller.DownloadArquivo(" + '"'+ documento.ArquivoNome + '"'+");' class='btn btn-link DownloadArquivoId' style='" + (documento.Novo?"display:none;":"") + "'><i class='fa fa-download' title='Baixar Arquivo'></i></button></td>";
            newContent += "</tr>";
        });
        
        $("#bodyDocumentos").append(newContent);
        //if(!controller.modoEditar) $(".DownloadArquivoId").hide();
    }).bind(this);

    return this;
}
export default DocumentosComponent;