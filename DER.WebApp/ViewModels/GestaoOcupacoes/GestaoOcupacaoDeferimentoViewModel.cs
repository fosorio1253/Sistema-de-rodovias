using System;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacaoDeferimentoViewModel
    {
        #region Propriedades

        public int Id { get; set; }
        public DateTime? DataDespachoAutorizativo { get; set; }
        public string NumeroProcesso { get; set; }
        public DateTime? DataAssinatura { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string TermoAnexadoNome { get; set; }
        public string TermoAnexadoArquivo { get; set; }
        public string CaminhoArquivo { get; set; }

        #endregion

        #region Propriedades Complexas

        public GestaoOcupacaoViewModel GestaoOcupacaoViewModel { get; set; }

        #endregion
    }
}