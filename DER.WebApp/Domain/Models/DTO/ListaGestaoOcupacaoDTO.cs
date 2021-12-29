using System;

namespace DER.WebApp.Domain.Models.DTO
{
    public class ListaGestaoOcupacaoDTO
    {
        #region Propriedades
        public int Id { get; set; }
        public string Interessado { get; set; }
        public string Regional { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public string NumeroSPDOC { get; set; }
        public string NumeroProcesso { get; set; }
        public string DataImplantacao { get; set; }
        public string OrigemSolicitacao { get; set; }
        public string SituacaoSolicitacao { get; set; }
        public string SituacaoOcupacao { get; set; }
        public int IdOrigem { get; set; }
        public int IdRegional { get; set; }
        public int UsuarioId { get; set; }
        public int WorkflowId { get; set; }
        public int Sequencia { get; set; }


        #endregion
    }
}