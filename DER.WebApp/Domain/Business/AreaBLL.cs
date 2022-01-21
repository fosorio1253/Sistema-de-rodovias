using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class AreaBLL
    {
        private AreasBLL areasBLL;

        public AreaBLL()
        {
            areasBLL = new AreasBLL();
        }

        public List<AreaViewModel> ObtemAreas()
        {
            var retorno = new List<AreaViewModel>();
            retorno.Add(new AreaViewModel() { AreaId = 0, Nome = "Selecione" });
            areasBLL.LoadView().ForEach(x => retorno.Add(new AreaViewModel() { AreaId = x.AreaId, Nome = x.Nome }));
            return retorno;
        }
    }
}