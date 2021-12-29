using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacaoParecer
    {
        #region Propriedades

        public int Id { get; set; }
        public int GestaoOcupacaoId { get; set; }
        public int ParecerRegionalId { get; set; }
        public string ParecerRegionalObservacao { get; set; }
        public DateTime? ParecerRegionalData { get; set; }
        public int ParecerDiretoriaEngenhariaId { get; set; }
        public string ParecerDiretoriaEngenhariaObservacao { get; set; }
        public DateTime? ParecerDiretoriaEngenhariaData { get; set; }
        public int ParecerCoordenadoriaOperacoesId { get; set; }
        public string ParecerCoordenadoriaOperacoesObservacao { get; set; }
        public DateTime? ParecerCoordenadoriaOperacoesData { get; set; }
        public int ParecerFaixaDominioId { get; set; }
        public string ParecerFaixaDominioObservacao { get; set; }
        public DateTime? ParecerFaixaDominioData { get; set; }
        public DateTime? Data { get; set; }
        public string ParecerRegionalDocumentoArquivo { get; set; }
        public string ParecerDiretoriaDocumentoArquivo { get; set; }
        public string ParecerCoordenadoriaDocumentoArquivo { get; set; }
        public string ParecerFaixaDominioDocumentoArquivo { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual GestaoOcupacao GestaoOcupacao { get; set; }

        #endregion
    }
}