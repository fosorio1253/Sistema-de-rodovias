using System;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacaoDocumento
    {
        #region Propriedades

        public int Id { get; set; }
        public int GestaoOcupacaoId { get; set; }
        public int? TipoDocumentoId { get; set; }
        public string Documento { get; set; }
        public string Arquivo { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime? DataAdicionado { get; set; }

        #endregion
    }
}