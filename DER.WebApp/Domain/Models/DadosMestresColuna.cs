using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class DadosMestresColuna
    {
        #region Propriedades

        public int Id { get; set; }
        public string Nome { get; set; }
        public string TabelaId { get; set; }
        public int TipoDado { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual DadosMestresTabela Tabela { get; set; }
        public virtual ICollection<DadosMestresValores> Valores { get; set; }

        #endregion
    }
}