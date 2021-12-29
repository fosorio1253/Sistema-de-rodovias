function showMessage(type, title, text) {
    Swal({
        type: type,
        title: title,
        text: text
    })
}

function Logout() {
    swal({
        title: 'Saindo do sistema'
    });
    swal.showLoading();
    var response = POST("/Login/Logout")
    if (response.status == true) {
        swal.close();
        window.location.href = '/Login/Index';
    }
}

/// FUNÇÃO QUE PEGA URL DA PAGINA

$.urlParam = function (name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    return results[1] || 0;
}

//FORMATA DA DATA DE /date(1515841251894)/ -> dd/MM/yyyy
function FormatDate(paramValue) {
    var date, day, month, year;

    date = new Date(parseInt(paramValue.substr(6)));

    day = date.getDate().toString().padStart(2, '0');
    month = (date.getMonth() + 1).toString().padStart(2, '0')
    year = date.getFullYear();

    return day + '/' + month + '/' + year;
}

function ModalTrocaSenha() {
    $("#modalTrocarSenhaAtual").modal('show');
}


function AlterarSenhaAtual() {
    event.preventDefault();

    var objSenha = {
        txtSenhaAtual: $("#txtSenhaAtual").val(),
        txtSenhaNova: $("#txtSenhaNova").val(),
        txtSenhaNovaConfirmar: $("#txtSenhaNovaConfirmar").val()
    };
    if (validarSenha()) {
        if (objSenha.txtSenhaNova == objSenha.txtSenhaNovaConfirmar) {
            
            

            var response = POST("/Login/AlterarSenhaUsuario", JSON.stringify({ SenhaAtual: objSenha.txtSenhaAtual, SenhaNova: objSenha.txtSenhaNova, IdUsuario: getCookie('idUsuario') }))

            if (response.status == true) {
                swal({
                    type: 'success',
                    title: 'Sucesso',
                    text: 'Senha alterada com sucesso!'
                });
                $("#modalTrocarSenhaAtual").modal('hide');
            }
            else {
                if (objSenha.txtSenhaAtual == objSenha.txtSenhaNova) {
                    swal({
                        type: 'error',
                        title: 'Aviso',
                        text: 'A nova senha não pode ser igual a anterior!'
                    });
                    return;
                }
                else {
                    swal({
                        type: 'error',
                        title: 'Aviso',
                        text: 'Senha atual não confere!'
                    });
                }
            }
        }
        else {
            swal({
                type: 'error',
                title: 'Aviso',
                text: 'Nova senha e Senha de confirmação estão diferentes!'
            });
        }
    }
}

function validarSenha() {
    var mensagem = "";
    var resultadoMensagem = "";
    
    var txtSenhaAtual = $("#txtSenhaAtual").val();
    var txtSenhaNova = $("#txtSenhaNova").val();
    var txtSenhaNovaConfirmar = $("#txtSenhaNovaConfirmar").val();

    if (txtSenhaAtual.trim() == "") {
        mensagem += 'Senha Atual' + '<br/>';
    }
    if (txtSenhaNova.trim() == "") {
        mensagem += 'Nova Senha' + '<br/>';
    }
    else if (txtSenhaNova.length < 5) {
        mensagem += 'Senha deve ser maior que 5 caracteres<br/>'
    }
    if (txtSenhaNovaConfirmar.trim() == "") {
        mensagem += 'Confirmação de Nova Senha' + '<br/>';
    }

    

    resultadoMensagem = mensagem;

    if (resultadoMensagem != "") {
        if (txtSenhaAtual === "") {
            $("#txtSenhaNova").focus();
        }
        else if (txtSenhaNova === "") {
            $("#txtSenhaNova").focus();
        } else if (txtSenhaNovaConfirmar === "") {
            $("#txtSenhaNovaConfirmar").focus();
        }
        swal({
            type: 'error',
            title: 'Por favor verificar o(s) campo(s).',
            html: mensagem
        });
        return false;
    }
    return true;
}

$.fn.toggleAttr = function (attr, val) {
    var test = $(this).attr(attr);
    if (test) {
        // if attrib exists with ANY value, still remove it
        $(this).removeAttr(attr);
    } else {
        $(this).attr(attr, val);
    }
    return this;
};

// jquery toggle just the attribute value
$.fn.toggleAttrVal = function (attr, val1, val2) {
    var test = $(this).attr(attr);
    if (test === val1) {
        $(this).attr(attr, val2);
        return this;
    }
    if (test === val2) {
        $(this).attr(attr, val1);
        return this;
    }
    // default to val1 if neither
    $(this).attr(attr, val1);
    return this;
};

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toGMTString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

/*function TestaCPF(inputCPF) {
    var valido = true;
    var Soma;
    var Resto;
    Soma = 0;
    var strCPF = $(inputCPF).val().replace(/\./g, '').replace('-', '');

    if (strCPF == "00000000000") {
        var input = $(inputCPF).parent().find('.text-danger').html('CPF Inválido')
        valido = false;
    }

    for (i = 1; i <= 9; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10))) {
        var input = $(inputCPF).parent().find('.text-danger').html('CPF Inválido')
        valido = false;
    }

    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11))) {
        var input = $(inputCPF).parent().find('.text-danger').html('CPF Inválido')
        valido = false;
    }

    return valido;
}

function TestaCNPJ(inputCnpj) {
    var valido = true;

    var cnpj = $(inputCnpj).val();

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') {
        valido = false;
    }

    if (cnpj.length != 14) {
        valido = false;
    }

    // Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999") {
        valido = false;
    }

    // Valida DVs
    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0, tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0)) {
        valido = false;
    }

    tamanho = tamanho + 1;
    numeros = cnpj.substring(0, tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
        soma += numeros.charAt(tamanho - i) * pos--;
        if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1)) {
        valido = false;
    }
    if (!valido) {
        $(inputCnpj).parent().parent().find('.cnpjInvalido').html('CNPJ Inválido')
    } else {
        $(inputCnpj).parent().parent().find('.cnpjInvalido').html('')
    }

    return valido;
}*/