namespace DER.WebApp.Domain.Models
{
    public class GestaoInteressadoEndereco
    {
        #region Propriedades

        public int Id { get; set; }
        public int GestaoInteressadoId { get; set; }
        public int UnidadeId { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int MunicipioId { get; set; }
        public string NomeDoContato { get; set; }
        public bool? Principal { get; set; }

        #endregion

        #region Propriedades Complexas

        public virtual GestaoInteressado GestaoInteressado { get; set; }
        public virtual DadosMestresValores Municipio { get; set; }
        public virtual DadosMestresValores Unidade { get; set; }

        #endregion
    }
}