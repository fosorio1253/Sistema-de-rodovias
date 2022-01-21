using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoEmpresaBLL
    {
        private TipoEmpresasBLL tipoEmpresasBLL;

        public TipoEmpresaBLL()
        {
            tipoEmpresasBLL = new TipoEmpresasBLL();
        }

        public List<TipoEmpresaViewModel> ObtemTipoEmpresa()
        {
            var retorno = new List<TipoEmpresaViewModel>();
            tipoEmpresasBLL.LoadView().ForEach(x => retorno.Add(new TipoEmpresaViewModel() { TipoEmpresaId = x.TipoEmpresaId, Nome = x.Nome }));
            return retorno;
        }
    }
}