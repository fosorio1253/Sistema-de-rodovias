using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class SituacaoDaOcupacaoBLL
    {
        private SituacaoOcupacaoBLL situacaoOcupacaoBLL;

        public SituacaoDaOcupacaoBLL()
        {
            situacaoOcupacaoBLL = new SituacaoOcupacaoBLL();
        }

        public List<GestaoOcupacoesSituacaoOcupacaoViewModel> ObtemSituacaoOcupacoes()
        {
            var retorno = new List<GestaoOcupacoesSituacaoOcupacaoViewModel>();
            situacaoOcupacaoBLL.LoadView().ForEach(x => retorno.Add(new GestaoOcupacoesSituacaoOcupacaoViewModel() { SituacaoOcupacaoId = x.SituacaoOcupacaoId, Nome = x.Nome }));
            return retorno;
        }
    }
}