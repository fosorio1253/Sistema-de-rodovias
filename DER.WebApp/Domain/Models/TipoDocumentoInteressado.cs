using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class TipoDocumentoInteressado
    {
        public int tipo_documento_interessado_id { get; set; }
        public string descricao { get; set; }
        public int tipo_interessado { get; set; }
    }
}