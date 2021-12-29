using System;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacoesAcoesJudiciaisViewModel
    {
        public int IdAcoesJudiciais { get; set; }
        public int IdInteressado { get; set; }
        public int IdOcupacao { get; set; }
        public int IdRodovia { get; set; }
        public int IdTipoOcupacao { get; set; }
        public int IdSituacaoProcessual { get; set; }
        public string SituacaoProcessual { get; set; }
        public string CPNJ { get; set; }
        public string Protocolo { get; set; }
        public string ProcessoJudicial { get; set; }
        public string HistoricoResumido { get; set; }
        public string CobrancaPEP { get; set; }
        public string CobrancaRegularizacao { get; set; }
        public string CobrancaAnuidade { get; set; }
        public string CobrancaLevantamento { get; set; }
        public string Assinatura { get; set; }
        public string MotivoAssinatura { get; set; }
        public string Observacao { get; set; }
        public double KmInicial { get; set; }
        public double KmFinal { get; set; }        
        public DateTime? DataDespacho { get; set; }

        public virtual SelectList SituacoesProcessuais { get; set; }
    }
}