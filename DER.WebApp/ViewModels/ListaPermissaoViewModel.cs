using DER.WebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class ListaPermissaoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Codigo { get; set; }

        public List<ListaPermissaoViewModel> PermissaoFilho { get; set; }

        public virtual ICollection<Perfil> Perfis { get; set; }
    }
}