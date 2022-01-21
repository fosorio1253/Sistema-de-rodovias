using AutoMapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using DER.WebApp.Helper;
using DER.WebApp.Common.Helper;
using System.Web;
using DER.WebApp.ModelosEmail;

namespace DER.WebApp.Domain.Business
{
    public class PerfilBLL
    {
        private PerfilDAO _perfilDAO;
        private PermissaoDAO _permissaoDAO;
        private DerContext _context;
        private UsuarioDAO _usuarioDAO;

        public PerfilBLL()
        {
            _context = new DerContext();
            _permissaoDAO = new PermissaoDAO(_context);
            _perfilDAO = new PerfilDAO(_context);
            _usuarioDAO = new UsuarioDAO(_context);

        }

        public List<Perfil> ObtemTodos()
        {
            return _perfilDAO.GetAll().Where(x => x.Excluido == false).ToList();
        }

        public PerfilAcessoViewModel ObtemId(int id)
        {
            var Perfil = _perfilDAO.Get(id);
            var perfil = Mapper.Map<Perfil, PerfilAcessoViewModel>(Perfil);

            perfil.PermissoesIds = new List<int>();
            perfil.Permissoes.ForEach(x => perfil.PermissoesIds.Add(x.Id));

            return perfil;
        }

        public bool ExisteNomeCadastro(string nome, int idPerfil)
        {
            var perfil = _perfilDAO.ObtemPorNome(nome, idPerfil);
            return (perfil != null) ? true : false;
        }

        public int Salvar(PerfilAcessoViewModel Perfil)
        {
            try
            {
                var perfil = Mapper.Map<PerfilAcessoViewModel, Perfil>(Perfil);

                if (perfil.Id == 0)
                {
                    perfil.Permissoes = new List<Permissao>();
                    //perfil.DataCriacao = DateTime.Now;
                }
                else
                {
                    var perfilLocal = _perfilDAO.Get(perfil.Id);
                    perfil.Grupos = perfilLocal.Grupos;
                    perfil.Permissoes = perfilLocal.Permissoes;
                    perfil.Permissoes.Clear();
                }

                if (Perfil.PermissoesIds.Count() > 0)
                    Perfil.PermissoesIds.ForEach(x => perfil.Permissoes.Add(_permissaoDAO.Get(x)));

                _perfilDAO.AddOrUpdate(perfil);
                return perfil.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public bool Excluir(int id)
        {
            try
            {
                var perfil = _perfilDAO.Get(id);
                perfil.Excluido = true;
                _perfilDAO.AddOrUpdate(perfil);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public PerfilAcessoViewModel ObtemPerfilUsuario(int UsuarioSessaoId)
        {
            var retorno = _perfilDAO.ObtemPerfilUsuario(UsuarioSessaoId);
            return retorno;
        }

        public string ConsultarValidadeCredenciamentoLogin(int UsuarioId)
        {
            var retorno = _perfilDAO.ConsultarValidadeCredenciamentoLogin(UsuarioId);
            try
            {
                if (retorno != string.Empty && Convert.ToDateTime(retorno) >= DateTime.Now)
                {
                    
                    var usuario = _usuarioDAO.GetByLogin(PerfilUsuario.LoginUsuario);                                        

                    Emails Email = new Emails();
                    Email.Destinatario = usuario.Email;
                    Email.Assunto = "SGFD - Credenciamento de Interessado.";
                    //Email.CorpoEmail = $"Olá {usuario.Nome}, o seu cadastro no Sistema de Gestão de Faixas de Domínio vencerá em 30 dias. Por favor, acesse o sistema e realize o recadastramento dos seus dados. ";
                    var HTMLEmail = ModelosEmails.EmailExpiracaoCadastroCredenciado();
                    Email.CorpoEmail = HTMLEmail.Replace("{Nome}", usuario.Nome);

                    DER.WebApp.Common.Helper.Email EmailHelper = new Common.Helper.Email();
                    EmailHelper.EnviarEmail(Email);
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
               
        //public string UsuarioSessaoCadastrouInteressado(int UsuarioId)
        //{
        //    try
        //    {         
        //            var usuario = _usuarioDAO.GetByLogin(PerfilUsuario.LoginUsuario);

        //            Emails Email = new Emails();
        //            Email.Destinatario = usuario.Email;
        //            Email.Assunto = "SGFD - Credenciamento de Interessado.";
        //            Email.CorpoEmail = $"Olá {usuario.Nome}, o seu cadastro no Sistema de Gestão de Faixas de Domínio vencerá em 30 dias. Por favor, acesse o sistema e realize o recadastramento dos seus dados. ";

        //            DER.WebApp.Common.Helper.Email EmailHelper = new Common.Helper.Email();
        //            EmailHelper.EnviarEmail(Email);

        //        //return retorno;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}