using System;
using System.ComponentModel.DataAnnotations;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacoesOcorrenciaViewModel
    {
        #region Propriedades

        public int Id { get; set; }
        public string GestaoOcupacoesId { get; set; }
        public string DataOcorrencia { get; set; }
        public string Autor { get; set; }
        public string Area { get; set; }
        public int AreaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(250, ErrorMessage = "O tamanho máximo é de 250 caracteres.")]
        public string Ocorrencia { get; set; }
               
        #endregion

        #region Propriedade Complexas

        public virtual GestaoOcupacoesViewModel GestaoOcupacoesViewModel { get; set; }

        #endregion
    }
}