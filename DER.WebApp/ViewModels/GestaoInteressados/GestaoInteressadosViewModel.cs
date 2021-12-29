using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.GestaoInteressados
{
    public class GestaoInteressadosViewModel
    {
        #region Construtor

        public GestaoInteressadosViewModel()
        {
            /* GruposIDs = new List<int>();
             EmpresasIDs = new List<int>();
             Requerimentos = new List<int>();*/
        }

        #endregion

        #region Propriedades
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]
        public string NumeroSPDOC { get; set; }

        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]
        public string StatusSPDOC { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int NaturezaJuridicaId { get; set; }
        
        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(18, ErrorMessage = "O tamanho máximo é de 18 caracteres.")]
        [MinLength(14, ErrorMessage = "Documento Incompleto")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int TipoEmpresaId { get; set; }
        
        public string Validade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres")]
        public string NomeFantasia { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public string ExisteValidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int TipoDeDocumentoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int TipoInteressadoId { get; set; }
        public virtual SelectList TiposInteressados { get; set; }
        public virtual SelectList NaturezasJuridicas { get; set; }
        public virtual SelectList Status { get; set; }
        public virtual SelectList TiposEmpresas { get; set; }
        public virtual SelectList TipoDeDocumentos { get; set; }

        public virtual List<TipoDeConcessaoViewModel> TiposDeConcessoes { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual List<GestaoEnderecoViewModel> Enderecos { get; set; }
        public virtual List<GestaoContatoViewModel> Contatos { get; set; }
        public virtual List<GestaoDocumentoViewModel> Documentos { get; set; }
        public virtual List<GestaoObservacaoViewModel> Observacoes { get; set; }

        public virtual GestaoEnderecoViewModel Endereco { get; set; }
        public virtual GestaoContatoViewModel Contato { get; set; }
        public virtual GestaoObservacaoViewModel Obs { get; set; }
        public virtual GestaoDocumentoViewModel Doc { get; set; }

        public virtual GestaoContatoVisualizarViewModel ContatoVisualizar { get; set; }

        #endregion
    }
}  