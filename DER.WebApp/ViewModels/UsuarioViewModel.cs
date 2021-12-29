using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class UsuarioViewModel
    {
        public string usu_nome { get; set; }
        public string usu_login { get; set; }
        public string usu_senha { get; set; }
        public int usu_id { get; set; }

        public List<string> Permissoes { get; set; }

    }
}