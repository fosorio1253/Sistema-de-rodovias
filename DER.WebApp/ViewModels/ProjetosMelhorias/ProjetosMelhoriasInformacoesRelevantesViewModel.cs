using System;
using System.ComponentModel.DataAnnotations;

namespace DER.WebApp.ViewModels.ProjetosMelhorias
{
    public class ProjetosMelhoriasInformacoesRelevantesViewModel
    {
        #region Propriedades

        public int Id { get; set; }
        public string ProjetosMelhoriasId { get; set; }

        [MaxLength(500, ErrorMessage = "O tamanho máximo é de 500 caracteres")]
        public string Descricao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string AdicionadoPor { get; set; }
        
        #endregion

        #region Propriedade Complexas

        public virtual ProjetosMelhoriasViewModel ProjetosMelhoriasViewModel { get; set; }

        #endregion
    }
}