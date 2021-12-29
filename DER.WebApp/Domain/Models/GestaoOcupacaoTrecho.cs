namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacaoTrecho
    {
        #region Propriedades

        public int Id { get; set; }
        public int GestaoOcupacaoId { get; set; }
        public int? RodoviaId { get; set; }
        public decimal KmInicial { get; set; }
        public int KmInicialMetragem { get; set; }
        public decimal KmFinal { get; set; }
        public int KmFinalMetragem { get; set; }
        public decimal Extensao { get; set; }
        public int? Localizacao { get; set; }
        public int? TipoImplantacaoId { get; set; }
        public int? TipoPassagemId { get; set; }
        public int? LadoId { get; set; }
        public int? TipoOcupacaoId { get; set; }
        public decimal Altura { get; set; }
        public decimal Profundidade { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual GestaoOcupacao GestaoOcupacao { get; set; }
        public virtual DadosMestresValores Trechos { get; set; }
        public virtual ProjetosMelhorias ProjetosMelhorias { get; set; }

        #endregion
    }
}