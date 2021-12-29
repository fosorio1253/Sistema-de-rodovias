namespace DER.WebApp.Domain.Models
{
    public class GestaoInteressadoTipoDeConcessao
    {
        #region Propriedades

        public int Id { get; set; }
        public int GestaoInteressadoId { get; set; }
        public int TipoDeConcessaoId { get; set; }
        public bool Marcado { get; set; }

        #endregion


        #region Propriedades Complexas
        
        public virtual GestaoInteressado GestaoInteressado { get; set; }
        public virtual DadosMestresValores TipoDeConcessao { get; set; }

        #endregion
    }
}