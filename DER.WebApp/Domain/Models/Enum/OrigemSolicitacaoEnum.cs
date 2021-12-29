using System;
using System.ComponentModel;
using System.Reflection;

namespace DER.WebApp.Models.Enum
{
    //222 1   Solicitação de Implantação  33
    //246 2   Solicitação de Cancelamento 33
    //247 3   Transferência de Titularidade   33
    //221446  4   Regularização   33
    //221447  5   Ajuizamento de Ação 33
    //221448  6   Manutenção de Rotina    33
    //221449  7   Retificação 33
    public enum OrigemSolicitacaoEnum
    {
        [Description("implantacao")]
        implantacao = 222,
        [Description("cancelamento")]
        cancelamento = 246,
        [Description("transferencia")]
        transferencia = 247,
        [Description("regularizacao")]
        regularizacao = 221446,
        [Description("ajuizamento")]
        ajuizamento = 221447,
        [Description("manutencao")]
        manutencao = 221448,
        [Description("retificacao")]
        retificacao = 221449,
    }
    
}