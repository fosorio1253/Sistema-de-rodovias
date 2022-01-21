using DER.WebApp.Domain.Models;
using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.ProjetosMelhorias;
using System;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class RodoviaBLL
    {
        private RodoviasBLL rodoviasBLL;

        public RodoviaBLL()
        {
            rodoviasBLL = new RodoviasBLL();
        }

        public List<RodoviaViewModel> ObtemRodovia()
        {
            var retorno = new List<RodoviaViewModel>();
            rodoviasBLL.LoadView().ForEach(x => retorno.Add(new RodoviaViewModel() { RodoviaId = x.rodovia_id, Nome = x.Nome, rod_codigo = x.rod_codigo }));
            return retorno;
        }
    }
}