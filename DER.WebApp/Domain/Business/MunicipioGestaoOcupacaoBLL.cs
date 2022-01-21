using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class MunicipioGestaoOcupacaoBLL
    {
        private MunicipiosBLL municipiosBLL;

        public MunicipioGestaoOcupacaoBLL()
        {
            municipiosBLL = new MunicipiosBLL();
        }

        public List<GestaoOcupacoesMunicipioViewModel> ObtemMunicipio()
        {
            var retorno = new List<GestaoOcupacoesMunicipioViewModel>();
            municipiosBLL.LoadView().ForEach(X => retorno.Add(new GestaoOcupacoesMunicipioViewModel() { MunicipioId = X.municipio_id, Nome = X.municipio }));
            return retorno;
        }
    }
}