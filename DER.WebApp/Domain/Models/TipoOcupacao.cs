using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class TipoOcupacao
    {
        public int tipo_ocupacao_id { get; set; }
        public string nome { get; set; }
        public double altura_minima { get; set; }
        public double profundidade_minima { get; set; }
    }
}