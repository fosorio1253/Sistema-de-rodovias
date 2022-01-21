using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoDeImplantacaoBLL
    {
        private TipoImplantacaoBLL tipoImplantacaoBLL;

        public TipoDeImplantacaoBLL()
        {
            tipoImplantacaoBLL = new TipoImplantacaoBLL();
        }

        public List<GestaoOcupacoesTipoImplantacaoViewModel> ObtemTipoImplantacoes()
        {
            var retorno = new List<GestaoOcupacoesTipoImplantacaoViewModel>();
            tipoImplantacaoBLL.LoadView().ForEach(x => retorno.Add(new GestaoOcupacoesTipoImplantacaoViewModel() { TipoImplantacaoId = (int)x.TipoImplantacaoId, Nome = x.Nome }));
            return retorno;
        }
    }
}