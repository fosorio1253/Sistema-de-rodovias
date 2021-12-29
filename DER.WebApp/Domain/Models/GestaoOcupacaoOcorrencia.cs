using System;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacaoOcorrencia
    {
        #region Propriedades

        public int Id { get; set; }
        public int GestaoOcupacaoId { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Autor { get; set; }
        public string Area { get; set; }
        public int AreaId { get; set; }
        public string Ocorrencia { get; set; }
        #endregion

        #region Propriedades Complexas

        public virtual GestaoOcupacao GestaoOcupacao { get; set; }
        public virtual DadosMestresValores Areas { get; set; }

        #endregion
    }
}