using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoInteressadoBLL
    {
        private TipoInteressadosBLL tipoInteressadoBLL;

        public TipoInteressadoBLL()
        {
            tipoInteressadoBLL = new TipoInteressadosBLL();
        }

        public List<TipoInteressadoViewModel> ObtemTipoInteressado()
        {
            var retorno = new List<TipoInteressadoViewModel>();
            tipoInteressadoBLL.LoadView().ForEach(x => retorno.Add(new TipoInteressadoViewModel() { TipoInteressadoId = x.tipo_interessado_id, Nome = x.descricao }));
            return retorno;
        }
    }
}