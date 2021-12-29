using DER.WebApp.ViewModels.Financeiro.Faturamento;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class FaturamentoBLL
    {
        private GestaoOcupacaoPEPBLL _PEP;
        private GestaoOcupacaoRemuneracaoBLL gestaoOcupacaoRemuneracaoBLL;
        private BancoBrasilBoletoBLL _Boleto;

        public FaturamentoBLL()
        {
            _PEP = new GestaoOcupacaoPEPBLL();
            gestaoOcupacaoRemuneracaoBLL = new GestaoOcupacaoRemuneracaoBLL();
            _Boleto = new BancoBrasilBoletoBLL();
        }

        public List<FaturamentoViewModel> ObterFaturamento(FaturamentoViewModelParams viewModel = null)
        {
            var lfaturamento = new List<FaturamentoViewModel>();
            PepToFaturamento().ForEach(x => lfaturamento.Add(x));
            RemuneracaoToFaturamento().ForEach(x => lfaturamento.Add(x));

            if (viewModel != null)
            {
                lfaturamento = viewModel.TipoFaturamento.Equals("Selecione") ? lfaturamento : lfaturamento.Where(x => x.TipoFaturamento.Equals(viewModel.TipoFaturamento)).ToList();
                lfaturamento = viewModel.Status.Equals("Selecione") ? lfaturamento : lfaturamento.Where(x => x.Status.Equals(viewModel.Status)).ToList();
                lfaturamento = viewModel.TipoOcupacao == null ? lfaturamento : lfaturamento.Where(x => x.TipoOcupacao.Equals(viewModel.TipoOcupacao)).ToList();
                lfaturamento = viewModel.ValorTotal.Equals(0) ? lfaturamento : lfaturamento.Where(x => x.ValorTotal.Equals(viewModel.ValorTotal)).ToList();
            }
            

            lfaturamento = lfaturamento.OrderByDescending(x => x.Periodo).ToList();
            return lfaturamento;
        }

        private List<FaturamentoViewModel> PepToFaturamento()
        {
            var lfaturamento = new List<FaturamentoViewModel>();
            _PEP.Read().ForEach(x =>
            {
                var faturamento = new FaturamentoViewModel();
                faturamento.TipoFaturamento = "PEP";
                faturamento.TipoOcupacao = "";//inserir o tipo
                faturamento.ValorTotal = (double)x.Valor;
                faturamento.Periodo = x.DataEmissãoPEP;
                faturamento.Status = _Boleto.ObterTodos().Where(y => y.TipoFaturamento.Equals(faturamento.TipoFaturamento) && y.IdFaturamento.Equals(x.Id_PEP)).Select(y => y.pago).FirstOrDefault() ? "Pago" : "Não Pago";

                lfaturamento.Add(faturamento);
            });

            return lfaturamento;
        }

        private List<FaturamentoViewModel> RemuneracaoToFaturamento()
        {
            var lfaturamento = new List<FaturamentoViewModel>();
            gestaoOcupacaoRemuneracaoBLL.Read().ForEach(x =>
            {
                var faturamento = new FaturamentoViewModel();
                faturamento.TipoFaturamento = "Anuidade";
                faturamento.TipoOcupacao = "";//inserir o tipo
                faturamento.ValorTotal = (double)x.ValorRemuneracao;
                faturamento.Periodo = x.DataRemuneracao;
                faturamento.Status = _Boleto.ObterTodos().Where(y => y.TipoFaturamento.Equals(faturamento.TipoFaturamento) && y.IdFaturamento.Equals(x.IdGestaoOcupacoesRemuneracao)).Select(y => y.pago).FirstOrDefault() ? "Pago" : "Não Pago";

                lfaturamento.Add(faturamento);
            });

            return lfaturamento;
        }
    }
}