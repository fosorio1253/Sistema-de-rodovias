using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class UnidadeBLL
    {
        private UnidadesBLL unidadesBLL;

        public UnidadeBLL()
        {
            unidadesBLL = new UnidadesBLL();
        }

        public List<ViewModels.UnidadeViewModel> ObtemUnidades()
        {
            var retorno = new List<ViewModels.UnidadeViewModel>();
            unidadesBLL.LoadView().ForEach(x => retorno.Add(new ViewModels.UnidadeViewModel() { unidade_id = x.unidade_id, nome = x.nome }));
            return retorno;
        }
    }
}