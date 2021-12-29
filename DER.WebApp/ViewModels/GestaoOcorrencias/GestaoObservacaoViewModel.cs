using System;
using System.ComponentModel.DataAnnotations;

namespace DER.WebApp.ViewModels.GestaoOcorrencias

{
    public class GestaoObservacaoViewModel
    {
        #region Propriedades

        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres")]
        public string Observacao { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public DateTime? DataCadastro { get; set; }

        #endregion

        #region Propriedade Complexas

        public virtual GestaoOcorrenciasViewModel GestaoOcorrenciasViewModel { get; set; }

        #endregion
    }
}