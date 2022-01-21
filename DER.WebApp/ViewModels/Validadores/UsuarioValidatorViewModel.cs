using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels.Validadores
{
    public class UsuarioValidatorViewModel
    {
        public int id { get; set; }
        public bool CNPJExists { get; set; }
        public bool validCNPJ { get; set; }
        public bool validCPF { get; set; }
        public bool valid { get; set; }
        public bool anyEmail { get; set; }
        public bool anyLogin { get; set; }
        public bool anyCPF { get; set; }

        public bool anyDocumento { get; set; } = true;
        public bool anyProcuracao { get; set; } = true;
    }
}