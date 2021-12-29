using AutoMapper;
using DER.WebApp.Common.Helper;
using DER.WebApp.DAO;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.Models;
using DER.WebApp.Models.Enum;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.Validadores;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.ModelBinding;

namespace DER.WebApp.Domain.Business
{
    public class UsuarioBLL
    {
        private GrupoDAO grupoDAO;
        private UsuarioDAO usuarioDAO;
        private EmpresaDAO empresaDAO;
        private DerContext _context;
        private ArquivoDAO arquivoDAO;

        public UsuarioBLL()
        {
            _context = new DerContext();
            grupoDAO = new GrupoDAO(_context);
            usuarioDAO = new UsuarioDAO(_context);
            empresaDAO = new EmpresaDAO(_context);
            arquivoDAO = new ArquivoDAO(_context);
        }

        public UsuarioValidatorViewModel Salvar(Usuario usuario)
        {
            bool novoUsuario = false;
            try
            {
                var verificaEnvioDocumentosObrigatorios = usuarioDAO.VerificaEnvioDocumentos(usuario);
                if (!verificaEnvioDocumentosObrigatorios.valid)
                    return verificaEnvioDocumentosObrigatorios;

                if (usuario.Id == 0)
                {
                    var jaCadastrado = usuarioDAO.VerificaJaCadastrado(usuario);
                    if (!jaCadastrado.valid)
                        return jaCadastrado;

                    if (usuario.DocumentoFoto == null || usuario.Procuracao == null) // CADASTRA APENAS O USUÁRIO INTERNO NOVO COMO ATIVO. O USUÁRIO EXTERNO, NECESSITA DE APROVAÇÃO DE UM USUÁRIO INTERNO PRA TER ACESSO AO SISTEMA.
                    {
                        usuario.Ativo = true;
                    }

                    usuario.DataCriacao = DateTime.Now;
                    usuario.Senha = Criptografar.Encrypt("admin");
                    usuario.Grupos = new List<Grupo>();
                    if (usuario.Empresas == null)
                    {
                        usuario.Empresas = new List<Empresa>();
                    }
                    usuario.StatusAprovacaoId = (int)StatusAprovacaoEnum.Aprovado;
                    novoUsuario = true;
                }
                else
                {
                    var usuarioLocal = usuarioDAO.Get(usuario.Id);
                    usuario.Grupos = usuarioLocal.Grupos;
                    usuario.Grupos.Clear();

                    usuario.Empresas = usuarioLocal.Empresas;
                    usuario.Empresas.Clear();

                    usuario.Senha = usuarioLocal.Senha;
                    usuario.DataCriacao = usuarioLocal.DataCriacao;
                }

                if (usuario.GruposIDs?.Count() > 0)
                    usuario.GruposIDs.ForEach(x => usuario.Grupos.Add(grupoDAO.Get(x)));

                if (usuario.EmpresasIDs?.Count() > 0)
                    usuario.EmpresasIDs.ForEach(x => usuario.Empresas.Add(empresaDAO.Get(x)));

                usuarioDAO.AddOrUpdate(usuario);

                if ((usuario.Files?.Count() ?? 0) > 0)
                {
                    SalvarArquivo(usuario);
                }

                if (novoUsuario)
                {
                    //TODO
                    //pesquisar email do Admin do sistema e enviar para ele
                    //Helper.Email.EnviaMensagemEmail("guilherme.souza@bureauveritas.com", "Novo usuario cadastrado", $"Foi Cadastrado um novo usuario {usuario.Nome}");
                    Emails Email = new Emails();
                    Email.Destinatario = "eduardo-veiga.silva@bureauveritas.com";
                    Email.Assunto = "Novo usuario cadastrado";
                    Email.CorpoEmail = $"Foi cadastrado um novo usuário {usuario.Nome}, email {usuario.Email}. O usuário está ativo? {usuario.Ativo}";
                    DER.WebApp.Common.Helper.Email EmailHelper = new Email();
                    EmailHelper.EnviarEmail(Email);

                    // Envia Email para o usuário solicitando nova senha
                    SolicitaNovaSenhaUsuario(usuario.Email, 1);
                }

                return new UsuarioValidatorViewModel() { valid = true };
            }
            catch (Exception ex)
            {
                return new UsuarioValidatorViewModel() { valid = false };
            }
        }

