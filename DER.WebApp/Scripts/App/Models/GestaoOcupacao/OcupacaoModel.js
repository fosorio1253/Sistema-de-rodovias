var OcupacaoModel = {
    Assunto: "",
    Observacao: "",
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate: function(controller){
        // var model = this.new();
        var model = Object.assign({}, this);
        model.Assunto = $("#Assunto").val();
        model.Observacao = $("#Observacao").val();
        return model;
    }
};
export default OcupacaoModel;