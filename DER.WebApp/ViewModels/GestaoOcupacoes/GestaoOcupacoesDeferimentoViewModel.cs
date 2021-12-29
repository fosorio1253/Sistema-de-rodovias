using System;
using System.Web;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacoesDeferimentoViewModel
    {
        #region Propriedades
        public int? Id { get; set; }
        public string DataDespachoAutorizativo { get; set; }
        public string NumeroProcesso { get; set; }
        public string DataAssinatura { get; set; }
        public string DataPublicacao { get; set; }
        public string CaminhoArquivo { get; set; }

        
        #endregion

        #region Propriedade Complexas

        public virtual GestaoOcupacoesViewModel GestaoOcupacoesViewModel { get; set; }

        #endregion
    }
}