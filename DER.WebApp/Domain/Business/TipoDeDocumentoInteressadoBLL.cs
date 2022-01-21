using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoDeDocumentoInteressadoBLL
    {
        private TipoDocumentoInteressadoBLL tipoDocumentoInteressadoBLL;

        public TipoDeDocumentoInteressadoBLL()
        {
            tipoDocumentoInteressadoBLL = new TipoDocumentoInteressadoBLL();
        }

        public List<TipoDeDocumentoInteressadoViewModel> ObtemTipoDeDocumentosInteressado()
        {
            var retorno = new List<TipoDeDocumentoInteressadoViewModel>();
            tipoDocumentoInteressadoBLL.LoadView().ForEach(x => retorno.Add(new TipoDeDocumentoInteressadoViewModel() { TipoDeDocumentoInteressadoId = x.tipo_documento_interessado_id, Nome = x.descricao }));
            return retorno;
        }
    }
}