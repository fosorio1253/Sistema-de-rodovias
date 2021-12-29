using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class Perfil
    {
        #region Propriedades

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Excluido { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<Permissao> Permissoes { get; set; }

        #endregion
    }
}