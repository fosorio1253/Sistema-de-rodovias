var trecho_interferencia_tipo_model = { 
    interferencia_tipo_id: "", 
    nome: "" ,
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate: function(){
        var model = trecho_interferencia_tipo_model.new();
        model.interferencia_tipo_id = $("#TrechoInterferencia_TipoInterferencia").val();
        model.nome = $("#TrechoInterferencia_TipoInterferencia option:selected").text();
        return model;
    }
};
export default trecho_interferencia_tipo_model;