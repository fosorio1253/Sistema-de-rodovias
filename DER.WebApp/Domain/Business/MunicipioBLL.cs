using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoInteressados;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class MunicipioBLL
    {
        private MunicipiosBLL municipiosBLL;

        public MunicipioBLL()
        {
            municipiosBLL = new MunicipiosBLL();
        }

        public List<ViewModels.MunicipioViewModel> ObtemMunicipio()
        {
            return municipiosBLL.LoadView();
        }
    }
}