using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class Municipio
    {
        public int municipio_id { get; set; }
        public string codigo { get; set; }
        public string municipio { get; set; }
        public string regional { get; set; }
    }
}