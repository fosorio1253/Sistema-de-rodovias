using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class LadoBLL
    {
        private LadosBLL ladosBLL;

        public LadoBLL()
        {
            ladosBLL = new LadosBLL();
        }

        public List<LadoViewModel> ObtemLados()
        {
            var retorno = new List<LadoViewModel>();
            ladosBLL.LoadView().ForEach(x => retorno.Add(new LadoViewModel() { LadoId = x.LadoId, Nome = x.Nome }));
            return retorno;
        }
    }
}