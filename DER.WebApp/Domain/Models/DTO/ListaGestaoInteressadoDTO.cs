using System;

namespace DER.WebApp.Domain.Models.DTO
{
    public class ListaGestaoInteressadoDTO
    {
        #region Propriedades
        public int Id { get; set; }
        public string Interessado { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
        public string Tipo { get; set; }
        public string Natureza { get; set; }
        public DateTime? Validade { get; set; }
        public string Status { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public DateTime? DataCadastro { get; set; }
        public int UsuarioId { get; set; }

        #endregion
    }
}