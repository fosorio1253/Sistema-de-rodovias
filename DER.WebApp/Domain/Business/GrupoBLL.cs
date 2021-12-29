using AutoMapper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class GrupoBLL
    {
        private GrupoDAO GrupoDAO;
        private UsuarioDAO UsuarioDAO;
        private DerContext _context;

        public GrupoBLL()
        {
            _context = new DerContext();
            GrupoDAO = new GrupoDAO(_context);
            UsuarioDAO = new UsuarioDAO(_context);
        }
        public void CriaGrupo()
        {
            var grupo = new Grupo()
            {
                Descricao = "teste",
                Perfil = new Perfil(),
                Nome = "Teste"
            };
            GrupoDAO.AddOrUpdate(grupo);
        }
        public List<Grupo> ObtemTodos()
        {
            return GrupoDAO.GetAll().Where(x => x.Excluido == false).ToList();
        }
        public GrupoViewModel ObtemId(int Id)
        {
            var grupo = GrupoDAO.Get(Id);
            grupo.UsuariosIds = new List<int>();
            grupo.Usuarios.ForEach(x => grupo.UsuariosIds.Add(x.Id));
            var grupoVM = Mapper.Map<Grupo, GrupoViewModel>(grupo);
            return grupoVM;
        }
        public bool Salvar(GrupoViewModel Grupo)
        {
            try
            {
                var grupo = Mapper.Map<GrupoViewModel, Grupo>(Grupo);
                if (grupo.Id == 0)
                {
                    //grupo.DataCriacao = DateTime.Now;
                    grupo.Usuarios = new List<Usuario>();
                }
                else
                {
                    var grupoLocal = GrupoDAO.Get(grupo.Id);
                    grupo.Usuarios = grupoLocal.Usuarios;
                    grupo.Usuarios.Clear();
                }

                if (grupo.UsuariosIds.Count() > 0)
                    foreach (var item in grupo.UsuariosIds)
                        grupo.Usuarios.Add(UsuarioDAO.Get(item));

                GrupoDAO.AddOrUpdate(grupo);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
        public bool Excluir(int id)
        {
            try
            {
                var grupoLocal = GrupoDAO.Get(id);
                grupoLocal.Excluido = true;
                GrupoDAO.AddOrUpdate(grupoLocal);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool ExisteNomeCadastro(string nome, int idGrupo)
        {
            var grupo = GrupoDAO.ObtemPorNome(nome, idGrupo);
            return (grupo != null) ? true : false;
        }
    }
}