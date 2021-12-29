using DER.WebApp.Models.Enum;
using System;

namespace DER.WebApp.Domain.Models.DTO
{
    public class ListaArquivosDTO
    {
        #region Propriedades
        public int Id { get; set; }
        public bool Apagado { get; set; }
        public string ArquivoNome { get; set; }
        public string Extensao { get; set; }
        public TipoArquivoEnum TipoArquivo { get; set; }
        public string Documento { get; set; }
        public int TipoInteressado { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public int UsuarioId { get; set; }

        #endregion
    }
}