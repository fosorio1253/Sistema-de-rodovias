using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class StatusAprovacao
    {
        #region Propriedades

        public int Id { get; set; }
        public string Nome { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual List<Usuario> Usuarios { get; set; }
        public virtual ICollection<GestaoInteressado> GestaoInteressados { get; set; }

        #endregion


    }
}