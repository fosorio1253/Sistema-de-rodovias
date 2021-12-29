var GestaoInteressadoModel = {
    Documentos: [],
    new:function(){
        return Object.assign({}, this);
    },
    newInit:function(ListaDocumentos){
        var model = GestaoInteressadoModel.new();
        model.Documentos = ListaDocumentos;
        return model;        
    },
    getPopulate:function(){
        var model = GestaoInteressadoModel.new();
        var controller = window.controller;

        model.Documentos = controller.documentosComponent.documentos;

        return model;
    },
    getData:function(){
        var model = GestaoInteressadoModel.getPopulate();
        return JSON.parse(JSON.stringify(model));
    }
};
export default GestaoInteressadoModel;