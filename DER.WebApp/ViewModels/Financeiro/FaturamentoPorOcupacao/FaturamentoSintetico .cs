using System;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.Financeiro.FaturamentoPorOcupacao
{
    public class FaturamentoSintetico
    {
        public DateTime? PeriodoInt { get; set; }
        public string Periodo { get; set; }
        public double ValorTotal { get; set; }
        public double ValorPrevisto { get; set; }
    }
}