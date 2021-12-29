using System;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class GestaoInteressadoDocumento
    {
        #region Propriedades

        public int Id { get; set; }
        public int? GestaoInteressadoId { get; set; }
        public string Documento { get; set; }
        public string Arquivo { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataValidade { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual GestaoInteressado GestaoInteressado { get; set; }

        #endregion
    }
}