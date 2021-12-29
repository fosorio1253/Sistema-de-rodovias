using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class PermissaoBLL
    {
        private PermissaoDAO _permissaoDAO;
        private DerContext _context;

        public PermissaoBLL()
        {
            _context = new DerContext();
            _permissaoDAO = new PermissaoDAO(_context);
        }
        
        public List<ListaPermissaoViewModel> ObtemListaPermissoes(List<Permissao> permissoes = null)
        {
            if(permissoes == null)
            {
                permissoes = _permissaoDAO.GetAll().Where(x => x.Excluido == false).ToList();
            }
            var permissoesViewModels = new List<ListaPermissaoViewModel>();
            var ListaPronta = new List<ListaPermissaoViewModel>();
            foreach (var permissao in permissoes)
            {
                ListaPronta = verificaFilho(permissoes, permissao, ListaPronta);
            }
            return ListaPronta;
        }

        public List<ListaPermissaoViewModel> verificaFilho(List<Permissao> permissoes, Permissao permissao, List<ListaPermissaoViewModel> ListaPronta)
        {
            var filhos = permissoes.Where(x => x.PermissaoPaiId == permissao.Id);
            var temfilhos = filhos.Count() > 0;
            var efilho = permissoes.Where(x => x.Id == permissao.PermissaoPaiId).Any();
            
            if(efilho && temfilhos)
            {
                ListaPronta = EntraTodos(ListaPronta,permissao,filhos.ToList());
            }
            else if(temfilhos)
            {
                ListaPronta.Add(new ListaPermissaoViewModel()
                {
                    Id = permissao.Id,
                    Nome = permissao.Nome,
                    Codigo = permissao.Codigo,
                    PermissaoFilho = filhos.Select(x => new ListaPermissaoViewModel() { Id = x.Id, Nome = x.Nome, Codigo = x.Codigo }).ToList()
                });
            }
            return ListaPronta;
        }

        public List<ListaPermissaoViewModel> EntraTodos(List<ListaPermissaoViewModel> ListaPronta, Permissao permissao, List<Permissao> Permissoesfilhos)
        {
            foreach(var itemLista in ListaPronta)
            {
                if(itemLista.Id == permissao.Id)
                {
                    itemLista.PermissaoFilho = new List<ListaPermissaoViewModel>();
                    itemLista.PermissaoFilho.AddRange(Permissoesfilhos.Select(x => new ListaPermissaoViewModel() { Nome = x.Nome, Id = x.Id, Codigo = x.Codigo }).ToList());
                }
                else
                {
                    if (itemLista.PermissaoFilho?.Count() > 0)
                        itemLista.PermissaoFilho = EntraTodos(itemLista.PermissaoFilho, permissao, Permissoesfilhos);
                }
            }
            return ListaPronta;
        }
    }
}