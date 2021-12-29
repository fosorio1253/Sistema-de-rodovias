using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels.GestaoInteressados
{
    public class GestaoContatoVisualizarViewModel
    {
        public List<int> GruposIDs { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Login { get; set; }
        public List<int> EmpresasIDs { get; set; }
        public string Email { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
    }
}