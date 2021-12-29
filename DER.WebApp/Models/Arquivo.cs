﻿using DER.WebApp.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DER.WebApp.Models
{
    [Table("tab_arquivos")]
    public class Arquivo
    {
        [Key]
        [Column("arq_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Column("arq_apagado")]
        public bool Apagado { get; set; }

        [Column("arq_nome")]
        [MaxLength(100)]
        public string ArquivoNome { get; set; }        

        [Column("arq_extensao")]
        public string ArquivoExtensao { get; set; }
        
        [Column("arq_arquivo")]
        public string ArqArquivo { get; set; }

        [Column("arq_data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("arq_data_atualizacao")]
        public DateTime DataAtualizacao { get; set; }

        [Column("arq_tipo")]
        public TipoArquivo TipoArquivo { get; set; }

        [ForeignKey("Usuario")]
        [Column(Order = 1)]
        public int usu_id { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}