using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class AreaBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public AreaBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<AreaViewModel> ObtemAreas()
        {
            var retorno = new List<AreaViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.Area);

            retorno.Add(new AreaViewModel() { AreaId = 0, Nome = "Selecione" });

            foreach (var d in dominio)
            {
                retorno.Add(new AreaViewModel() { AreaId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}