using System;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class RetornoOcorrenciaViewModel
    {
        public int Id { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Autor { get; set; }
        public string Area { get; set; }
        public int AreaId { get; set; }
        public string Ocorrencia { get; set; }
    }
}