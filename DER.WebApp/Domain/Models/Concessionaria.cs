using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class Concessionaria
    {
        public int concessionaria_id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
    }
}