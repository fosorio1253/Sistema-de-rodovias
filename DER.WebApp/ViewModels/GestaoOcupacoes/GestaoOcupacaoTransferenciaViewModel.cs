using System;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacaoTransferenciaViewModel
    {
        public int id { get; set; }
        public int InteressadoAntecessorId { get; set; }
        public string NumerospdocAntecessor { get; set; }
        public string NumeroProcessoAntecessor { get; set; }
        public bool Recolher { get; set; }
        public bool LiminarDepositoJudicial { get; set; }
        public bool LiminarSuspensoRecolhimento { get; set; }
        public string Observacao { get; set; }
        public string AntecessorInteressado { get; set; }
        public string AntecessorInteressadoEmail { get; set; }
        public string AntecessorDocumento { get; set; }
        public string DataSolicitacao { get; set; }
    }
}