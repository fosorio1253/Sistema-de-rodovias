using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class TipoConcessaoViewModel
    {
        public int tipo_concessao_id { get; set; }
        public string Descricao { get; set; }
        public string Documentos { get; set; }
        public double profundidade_minima { get; set; }
       
    }
}