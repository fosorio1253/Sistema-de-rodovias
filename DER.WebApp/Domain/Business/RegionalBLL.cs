using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class RegionalBLL
    {
        private RegionalsBLL regionalsBLL;

        public RegionalBLL()
        {
            regionalsBLL = new RegionalsBLL();
        }

        public List<RegionalViewModel> ObtemRegionais()
        {
            var retorno = new List<RegionalViewModel>();
            regionalsBLL.LoadView().ForEach(x => retorno.Add(new RegionalViewModel() { RegionalId = x.RegionalId, Nome = x.Nome }));
            return retorno;
        }
    }
}