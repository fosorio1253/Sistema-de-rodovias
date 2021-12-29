using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacaoTrechoInterferencia
    {
        public int Id { get; set; }
        public int GestaoOcupacaoTrechoId { get; set; }
        public int TipoInterferencia { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Volume { get; set; }
        public decimal VolumeTotal { get; set; }
    }
}