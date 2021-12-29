using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoDeDocumentoInteressadoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public TipoDeDocumentoInteressadoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<TipoDeDocumentoInteressadoViewModel> ObtemTipoDeDocumentosInteressado()
        {
            var retorno = new List<TipoDeDocumentoInteressadoViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.TipodeDocumentoInteressado);

            foreach (var d in dominio)
            {
                retorno.Add(new TipoDeDocumentoInteressadoViewModel() { TipoDeDocumentoInteressadoId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}