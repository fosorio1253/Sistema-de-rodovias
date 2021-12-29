using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class Grupo
    {
        #region Construtor

        public Grupo()
        {
            Usuarios = new List<Usuario>();
            UsuariosIds = new List<int>();
        }

        #endregion

        #region Propriedades

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int PerfilId { get; set; }
        public bool Excluido { get; set; }
        public bool Ativo { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual Perfil Perfil { get; set; }
        public List<int> UsuariosIds { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

        #endregion
    }
}