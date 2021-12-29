using DER.WebApp.Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels
{
    public class UsuarioInternoViewModel
    {
        public UsuarioInternoViewModel()
        {
            GruposIDs = new List<int>();
        }

        [Required(ErrorMessage = "Selecione ao menos um Grupo")]
        public List<int> GruposIDs { get; set; }

        public int Id { get; set; }
        public int StatusAprovacaoId { get; set; } = (int)StatusAprovacaoEnum.AguardandoAprovacao;
        public DateTime? DataCriacao { get; set; }
        public string TelefoneRamal { get; set; }

        [MaxLength(2)]
        public string DDD { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int RegionalId { get; set; }
        public virtual SelectList Regionais { get; set; }

        [EmailAddress(ErrorMessage = "Insira um e-mail válido")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10, ErrorMessage = "O tamanho máximo é de 10 caracteres.")]
        public string Login { get; set; }

        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres.")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo é de 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(15, ErrorMessage = "O tamanho máximo é de 15 caracteres.")]
        [MinLength(14, ErrorMessage = "CPF Incompleto")]
        public string CPF { get; set; }
        public bool Externo { get; set; } = false;
        public bool Ativo { get; set; }
        public string Senha { get; set; }
    }

    public class RegionalViewModel
    {
        public int RegionalId { get; set; }
        public string Nome { get; set; }
    }
}