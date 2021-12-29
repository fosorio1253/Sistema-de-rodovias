var RodoviaModel = { 
    RodoviaId: "", 
    Nome: "" ,
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate: function(){
        var model = RodoviaModel.new();
        model.RodoviaId = $("#RodoviaId").val();
        model.Nome = $("#RodoviaId option:selected").text();
        return model;
    }
};
export default RodoviaModel;