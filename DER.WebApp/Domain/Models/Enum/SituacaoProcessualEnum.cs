using System.ComponentModel;

namespace DER.WebApp.Domain.Models.Enum
{
    public class SituacaoProcessualEnum
    {
        public enum Situacao
        {
            [Description("TEP E ANUIDADES À FAVOR DO DER/SP")]
            TotalFavor      = 1,
            [Description("TEP E ANUIDADES SUSPENSAS(AFASTADAS)")]
            TotalContra     = 2,
            [Description("TEP À FAVOR DO DER/SP E ANUIDADES SUSPENSA(AFASTADA)")]
            TEPFavor        = 3,
            [Description("TEP SUSPENSA(AFASTADA) E ANUIDADES À FAVOR DO DER/SP")]
            AnuidadeFavor   = 4,
        }
    }
}