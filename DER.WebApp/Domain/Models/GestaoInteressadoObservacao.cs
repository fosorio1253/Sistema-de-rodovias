using System;

namespace DER.WebApp.Domain.Models
{
    public class GestaoInteressadoObservacao
    {
        #region Propriedades

        public int Id { get; set; }
        public int GestaoInteressadoId { get; set; }
        public string AdicionadoPor { get; set; }
        public string Observacao { get; set; }
        public DateTime Data { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual GestaoInteressado GestaoInteressado { get; set; }

        #endregion
    }
}