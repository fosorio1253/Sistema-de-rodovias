using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class LadoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public LadoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<LadoViewModel> ObtemLados()
        {
            var retorno = new List<LadoViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.Lado);

            foreach (var d in dominio)
            {
                retorno.Add(new LadoViewModel() { LadoId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}