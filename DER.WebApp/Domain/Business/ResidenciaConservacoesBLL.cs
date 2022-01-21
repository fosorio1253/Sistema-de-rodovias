using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class ResidenciaConservacoesBLL
    {
        private ResidenciaConservacaoBLL residenciaConservacaoBLL;

        public ResidenciaConservacoesBLL()
        {
            residenciaConservacaoBLL = new ResidenciaConservacaoBLL();
        }

        public List<GestaoOcupacoesResidenciaConservacaoViewModel> ObtemResidenciaConservacoes()
        {
            var retorno = new List<GestaoOcupacoesResidenciaConservacaoViewModel>();
            residenciaConservacaoBLL.LoadView().ForEach(x => retorno.Add(new GestaoOcupacoesResidenciaConservacaoViewModel() { ResidenciaConservacaoId = x.residencia_conservacao_id, Nome = x.Nome }));
            return retorno;
        }
    }
}