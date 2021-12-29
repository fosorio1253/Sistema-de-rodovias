using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DER.WebApp.Domain.Models
{
    [Table("tab_tipo_documentos")]
    public class TipoDocumento
    {
        [Key]
        [Column("doc_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("doc_tipo_interessado")]
        public int DocTipoInteressado { get; set; }

        [Column("doc_documentos")]
        public string NomeDocumento { get; set; }

        [Column("doc_data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("doc_data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }
    }
}