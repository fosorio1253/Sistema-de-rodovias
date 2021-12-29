using System;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacaoDeferimento
    {
        #region Propriedades
        public int Id { get; set; }
        public int GestaoOcupacaoId { get; set; }
        public DateTime? DataDespachoAutorizativo { get; set; }
        public string NumeroProcesso { get; set; }
        public DateTime? DataAssinatura { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string TermoAnexadoArquivo { get; set; }

        #endregion
    }
}