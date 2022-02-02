using DER.WebApp.Models.Enum;
using DER.WebApp.ViewModels.Financeiro.FaturamentoPorOcupacao;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class FaturamentoOcupacaoBLL
    {
        private GestaoOcupacaoPEPBLL _PEP;
        private GestaoOcupacaoRemuneracaoBLL gestaoOcupacaoRemuneracaoBLL;
        private AcoesJudiciaisBLL acoesJudiciaisBLL;
        private BancoBrasilBoletoBLL _Boleto;
        private GestaoOcupacaoBLL _Ocupacao;
        private TipoOcupacaoBLL tipoOcupacaoBLL;

        public FaturamentoOcupacaoBLL()
        {
            _PEP = new GestaoOcupacaoPEPBLL();
            gestaoOcupacaoRemuneracaoBLL = new GestaoOcupacaoRemuneracaoBLL();
            acoesJudiciaisBLL = new AcoesJudiciaisBLL();
            _Boleto = new BancoBrasilBoletoBLL();
            _Ocupacao = new GestaoOcupacaoBLL();
            tipoOcupacaoBLL = new TipoOcupacaoBLL();
        }

        public List<FaturamentoPorOcupacaoViewModel> ObterFaturamento(FaturamentoPorOcupacaoViewModelParam viewModel = null)
        {
            viewModel.Termo = string.Empty;//Falta retorno do cliente para implementação - Termo
            var lfaturamento = new List<FaturamentoPorOcupacaoViewModel>();
            PepToFaturamento().ForEach(x => lfaturamento.Add(x));
            RemuneracaoToFaturamento().ForEach(x => lfaturamento.Add(x));
            var result = viewModel == null ? lfaturamento : Filtrar(lfaturamento, viewModel);
            return result;
        }

        public List<FaturamentoPorOcupacaoViewModel> ObterFaturamentoInadimplentes()
        {
            var lfaturamento = new List<FaturamentoPorOcupacaoViewModel>();
            PepToFaturamento().ForEach(x => lfaturamento.Add(x));
            RemuneracaoToFaturamento().ForEach(x => lfaturamento.Add(x));
            return lfaturamento.Where(x => x.PeriodoInt < DateTime.Now).ToList();
        }

        private List<FaturamentoPorOcupacaoViewModel> Filtrar(List<FaturamentoPorOcupacaoViewModel> lfaturamento, FaturamentoPorOcupacaoViewModelParam viewModel)
        {
            if (!viewModel.TrechoConcedido.Equals("Todos")) lfaturamento = lfaturamento.Where(x => x.TrechoConcedido.Equals(viewModel.TrechoConcedido)).ToList();
            if (!viewModel.AcoesJudiciais.Equals("Todos")) lfaturamento = lfaturamento.Where(x => x.AcoesJudiciais.Equals(viewModel.AcoesJudiciais)).ToList();
            if (!viewModel.ValorTotal.Equals(0)) lfaturamento = lfaturamento.Where(x => x.ValorTotal.Equals(viewModel.ValorTotal)).ToList();
            if (!viewModel.RodoviaId.Equals(0)) lfaturamento = lfaturamento.Where(x => x.RodoviaId.Equals(viewModel.RodoviaId)).ToList();
            if (!viewModel.KmInicial.Equals(0)) lfaturamento = lfaturamento.Where(x => x.KmInicial > viewModel.KmInicial).ToList();
            if (!viewModel.KmFinal.Equals(0)) lfaturamento = lfaturamento.Where(x => x.KmFinal < viewModel.KmFinal).ToList();
            if (!string.IsNullOrWhiteSpace(viewModel.TipoOcupacao)) lfaturamento = lfaturamento.Where(x => x.TipoOcupacaoId.Equals(viewModel.TipoOcupacao)).ToList();
            if (!string.IsNullOrWhiteSpace(viewModel.InteressadoId)) lfaturamento = lfaturamento.Where(x => x.InteressadoId.Equals(viewModel.InteressadoId)).ToList();
            if (!string.IsNullOrWhiteSpace(viewModel.Regional)) lfaturamento = lfaturamento.Where(x => x.Regional.Equals(viewModel.Regional)).ToList();
            if (!string.IsNullOrWhiteSpace(viewModel.ResidenciaConservacao)) lfaturamento = lfaturamento.Where(x => x.Residencia.Equals(viewModel.ResidenciaConservacao)).ToList();
            if (!string.IsNullOrWhiteSpace(viewModel.Protocolo)) lfaturamento = lfaturamento.Where(x => x.Protocolo.Equals(viewModel.Protocolo)).ToList();
            if (!string.IsNullOrWhiteSpace(viewModel.Processo)) lfaturamento = lfaturamento.Where(x => x.Processo.Equals(viewModel.Processo)).ToList();
            if (!string.IsNullOrWhiteSpace(viewModel.Termo)) lfaturamento = lfaturamento.Where(x => x.Termo.Equals(viewModel.Termo)).ToList();
            if (viewModel.DataInicial.HasValue) lfaturamento = lfaturamento.Where(x => x.PeriodoInt > viewModel.DataInicial).ToList();
            if (viewModel.DataFinal.HasValue) lfaturamento = lfaturamento.Where(x => x.PeriodoInt < viewModel.DataFinal).ToList();

            if (!viewModel.TipoFaturamentoAnuidade) lfaturamento = lfaturamento.Where(x => !x.TipoFaturamento.Equals("Anuidade")).ToList();
            if (!viewModel.TipoFaturamentoPEP) lfaturamento = lfaturamento.Where(x => !x.TipoFaturamento.Equals("PEP")).ToList();
            if (!viewModel.TipoFaturamentoRegularizacao) lfaturamento = lfaturamento.Where(x => !x.TipoFaturamento.Equals("Regularizacao")).ToList();
            if (!viewModel.TipoFaturamentoJuridica) lfaturamento = lfaturamento.Where(x => !x.TipoFaturamento.Equals("Juridica")).ToList();

            if (!viewModel.StatusPago) lfaturamento = lfaturamento.Where(x => !x.Status.Equals("Pago")).ToList();
            if (!viewModel.StatusPendente) lfaturamento = lfaturamento.Where(x => !x.Status.Equals("Pendente")).ToList();
            if (!viewModel.StatusVencido) lfaturamento = lfaturamento.Where(x => !x.Status.Equals("Vencido")).ToList();

            lfaturamento = lfaturamento.OrderByDescending(x => x.PeriodoInt).ToList();
            return lfaturamento;
        }

        private List<FaturamentoPorOcupacaoViewModel> PepToFaturamento()
        {
            var lfaturamento = new List<FaturamentoPorOcupacaoViewModel>();

            foreach (var pep in _PEP.Read())
            {
                var ocupacao = _Ocupacao.ObtemInfoId(pep.Id_Interessado);
                var faturamento = new FaturamentoPorOcupacaoViewModel();
                faturamento.TipoFaturamento     = "PEP";
                faturamento.TipoOcupacaoId      = ocupacao.Trechos.Count.Equals(0) ? "" : ocupacao.Trechos.First().TipoOcupacaoId.ToString();
                faturamento.TipoOcupacao        = tipoOcupacaoBLL.LoadView().Where(x => x.tipo_ocupacao_id.Equals(string.IsNullOrEmpty(faturamento.TipoOcupacaoId) ? 0 : Convert.ToInt32(faturamento.TipoOcupacaoId))).Select(x => x.nome).FirstOrDefault();
                faturamento.ValorTotal          = (double)pep.Valor;
                faturamento.ValorPrevisto       = (double)pep.Valor + ((double)pep.Valor / 100 * 10.20);//ajustar calculo
                faturamento.PeriodoInt          = pep.DataEmissãoPEP;
                faturamento.Periodo             = $@"{pep.DataEmissãoPEP.Value.Day}/{pep.DataEmissãoPEP.Value.Month}/{pep.DataEmissãoPEP.Value.Year}";
                faturamento.Status              = pep.Status;
                faturamento.InteressadoId       = ocupacao.InteressadoId.ToString();
                faturamento.Interessado         = ocupacao.Interessado;
                faturamento.Regional            = ocupacao.RegionalId.ToString();
                faturamento.Residencia          = ocupacao.ResidenciaConservacaoId.ToString();
                faturamento.Protocolo           = ocupacao.NumeroSPDOC;
                faturamento.Processo            = ocupacao.NumeroProcesso;
                faturamento.KmInicial           = ocupacao.Trechos.Count.Equals(0) ? 0 : (double)ocupacao.Trechos.Min(x => x.KmInicial);
                faturamento.KmFinal             = ocupacao.Trechos.Count.Equals(0) ? 0 : (double)ocupacao.Trechos.Max(x => x.KmInicial);
                faturamento.RodoviaId           = ocupacao.RodoviaId ?? 0;
                faturamento.TrechoConcedido     = ocupacao.SituacaoSolicitacaoId.Equals(SituacaoSolicitacaoIdEnum.deferido.GetHashCode()) ? "Sim" : "Não";
                faturamento.AcoesJudiciais      = acoesJudiciaisBLL.ValidarAcaoJudicialPEP(ocupacao.Id) ? "Sim" : "Não";
                faturamento.Termo               = "";//Falta retorno do cliente para implementação - Termo

                lfaturamento.Add(faturamento);
            }

            return lfaturamento;
        }

        private List<FaturamentoPorOcupacaoViewModel> RemuneracaoToFaturamento()
        {
            var lfaturamento = new List<FaturamentoPorOcupacaoViewModel>();
            foreach (var rem in gestaoOcupacaoRemuneracaoBLL.Read())
            {
                var ocupacao = _Ocupacao.ObtemInfoId(rem.IdOcupacao);
                var faturamento = new FaturamentoPorOcupacaoViewModel();
                faturamento.TipoFaturamento = "Anuidade";
                faturamento.TipoOcupacaoId  = ocupacao.Trechos.Count.Equals(0) ? "" : ocupacao.Trechos.First().TipoOcupacaoId.ToString();
                faturamento.TipoOcupacao    = tipoOcupacaoBLL.LoadView().Where(x => x.tipo_ocupacao_id.Equals(Convert.ToInt32(faturamento.TipoOcupacaoId))).Select(x => x.nome).FirstOrDefault();
                faturamento.ValorTotal      = (double)rem.ValorRemuneracao;
                faturamento.ValorPrevisto   = (double)rem.ValorRemuneracao + ((double)rem.ValorRemuneracao / 100 * 10.20);//ajustar calculo
                faturamento.PeriodoInt      = rem.DataRemuneracao;
                faturamento.Periodo         = $@"{rem.DataRemuneracao.Value.Day}/{rem.DataRemuneracao.Value.Month}/{rem.DataRemuneracao.Value.Year}";
                faturamento.Status          = rem.Status;
                faturamento.InteressadoId   = ocupacao.InteressadoId.ToString();
                faturamento.Interessado     = ocupacao.Interessado;
                faturamento.Regional        = ocupacao.RegionalId.ToString();
                faturamento.Residencia      = ocupacao.ResidenciaConservacaoId.ToString();
                faturamento.Protocolo       = ocupacao.NumeroSPDOC;
                faturamento.Processo        = ocupacao.NumeroProcesso;
                faturamento.KmInicial       = ocupacao.Trechos.Count.Equals(0) ? 0 : (double)ocupacao.Trechos.Min(x => x.KmInicial);
                faturamento.KmFinal         = ocupacao.Trechos.Count.Equals(0) ? 0 : (double)ocupacao.Trechos.Max(x => x.KmInicial);
                faturamento.RodoviaId       = ocupacao.RodoviaId ?? 0;
                faturamento.TrechoConcedido = ocupacao.SituacaoSolicitacaoId.Equals(SituacaoSolicitacaoIdEnum.deferido.GetHashCode()) ? "Sim" : "Não";
                faturamento.AcoesJudiciais  = acoesJudiciaisBLL.ValidarAcaoJudicialAnuidade(ocupacao.Id) ? "Sim" : "Não";
                faturamento.Termo           = "";//Falta retorno do cliente para implementação - Termo

                lfaturamento.Add(faturamento);
            }

            return lfaturamento;
        }
    }
}
