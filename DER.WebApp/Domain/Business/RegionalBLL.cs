using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class RegionalBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public RegionalBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<RegionalViewModel> ObtemRegionais()
        {
            var retorno = new List<RegionalViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.DivisaoRegional);

            foreach(var d in dominio)
            {
                retorno.Add(new RegionalViewModel() { RegionalId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}