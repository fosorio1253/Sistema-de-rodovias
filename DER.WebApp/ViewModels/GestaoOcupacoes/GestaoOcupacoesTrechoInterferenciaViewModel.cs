using System.ComponentModel.DataAnnotations;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacoesTrechoInterferenciaViewModel
    {
        #region Propriedades

        public int Id { get; set; }
        public int GestaoOcupacaoTrechoId { get; set; }
        public int interferencia_tipo_id { get; set; }
        public TipoDeInterferenciaViewModel interferencia_tipo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public decimal quantidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public decimal volume_unitario { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public decimal volume_total { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual GestaoOcupacoesTrechoViewModel GestaoOcupacoesTrechoViewModel { get; set; }

        #endregion
    }
}