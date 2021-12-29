using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.Log
{
    public class LogViewModelParam
    {
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public string TipoAlteracao { get; set; }
    }

    public class LogViewModel
    {
        public int Id { get; set; }
        public string NomeEntidade { get; set; }
        public string IdPrimaryKey { get; set; }
        public string ValorAntigo { get; set; }
        public string NovoValor { get; set; }
        public int ReponsavelAlteracao { get; set; }
        public string NomeUsuarioResponsavel { get; set; }
        public string DataAlteracao { get; set; }
        public string TipoAlteracao { get; internal set; }
    }
}
