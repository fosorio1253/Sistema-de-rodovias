using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoDeInterferenciaBLL
    {
        private TipoInterferenciaBLL tipoInterferenciaBLL;

        public TipoDeInterferenciaBLL()
        {
            tipoInterferenciaBLL = new TipoInterferenciaBLL();
        }

        public List<TipoDeInterferenciaViewModel> ObtemTipoDeInterferencias()
        {
            var retorno = new List<TipoDeInterferenciaViewModel>();
            tipoInterferenciaBLL.LoadView().ForEach(x => retorno.Add(new TipoDeInterferenciaViewModel() { TipoDeInterferenciaId = (int)x.TipoInterferenciaId, Nome = x.Nome }));
            return retorno;
        }
    }
}