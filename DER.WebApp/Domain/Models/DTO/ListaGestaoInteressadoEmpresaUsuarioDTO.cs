using System;

namespace DER.WebApp.Domain.Models.DTO
{
    public class ListaGestaoInteressadoEmpresaUsuarioDTO
    {
        #region Propriedades
        public int EmpresaId { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }      

        #endregion
    }
}