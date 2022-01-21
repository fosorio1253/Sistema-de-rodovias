using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;


namespace DER.WebApp.Domain.Business
{
    public class NaturezaJuridicaBLL
    {
        private NaturezaJuridicasBLL naturezaJuridicasBLL;

        public NaturezaJuridicaBLL()
        {
            naturezaJuridicasBLL = new NaturezaJuridicasBLL();
        }

        public List<ViewModels.NaturezaJuridicaViewModel> ObtemNaturezaJuridica()
        {
            var retorno = new List<ViewModels.NaturezaJuridicaViewModel>();
            naturezaJuridicasBLL.LoadView().ForEach(x => retorno.Add(new ViewModels.NaturezaJuridicaViewModel() { NaturezaJuridicaId = x.NaturezaJuridicaId, Nome = x.Nome }));
            return retorno;
        }
    }
}