using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class StatusBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public StatusBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<ViewModels.StatusOcorrenciaViewModel> ObtemStatus()
        {
            var retorno = new List<ViewModels.StatusOcorrenciaViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.OcorrenciaStatus);

            foreach (var d in dominio)
            {
                retorno.Add(new ViewModels.StatusOcorrenciaViewModel() { StatusId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}