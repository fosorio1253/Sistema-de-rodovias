using DER.WebApp.Helper;
using System;
using System.Collections.Generic;

namespace DER.WebApp.ViewModels
{
    public class InadimplentesViewModel
    {
        public string       NomeInteressado { get; set; }
        public string       CpfCnpj         { get; set; }
        public string       Protocolo       { get; set; }
        public string       Processo        { get; set; }
        public string       FiltroValor     { get; set; }
        public string       FiltroDias      { get; set; }
        public decimal      Valor           { get; set; }
        public DateTime?    Periodo         { get; set; }
        public DateTime?    DataVenciemntoPrimeiro  { get; set; }
        public DateTime?    DataVenciemntoSegundo   { get; set; }

        public List<InadimplentesTabelaViewModel> lInadimplentes { get; set; }

        public virtual relatorio Relatorio { get; set; }
    }

    public class InadimplentesTabelaViewModel
    {
        public int          Id              { get; set; }
        public string       Dias            { get; set; }
        public string       Protocolo       { get; set; }
        public string       Processo        { get; set; }
        public string       CpfCnjp         { get; set; }
        public string       NomeInteressado { get; set; }
        public string       TipoFaturamento { get; set; }
        public string       TipoOcupacao    { get; set; }
        public string       StatusBoleto    { get; set; }
        public decimal      ValorTotal      { get; set; }
        public decimal      ValorPrevisto   { get; set; }
        public DateTime?    Periodo         { get; set; }
        public DateTime?    DataVenciemntoPrimeiro  { get; set; }
        public DateTime?    DataVenciemntoSegundo   { get; set; }
    }
}