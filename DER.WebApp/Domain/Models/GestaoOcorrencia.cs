using System;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcorrencia
    {
        #region Propriedades

        public int Id { get; set; }
        public int InteressadoId { get; set; }
        public string Documento { get; set; }
        public int? OcupacaoId { get; set; }
        public int? TipoOcupacaoId { get; set; }
        public int? TrechoId { get; set; }
        public int? RodoviaId { get; set; }
        public string KmInicial { get; set; }
        public string KmFinal { get; set; }
        public int? LadoId { get; set; }
        public int? ResidenciaConservacaoId { get; set; }
        public int? RegionalId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Titulo { get; set; }
        public int? AssuntoId { get; set; }
        public int? SeveridadeId { get; set; }
        public int? StatusId { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string AdicionadoPor { get; set; }
        public bool Ativo { get; set; }
        public string CodigoOcorrencia { get; set; }

        #endregion

        #region Propriedades Complexas    

        public virtual DadosMestresValores Ocupacoes { get; set; }
        public virtual DadosMestresValores Trechos { get; set; }
        public virtual DadosMestresValores Rodovias { get; set; }
        public virtual DadosMestresValores Lados { get; set; }
        public virtual DadosMestresValores Residencias { get; set; }
        public virtual DadosMestresValores Regionais { get; set; }
        public virtual DadosMestresValores Assuntos { get; set; }
        public virtual DadosMestresValores Severidades { get; set; }
        public virtual DadosMestresValores Status { get; set; }

        public virtual ICollection<GestaoOcorrenciaObservacao> Observacoes { get; set; }


        #endregion
    }
}