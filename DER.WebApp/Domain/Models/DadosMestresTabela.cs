using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class DadosMestresTabela
    {
        #region Propriedades

        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int NumeroCodigo { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual ICollection<DadosMestresColuna> Dados { get; set; }

        #endregion

    }
}