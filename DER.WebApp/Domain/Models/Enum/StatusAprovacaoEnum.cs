using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models.Enum
{
    public enum StatusAprovacaoEnum
    {
        EmAnalise = 1,
        Credenciado = 2,
        DocumentacaoPendente = 3,
        Reprovado = 4,
        Vencido = 5,
        AguardandoAprovacao = 6,
        Aprovado = 8
    }
}