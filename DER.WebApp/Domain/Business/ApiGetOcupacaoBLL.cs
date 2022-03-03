using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class ApiGetOcupacaoBLL
    {
        private GestaoOcupacaoBLL gestaoOcupacaoBLL;
        private SituacaoOcupacaoBLL situacaoOcupacaoBLL;

        public ApiGetOcupacaoBLL()
        {
            gestaoOcupacaoBLL = new GestaoOcupacaoBLL();
            situacaoOcupacaoBLL = new SituacaoOcupacaoBLL();
        }

        public List<ApiGetOcupacaoRetornoViewModel> BuscarApiGetOcupacao(int cod_rod, double km_inicial, double km_final)
        {
            try
            {
                return gestaoOcupacaoBLL.GetListGestaoOcupacaoComTrecho()
                    .Where(X => X.Trechos.Any(y => 
                        y.IdRodovia.Equals(cod_rod.Equals(0) ? y.IdRodovia : cod_rod) &&
                        y.KmInicial >= (decimal)km_inicial &&
                        y.KmFinal <= (km_final.Equals(0) ? y.KmFinal : (decimal)km_final)))
                    .Select(x => x.Trechos.Select(y => new ApiGetOcupacaoRetornoViewModel()
                    {
                        numero_termo = Convert.ToInt32(x.NumeroProcesso),
                        interessado = x.Interessado,
                        situacao = situacaoOcupacaoBLL.LoadView().Where(z => z.SituacaoOcupacaoId.Equals(x.SituacaoOcupacaoId)).FirstOrDefault().Nome,
                        tipo_de_implantacao = y.TipoImplantacao.Nome,
                        tipo_de_ocupacao = y.TipoOcupacao.nome,
                        lado = y.Lado.Nome,
                        km_inicial = (double)y.KmInicial,
                        km_final = (double)y.KmFinal,
                        altura_da_ocupacao_aerea = (double)y.Altura,
                        profundidade_da_ocupacao_subterranea = (double)y.Profundidade
                    })).FirstOrDefault().ToList();
            }
            catch(Exception e)
            {
                return new List<ApiGetOcupacaoRetornoViewModel>();
            }
        }
    }
}