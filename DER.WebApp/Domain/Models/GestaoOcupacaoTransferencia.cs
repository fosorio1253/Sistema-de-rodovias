using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacaoTransferencia
    {
        #region Propriedades

        public int id { get; set; }
        public int GestaoOcupacaoId { get; set; }
        public int InteressadoAntecessorId { get; set; }
        public string NumerospdocAntecessor { get; set; }
        public string NumeroProcessoAntecessor { get; set; }
        public bool Recolher { get; set; }
        public bool LiminarDepositoJudicial { get; set; }
        public bool LiminarSuspensoRecolhimento { get; set; }
        public string Observacao { get; set; }
        public DateTime DataSolicitacao { get; set; }


        #endregion

        #region Propriedades Complexas
        public virtual GestaoOcupacao GestaoOcupacao { get; set; }
        public virtual string AntecessorInteressado { get; set; }
        public virtual string AntecessorInteressadoEmail { get; set; }
        public virtual string AntecessorDocumento { get; set; }

        #endregion
    }
}