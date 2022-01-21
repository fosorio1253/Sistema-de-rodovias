using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class StatusBLL
    {
        private OcorrenciaStatusBLL ocorrenciaStatusBLL;

        public StatusBLL()
        {
            ocorrenciaStatusBLL = new OcorrenciaStatusBLL();
        }

        public List<ViewModels.StatusOcorrenciaViewModel> ObtemStatus()
        {
            var retorno = new List<ViewModels.StatusOcorrenciaViewModel>();
            ocorrenciaStatusBLL.LoadView().ForEach(x => retorno.Add(new ViewModels.StatusOcorrenciaViewModel() { StatusId = x.ocorrencia_status_id, Nome = x.nome }));
            return retorno;
        }
    }
}