using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoDePassagemBLL
    {
        private TipoPassagemBLL tipoPassagemBLL;

        public TipoDePassagemBLL()
        {
            tipoPassagemBLL = new TipoPassagemBLL();
        }

        public List<GestaoOcupacoesTipoPassagemViewModel> ObtemTipoPassagens()
        {
            var retorno = new List<GestaoOcupacoesTipoPassagemViewModel>();
            tipoPassagemBLL.LoadView().ForEach(x => retorno.Add(new GestaoOcupacoesTipoPassagemViewModel() { TipoPassagemId = (int)x.TipoPassagemId, Nome = x.Nome }));
            return retorno;
        }
    }
}