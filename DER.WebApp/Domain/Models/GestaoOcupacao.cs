using System;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacao
    {
        #region Propriedades

        public int Id { get; set; }
        public int InteressadoId { get; set; }
        public int? RegionalId { get; set; }
        public string NumeroSPDOC { get; set; }
        public string NumeroProcesso { get; set; }
        public DateTime? DataImplantacao{ get; set; }
        public int? OrigemSolicitacaolId { get; set; }
        public int? SituacaoSolicitacaoId { get; set; }
        public int? SituacaoOcupacaoId { get; set; }
        public int? ResidenciaConservacaoId { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public DateTime? DataCadastro { get; set; }              
        public bool Ativo { get; set; }
        public int WorkflowId { get; set; }
        public int Sequencia { get; set; }

        #endregion
    }
}