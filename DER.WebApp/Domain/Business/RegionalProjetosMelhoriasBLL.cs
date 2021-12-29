using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System.Collections.Generic;
using DER.WebApp.ViewModels.ProjetosMelhorias;

namespace DER.WebApp.Domain.Business
{
    public class RegionalProjetosMelhoriasBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public RegionalProjetosMelhoriasBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<ProjetosMelhoriasRegionalViewModel> ObtemRegionais()
        {
            var retorno = new List<ProjetosMelhoriasRegionalViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.DivisaoRegional, "Regional");

            foreach(var d in dominio)
            {
                retorno.Add(new ProjetosMelhoriasRegionalViewModel() { RegionalId = d.Id, Nome = d.Nome, Sigla = d.Sigla });
            }

            return retorno;
        }
    }
}