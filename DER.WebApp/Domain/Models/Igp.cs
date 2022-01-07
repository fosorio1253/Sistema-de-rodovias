using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class Igp
    {
        public int IGP_id { get; set; }
        public DateTime? mes_ano { get; set; }
        public double valor { get; set; }
    }
}