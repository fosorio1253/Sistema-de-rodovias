using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoContatoVisualizarViewModel
    {
        public List<int> InteressadosIDs { get; set; }
        public string Municipio { get; set; }
        public string CpfCnpj { get; set; }
        public string Estado { get; set; }
        public List<int> TiposIDs { get; set; }
        public List<int> NaturezasIDs { get; set; }      
    }
}