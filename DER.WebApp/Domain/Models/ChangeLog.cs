using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DER.WebApp.Domain.Models
{
    public class LogAlteracao
    {
        #region Propriedades

        public int Id { get; set; }
        public string NomeEntidade { get; set; }
        public string IdPrimaryKey { get; set; }
        public string ValorAntigo { get; set; }
        public string NovoValor { get; set; }
        public int ReponsavelAlteracao { get; set; }
        public string NomeUsuarioResponsavel { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public string TipoAlteracao { get; internal set; }

        #endregion
    }
}