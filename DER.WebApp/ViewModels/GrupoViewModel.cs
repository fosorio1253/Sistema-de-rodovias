using DER.WebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class GrupoViewModel
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [MaxLength(150, ErrorMessage = "O tamanho máximo é de 150 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int PerfilId { get; set; }

        public List<int> UsuariosIds { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}