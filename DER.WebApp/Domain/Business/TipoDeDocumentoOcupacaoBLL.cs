using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoDeDocumentoOcupacaoBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;

        public TipoDeDocumentoOcupacaoBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
        }

        public List<TipoDeDocumentoOcupacaoViewModel> ObtemTipoDeDocumentosOcupacao()
        {
            var retorno = new List<TipoDeDocumentoOcupacaoViewModel>();

            var dominio = dadosMestresDAO.ObtemDominio((int)TabelaDadosMestresEnum.TipoDeDocumentoOcupacao);

            foreach (var d in dominio)
            {
                retorno.Add(new TipoDeDocumentoOcupacaoViewModel() { TipoDeDocumentoOcupacaoId = d.Id, Nome = d.Nome });
            }

            return retorno;
        }
    }
}