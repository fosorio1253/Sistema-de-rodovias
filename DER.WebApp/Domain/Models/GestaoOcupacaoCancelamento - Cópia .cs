using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacaoWorkflow
    {
        #region Propriedades

        public int id { get; set; }
        public DateTime DataCadastro { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual List<GestaoOcupacao> ListaGestaoOcupacao { get; set; }

        #endregion
    }
}