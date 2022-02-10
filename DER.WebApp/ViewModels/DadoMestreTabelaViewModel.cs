using System.Collections.Generic;

namespace DER.WebApp.ViewModels
{
    public class DadoMestreTabelaViewModel
    {
        public string nome_tabela { get; set; }
        public string sigla { get; set; }
        public List<List<DadoMestreTabelaValoresViewModel>> valores { get; set; }
    }

    public class DadoMestreTabelaValoresViewModel
    {
        public string nome_coluna { get; set; }
        public string valor { get; set; }
    }
}