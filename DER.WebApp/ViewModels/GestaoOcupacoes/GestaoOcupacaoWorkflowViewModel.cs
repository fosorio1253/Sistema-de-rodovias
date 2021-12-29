using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacaoWorkflowViewModel
    {
        #region Propriedades
        public int OcupacaoId { get; set; }
        public int Sequencia { get; set; }
        public bool Ativo { get; set; }
        public int WorkflowId { get; set; }
        public int SituacaoId { get; set; }
        public string SituacaoValor { get; set; }
        public int OrigemId { get; set; }
        public string OrigemValor { get; set; }
        public DateTime DataCadastro { get; set; }

        #endregion

        #region Propriedade Complexas



        #endregion
    }
}