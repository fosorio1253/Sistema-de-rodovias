let TipoImplantacaoModel = { 
    TipoImplantacaoId: "", 
    Nome: "",
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate: function(){
        // var model = this.new();
        var model = Object.assign({}, this);
        model.TipoImplantacaoId = $("#TipoImplantacaoId").val();
        model.Nome = $("#TipoImplantacaoId option:selected").text();
        return model;
    }
};
export default TipoImplantacaoModel;