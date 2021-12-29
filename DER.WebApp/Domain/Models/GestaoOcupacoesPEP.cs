using System;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacoesPEP
    {
        public int Id_PEP { get; set; }
        public int Id_Interessado { get; set; }
        public int Id_Ocupacao { get; set; }
        public int Tipo_Ocupacao { get; set; }

        public DateTime? DataEmissãoPEP { get; set; }
        public DateTime? DataPagamento { get; set; }
        public DateTime? Datavencimento { get; set; }
        public decimal Valor { get; set; }
        public string Comprovante { get; set; }
        public string Status { get; set; }

        public string dataBaseCalculo { get; set; }
        public decimal UFESP { get; set; }
        public decimal extensaoOcupacaoLongitudinal { get; set; }
        public decimal extensaoOcupacaoTransversal { get; set; }
        public decimal extensaoOcupacaoPontual { get; set; }
        public decimal fatorRemuneracao { get; set; }

        public decimal OcupacaoLongitudinal { get; set; }
        public decimal OcupacaoTransversal { get; set; }
        public decimal OcupacaoPontual { get; set; }
        public decimal totalCalculado { get; set; }
    }
}