using DER.WebApp.Domain.Models.Enum;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class TipoOcupacoesBLL
    {
        private TipoOcupacaoBLL tipoOcupacaoBLL;

        public TipoOcupacoesBLL()
        {
            tipoOcupacaoBLL = new TipoOcupacaoBLL();
        }

        public List<TipoDeOcupacaoViewModel> ObtemTipoOcupacoes()
        {
            var retorno = new List<TipoDeOcupacaoViewModel>();
            tipoOcupacaoBLL.LoadView().ForEach(x => retorno.Add(new TipoDeOcupacaoViewModel()
            {
                TipoOcupacaoId = x.tipo_ocupacao_id,
                Nome = x.nome
            }));
            return retorno;
        }
    }
}