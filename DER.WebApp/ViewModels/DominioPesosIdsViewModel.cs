using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class DominioPesosIdsViewModel
    {
        public int dominio_pesos_id { get; set; }
        public string pes_anomalia { get; set; }
        public string pes_severidade { get; set; }
        public double pes_nota { get; set; }
    }
}