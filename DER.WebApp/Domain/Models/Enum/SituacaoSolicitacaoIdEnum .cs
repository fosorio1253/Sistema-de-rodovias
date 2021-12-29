using System;
using System.ComponentModel;
using System.Reflection;

namespace DER.WebApp.Models.Enum
{
    public enum SituacaoSolicitacaoIdEnum
    {
        [Description("deferido")]
        deferido = 218,
        [Description("analise")]
        analise = 217,
        [Description("autorizado")]
        autorizado = 222448,
    }
    
}