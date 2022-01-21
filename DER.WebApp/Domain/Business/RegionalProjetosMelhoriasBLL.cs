using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System.Collections.Generic;
using DER.WebApp.ViewModels.ProjetosMelhorias;

namespace DER.WebApp.Domain.Business
{
    public class RegionalProjetosMelhoriasBLL
    {
        private DivisaoRegionalBLL divisaoRegionalBLL;

        public RegionalProjetosMelhoriasBLL()
        {
            divisaoRegionalBLL = new DivisaoRegionalBLL();
        }

        public List<ProjetosMelhoriasRegionalViewModel> ObtemRegionais()
        {
            var retorno = new List<ProjetosMelhoriasRegionalViewModel>();
            divisaoRegionalBLL.LoadView().ForEach(x => retorno.Add(new ProjetosMelhoriasRegionalViewModel() { RegionalId = x.divisao_regional_id, Nome = x.descricao, Sigla = x.sigla }));
            return retorno;
        }
    }
}