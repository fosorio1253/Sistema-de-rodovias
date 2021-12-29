var GestaoOcupacaoService = {
    save:function(data){
        return $.ajax({
            url: '/GestaoOcupacoes/Salvar',
            processData: true,
            data: data,
            type: 'POST',
            dataType: 'json'
        });
    },
    ValidacaoTrechoProjetoMelhoria:function(data){
        return $.ajax({
            url: '/GestaoOcupacoes/ValidacaoTrechoProjetoMelhoria',
            processData: true,
            data: data,
            type: 'POST',
            dataType: 'json'
        });
    },
};
export default GestaoOcupacaoService;