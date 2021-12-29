using DER.WebApp.Helper;
using System;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.Financeiro.FaturamentoPorOcupacao
{
    public class FaturamentoPorOcupacaoViewModel
    {
        public DateTime? PeriodoInt { get; set; }
        public string Periodo { get; set; }
        public string Termo { get; set; }
        public string TipoFaturamento { get; set; }
        public string TipoOcupacao { get; set; }
        public string TipoOcupacaoId { get; set; }
        public double ValorTotal { get; set; }
        public double ValorPrevisto { get; set; }
        public string Status { get; set; }
        public string Interessado { get; set; }
        public string InteressadoId { get; set; }
        public string Regional { get; set; }
        public string Residencia { get; set; }
        public string Protocolo { get; set; }
        public string Processo { get; set; }
        public int RodoviaId { get; set; }
        public double KmInicial { get; set; }
        public double KmFinal { get; set; }
        public string TrechoConcedido { get; set; }
        public string AcoesJudiciais { get; set; }
    }

    public class FaturamentoPorOcupacaoViewModelParam
    {
        public string Protocolo { get; set; }
        public string Processo { get; set; }
        public string Termo { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public string TipoOcupacao { get; set; }
        public string InteressadoId { get; set; }
        public string Regional { get; set; }
        public string ResidenciaConservacao { get; set; }
        public double ValorTotal { get; set; }
        public double SomatorioTotalValores { get; set; }
        public string AcoesJudiciais { get; set; }
        public string TrechoConcedido { get; set; }
        public int RodoviaId { get; set; }
        public double KmInicial { get; set; }
        public double KmFinal { get; set; }
        public bool StatusPendente { get; set; }
        public bool StatusVencido { get; set; }
        public bool StatusPago { get; set; }
        public bool TipoFaturamentoAnuidade { get; set; }
        public bool TipoFaturamentoPEP { get; set; }
        public bool TipoFaturamentoRegularizacao { get; set; }
        public bool TipoFaturamentoJuridica { get; set; }
        
        public virtual relatorio Relatorio { get; set; }
        public virtual SelectList Ocupacoes { get; set; }
        public virtual SelectList Regionais { get; set; }
        public virtual SelectList ResidenciaConservacoes { get; set; }
        public virtual SelectList Rodovias { get; set; }
        public virtual SelectList Interessados { get; set; }
    }
}