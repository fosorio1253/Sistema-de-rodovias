using System;

namespace DER.WebApp.Domain.Models
{
    public class AlterarSenha
    {
        #region Propriedades

        public Guid Id { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool JaUtilizado { get; set; } = false;
        public int UsuarioId { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual Usuario Usuario { get; set; }

        #endregion
    }
}