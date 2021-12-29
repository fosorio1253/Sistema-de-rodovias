var lado_model = { 
    LadoId: "", 
    Nome: "" ,
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate: function(){
        var model = lado_model.new();
        model.LadoId = $("#LadoId").val();
        model.Nome = $("#LadoId option:selected").text();
        return model;
    }
};
export default lado_model;