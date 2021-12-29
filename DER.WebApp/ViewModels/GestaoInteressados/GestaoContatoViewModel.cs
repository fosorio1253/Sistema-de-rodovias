using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DER.WebApp.ViewModels.GestaoInteressados
{
    public class GestaoContatoViewModel
    {
        #region Propriedades

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EmpresaId { get; set; }
        public virtual SelectList Empresas { get; set; }

        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        public string Cargo { get; set; }

        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        public string Nome { get; set; }

        [MaxLength(10, ErrorMessage = "O tamanho máximo é de 10 caracteres.")]
        public string Login { get; set; }

        [MaxLength(100, ErrorMessage = "O tamanho máximo é de 100 caracteres.")]
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string DDD { get; set; }

        public int EstadoId { get; set; }
        public virtual SelectList Estados { get; set; }

        #endregion

        #region Propriedade Complexas

        public virtual GestaoInteressadosViewModel GestaoInteressadosViewModel { get; set; }

        #endregion
    }
}