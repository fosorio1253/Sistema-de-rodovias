using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoDocumentoViewModel
    {
        #region Propriedades

        public int? Id { get; set; }
        public int? TipoDocumentoId { get; set; }
        public virtual SelectList TiposDocumentos { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Documento { get; set; }


        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Arquivo { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime Data { get; set; }
        public int StatusId { get; set; }
        //public HttpPostedFileBase[] Files { get; set; }
        public virtual SelectList Status { get; set; }
        public string CaminhoArquivo { get; set; }


        #endregion

        #region Propriedade Complexas

        public virtual GestaoOcupacoesViewModel GestaoOcupacoesViewModel { get; set; }

        #endregion
    }
}