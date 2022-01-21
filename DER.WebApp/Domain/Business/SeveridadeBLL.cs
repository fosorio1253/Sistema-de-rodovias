using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class SeveridadeBLL
    {
        private OcorrenciaSeveridadeBLL ocorrenciaSeveridadeBLL;

        public SeveridadeBLL()
        {
            ocorrenciaSeveridadeBLL = new OcorrenciaSeveridadeBLL();
        }

        public List<ViewModels.SeveridadesViewModel> ObtemSeveridades()
        {
            var retorno = new List<ViewModels.SeveridadesViewModel>();
            ocorrenciaSeveridadeBLL.LoadView().ForEach(x => retorno.Add(new ViewModels.SeveridadesViewModel() { SeveridadeId = x.ocorrencia_severidade_id, Nome = x.nome }));
            return retorno;
        }
    }
}