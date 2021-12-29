var InteressadoModel = {
    Interessado: "",
    IdMunicipio: "",
    Documento: "",
    IdEstado: "",
    IdTipo: "",
    IdNatureza: "",
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate: function(){
        // var model = this.new();
        var model = Object.assign({}, this);
        model.Interessado = $("#InteressadoBuscar").val();
        model.IdMunicipio = $("#MunicipioId").val();
        model.Documento = $("#CpfCNPJ").val();
        model.IdEstado = $("#EstadoId").val();
        model.IdTipo = $("#TipoInteressadoId").val();
        model.IdNatureza = $("#NaturezaJuridicaId").val();
        return model;
    }
}
export default InteressadoModel;