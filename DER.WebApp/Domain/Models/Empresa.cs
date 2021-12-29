using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class Empresa
    {
        #region Propriedades

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public bool Excluido { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual ICollection<Usuario> Usuarios { get; set; }

        #endregion
    }
}