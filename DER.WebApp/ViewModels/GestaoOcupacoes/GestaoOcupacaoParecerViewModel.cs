using System;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacaoParecerViewModel
    {
        #region Propriedades
        public int Id { get; set; }
        public int ParecerRegionalId { get; set; }
        public string ParecerRegionalObservacao { get; set; }
        public DateTime ParecerRegionalData { get; set; }
        public string ParecerRegionalDocumentoArquivo { get; set; }
        public string ParecerRegionalDocumentoNome { get; set; }
        public int ParecerDiretoriaEngenhariaId { get; set; }
        public string ParecerDiretoriaEngenhariaObservacao { get; set; }
        public DateTime ParecerDiretoriaEngenhariaData { get; set; }
        public string ParecerDiretoriaDocumentoArquivo { get; set; }
        public string ParecerDiretoriaDocumentoNome { get; set; }
        public int ParecerCoordenadoriaOperacoesId { get; set; }
        public string ParecerCoordenadoriaOperacoesObservacao { get; set; }
        public DateTime ParecerCoordenadoriaOperacoesData { get; set; }
        public string ParecerCoordenadoriaDocumentoArquivo { get; set; }
        public string ParecerCoordenadoriaDocumentoNome { get; set; }
        public int ParecerFaixaDominioId { get; set; }
        public string ParecerFaixaDominioObservacao { get; set; }
        public DateTime ParecerFaixaDominioData { get; set; }
        public string ParecerFaixaDominioDocumentoArquivo { get; set; }
        public string ParecerFaixaDominioDocumentoNome { get; set; }
        public DateTime Data { get; set; }
        public string CaminhoArquivoDiretoria { get; set; }
        public string CaminhoArquivoRegional { get; set; }
        public string CaminhoArquivoCoordenadoria { get; set; }
        public string CaminhoArquivoFaixaDominio { get; set; }


        #endregion

        #region Propriedades Complexas

        public virtual GestaoOcupacaoViewModel GestaoOcupacaoViewModel { get; set; }

        #endregion
    }
}