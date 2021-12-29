using DER.WebApp.ViewModels.GestaoOcorrencias;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.GestaoOcorrencias
{
    public class GestaoOcorrenciasViewModel
    {
        #region Construtor

        public GestaoOcorrenciasViewModel()
        {

        }

        #endregion

        #region Propriedades
        public int Id { get; set; }
        public string Interessado { get; set; }
        public int InteressadoId { get; set; } //PODE SER NULO
        public string Documento { get; set; }
        public int OcupacaoId { get; set; }
        public int TipoOcupacaoId { get; set; }
        public int TrechoId { get; set; }
        public int RodoviaId { get; set; }
        public string Rodovia { get; set; }
        public string Regional { get; set; }
        public string TipoOcupacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string KmInicial { get; set; }                
        public string KmFinal { get; set; }
        public int LadoId { get; set; }
        public int ResidenciaConservacaoId { get; set; }
        public int RegionalId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Titulo { get; set; }
        public int AssuntoId { get; set; }
        public int StatusId { get; set; }
        public int SeveridadeId { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public int MunicipioId { get; set; }
        public int EstadoId { get; set; }
        public int NaturezaJuridicaId { get; set; }
        public int TipoInteressadoId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string CodigoOcorrencia { get; set; }


        public virtual SelectList Interessados { get; set; }
        public virtual SelectList TipoOcupacoes { get; set; }
        public virtual SelectList Trechos { get; set; }
        public virtual SelectList Rodovias { get; set; }
        public virtual SelectList Lados { get; set; }
        public virtual SelectList ResidenciaConservacoes { get; set; }
        public virtual SelectList Regionais { get; set; }
        public virtual SelectList Assuntos { get; set; }
        public virtual SelectList Severidades { get; set; }
        public virtual SelectList Status { get; set; }
        public virtual SelectList Municipios { get; set; }
        public virtual SelectList NaturezasJuridicas { get; set; }
        public virtual SelectList Estados { get; set; }
        public virtual SelectList TiposInteressados { get; set; }
        public virtual SelectList TipoDocumentoOcorrencia { get; set; }

        //public IEnumerable<SelectListItem> TipoInteressadoId { get; set; }
        //public IEnumerable<SelectListItem> RodoviaId2 { get; set; }
        //public IEnumerable<SelectListItem> Interessados { get; set; }
        //public IEnumerable<SelectListItem> Status { get; set; }
        //public virtual SelectList Status2 { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual List<GestaoOcorrenciaDocumentoViewModel> Documentos { get; set; }
        public virtual List<GestaoObservacaoViewModel> Observacoes { get; set; }
        public virtual GestaoObservacaoViewModel Obs { get; set; }


        //public virtual List<GestaoOcupacoesTrechoViewModel> ListaTrecho { get; set; }
        //public virtual List<GestaoOcupacoesTrechoInterferenciaViewModel> ListaTrechoInterferencia { get; set; }
        //public virtual List<GestaoOcupacoesOcorrenciaViewModel> ListaOcorrencias { get; set; }
        //public virtual GestaoContatoVisualizarViewModel ContatoVisualizar { get; set; }
        //public virtual GestaoOcupacoesTrechoViewModel Trecho { get; set; }
        //public virtual GestaoOcupacoesTrechoInterferenciaViewModel TrechoInterferencia { get; set; }
        //public virtual GestaoOcupacoesOcorrenciaViewModel Oco { get; set; }
        //public virtual GestaoDocumentoViewModel Doc { get; set; }
        //public virtual GestaoOcupacoesParecerViewModel Parecer { get; set; }
        //public virtual GestaoOcupacoesDeferimentoViewModel Deferimento { get; set; }

        #endregion
    }

    public class GestaoOcorrenciasViewModelApi
    {
        #region Construtor

        public GestaoOcorrenciasViewModelApi()
        {

        }

        #endregion

        #region Propriedades
        public int Id { get; set; }
        public string Interessado { get; set; }
        public int InteressadoId { get; set; } //PODE SER NULO
        public string Documento { get; set; }
        public int OcupacaoId { get; set; }
        public int TipoOcupacaoId { get; set; }
        public int TrechoId { get; set; }
        public int RodoviaId { get; set; }
        public string Rodovia { get; set; }
        public string Regional { get; set; }
        public string TipoOcupacao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string KmInicial { get; set; }
        public string KmFinal { get; set; }
        public int LadoId { get; set; }
        public int ResidenciaConservacaoId { get; set; }
        public int RegionalId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Titulo { get; set; }
        public int AssuntoId { get; set; }
        public int StatusId { get; set; }
        public int SeveridadeId { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public string AdicionadoPor { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        
        public string CodigoOcorrencia { get; set; }
        public bool Ativo { get; set; }
        public int MunicipioId { get; set; }
        public int EstadoId { get; set; }
        public int NaturezaJuridicaId { get; set; }
        public int TipoInteressadoId { get; set; }
        public int TipoDocumentoId { get; set; }


        //public IEnumerable<SelectListItem> TipoInteressadoId { get; set; }
        //public IEnumerable<SelectListItem> RodoviaId2 { get; set; }
        //public IEnumerable<SelectListItem> Interessados { get; set; }
        //public IEnumerable<SelectListItem> Status { get; set; }
        //public virtual SelectList Status2 { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual List<GestaoOcorrenciaDocumentoViewModel> Documentos { get; set; }
        public virtual List<GestaoObservacaoViewModel> Observacoes { get; set; }
        public virtual GestaoObservacaoViewModel Obs { get; set; }


        //public virtual List<GestaoOcupacoesTrechoViewModel> ListaTrecho { get; set; }
        //public virtual List<GestaoOcupacoesTrechoInterferenciaViewModel> ListaTrechoInterferencia { get; set; }
        //public virtual List<GestaoOcupacoesOcorrenciaViewModel> ListaOcorrencias { get; set; }
        //public virtual GestaoContatoVisualizarViewModel ContatoVisualizar { get; set; }
        //public virtual GestaoOcupacoesTrechoViewModel Trecho { get; set; }
        //public virtual GestaoOcupacoesTrechoInterferenciaViewModel TrechoInterferencia { get; set; }
        //public virtual GestaoOcupacoesOcorrenciaViewModel Oco { get; set; }
        //public virtual GestaoDocumentoViewModel Doc { get; set; }
        //public virtual GestaoOcupacoesParecerViewModel Parecer { get; set; }
        //public virtual GestaoOcupacoesDeferimentoViewModel Deferimento { get; set; }

        #endregion
    }
}