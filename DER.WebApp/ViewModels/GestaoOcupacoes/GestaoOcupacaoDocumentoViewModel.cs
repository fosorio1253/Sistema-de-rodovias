using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacaoDocumentoViewModel
    {
        #region Propriedades

        public int? Id { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string Documento { get; set; }
        public string ArquivoNome { get; set; }
        public string Arquivo { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime? DataAdicionado { get; set; }
        public string CaminhoArquivo { get; set; }

        #endregion

        #region Propriedade Complexas

        public virtual GestaoOcupacaoViewModel GestaoOcupacaoViewModel { get; set; }

        #endregion
    }
}