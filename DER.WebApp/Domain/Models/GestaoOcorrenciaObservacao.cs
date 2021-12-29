using System;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcorrenciaObservacao
    {
        #region Propriedades

        public int Id { get; set; }
        public int GestaoOcorrenciaId { get; set; }
        public string Observacao { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public DateTime DataCadastro { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual GestaoOcorrencia GestaoOcorrencia { get; set; }

        #endregion
    }
}