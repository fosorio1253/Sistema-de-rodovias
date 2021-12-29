var TipoPassagemModel = {
    TipoPassagemId: "", 
    Nome:"",
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate: function(){
        // var model = this.new();
        var model = Object.assign({}, this);
        model.TipoPassagemId = $("#TipoPassagemId").val();
        model.Nome = $("#TipoPassagemId option:selected").text();
        return model;
    }
};
export default TipoPassagemModel;