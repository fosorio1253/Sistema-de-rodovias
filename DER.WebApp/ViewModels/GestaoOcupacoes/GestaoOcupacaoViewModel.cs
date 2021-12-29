using System;
using System.Collections.Generic;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacaoViewModel
    {
        #region Propriedades

        public int Id { get; set; }
        public int InteressadoId { get; set; }
        public int? RegionalId { get; set; }
        public int? ResidenciaConservacaoId { get; set; }
        public string NumeroSPDOC { get; set; }
        public string NumeroProcesso { get; set; }
        public DateTime? DataImplantacao { get; set; }
        public int OrigemSolicitacaoId { get; set; }
        public int SituacaoSolicitacaoId { get; set; }
        public int SituacaoOcupacaoId { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Interessado { get; set; }
        public string InteressadoEmail { get; set; }
        public int? RodoviaId { get; set; }
        public DateTime? DataDespachoAutorizativo { get; set; }
        public bool Ativo { get; set; }
        public int WorkflowId { get; set; }
        public int Sequencia { get; set; }
        public bool criarNovaOcupacao { get; set; }
        #endregion


        #region Propriedades Complexas

        public GestaoOcupacaoOcupacaoViewModel Ocupacao { get; set; }
        public GestaoOcupacaoParecerViewModel Parecer { get; set; }
        public GestaoOcupacaoDeferimentoViewModel Deferimento { get; set; }
        public GestaoOcupacaoTransferenciaViewModel Transferencia { get; set; }
        public GestaoOcupacaoRetificacaoViewModel Retificacao { get; set; }
        public GestaoOcupacaoRegularizacaoViewModel Regularizacao { get; set; }
        public GestaoOcupacaoManutencaoViewModel Manutencao { get; set; }
        public GestaoOcupacaoCancelamentoViewModel Cancelamento { get; set; }
        public List<GestaoOcupacoesTrechoViewModel> Trechos { get; set; }
        public List<RetornoOcorrenciaViewModel> Ocorrencias { get; set; }
        public List<GestaoOcupacaoDocumentoViewModel> Documentos { get; set; }
        public List<GestaoOcupacaoWorkflowViewModel> ListaOcupacaoWorkflow { get; set; }

        #endregion
    }
}