import InteressadoModel from '../../Models/Interessado/InteressadoModel';

function BuscarInteressadosComponent(InteressadoId, onUpdate){
    this.interessados = [];
    this.interessadoSelecionado = InteressadoId ? {IdInteressado:InteressadoId} : null;

    var _this = this;

    this.init = function(){
        $("#NaturezaJuridicaId").change(function () {
            $("#Documento").unmask();
            let idNatureza = $("#NaturezaJuridicaId").val();
    
            if (idNatureza == 32) {
                $("#Documento").prop("disabled", false)
                $("#Documento").mask("99.999.999/9999-99");
            } else if (idNatureza == 33) {
                $("#Documento").prop("disabled", false)
                $("#Documento").mask("999.999.999-99");
            } else {
                $("#Documento").prop("disabled", true)
                $("#Documento").unmask();
            }
        });
    }
    this.ModalBuscarInteressado = (function() {
        $("#modalBuscarInteressado").modal('show');
        $("#bodyConsultaContatos").empty();
        $("#bodyAdicionaContatos").empty();
    }).bind(this);
    this.RemoverInteressado = (function(linhaRemocao) {
        $("#bodyAdicionaContatos").empty();
        this.interessadoSelecionado = null;
    }).bind(this);
    this.PesquisarInteressado = (function() {
        $.ajax({
            type: "POST",
            url: '/GestaoOcupacoes/ConsultarInteressado',
            data: { viewModel: InteressadoModel.getPopulate() },
            cache: false,
            dataType: "json",
            success: function (data) {
                _this.interessados = data;
                _this.InteressadosCallBack(data);
            }
        });
    }).bind(this);
    this.InteressadosCallBack = (function(data) {
        $("#bodyConsultaContatos").empty();
        var newContent = "";
        var linha = 1;
    
        $(data).each(function () {
            newContent = newContent + "<tr>";
            newContent = newContent + "<td class='leftText'><span id='consinteressadoId" + linha + "' value='" + this.Interessado + "'>" + this.Interessado + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='constipointeressadoId" + linha + "' value='" + this.Tipo + "'>" + this.Tipo + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='natureza" + linha + "' value='" + this.Natureza + "'>" + this.Natureza + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='conscpfcnpj" + linha + "' value='" + this.Documento + "'>" + this.Documento + "</span></td>";
            newContent = newContent + "<td><button type='button' onclick='controller.buscarInteressadosComponent.IncluirInteressado(" + linha + ");' class='btn btn-link'  title='Adicionar Contato' id='btnIncluirInteressado'><i class='fa fa-user-plus'></i></button></td>"
            linha++;
        });
    
        $("#bodyConsultaContatos").append(newContent);
    }).bind(this);
    this.IncluirInteressado = (function(index) {
        $("#bodyAdicionaContatos").empty();
    
        this.interessadoSelecionado = Object.assign({}, this.interessados[index - 1]);
        var data = [this.interessadoSelecionado];
        var newContentAdd = "";
        var linha = 1;
        $(data).each(function () {
            newContentAdd = newContentAdd + "<tr>";
            newContentAdd = newContentAdd + "<td class='leftText'><span id='addinteressado" + linha + "' value='" + this.Interessado + "'>" + this.Interessado + "</span></td>";
            newContentAdd = newContentAdd + "<td class='leftText'><span id='addtipo" + linha + "' value='" + this.Tipo + "'>" + this.Tipo + "</span></td>";
            newContentAdd = newContentAdd + "<td class='leftText'><span id='addnatureza" + linha + "' value='" + this.Natureza + "'>" + this.Natureza + "</span></td>";
            newContentAdd = newContentAdd + "<td class='leftText'><span id='adddocumento" + linha + "' value='" + this.Documento + "'>" + this.Documento + "</span></td>";
            newContentAdd = newContentAdd + "<td><button type='button' onclick='controller.buscarInteressadosComponent.RemoverInteressado(" + linha + ");' class='btn btn-link'  title='Remover Contato' id='btnRemoverInteressado'><i class='fa fa-user-times'></i></button></td>"
            linha++;
        });
    
        $("#bodyAdicionaContatos").append(newContentAdd);
    }).bind(this);
    this.SalvarInteressado = (function() {
        if (!this.interessadoSelecionado) {
            swal({
                type: 'error',
                title: 'Formulário Inválido',
                text: 'Busque e selecione 1 interessado!'
            });
            return;
        }
    
        $("#Interessado").val(this.interessadoSelecionado.Interessado);
        $("#Interessado").valid();
        
        if(onUpdate) onUpdate(this.interessadoSelecionado);
    
        $("#modalBuscarInteressado").modal('hide');
    }).bind(this);

    return this;
}
export default BuscarInteressadosComponent;