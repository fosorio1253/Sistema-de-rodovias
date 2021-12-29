using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacaoManutencao
    {
        #region Propriedades

        public int id { get; set; }
        public int GestaoOcupacaoId { get; set; }
        public DateTime DataAssinatura { get; set; }
        public DateTime DataAprovacaoRegional { get; set; }
        public string Observacao { get; set; }
        public string CaminhoArquivo { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual GestaoOcupacao GestaoOcupacao { get; set; }

        #endregion
    }
}