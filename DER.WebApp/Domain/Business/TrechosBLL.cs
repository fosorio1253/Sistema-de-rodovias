using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TrechosBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public TrechosBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<ViewModels.TrechoViewModel> ObtemTrechos()
        {
            var retorno = new List<ViewModels.TrechoViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.OcorrenciaTrecho);

            foreach (var d in dominio)
            {
                retorno.Add(new ViewModels.TrechoViewModel() { TrechoId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}