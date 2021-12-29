using System;

namespace DER.WebApp.Domain.Models.DTO
{
    public class ListaGestaoOcorrenciaDTO
    {
        #region Propriedades
        public int Id { get; set; }
        public int InteressadoId { get; set; } //PODE SER NULO
        public string Interessado { get; set; } //PODE SER NULO
        public string Protocolo { get; set; }
        public string Documento { get; set; }
        public int TipoOcupacaoId { get; set; }
        public string TipoOcupacao { get; set; }
        public int TrechoId { get; set; }
        public int RodoviaId { get; set; }
        public string Rodovia { get; set; }
        public double KmInicial { get; set; }
        public double KmFinal { get; set; }
        public int LadoId { get; set; }
        public int ResidenciaConservacaoId { get; set; }
        public int RegionalId { get; set; }
        public string Regional { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public string Titulo { get; set; }
        public int AssuntoId { get; set; }
        public int StatusId { get; set; }
        public int SeveridadeId { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Apagado { get; set; }
        public string CodigoOcorrencia { get; set; }

        #endregion
    }
}