        public void SalvarArquivo(Usuario usuario)
        {
            var arquivo = new List<Arquivo>();

            int index = 0;
            if (usuario.Files != null)
            {
                foreach (var item in usuario.Files)
                {
                    if (item.ContentLength > 0)
                    {
                        TipoArquivoEnum tipoArquivo = 0;
                        var documento = "";
                        if (usuario.Files.Count() > 1)
                        {
                            tipoArquivo = index == 0 ? TipoArquivoEnum.Foto : TipoArquivoEnum.Procuracao;
                            documento = index == 0 ? "Documento com Foto" : "Procuração";
                        }
                        else
                        {
                            tipoArquivo = usuario.Procuracao.ToString() != null ? TipoArquivoEnum.Procuracao : TipoArquivoEnum.Foto;
                            documento = usuario.Procuracao.ToString() != null ? "Procuração" : "Documento com Foto";
                        };

                        var arquivos = arquivoDAO.GetByUsuarioId(usuario.Id);

                        if (arquivos != null)
                        {
                            var arq = arquivos.FirstOrDefault(x => x.TipoArquivo == tipoArquivo);

                            if (arq != null)
                            {
                                this.ExcluirArquivoFisico(arq.ArquivoNome);

                                arquivoDAO.Excluir(arq);
                            }
                        }

                        string tipoArquivoText = (tipoArquivo == TipoArquivoEnum.Foto) ? "foto" : "procuracao";
                        string path = "C:\\der\\arquivos\\";
                        var Extensao = Path.GetExtension(item.FileName);
                        var NomeArquivo = DateTime.Now.ToString("yyyyMMddHHmmss") + tipoArquivoText;
                        var caminhoCompletoSalvar = path + NomeArquivo + Extensao;
                        Directory.CreateDirectory(path);
                        item.SaveAs(caminhoCompletoSalvar);

                        var file = new Arquivo()
                        {
                            usu_id = usuario.Id,
                            Apagado = false,
                            ArquivoNome = caminhoCompletoSalvar,
                            ArquivoExtensao = item.ContentType.Contains("pdf") ? ".pdf" : ".jpg",
                            TipoArquivo = tipoArquivo,
                            Documento = documento,
                            TipoInteressado = 1,
                            DataCadastro = DateTime.Now,
                            DataAtualizacao = DateTime.Now
                        };
                        arquivo.Add(file);
                    }
                    index++;
                }


                _context.Arquivo.AddRange(arquivo);
                _context.SaveChanges();
            }
        }

        public UsuarioValidatorViewModel SalvarComEmpresa(UsuarioExternoViewModel Usuario)
        {
            try
            {
                if (Usuario.CNPJEmpresa != null)
                {
                    var empresa = new Empresa();
                    Usuario.Empresas = new List<Empresa>();

                    empresa.CNPJ = Usuario.CNPJEmpresa;
                    empresa.Nome = Usuario.NomeEmpresa;

                    Usuario.Empresas.Add(empresa);
                }

                Usuario.StatusAprovacaoId = (int)StatusAprovacaoEnum.Aprovado;

                var usuario = Mapper.Map<UsuarioExternoViewModel, Usuario>(Usuario);

                return Salvar(usuario);
            }
            catch (Exception ex)
            {
                return new UsuarioValidatorViewModel() { valid = false };
            }
        }

