var OcorrenciaModel = {
    DataOcorrencia: "",
    Autor: "",
    Ocorrencia: "",
    Area: "",
    AreaId: "",
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate: function(DataOcorrencia, Autor){
        // var model = this.new();
        var model = Object.assign({}, this);
        
        model.DataOcorrencia = DataOcorrencia;
        model.Autor = Autor;
        model.Ocorrencia = $("#Ocorrencia").val();
        model.Area = $("#AreaId option:selected").text();
        model.AreaId = $("#AreaId").val();      
        return model;
    }
}
export default OcorrenciaModel;