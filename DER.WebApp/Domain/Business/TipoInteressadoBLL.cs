using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoInteressadoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public TipoInteressadoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<TipoInteressadoViewModel> ObtemTipoInteressado()
        {
            var retorno = new List<TipoInteressadoViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.TipoInteressado);

            foreach (var d in dominio)
            {
                retorno.Add(new TipoInteressadoViewModel() { TipoInteressadoId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}