using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class UnidadeGestaoOcupacaoBLL
    {
        private UnidadesBLL unidadesBLL;

        public UnidadeGestaoOcupacaoBLL()
        {
            unidadesBLL = new UnidadesBLL();
        }

        public List<GestaoOcupacoesUnidadeViewModel> ObtemUnidades()
        {
            var retorno = new List<GestaoOcupacoesUnidadeViewModel>();
            unidadesBLL.LoadView().ForEach(x => retorno.Add(new GestaoOcupacoesUnidadeViewModel() { UnidadeId = x.unidade_id, Nome = x.nome }));
            return retorno;
        }
    }
}