using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class UnidadeBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public UnidadeBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<ViewModels.UnidadeViewModel> ObtemUnidades()
        {
            var retorno = new List<ViewModels.UnidadeViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.Unidade);

            foreach (var d in dominio)
            {
                retorno.Add(new ViewModels.UnidadeViewModel() { UnidadeId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}