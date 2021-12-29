using System;
using System.ComponentModel.DataAnnotations;

namespace DER.WebApp.ViewModels.GestaoInteressados
{
    public class GestaoObservacaoViewModel
    {
        #region Propriedades

        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres")]
        public string Observacao { get; set; }
        public DateTime Data { get; set; }
        public string AdicionadoPor { get; set; }

        #endregion

        #region Propriedade Complexas

        public virtual GestaoInteressadosViewModel GestaoInteressadosViewModel { get; set; }

        #endregion
    }
}