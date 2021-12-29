using System;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacoesRemuneracao
    {
        public int IdGestaoOcupacoesRemuneracao { get; set; }
        public int IdOcupacao { get; set; }
        public DateTime? DataRemuneracao { get; set; }
        public decimal ValorRemuneracao { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public bool Liberado { get; set; }
    }
}