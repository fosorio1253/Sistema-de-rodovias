using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class OrigemDaSolicitacaoBLL
    {
        private OrigemSolicitacaoBLL origemSolicitacaoBLL;

        public OrigemDaSolicitacaoBLL()
        {
            origemSolicitacaoBLL = new OrigemSolicitacaoBLL();
        }

        public List<GestaoOcupacoesOrigemSolicitacaoViewModel> ObtemOrigemSolicitacoes()
        {
            var retorno = new List<GestaoOcupacoesOrigemSolicitacaoViewModel>();
            origemSolicitacaoBLL.LoadView().ForEach(x => retorno.Add(new GestaoOcupacoesOrigemSolicitacaoViewModel() { OrigemSolicitacaoId = x.origem_da_solicitacao_id, Nome = x.nome }));
            return retorno;
        }
    }
}