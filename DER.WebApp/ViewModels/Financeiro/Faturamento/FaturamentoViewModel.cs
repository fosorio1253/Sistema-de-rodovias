using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.Financeiro.Faturamento
{
    public class FaturamentoViewModelParams
    {
        public DateTime? Periodo { get; set; }
        public string TipoFaturamento { get; set; }
        public string TipoOcupacao { get; set; }
        public int QTDOcupacao { get; set; }
        public double ValorTotal { get; set; }
        public string Status { get; set; }

        public virtual SelectList Ocupacoes { get; set; }
    }

    public class FaturamentoViewModel
    {
        public DateTime? Periodo { get; set; }
        public string TipoFaturamento { get; set; }
        public string TipoOcupacao { get; set; }
        public double ValorTotal { get; set; }
        public string Status { get; set; }
    }
}