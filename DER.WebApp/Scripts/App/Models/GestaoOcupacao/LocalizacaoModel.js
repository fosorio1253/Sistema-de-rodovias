var LocalizacaoModel = { 
    LocalizacaoId: "", 
    Nome: "" ,
    new:function(){
        return Object.assign({}, this);
    },
    getPopulate: function(){
        // var model = this.new();
        var model = Object.assign({}, this);
        model.LocalizacaoId = $("input[name='resumotrechorbt']:checked").val();
        model.Nome = $("input[name='resumotrechorbt']:checked").val();
        return model;
    }
};
export default LocalizacaoModel;