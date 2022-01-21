using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoDeDocumentoOcupacaoBLL
    {
        private TipoDocumentoOcupacaoBLL tipoDocumentoOcupacaoBLL;

        public TipoDeDocumentoOcupacaoBLL()
        {
            tipoDocumentoOcupacaoBLL = new TipoDocumentoOcupacaoBLL();
        }

        public List<TipoDeDocumentoOcupacaoViewModel> ObtemTipoDeDocumentosOcupacao()
        {
            var retorno = new List<TipoDeDocumentoOcupacaoViewModel>();
            tipoDocumentoOcupacaoBLL.LoadView().ForEach(x => retorno.Add(new TipoDeDocumentoOcupacaoViewModel() { TipoDeDocumentoOcupacaoId = x.TipoDeDocumentoOcupacaoId, Nome = x.Nome }));
            return retorno;
        }
    }
}