using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class RetornoInteressadoOcupacaoViewModel
    {
        public int IdInteressado { get; set; }
        public string Interessado { get; set; }
        public string Documento { get; set; }
        public string Tipo { get; set; }

        public string Natureza { get; set; }

        public virtual List<TipoDeConcessaoViewModel> TipoConcessoes { get; set; }

    }
}