using DER.WebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class PerfilAcessoViewModel
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho maximo 50 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [MaxLength(255, ErrorMessage = "Tamanho maximo 255 caracteres")]
        public string Descricao { get; set; }

        public bool Excluido { get; set; }

        public List<int> PermissoesIds { get; set; }
        public string PerfilUsuario { get; set; }
        public int UsuarioEmpresaId { get; set; }
        public int UsuarioPerfilId { get; set; }
        public string DataCredenciamento { get; set; }


        public virtual ICollection<Permissao> Permissoes { get; set; }

    }
}