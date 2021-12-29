using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.DTO;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class EmpresaBLL
    {
        private EmpresaDAO empresaDAO;
        private DerContext _context;

        public EmpresaBLL()
        {
            _context = new DerContext();
            empresaDAO = new EmpresaDAO(_context);
        }

        public List<Empresa> ObtemTodos()
        {
            return empresaDAO.GetAll().Where(x => x.Excluido == false).ToList();
        }

        public List<EmpresaViewModel> ObtemEmpresas()
        {
            var retorno = new List<EmpresaViewModel>();

            //var empresas = empresaDAO.GetAll().Where(x => x.Excluido == false).ToList();
            var empresas = empresaDAO.ObtemEmpresaUsuario(PerfilUsuario.UsuarioId);

            foreach (var empresa in empresas)
            {
                retorno.Add(new EmpresaViewModel() { EmpresaId = empresa.EmpresaId, Nome = empresa.Nome });
            }

            return retorno;
        }

        //public List<EmpresaViewModel> ObtemEmpresaUsuario()
        //{
        //    var retorno = new List<EmpresaViewModel>();

        //    var empresas = empresaDAO.GetAll().Where(x => x.Excluido == false).ToList();


        //    foreach (var empresa in empresas)
        //    {
        //        retorno.Add(new EmpresaViewModel() { EmpresaId = empresa.Id, Nome = empresa.Nome });
        //    }

        //    return retorno;
        //}

     
        //public EmpresaUsuarioViewModel ObtemEmpresaUsuario(int UsuarioSessaoId)
        //{
        //    var retorno = empresaDAO.ObtemEmpresaUsuario(UsuarioSessaoId);
        //    return retorno;
        //}


        public bool VerificaCNPJExiste(string cnpj)
        {
            var retorno = empresaDAO.GetAll().FirstOrDefault(x => x.CNPJ.Equals(cnpj));

            return (retorno == null) ? false : true;
        }
    }
}