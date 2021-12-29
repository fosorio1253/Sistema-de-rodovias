
//Função para Login -- Validando os campos login e senha preenchidos
function Login() {
    //debugger;
    event.preventDefault();
    var result = validarCamposEditar();
    if (result == false) {
        return false;
    }
    var objetoLogin = {
        usu_login: $("#usu_login").val(),
        usu_senha: $("#usu_senha").val(),
    };
    var response = POST("/Login/ValidarUsuario", JSON.stringify(objetoLogin));
    if (response.status == true) {
        var usuario = response.usuario;
        setCookie('idUsuario', usuario.usu_id, 1);
        
        window.location.href = "/Home/Index";
    }
    else {
        swal({
            position: 'top',
            type: 'error',
            text: 'Usuário ou senha incorretos',
            title: 'Aviso'
        });
    }
}

function AlterarSenhaPadrao() {
    event.preventDefault();
    var objSenha = {
        txtSenhaNova: $("#txtSenhaNova").val(),
        txtSenhaNovaConfirmar: $("#txtSenhaNovaConfirmar").val()
    };
    if (validarSenha()) {
        if (objSenha.txtSenhaNova != '123Mudar') {
            if (objSenha.txtSenhaNova == objSenha.txtSenhaNovaConfirmar) {

                var response = POST("/Login/AlterarSenhaUsuario", JSON.stringify({ txtSenhaNova: objSenha.txtSenhaNova }))

                if (response.status == true) {
                    swal({
                        type: 'success',
                        title: 'Sucesso',
                        text: 'Senha alterada com sucesso!'
                    });
                    $("#modalTrocarSenha").modal('hide');
                }
                else {
                    swal({
                        type: 'error',
                        title: 'Aviso',
                        text: 'Erro ao gravar nova senha!'
                    });
                }


            }
            else {
                swal({
                    type: 'error',
                    title: 'Aviso',
                    text: 'As senhas não conferem!'
                });
            }
        }
        else {
            swal({
                type: 'error',
                title: 'Aviso',
                text: 'A nova senha não pode ser igual a anterior!'
            });
        }
    }
}

//Validar campos 
function validarCamposEditar() {
    var mensagem = "";

    var usu_login = $("#usu_login").val();
    var usu_senha = $("#usu_senha").val();

    if (usu_login.trim() == "") {
        mensagem += 'Login é obrigatório' + '<br/>';
    }
    if (usu_senha.trim() == "") {
        mensagem += 'Senha é obrigatório' + '<br/>';
    }

    if (mensagem != "") {
        if (usu_login === "") {
            $("#usu_login").focus();
        } else if (usu_senha === "") {
            $("#usu_senha").focus();
        }
        swal({
            position: 'top',
            title: '<small>' + 'Por favor verificar o(s) campo(s).' + '</small>',
            html: mensagem
        });
        return false;
    }
    return true;
}

function validarSenha() {
    
    var mensagem = "";

    var txtSenhaNova = $("#txtSenhaNova").val();
    var txtSenhaNovaConfirmar = $("#txtSenhaNovaConfirmar").val();

    if (txtSenhaNova.trim() == "") {
        mensagem += 'Nova Senha' + '<br/>';
    }
    if (txtSenhaNovaConfirmar.trim() == "") {
        mensagem += 'Confirmação de Nova Senha' + '<br/>';
    }

    if (mensagem != "") {
        if (txtSenhaNova === "") {
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

