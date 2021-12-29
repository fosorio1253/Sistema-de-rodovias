using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class Usuario
    {
        #region Construtor

        public Usuario()
        {
            GruposIDs = new List<int>();
        }

        #endregion

        #region Propriedades

        public int Id { get; set; }
        public bool Ativo { get; set; }
        public bool Externo { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public int? RegionalId { get; set; }
        public string DDD { get; set; }
        public string TelefoneRamal { get; set; }
        public DateTime? DataCriacao { get; set; }
        public int StatusAprovacaoId { get; set; }
        public bool Excluido { get; set; }
        public string CPF { get; set; }
        public Guid AlteracaoGuid { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
        public virtual StatusAprovacao StatusAprovacao { get; set; }
        public virtual ICollection<GestaoInteressadoContato> GestaoInteressadosContatos { get; set; }
        public virtual DadosMestresValores Regional { get; set; }
        public virtual ICollection<AlterarSenha> AlterarSenhas { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Selecione ao menos um Grupo")]
        public List<int> GruposIDs { get; set; }

        [NotMapped]
        public List<int> EmpresasIDs { get; set; }

        [NotMapped]
        public HttpPostedFileBase[] Files { get; set; }

        [NotMapped]
        public string Procuracao { get; set; }

        [NotMapped]
        public string DocumentoFoto { get; set; }

        #endregion
    }
}