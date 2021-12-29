using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.ProjetosMelhorias
{
    public class ProjetosMelhoriasViewModel
    {
        #region Construtor

        public ProjetosMelhoriasViewModel()
        {
          
        }

        #endregion

        #region Propriedades
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int RegionalId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int MunicipioId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int RodoviaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(250, ErrorMessage = "O tamanho máximo é de 250 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public double KmInicial { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public double KmFinal { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public double Extensao { get; set; }

        
        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres.")]
        public string Sentido { get; set; }        

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int LadoId { get; set; }

        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        public string Lote { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 20 caracteres.")]
        public string Status { get; set; }

        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres.")]
        public string NumeroContrato { get; set; }

        [MaxLength(3, ErrorMessage = "O tamanho máximo é de 3 caracteres.")]
        public string Prazo { get; set; }

        public string PrevisaoInicio { get; set; }

        [MaxLength(500, ErrorMessage = "O tamanho máximo é de 500 caracteres.")]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres.")]
        public string UnidadeConservacao { get; set; }

        public virtual SelectList Rodovias { get; set; }
        public virtual SelectList Lados { get; set; }
        public virtual SelectList Municipios { get; set; }
        public virtual SelectList Regionais { get; set; }
        public virtual List<ProjetosMelhoriasStatusViewModel> TipoStatus { get; set; }

        //public IEnumerable<SelectListItem> RodoviaIdList { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual List<ProjetosMelhoriasInformacoesRelevantesViewModel> Informacoes { get; set; }       
        public virtual ProjetosMelhoriasInformacoesRelevantesViewModel Info { get; set; }     
        


        #endregion
    }
}