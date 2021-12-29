using DER.WebApp.Common.Helper;
using DER.WebApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels
{
    public class UsuarioExternoViewModel
    {
        public UsuarioExternoViewModel()
        {
            GruposIDs = new List<int>();
            EmpresasIDs = new List<int>();
        }

        [Required(ErrorMessage = "Selecione ao menos um Grupo")]
        public List<int> GruposIDs { get; set; }

        [Required(ErrorMessage = "Selecione ao menos uma Empresa")]
        public List<int> EmpresasIDs { get; set; }

        public int Id { get; set; }
        public int StatusAprovacaoId { get; set; }
        public DateTime DataCriacao { get; set; }
        public string TelefoneRamal { get; set; }
        public string DDD { get; set; }

        [EmailAddress(ErrorMessage = "Insira um e-mail válido")]
        [MaxLength(255, ErrorMessage = "O tamanho máximo é de 255 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(10, ErrorMessage = "O tamanho máximo é de 10 caracteres.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres.")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo é de 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(15, ErrorMessage = "O tamanho máximo é de 14 caracteres.")]
        [MinLength(14, ErrorMessage = "CPF Incompleto")]
        public string CPF { get; set; }

        public bool Externo { get; set; } = true;
        public bool Ativo { get; set; }
        public ICollection<Empresa> Empresas { get; set; }

        [MaxLength(150, ErrorMessage = "O tamanho máximo é de 150 caracteres.")]
        public string NomeEmpresa { get; set; }
                
        [MaxLength(19, ErrorMessage = "O tamanho máximo é de 18 caracteres.")]
        [MinLength(18, ErrorMessage = "CNPJ Incompleto")]
        public string CNPJEmpresa { get; set; }

        [NotMapped]
        public HttpPostedFileBase[] Files { get; set; }

        [NotMapped]
        public string DocumentoFoto { get; set; }

        [NotMapped]
        public string Procuracao { get; set; }

        public List<ArquivoViewModel> Arquivos { get; set; }
    }
}