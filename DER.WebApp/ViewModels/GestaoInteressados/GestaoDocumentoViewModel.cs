using System;
using System.Web;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.GestaoInteressados
{
    public class GestaoDocumentoViewModel
    {
        #region Propriedades

        public int? Id { get; set; }
        public int? TipoDocumentoId { get; set; }
        public virtual SelectList TiposDocumentos { get; set; }
        public string Documento { get; set; }
        public string ArquivoNome { get; set; }
        public string Arquivo { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string CaminhoArquivo { get; set; }


        //public HttpPostedFileBase[] Files { get; set; }

        #endregion

        #region Propriedade Complexas

        public virtual GestaoInteressadosViewModel GestaoInteressadosViewModel { get; set; }

        #endregion
    }
}