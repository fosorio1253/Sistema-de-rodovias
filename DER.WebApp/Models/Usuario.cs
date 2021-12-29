using DER.WebApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace DER.WebApp.Models
{
    [Table("tab_usuarios")]
    public class Usuario
    {
        public Usuario()
        {
            GruposIDs = new List<int>();
        }

        [Key]
        [Column("usu_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("usu_ativo")]
        public bool Ativo { get; set; }

        [Column("usu_externo")]
        public bool Externo { get; set; }

        [Column("usu_nome")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo é de 150 caracteres.")]
        public string Nome { get; set; }

        [Column("usu_cargo")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        public string Cargo { get; set; }

        [Column("usu_login")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        public string Login { get; set; }

        [Column("usu_senha")]
        [MaxLength(255, ErrorMessage = "O tamanho máximo é de 255 caracteres.")]
        public string Senha { get; set; }

        [Column("usu_email")]
        [EmailAddress]
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Column("usu_regional")]
        public string Regional { get; set; }

        [Column("usu_ddd")]
        [MaxLength(2)]
        public string DDD { get; set; }

        [Column("usu_telefoneRamal")]
        public string TelefoneRamal { get; set; }

        [Column("usu_dataCriacao")]
        public DateTime DataCriacao { get; set; }

        [ForeignKey("StatusAprovacao")]
        [Column("sta_id")]
        public int StatusAprovacaoId { get; set; }

        [Column("usu_excluido")]
        public bool Excluido { get; set; }

        [Column("usu_cpf")]
        [MaxLength(15)]
        public string CPF { get; set; }

        [Column("usu_token_alteracao")]
        public Guid AlteracaoGuid { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }

        public virtual StatusAprovacao StatusAprovacao { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Selecione ao menos um Grupo")]
        public List<int> GruposIDs { get; set; }

        [NotMapped]
        public List<int> EmpresasIDs { get; set; }

        [NotMapped]
        public HttpPostedFileBase[] Files { get; set; }
    }
}