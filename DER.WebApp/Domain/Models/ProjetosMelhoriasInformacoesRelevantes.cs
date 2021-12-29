using System;

namespace DER.WebApp.Domain.Models
{
    public class ProjetosMelhoriasInformacoesRelevantes
    {
        #region Propriedades

        public int Id { get; set; }
        public int ProjetosMelhoriasId { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string AdicionadoPor { get; set; }
        public string Descricao { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual ProjetosMelhorias ProjetosMelhorias { get; set; }

        #endregion
    }
}