using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class ValidacaoTrechoProjetoViewModel
    {
        public int RodoviaId { get; set; }
        public decimal KmInicial { get; set; }
        public decimal KmFinal { get; set; }
        public string Lado { get; set; }
    }
}