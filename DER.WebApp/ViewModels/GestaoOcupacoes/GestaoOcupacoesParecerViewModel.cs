using System;
using System.Web;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacoesParecerViewModel
    {
        #region Propriedades
        public int? Id { get; set; }
        public string ParecerRegional { get; set; }
        public string ParecerDiretoria { get; set; }
        public string ParecerCoordenadoria { get; set; }
        public string ParecerFaixaDominio { get; set; }
        public string Favoravel { get; set; }
        public string Excepcionalidade { get; set; }
        public string Desfavoravel { get; set; }
        public DateTime Data { get; set; }
        public string CaminhoArquivoDiretoria { get; set; }
        public string CaminhoArquivoRegional { get; set; }
        public string CaminhoArquivoCoordenadoria { get; set; }
        public string CaminhoArquivoFaixaDominio { get; set; }

        #endregion


        #region Propriedade Complexas

        public virtual GestaoOcupacoesViewModel GestaoOcupacoesViewModel { get; set; }

        #endregion
    }
}