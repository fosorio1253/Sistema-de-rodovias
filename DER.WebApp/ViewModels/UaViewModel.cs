using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class UaViewModel
    {
        public int ua_id { get; set; }
        public string sigla { get; set; }
        public string nome_ua { get; set; }
        public string unidade { get; set; }
        public string regional { get; set; }
    }
}