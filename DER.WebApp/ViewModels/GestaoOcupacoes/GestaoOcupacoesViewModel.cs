using DER.WebApp.ViewModels.GestaoInteressados;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacoesViewModel
    {
        #region Construtor

        public GestaoOcupacoesViewModel()
        {
        }

        #endregion

        #region Propriedades
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Interessado { get; set; }

        public string InteressadoEmail { get; set; }

        public int InteressadoId { get; set; }

        public List<TipoDeConcessaoViewModel> InteressadoTipoDeConcessoes { get; set; }

        public string TipoOcupacao { get; set; }
        public string Rodovia { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int RegionalId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int ResidenciaConservacaoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int RodoviaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string DataSolicitacao { get; set; }

        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres.")]
        public string NumeroSPDOC { get; set; }

        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres.")]
        public string NumeroProcesso { get; set; }
        public int Sequencia { get; set; }
        public bool Ativo { get; set; }

        public string DataImplantacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int OrigemSolicitacaoId { get; set; }

        public int SituacaoSolicitacaoId { get; set; }

        public int SituacaoOcupacaoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string DataCadastro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(250, ErrorMessage = "O tamanho máximo é de 250 caracteres.")]
        public string Assunto { get; set; }

        [MaxLength(250, ErrorMessage = "O tamanho máximo é de 250 caracteres.")]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string KmInicial { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string KmFinal { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(11, ErrorMessage = "O tamanho máximo é de 10 caracteres.")]
        public string Extensao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres.")]
        public string Lado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        //[Range(0, 7,ErrorMessage = "O valor para {0} deve ser entre {1} e {2}.")]
        [Range(2, Double.PositiveInfinity, ErrorMessage = "O valor para {0} deve ser no mínimo {1}.")]
        public double Altura { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        //[Range(0, 15,ErrorMessage = "O valor para {0} deve ser entre {1} e {2}.")]
        [Range(2, Double.PositiveInfinity, ErrorMessage = "O valor para {0} deve ser no mínimo {1}.")]
        public double Profundidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int TipoImplantacaoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int TipoPassagemId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int TipoOcupacaoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int LadoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int AreaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int TipoInterferenciaId { get; set; }

        /*[Required(ErrorMessage = "Campo Obrigatório")]
        public int TipoDocumentosOcupacoesId { get; set; }*/
        [Required(ErrorMessage = "Campo Obrigatório")]
        public int TipoDeDocumentoOcupacaoId { get; set; }



        public int ParecerRegionalId { get; set; }
        public string ParecerRegionalObservacao { get; set; }
        public string ParecerRegionalData { get; set; }
        public string DocumentoUploadRegional { get; set; }

        public int ParecerDiretoriaEngenhariaId { get; set; }
        public string ParecerDiretoriaEngenhariaObservacao { get; set; }
        public string ParecerDiretoriaEngenhariaData { get; set; }
        public string DocumentoUploadEngenharia { get; set; }


        public int ParecerCoordenadoriaOperacoesId { get; set; }
        public string ParecerCoordenadoriaOperacoesObservacao { get; set; }
        public string ParecerCoordenadoriaOperacoesData { get; set; }
        public string DocumentoUploadCoordenadoria { get; set; }


        public int ParecerFaixaDominioId { get; set; }
        public string ParecerFaixaDominioObservacao { get; set; }
        public string ParecerFaixaDominioData { get; set; }
        public string DocumentoUploadFaixaDominio { get; set; }

        public string CaminhoArquivoDiretoria { get; set; }
        public string CaminhoArquivoRegional { get; set; }
        public string CaminhoArquivoCoordenadoria { get; set; }
        public string CaminhoArquivoFaixaDominio { get; set; }

        [MaxLength(250, ErrorMessage = "O tamanho máximo é de 250 caracteres.")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Ocorrencia { get; set; }
        public int MunicipioId { get; set; }


        public string CpfCNPJ { get; set; }
        public int EstadoId { get; set; }
        //public int TipoInteressadoId { get; set; }
        public int NaturezaJuridicaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(18, ErrorMessage = "O tamanho máximo é de 18 caracteres.")]
        [MinLength(14, ErrorMessage = "Documento Incompleto")]
        public string Documento { get; set; }

        public int StatusId { get; set; }
        public string Regulamento { get; set; }
        public string Norma { get; set; }

        public virtual SelectList NaturezasJuridicas { get; set; }
        public virtual SelectList TiposInteressados { get; set; }
        public virtual SelectList Regionais { get; set; }

        public virtual SelectList Municipios { get; set; }

        public virtual SelectList Estados { get; set; }
        //CAMILO
        public virtual SelectList ResidenciaConservacoes { get; set; }
        public virtual SelectList SituacaoSolitacoes { get; set; }
        public virtual SelectList SituacaoOcupacoes { get; set; }

        public virtual SelectList Rodovias { get; set; }
        public virtual SelectList TipoImplantacoes { get; set; }
        public virtual SelectList TipoPassagens { get; set; }

        public virtual List<TipoOcupacaoViewModel> TipoOcupacoes { get; set; }

        public virtual SelectList TipoOcupacoesSelectList { get; set; }
        public virtual SelectList Lados { get; set; }
        public virtual SelectList TipoInterferencias { get; set; }

        public virtual SelectList OrigemSolicitacoes { get; set; }
        public virtual SelectList Areas { get; set; }
        public virtual SelectList TipoDocumentosOcupacoes { get; set; }

        public IEnumerable<SelectListItem> TipoInteressadoId { get; set; }
        public IEnumerable<SelectListItem> RodoviaId2 { get; set; }
        public IEnumerable<SelectListItem> Interessados { get; set; }
        public IEnumerable<SelectListItem> Status { get; set; }
        public virtual SelectList Status2 { get; set; }
        public bool CriarNovaOcupacao { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual List<GestaoDocumentoViewModel> ListaDocumentos { get; set; }
        public virtual List<GestaoOcupacoesTrechoViewModel> ListaTrecho { get; set; }
        public virtual List<GestaoOcupacoesTrechoInterferenciaViewModel> ListaTrechoInterferencia { get; set; }
        public virtual List<GestaoOcupacoesOcorrenciaViewModel> ListaOcorrencias { get; set; }
        public virtual GestaoContatoVisualizarViewModel ContatoVisualizar { get; set; }
        public virtual GestaoOcupacoesTrechoViewModel Trecho { get; set; }
        public virtual GestaoOcupacoesTrechoInterferenciaViewModel TrechoInterferencia { get; set; }
        public virtual GestaoOcupacoesOcorrenciaViewModel Oco { get; set; }
        public virtual GestaoDocumentoViewModel Doc { get; set; }
        public virtual GestaoOcupacoesParecerViewModel Parecer { get; set; }
        public virtual GestaoOcupacoesDeferimentoViewModel Deferimento { get; set; }
        public virtual GestaoOcupacoesPEPViewModel PEP { get; set; }
        public virtual List<GestaoOcupacoesRemuneracaoViewModel> Remuneracao { get; set; }
        public virtual GestaoOcupacoesAcoesJudiciaisViewModel AcoesJudiciais { get; set; }
        public virtual List<GestaoOcupacaoWorkflowViewModel> ListaOcupacaoWorkflow { get; set; }
        public virtual List<GestaoOcupacoesViewModel> ListaGestaoOcupacoesViewModel { get; set; }

        public virtual GestaoOcupacaoCancelamentoViewModel Cancelamento { get; set; }
        public virtual GestaoOcupacaoManutencaoViewModel Manutencao { get; set; }
        public virtual GestaoOcupacaoRegularizacaoViewModel Regularizacao { get; set; }
        public virtual GestaoOcupacaoRetificacaoViewModel Retificacao { get; set; }
        public virtual GestaoOcupacaoTransferenciaViewModel Transferencia { get; set; }

        #endregion
    }
}
