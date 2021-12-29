



function NovaLinha(tabela) {
    geraForm(tabela, null)
}

function Salvar() {
    var errospan = false;
    var Valores = [];




    $('.form-body [data-input]').each((i, e) => {

        
        var valor = {};
        valor.id = $(e).attr("name");
        valor.valor = $(e).val();
        valor.linha = $('#hdnLinha').val();
        valor.colunaId = $(e).attr('data-coluna');


        if (valor.colunaId == 11 && valor.valor.length < 7) {
            $("#spanerro" + valor.colunaId).text("Data inválida!");
            errospan = true;
        } 
        else if (valor.valor != null && valor.valor != undefined && valor.valor != " " && valor.valor != "") {
            Valores.push(valor);
            $("#spanerro" + valor.colunaId).text("");
        }
        else {
            $("#spanerro" + valor.colunaId).text("Campo Obrigatório!");
            errospan = true;
        }
        
    });

    if (errospan) {
        return;
    }

    data = {};
    data.Valores = Valores;
    data.TabelaId = $('#hdnTabela').val()
    var response = POST('/DadosMestres/Salvar', JSON.stringify(data))

    if (response.status == true) {
        swal({
            type: 'success',
            title: 'Sucesso',
            text: 'Dado salvo com sucesso!'
        }).then((result) => {
            if (result.value) {
                window.location.reload()
            }
        })
    }
}

function Editar(tabela, linha) {

    console.log({ tabela: tabela, linha: linha })
    geraForm(tabela, linha);
}

function geraForm(tabela, linha) {
    var json = JSON.parse("[" + $('#hdnColunas').val() + "]");
    inputs = [];
    $('.form-body').html("");
    $('.form-body').append($('<input/>', { type: 'hidden', value: tabela, id: 'hdnTabela' }));
    $('.form-body').append($('<input/>', { type: 'hidden', value: linha, id: 'hdnLinha' }));
    json.forEach((e, i) => {


        var valor = $($('[data-linha=' + linha + ']')[i])
        var div = "";
        if (e.tipodadocoluna == 1) {
            div =
                $('<div>', { class: "form-group row" }).append(
                    $('<label>', { class: 'col-sm-4 col-form-label', html: e.nome }),
                    $('<div>', { class: 'col-sm-8' }).append(
                        $('<input>', { required: 'true', name: (valor != null ? valor.attr('data-id') : ""), 'data-coluna': e.id, class: 'form-control', 'data-input': '', value: (valor != null ? valor.html() : ""), maxlength: 100 }),
                        $('<span>', { id: 'spanerro' + e.id, style: "color:red" })
                    )
                );
        }
        if (e.tipodadocoluna == 2) {
            div =
                $('<div>', { class: "form-group row" }).append(
                    $('<label>', { class: 'col-sm-4 col-form-label', html: e.nome }),
                    $('<div>', { class: 'col-sm-8' }).append(
                        $('<input>', { required: 'true', onkeyup: 'moeda(this)', name: (valor != null ? valor.attr('data-id') : ""), 'data-coluna': e.id, class: 'form-control', 'data-input': '', value: (valor != null ? valor.html() : ""), maxlength: 14 }),
                        $('<span>', { id: 'spanerro' + e.id, style: "color:red" })
                    )
                );
        }
        //if (e.tipodadocoluna == 3) {
        //    div =
        //        $('<div>', { class: "form-group row" }).append(
        //            $('<label>', { class: 'col-sm-4 col-form-label', html: e.nome }),
        //            $('<div>', { class: 'col-sm-8' }).append(
        //                $('<input>', { required: 'true', id: e.id, onkeyup: 'dataMesAno(this, event)', onkeypress: 'return enumero(event)', 'placeholder': 'MM/AAAA', name: (valor != null ? valor.attr('data-id') : ""), 'data-coluna': e.id, class: 'form-control', 'data-input': '', value: (valor != null ? valor.html() : ""), maxlength: 7 }),
        //                $('<span>', { id: 'spanerro' + e.id, style: "color:red" })
        //            )
        //        );
        //}
        if (e.tipodadocoluna == 3) {
            div =
                $('<div>', { class: "form-group row" }).append(
                    $('<label>', { class: 'col-sm-4 col-form-label', html: e.nome }),
                    $('<div>', { class: 'col-sm-8' }).append(
                        $('<input>', { required: 'true', id: e.id, onkeyup: "validarData(this);", 'placeholder': 'MM/AAAA', name: (valor != null ? valor.attr('data-id') : ""), 'data-coluna': e.id, class: 'form-control', 'data-input': '', value: (valor != null ? valor.html() : "") }),
                        $('<span>', { id: 'spanerro' + e.id, style: "color:red" })
                    )
                );
        }
        //onkeyup: 'formata_data(this)',

        $('.form-body').append(div)
    });

    $('#11').mask('00/0000', { 'translation': { 0: { pattern: /[0-9]/ } } })
    $('#modalFormulario').modal();
}

function validarData(campo) {

    if (campo.value.length >= 7 && !/(0[1-9]|1[0-2])[/](1[9]{1}|2[0-9])([0-9]{2})/.test(campo.value)) {

        $("#spanerro" + campo.id).text("Digite uma data válida!");

        $('#' + campo.id).val('');
    }
    else {

        $("#spanerro" + campo.id).text("");
    }
};

//Chamar essa função na tag input: onkeyup=“moeda(this);”
function moeda(z) {
    v = z.value;
    v = v.replace(/\D/g, "") // permite digitar apenas numero
    v = v.replace(/(\d{1})(\d{14})$/, "$1.$2") // coloca ponto antes dos ultimos digitos
    v = v.replace(/(\d{1})(\d{11})$/, "$1.$2") // coloca ponto antes dos ultimos 11 digitos
    v = v.replace(/(\d{1})(\d{8})$/, "$1.$2") // coloca ponto antes dos ultimos 8 digitos
    v = v.replace(/(\d{1})(\d{5})$/, "$1.$2") // coloca ponto antes dos ultimos 5 digitos
    v = v.replace(/(\d{1})(\d{1,2})$/, "$1,$2") // coloca virgula antes dos ultimos 2 digitos
    z.value = v;
}


function Excluir(id) {

    swal({
        title: 'Exclusão',
        text: "Deseja realmente excluir o dado?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Não',
        confirmButtonText: 'Sim'
    }).then((result) => {
        if (result.value) {
            var response = POST("/DadosMestres/Excluir", JSON.stringify({ tabelaId: $('#hdnTabela').val(), id: id }));
            if (response.status == true) {
                swal({
                    type: 'success',
                    title: 'Sucesso',
                    text: 'Dado excluído com sucesso!'
                }).then((result) => {
                    if (result.value) {
                        $('[data-id=' + id + ']').parent().remove()
                    }
                })

            }
        }
    });
}
