using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class Permissao
    {
        #region Propriedades

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public bool Excluido { get; set; }
        public int? PermissaoPaiId { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual Permissao PermissaoPai { get; set; }
        public virtual ICollection<Permissao> PermissoesFilhos { get; set; }
        public virtual ICollection<Perfil> Perfis { get; set; }

        #endregion
    }
}