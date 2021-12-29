using System;

namespace DER.WebApp.Domain.Models.DTO
{
    public class ListaProjetosMelhoriasDTO
    {
        #region Propriedades
        public int Id { get; set; }
        public string Regional { get; set; }
        public string Municipio { get; set; }
        public string Rodovia { get; set; }
        public string Nome { get; set; }
        public double KmInicial { get; set; }
        public double KmFinal { get; set; }
        public double Extensao { get; set; }
        public string Sentido { get; set; }
        public int LadoId { get; set; }
        public string Lote { get; set; }
        public string Status { get; set; }
        public string NumeroContrato { get; set; }
        public string Prazo { get; set; }
        public string PrevisaoInicio { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string UnidadeConservacao { get; set; }
        #endregion
    }
}