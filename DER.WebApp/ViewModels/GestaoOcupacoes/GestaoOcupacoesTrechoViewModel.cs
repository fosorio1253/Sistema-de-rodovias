using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DER.WebApp.ViewModels.GestaoOcupacoes
{
    public class GestaoOcupacoesTrechoViewModel
    {
        #region Propriedades

        public int Id { get; set; }
        public string GestaoOcupacoesId { get; set; }     
        public string Trecho { get; set; }
        public DateTime? DataCadastro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int RodoviaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public decimal KmInicial { get; set; }

        public int KmInicialMetragem { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public decimal KmFinal { get; set; }

        public int KmFinalMetragem { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public decimal Extensao { get; set; }
        public int TipoImplantacaoId { get; set; }
        public int TipoPassagemId { get; set; }
        public int LadoId { get; set; }
        public string LadoNome { get; set; }
        public int TipoOcupacaoId { get; set; }

        [Range(0, 7,
        ErrorMessage = "O valor para {0} deve ser entre {1} e {2}.")]
        public decimal Altura { get; set; }

        [Range(0, 15,
        ErrorMessage = "O valor para {0} deve ser entre {1} e {2}.")]
        public decimal Profundidade { get; set; }

        public TipoPassagemViewModel TipoPassagem { get; set; }
        public TipoInterferenciaViewModel TipoInterferencia { get; set; }

        public TipoImplantacaoViewModel TipoImplantacao { get; set; }
        public RodoviaTrechoViewModel Rodovia { get; set; }
        public LocalizacaoViewModel Localizacao { get; set; }
        public TipoOcupacaoViewModel TipoOcupacao { get; set; }
        public LadoViewModel Lado { get; set; }


        public int? IdTipoPassagem { get; set; }
        public string NomeTipoPassagem { get; set; }
        public int? IdTipoImplantacao { get; set; }
        public string NomeTipoImplantacao{ get; set; }

        public int? IdLocalizacao { get; set; }
        public string NomeLocalizacao { get; set; }

        public int? IdRodovia { get; set; }
        public string NomeRodovia { get; set; }

        public int? IdTipoOcupacao { get; set; }
        public string NomeTipoOcupacao { get; set; }

        public int TipoInterferenciaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string VolumeUnitarioInterferencia { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string QuantidadeInterferencia { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string VolumeTotalInterferencia { get; set; }


        #endregion

        #region Propriedade Complexas

        public virtual GestaoOcupacoesViewModel GestaoOucapacao { get; set; }

        public virtual List<GestaoOcupacoesTrechoInterferenciaViewModel> trecho_interferencias { get; set; }
        #endregion
    }

    public class TipoPassagemViewModel
    {
        public int? TipoPassagemId { get; set; }
        public string Nome { get; set; }

    }

    public class TipoImplantacaoViewModel
    {
        public int? TipoImplantacaoId { get; set; }
        public string Nome { get; set; }
    }

    public class RodoviaTrechoViewModel
    {
        public int? RodoviaId { get; set; }
        public string Nome { get; set; }
    }

    public class LocalizacaoViewModel
    {
        public int? LocalizacaoId { get; set; }
        public string Nome { get; set; }
    }

    public class TipoInterferenciaViewModel
    {
        public int? TipoInterferenciaId { get; set; }
        public string Nome { get; set; }

    }
}