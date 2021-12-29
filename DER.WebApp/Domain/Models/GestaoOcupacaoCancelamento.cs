using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacaoCancelamento
    {
        #region Propriedades

        public int id { get; set; }
        public int GestaoOcupacaoId { get; set; }
        public string MotivoCancelamento { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual GestaoOcupacao GestaoOcupacao { get; set; }

        #endregion
    }
}