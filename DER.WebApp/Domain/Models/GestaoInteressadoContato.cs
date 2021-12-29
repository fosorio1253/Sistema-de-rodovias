namespace DER.WebApp.Domain.Models
{
    public class GestaoInteressadoContato
    {
        #region Propriedades

        public int Id { get; set; }

        public int GestaoInteressadoId { get; set; }

        public int UsuarioId { get; set; }

        //public bool? Principal { get; set; }
        public int Principal { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual GestaoInteressado GestaoInteressado { get; set; }
        public virtual Usuario Usuario { get; set; }

        #endregion
    }
}