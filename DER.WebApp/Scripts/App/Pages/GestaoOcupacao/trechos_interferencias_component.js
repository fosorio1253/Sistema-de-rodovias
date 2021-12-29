import trecho_interferencia_model from './../../Models/GestaoOcupacao/trecho_interferencia_model';

function trechos_interferencias_component(trecho_interferencias) {
    this.trecho_interferencias = trecho_interferencias;

    this.init = (function() {
        $("#TrechoInterferencia_volume_total").attr("disabled", true);
        $("#TrechoInterferencia_volume_unitario").mask("##9.999", {reverse: true});
        $("#TrechoInterferencia_quantidade").mask("##9.999", {reverse: true});
        $("#TrechoInterferencia_volume_total").mask("#####9.999", {reverse: true});
        $("#TrechoInterferencia_volume_unitario").blur(this.volumeTotalCalculo);
        $("#TrechoInterferencia_volume_unitario").keyup(this.volumeTotalCalculo);
        $("#TrechoInterferencia_quantidade").blur(this.volumeTotalCalculo);
        $("#TrechoInterferencia_quantidade").keyup(this.volumeTotalCalculo);
    }).bind(this); 
    this.clear = (function() {
        this.trecho_interferencias = [];
        this.clearFields();
        this.ConstruirLista();
    }).bind(this); 
    this.set_trecho_interferencias = (function(trecho_interferencias) {
        this.trecho_interferencias = trecho_interferencias;
        this.clearFields();
        this.ConstruirLista();
    }).bind(this); 
    this.volumeTotalCalculo = (function() {
        var volume = parseFloat($("#TrechoInterferencia_volume_unitario").val().replace(",", "."));
        var quantidade = parseFloat($("#TrechoInterferencia_quantidade").val().replace(",", "."));
        volume = isNaN(volume) ? 0 : volume; 
        quantidade = isNaN(quantidade) ? 0 : quantidade; 
        var volumeTotal = volume * quantidade;
        volumeTotal = !volumeTotal ? "" : volumeTotal;

        var totalRemove = 0;
        var volumeTotalStr = volumeTotal.toString();
        var volumeTotalFormatado = volumeTotalStr;
        if (volumeTotalStr.indexOf(".") >= 0) {
            var len = volumeTotalStr.split(".")[1].length;
            var size = 3;
            if (len >= 4) {
                totalRemove = size - len;
                volumeTotalFormatado = volumeTotalStr.slice(0, totalRemove);
            }
        }
        $("#TrechoInterferencia_volume_total").val(volumeTotalFormatado);
    }).bind(this);
    this.volumesTotaisCalculo = (function() {
        var interferenciasGroups = Object.values(groupBy(this.trecho_interferencias, "interferencia_tipo_id"));
        var newContent = "";
        
        interferenciasGroups.forEach(function(group){
            var total = group.length <= 1 ?
                        group.length == 0 ? 0 : group[0].volume_total :
                        group.reduce((a, b) => a + b.volume_total, 0);
            //refatorar nome, corrigir no back
            var tipo = "";
            if(!group[0].interferencia_tipo && group[0].interferencia_tipo_id){
                tipo = $("#TrechoInterferencia_TipoInterferencia option[value="+group[0].interferencia_tipo_id+"]").text()
            } else if (group[0].interferencia_tipo) {
                tipo = group[0].interferencia_tipo.nome;
            }

            newContent += "<tr>"
            newContent += "    <td id='resumoIdTipodeInterferencia'>"+tipo+"</td>"
            newContent += "    <td id='resumoIdQtdInterferencia'>"+group.length+"</td>"
            newContent += "    <td id='resumoIdVolumeTotal'>"+total+"</td>"
            newContent += "</tr>"
        });

        $("#bodyInterferenciaTrechoTotais").empty();
        $("#bodyInterferenciaTrechoTotais").append(newContent);
    }).bind(this); 
    function groupBy(objectArray, property) {
        return objectArray.reduce(function (acc, obj) {
            var key = obj[property];
            if (!acc[key]) {
            acc[key] = [];
            }
            acc[key].push(obj);
            return acc;
        }, {});
    }
    this.cad_trecho_interferencias = (function() {
        if (!trecho_interferencia_model.validate()) return;
    
        this.trecho_interferencias.push(trecho_interferencia_model.getPopulate());

        // this.clearFields();    
        this.ConstruirLista();
    }).bind(this); 
    this.clearFields = (function(){
        $("#TrechoInterferencia_TipoInterferencia").val("").change();
        $("#TrechoInterferencia_volume_unitario").val("");
        $("#TrechoInterferencia_quantidade").val("");
        $("#TrechoInterferencia_volume_total").val("");
    }).bind(this);
    this.disabled = (function(value){
        $("#TrechoInterferencia_TipoInterferencia").attr("disabled", value);
        $("#TrechoInterferencia_volume_unitario").attr("disabled", value);
        $("#TrechoInterferencia_quantidade").attr("disabled", value);
        $("#TrechoInterferencia_volume_total").attr("disabled", value);
        $("#btn_cad_trecho_interferencia").attr("disabled", value);
        $(".excluirTrechoInterferencia").attr("disabled", value);
    }).bind(this);
    this.exc_trecho_interferencia = (function(linhaExclusao) {
        this.trecho_interferencias.splice(linhaExclusao, 1);
        this.ConstruirLista();
    }).bind(this);
    this.ConstruirLista = (function() {
        $("#bodyTrechoInterferencia").empty();
    
        var newContent = "";
        this.trecho_interferencias.forEach((trecho_interferencia, i) => {
            //refatorar nome, corrigir no back
            var nome = "";
            if(!trecho_interferencia.interferencia_tipo && trecho_interferencia.interferencia_tipo_id){
                nome = $("#TrechoInterferencia_TipoInterferencia option[value="+trecho_interferencia.interferencia_tipo_id+"]").text()
            } else if (trecho_interferencia.interferencia_tipo) {
                nome = trecho_interferencia.interferencia_tipo.nome;
            }
            newContent = newContent + "<tr>";
            newContent = newContent + "   <td class='leftText'><span id='TipoInterferencia" + i + "'>"+ nome +"</span></td>";
            newContent = newContent + "   <td class='leftText'><span id='Volume" + i + "'>"+ trecho_interferencia.volume_unitario +"</span></td>";
            newContent = newContent + "   <td class='leftText'><span id='Quantidade" + i + "'>"+ trecho_interferencia.quantidade +"</span></td>";
            newContent = newContent + "   <td class='leftText'><span id='VolumeTotal" + i + "'>"+ trecho_interferencia.volume_total +"</span></td>";
            newContent = newContent + "   <td>";
            newContent = newContent + "       <button type='button' onclick='controller.trechosComponent.exc_trecho_interferencia(" + i + ");' class='btn btn-link excluirTrechoInterferencia'><i class='fa fa-trash' title='Excluir'></i></button>";
            newContent = newContent + "   </td>";
            newContent = newContent + "</tr>";
        });
    
        $("#bodyTrechoInterferencia").append(newContent);
        this.volumesTotaisCalculo();
    }).bind(this);

    return this;
}
export default trechos_interferencias_component;