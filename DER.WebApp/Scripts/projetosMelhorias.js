
function Excluir(id) {
        swal({
        title: 'Exclusão',
        text: "Deseja realmente excluir?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Não',
        confirmButtonText: 'Sim'        
    }).then((result) => {        
        if (result.value) {            
            var response = POST("/ProjetosMelhorias/Excluir", JSON.stringify({ id: id }));            
            if (response.status == true) {
                swal({
                    type: 'success',
                    title: 'Sucesso',
                    text: 'Excluído com sucesso!'
                }).then((result) => {
                    if (result.value) {
                        $('[data-id=' + id + ']').remove()
                    }
                })

            }
        }
    });

}




//function Prazo(prazo) {    
//    $("#prazo").mask("9999");    
//};


//function validarData(campo) {

//    if (campo.value.length >= 10 && !/(0[1-9]|1[0-2])[/](1[9]{1}|2[0-9])([0-9]{2})/.test(campo.value)) {

//        $(campo.id).text("Digite uma data válida!");

//        $('#' + campo.id).val('');
//    }
//    else {

//        $(campo.id).text("");
//    }
//};



//function validarData(id) {
    
//        var RegExPattern = /^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])      [\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$/;

//        if (!((id.value.match(RegExPattern)) && (id.value != ''))) {
//            alert('Data inválida.');
//            id.focus();
//        }
//        else
//            alert('Data válida.');
//}



