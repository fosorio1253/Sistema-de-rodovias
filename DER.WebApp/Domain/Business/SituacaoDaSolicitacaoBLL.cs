using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class SituacaoDaSolicitacaoBLL
    {
        private SituacaoSolicitacaoBLL situacaoSolicitacaoBLL;

        public SituacaoDaSolicitacaoBLL()
        {
            situacaoSolicitacaoBLL = new SituacaoSolicitacaoBLL();
        }

        public List<GestaoOcupacoesSituacaoSolicitacaoViewModel> ObtemSituacaoSolicitacoes()
        {
            var retorno = new List<GestaoOcupacoesSituacaoSolicitacaoViewModel>();
            situacaoSolicitacaoBLL.LoadView().ForEach(x => retorno.Add(new GestaoOcupacoesSituacaoSolicitacaoViewModel() { SituacaoSolicitacaoId = x.SituacaoSolicitacaoId, Nome = x.Nome }));
            return retorno;
        }
    }
}