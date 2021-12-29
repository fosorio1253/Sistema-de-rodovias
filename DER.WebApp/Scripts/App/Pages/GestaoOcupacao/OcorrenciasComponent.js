import OcorrenciaModel from '../../Models/GestaoOcupacao/OcorrenciaModel';
import ValidateHelper from '../../Helpers/validate/ValidateHelper';

function OcorrenciasComponent(ocorrencias, DataOcorrencia, Autor) {
    this.ocorrencias = ocorrencias;
    this.ocorrenciaAtual = null;
    this.DataOcorrencia = DataOcorrencia;
    this.Autor = Autor;

    this.AdicionarOcorrencia = (function() {
        if (!ValidateHelper.validarCampos(["#Ocorrencia", "#AreaId"])) return;
    
        this.ocorrencias.push(OcorrenciaModel.getPopulate(this.DataOcorrencia, this.Autor));
    
        $("#Ocorrencia").val('');
    
        this.ConstruirListaOcorrencia();
    
        $("#AreaId").val("");
        $("#modalOcorrencia").modal("hide");
    }).bind(this);
    this.VisualizarOcorrencia = (function(index) {
        this.ModalOcorrenciaVisualizar();
        const ocorrencia = this.ocorrencias[index-1];
        if (ocorrencia) {
            setTimeout(()=>{
                $("#AreaId").val(ocorrencia.AreaId).change();
                $("#Ocorrencia").val(ocorrencia.Ocorrencia);
            }, 0);
        }
        
    }).bind(this);
    this.ModalOcorrenciaShowAddOuEditar = (function(showAdd) {
        if (showAdd) {
            $("#btnAdicionarOcorrencia").show();
            $("#btnAlterarOcorrencia").hide();
        } else {
            $("#btnAdicionarOcorrencia").hide();
            $("#btnAlterarOcorrencia").show();
        }
        $("#AreaId").removeAttr('disabled');
        $("#Ocorrencia").removeAttr('disabled');
    }).bind(this);
    this.ModalOcorrenciaAdd = (function() {
        $("#AreaId").val("").change();
        $("#Ocorrencia").val("");
        this.ModalOcorrenciaShowAddOuEditar(true);
        $("#modalOcorrencia").modal('show');
    }).bind(this);
    this.ModalOcorrenciaEditar = (function() {
        this.ModalOcorrenciaShowAddOuEditar(false);
        $("#modalOcorrencia").modal('show');
    }).bind(this);
    this.ModalOcorrenciaVisualizar = (function() {
        $("#btnAdicionarOcorrencia").hide();
        $("#btnAlterarOcorrencia").hide();
        $("#AreaId").attr('disabled', true);
        $("#Ocorrencia").attr('disabled', true);
        $("#modalOcorrencia").modal('show');
    }).bind(this);
    this.EditarOcorrencia = (function(index) {
        const ocorrencia = this.ocorrencias[index-1];
        this.ModalOcorrenciaEditar();
        if (ocorrencia) {
            this.ocorrenciaAtual = ocorrencia;
            setTimeout(function(){
                $("#AreaId").val(ocorrencia.AreaId).change();
                $("#Ocorrencia").val(ocorrencia.Ocorrencia);
            }, 0);
        }        
    }).bind(this);
    this.EditarOcorrenciaSalvar = (function() {
        let ocorrencia = $("#Ocorrencia").val();
        let area = $("#AreaId option:selected").text();
        let areaId = $("#AreaId").val();
    
        this.ocorrenciaAtual.Ocorrencia = ocorrencia;
        this.ocorrenciaAtual.Area = area;
        this.ocorrenciaAtual.AreaId = areaId;
    
        this.ConstruirListaOcorrencia();
        $("#modalOcorrencia").modal('hide');
    }).bind(this);
    this.ExcluirOcorrencia = (function(linhaExclusao) {
        this.ocorrencias.splice(linhaExclusao, 1);
        this.ConstruirListaOcorrencia();
    }).bind(this);
    this.ConstruirListaOcorrencia = (function() {
        $("#bodyOcorrencia").empty();
    
        var newContent = "";
        ocorrencias.forEach((ocorrencia, i) => {
            i = i+1;
            newContent = newContent + "<tr>";
            newContent = newContent + "<td class='leftText'><span id='dataOcorrencia" + i + "' value='" + ocorrencia.DataOcorrencia + "'>" + ocorrencia.DataOcorrencia + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='autor" + i + "' value='" + ocorrencia.Autor + "'>" + ocorrencia.Autor + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='ocorrencia" + i + "' value='" + ocorrencia.Ocorrencia + "'>" + ocorrencia.Ocorrencia + "</span></td>";
            newContent = newContent + "<td class='leftText'><span id='area" + i + "' value='" + ocorrencia.AreaId + "'>" + ocorrencia.Area + "</span></td>";
            newContent = newContent + "<td><button type='button' onclick='controller.ocorrenciasComponent.VisualizarOcorrencia(" + i + ");' class='btn btn-link'><i class='fa fa-search' title='Visualizar'></i></button>";
            newContent = newContent + "<button type='button' onclick='controller.ocorrenciasComponent.EditarOcorrencia(" + i + ");' class='btn btn-link'><i class='fa fa-pencil' title='Editar'></i></button>";
            newContent = newContent + "<button type='button' onclick='controller.ocorrenciasComponent.ExcluirOcorrencia(" + i + ");' class='btn btn-link' id='excluirOcorrencia'><i class='fa fa-trash' title='Excluir'></i></button></td>"
            newContent = newContent + "</tr>";
        });
    
        $("#bodyOcorrencia").append(newContent);
    }).bind(this);

    return this;
}
export default OcorrenciasComponent;