namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacaoOcupacao
    {
        #region Propriedades

        public int Id { get; set; }
        public int GestaoOcupacaoId { get; set; }
        public string Assunto { get; set; }
        public string Observacao { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual GestaoOcupacao GestaoOcupacao { get; set; }

        #endregion
    }
}