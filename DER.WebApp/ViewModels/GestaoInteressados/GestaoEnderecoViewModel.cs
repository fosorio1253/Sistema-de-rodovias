using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.GestaoInteressados
{
    public class GestaoEnderecoViewModel
    {
        #region Propriedades

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        public string Unidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(9, ErrorMessage = "O tamanho máximo é de 9 caracteres.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(5, ErrorMessage = "O tamanho máximo é de 5 caracteres.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo é de 50 caracteres.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int MunicipioId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int EstadoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        public string NomeContato { get; set; }

        public virtual SelectList Municipios { get; set; }
        public virtual SelectList Estados { get; set; }
        #endregion

        #region Propriedade Complexas

        public virtual GestaoInteressadosViewModel GestaoInteressadosViewModel { get; set; }

        #endregion
    }
}