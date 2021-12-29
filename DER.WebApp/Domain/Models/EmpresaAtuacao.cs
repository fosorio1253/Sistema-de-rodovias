using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class EmpresaAtuacao
    {
        #region Propriedades

        public int Id { get; set; }
        public string Nome { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual ICollection<GestaoInteressadoContato> GestaoInteressadosContatos { get; set; }

        #endregion
    }
}