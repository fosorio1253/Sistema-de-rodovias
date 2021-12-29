using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class PermissoesViewModel
    {
        public bool Listagem { get; set; }
        public bool Visualizar { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        public bool Criar { get; set; }
    }
}