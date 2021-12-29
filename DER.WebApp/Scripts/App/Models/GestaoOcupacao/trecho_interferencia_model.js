import ValidateHelper from './../../Helpers/validate/ValidateHelper';
import trecho_interferencia_tipo_model from './trecho_interferencia_tipo_model';

let trecho_interferencia_model = {
    interferencia_tipo_id:"",
    interferencia_tipo:trecho_interferencia_tipo_model.new(),
    volume_unitario:"",
    quantidade:"",
    volume_total:"",
    new:function(){
        return Object.assign({}, this);
    },
    validate:function(){
        return ValidateHelper.validarCampos(["#TrechoInterferencia_TipoInterferencia", "#TrechoInterferencia_volume_unitario", 
                                             "#TrechoInterferencia_quantidade", "#TrechoInterferencia_volume_total"]);
    },
    getPopulate:function(){
        var model = trecho_interferencia_model.new();
        model.interferencia_tipo  = trecho_interferencia_tipo_model.getPopulate();
        model.interferencia_tipo_id = model.interferencia_tipo.interferencia_tipo_id;
        model.volume_unitario  = parseFloat($("#TrechoInterferencia_volume_unitario").val());
        model.quantidade  = parseFloat($("#TrechoInterferencia_quantidade").val());
        model.volume_total  = parseFloat($("#TrechoInterferencia_volume_total").val());
        return model;
    }
}
export default trecho_interferencia_model;