using System.Collections.Generic;

namespace DER.WebApp.Domain.Models
{
    public class GestaoOcupacaoStatusDocumento
    {
        #region Propriedades

        public int StatusId { get; set; }
        public string Nome { get; set; }

        public List<GestaoOcupacaoStatusDocumento> ListaStatusDocumentos()

        {
            return new List<GestaoOcupacaoStatusDocumento>
            {

                new GestaoOcupacaoStatusDocumento { StatusId = 1, Nome = "Em Análise"},

                new GestaoOcupacaoStatusDocumento { StatusId = 2, Nome = "Deferido"},

                new GestaoOcupacaoStatusDocumento { StatusId = 3, Nome = "Indeferido" },

                new GestaoOcupacaoStatusDocumento { StatusId = 4, Nome = "Não Autorizado" },

                new GestaoOcupacaoStatusDocumento { StatusId = 5, Nome = "Cancelado" },

                new GestaoOcupacaoStatusDocumento { StatusId = 6, Nome = "Válido" },

                new GestaoOcupacaoStatusDocumento { StatusId = 7, Nome = "Inválido" }               

            };

        }
        #endregion

        #region Propriedades Complexas

        //public virtual GestaoOcupacao GestaoOcupacao { get; set; }

        #endregion
    }
}