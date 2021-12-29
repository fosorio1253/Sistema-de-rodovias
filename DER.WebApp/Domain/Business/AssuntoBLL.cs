using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class AssuntoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public AssuntoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<ViewModels.AssuntosViewModel> ObtemAssuntos()
        {
            var retorno = new List<ViewModels.AssuntosViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.OcorrenciaAssunto);

            foreach (var d in dominio)
            {
                retorno.Add(new ViewModels.AssuntosViewModel() { AssuntoId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}