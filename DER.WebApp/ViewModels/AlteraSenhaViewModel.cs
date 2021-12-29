using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class AlteraSenhaViewModel
    {
        public string token { get; set; }
        [MinLength(5, ErrorMessage = "Senha muito curta, digite mais que 5 caracteres")]
        public string senha { get; set; }
        public string senhaRepeticao { get; set; }
    }
}