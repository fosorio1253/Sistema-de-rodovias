using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TrechosBLL
    {
        private OcorrenciaTrechoBLL ocorrenciaTrechoBLL;

        public TrechosBLL()
        {
            ocorrenciaTrechoBLL = new OcorrenciaTrechoBLL();
        }

        public List<ViewModels.TrechoViewModel> ObtemTrechos()
        {
            var retorno = new List<ViewModels.TrechoViewModel>();
            ocorrenciaTrechoBLL.LoadView().ForEach(x => retorno.Add(new ViewModels.TrechoViewModel() { TrechoId = x.ocorrencia_trecho_id, Nome = x.nome }));
            return retorno;
        }
    }
}