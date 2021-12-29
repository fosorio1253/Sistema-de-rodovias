using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.ViewModels
{
    public class DadosMestresViewModels
    {
        public string CodigoTabela { get; set; }
        public string NomeTabela { get; set; }
        public List<DMColunas> Colunas { get; set; }
        public Dictionary<int,List<DMValores>> Tabela { get; set; }
    }

    public class DadosMestresRetornoViewModel
    {
        public List<DMValores> Valores { get; set; }
        public string TabelaId { get; set; }
    }

    public class DMColunas
    {
        public int idColuna { get; set; }
        public string NomeColuna { get; set; }
        public int TipoDadoColuna { get; set; }
    }

    public class DMValores
    {
        public int id { get; set; }
        public string valor { get; set; }
        public int linha { get; set; }
        public int colunaId { get; set; }
    }
}