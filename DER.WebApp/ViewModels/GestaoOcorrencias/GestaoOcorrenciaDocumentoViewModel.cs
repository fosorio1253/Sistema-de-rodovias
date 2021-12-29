using System;
using System.Web;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.GestaoOcorrencias
{
    public class GestaoOcorrenciaDocumentoViewModel
    {
        #region Propriedades

        public int? Id { get; set; }
        public int? TipoDocumentoId { get; set; }
        public virtual SelectList TiposDocumentos { get; set; }
        public string Documento { get; set; }
        public string Arquivo { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime DataCadastro { get; set; }

        //public HttpPostedFileBase[] Files { get; set; }

        #endregion

        #region Propriedade Complexas

        public virtual GestaoOcorrenciasViewModel GestaoOcorrenciasViewModel { get; set; }

        #endregion
    }
}