var TipoOcupacaoModel = {
    TipoOcupacaoId: "", 
    Nome:"",
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate: function(){
        // var model = this.new();
        var model = Object.assign({}, this);
        model.TipoOcupacaoId = $("#TipoOcupacaoId").val();
        model.Nome = $("#TipoOcupacaoId option:selected").text();
        return model;
    }
};
export default TipoOcupacaoModel;