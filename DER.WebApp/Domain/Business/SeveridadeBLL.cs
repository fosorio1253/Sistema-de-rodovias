using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class SeveridadeBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public SeveridadeBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<ViewModels.SeveridadesViewModel> ObtemSeveridades()
        {
            var retorno = new List<ViewModels.SeveridadesViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.OcorrenciaSeveridade);

            foreach (var d in dominio)
            {
                retorno.Add(new ViewModels.SeveridadesViewModel() { SeveridadeId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}