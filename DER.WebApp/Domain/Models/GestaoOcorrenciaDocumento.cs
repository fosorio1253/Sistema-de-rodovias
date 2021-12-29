using System;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcorrenciaDocumento
    {
        #region Propriedades

        public int Id { get; set; }
        public int? GestaoOcorrenciaId { get; set; }
        public string Documento { get; set; }
        public string Arquivo { get; set; }
        public string AdicionadoPor { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public DateTime DataCadastro { get; set; }
        

        #endregion

        #region Propriedades Complexas

        public virtual GestaoOcorrencia GestaoOcorrencia { get; set; }

        #endregion
    }
}