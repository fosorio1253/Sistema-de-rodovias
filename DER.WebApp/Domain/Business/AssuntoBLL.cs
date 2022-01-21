using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class AssuntoBLL
    {
        private AssuntosBLL assuntosBLL;

        public AssuntoBLL()
        {
            assuntosBLL = new AssuntosBLL();
        }

        public List<ViewModels.AssuntosViewModel> ObtemAssuntos()
        {
            var retorno = new List<ViewModels.AssuntosViewModel>();
            assuntosBLL.LoadView().ForEach(x => retorno.Add(new ViewModels.AssuntosViewModel() { AssuntoId = x.assunto_id, Nome = x.nome }));
            return retorno;
        }
    }
}