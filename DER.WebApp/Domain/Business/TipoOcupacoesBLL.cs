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

        public List<TipoOcupacaoViewModel> ObtemTipoOcupacoes()
        {
            var retorno = new List<TipoOcupacaoViewModel>();
            tipoOcupacaoBLL.LoadView().ForEach(x => retorno.Add(new TipoOcupacaoViewModel()
            {
                tipo_ocupacao_id = x.tipo_ocupacao_id,
                nome = x.nome,
                altura_minima = x.altura_minima,
                profundidade_minima = x.profundidade_minima
            }));
            return retorno;
        }
    }
}