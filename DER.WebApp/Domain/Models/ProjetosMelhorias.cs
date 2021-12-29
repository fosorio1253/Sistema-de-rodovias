using System;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class ProjetosMelhorias
    {
        #region Propriedade
        public int Id { get; set; }
        public int? RegionalId { get; set; }
        public int? MunicipioId { get; set; }
        public int? RodoviaId { get; set; }
        public string Nome { get; set; }
        public double KmInicial { get; set; }
        public double KmFinal { get; set; }
        public double Extensao { get; set; }
        public string Sentido { get; set; }
        public int LadoId { get; set; }
        public string Lote { get; set; }
        public string Status { get; set; }
        public string NumeroContrato { get; set; }
        public string Prazo { get; set; }
        public string PrevisaoInicio { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string UnidadeConservacao { get; set; }
        public int? InformacoesRelevantesId { get; set; }

        #endregion

        #region Propriedades Complexas       

        public virtual ICollection<ProjetosMelhoriasInformacoesRelevantes> Informacoes { get; set; }

        public virtual DadosMestresValores Rodovias { get; set; }
        public virtual DadosMestresValores Regionais { get; set; }
        public virtual ICollection<GestaoOcupacaoTrecho> Trechos { get; set; }
        #endregion
    }
}