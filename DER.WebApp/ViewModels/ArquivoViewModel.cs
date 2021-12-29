using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class ArquivoViewModel
    {
        public int Id { get; set; }
        public string TipoDeArquivo { get; set; }
        public string CaminhoArquivo { get; set; }
    }
}