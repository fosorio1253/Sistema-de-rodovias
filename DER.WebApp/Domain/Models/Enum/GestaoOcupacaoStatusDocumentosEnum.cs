using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models.Enum
{
    public enum GestaoOcupacaoStatusDocumentosEnum
    {
        EmAnalise = 1,
        Deferido = 2,
        Indeferido = 3,
        NaoAutorizado = 4,
        Cancelado = 5,
        Valido = 6,
        Invalido = 7
    }
}