        public bool AprovacaoUsuario(int usuarioId, int statusAprovacao)
        {
            try
            {
                var usuarioLocal = usuarioDAO.Get(usuarioId);
                usuarioLocal.StatusAprovacaoId = statusAprovacao;

                var email = new Emails();
                if (statusAprovacao == (int)StatusAprovacaoEnum.Aprovado)
                {
                    var token = SolicitarAlteracao(usuarioLocal.Email, true);
                    //email = _context.Emails.Where(x => x.Codigo == "APRVEMAIL").FirstOrDefault();
                }
                else
                {
                    usuarioLocal.AlteracaoGuid = Guid.NewGuid();
                    //email = _context.Emails.Where(x => x.Codigo == "RPRVEMAIL").FirstOrDefault();
                }
                usuarioDAO.AddOrUpdate(usuarioLocal);
                //Email.Enviar(email, usuarioLocal.Email);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public void SolicitaNovaSenhaUsuario(string email, int tipo)
        {
            try
            {
                var usuario = usuarioDAO.GetByEmail(email);

                var usuarioLocal = usuario.FirstOrDefault();
                if (usuarioLocal != null)
                {

                    var alteracaoSenha = new AlterarSenha();
                    alteracaoSenha.Id = Guid.NewGuid();
                    alteracaoSenha.Usuario = usuario.FirstOrDefault();
                    alteracaoSenha.DataExpiracao = DateTime.Now.AddHours(1);
                    usuarioDAO.solicitaAlteracaoSenha(alteracaoSenha);
                    alteracaoSenha.Id.ToString();

                    Emails Email = new Emails();
                    Email.Destinatario = email;
                    Email.Assunto = "Cadastro de nova senha";

                    string host = HttpContext.Current.Request.Url.ToString();
                    var novaUrl = string.Empty;

                    if (tipo == 1)
                    {
                        novaUrl = string.Concat(host.Replace("CadastrarUsuario", ""), "AlteraSenha?token=", alteracaoSenha.Id);
                    }

                    if (tipo == 2)
                    {
                        novaUrl = string.Concat(host.Replace("EsqueciMinhaSenha", ""), "AlteraSenha?token=", alteracaoSenha.Id);
                    }


                    Email.CorpoEmail = $"Olá usuário {alteracaoSenha.Usuario.Nome}, clique <a href='{novaUrl}'>Aqui</a> para cadastro da sua nova senha!";

                    //Email.CorpoEmail = $"Olá usuário {alteracaoSenha.Usuario.Nome}, clique <a href='AQUI_URL_PRODUCAO/Login/AlteraSenha?token={alteracaoSenha.Id}'>Aqui</a> para cadastro da sua nova senha!";

                    DER.WebApp.Common.Helper.Email EmailHelper = new Email();
                    EmailHelper.EnviarEmail(Email);

                }
            }
            catch (Exception ex)
            {

            }
        }


        public List<Usuario> ObtemTodos(bool? externo = null)
        {
            return usuarioDAO
                .GetAll()
                .Where(x => (externo == null || x.Externo == externo) && x.Excluido == false)
                .ToList();
        }

        public bool Excluir(int usuarioId)
        {
            try
            {
                var usuarioLocal = usuarioDAO.Get(usuarioId);
                usuarioLocal.Excluido = true;
                usuarioDAO.AddOrUpdate(usuarioLocal);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string SolicitarAlteracao(string email, bool aprovacao = false)
        {
            try
            {
                var usuario = usuarioDAO.GetByEmail(email);
                if (!aprovacao)
                {
                    usuario = usuario.Where(x => x.Ativo == true && x.Excluido == false);
                }
                var usuarioLocal = usuario.FirstOrDefault();
                if (usuarioLocal == null)
                {
                    return null;
                }
                var alteracaoSenha = new AlterarSenha();
                alteracaoSenha.Id = Guid.NewGuid();
                alteracaoSenha.Usuario = usuario.FirstOrDefault();
                alteracaoSenha.DataExpiracao = DateTime.Now.AddHours(1);
                usuarioDAO.solicitaAlteracaoSenha(alteracaoSenha);
                return alteracaoSenha.Id.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool EnviaUsuarioSenhaEmail(string email)
        {
            try
            {
                var usuario = usuarioDAO.GetByEmail(email).FirstOrDefault();
                if (usuario == null)
                {
                    return false;
                }
                //var login = usuario.Login;
                //var senha = Criptografar.Decrypt(usuario.Senha);
                //Emails Email = new Emails();
                //Email.Destinatario = email;
                //Email.Assunto = "Login e senha SGFD";
                //Email.CorpoEmail = $"Login: {login} Senha: {senha}";
                //Email EmailHelper = new Email();
                //EmailHelper.EnviarEmail(Email);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AlterarSenha(int idUsuario, string SenhaAtual, string SenhaNova)
        {
            try
            {
                return usuarioDAO.AlterarSenha(idUsuario, SenhaAtual, SenhaNova);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool? AlterarSenha(AlteraSenhaViewModel alteraSenha)
        {
            try
            {
                if (alteraSenha.senha == alteraSenha.senhaRepeticao)
                {
                    var usuario = usuarioDAO.AlterarSenha(alteraSenha);
                    return true;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public object AlterarSenhaComValidacao(AlteraSenhaViewModel alteraSenha)
        {
            return usuarioDAO.AlterarSenhaComValidacao(alteraSenha);
        }


        public bool VerificaToken(string token)
        {
            var alteraSenha = usuarioDAO.VerificaToken(token);
            return alteraSenha != null;
        }

        public Usuario ObtemId(int id)
        {
            //var Usuario = usuarioDAO.Get(id);
            var Usuario = usuarioDAO.ObtemUsuarioExterno(id);

            Usuario.GruposIDs = new List<int>();
            Usuario.Grupos.ForEach(x => Usuario.GruposIDs.Add(x.Id));

            Usuario.EmpresasIDs = new List<int>();
            Usuario.Empresas.ForEach(x => Usuario.EmpresasIDs.Add(x.Id));

            return Usuario;
        }

        public UsuarioExternoViewModel ObtemPeloToken(string token)
        {
            var usuario = usuarioDAO.ObtemPeloToken(token);
            if (usuario != null)
            {
                usuario.EmpresasIDs = new List<int>();
                usuario.Empresas.ForEach(x => usuario.EmpresasIDs.Add(x.Id));

                usuario.StatusAprovacaoId = (int)StatusAprovacaoEnum.Aprovado;
            }

            return usuario == null ? null : Mapper.Map<Usuario, UsuarioExternoViewModel>(usuario);
        }

        private void ExcluirArquivoFisico(string caminhoArquivo)
        {
            if (File.Exists(caminhoArquivo))
            {
                File.Delete(caminhoArquivo);
            }
        }
    }
}