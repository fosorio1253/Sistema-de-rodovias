using System;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacaoManutencaoViewModel
    {
        public int id { get; set; }
        public string DataAssinatura { get; set; }
        public string DataAprovacaoRegional { get; set; }
        public string Observacao { get; set; }
        public string CaminhoArquivo { get; set; }
        public string Arquivo { get; set; }
        public string NomeArquivo { get; set; }
    }
}