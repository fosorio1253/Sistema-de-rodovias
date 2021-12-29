using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.Financeiro.FaturamentoPorOcupacao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class InadimplentesViewBLL
    {
        private InadimplentesBLL inadimplentesBLL;
        private GestaoInteressadoBLL gestaoInteressadoBLL;

        public InadimplentesViewBLL()
        {
            inadimplentesBLL = new InadimplentesBLL();
            gestaoInteressadoBLL = new GestaoInteressadoBLL();
        }

        public bool Write(List<FaturamentoPorOcupacaoViewModel> lViewModel)
        {
            try
            {
                var lModel = PrepararViewModel(lViewModel);
                inadimplentesBLL.LoadView().TakeWhile(y => !lModel.Any(z => z.NomeInteressado.Equals(y.NomeInteressado))).ToList().ForEach(x => inadimplentesBLL.Remove(x));
                inadimplentesBLL.LoadView().TakeWhile(y => lModel.Any(z => z.NomeInteressado.Equals(y.NomeInteressado))).ToList().ForEach(x => inadimplentesBLL.Save(x));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<InadimplentesTabelaViewModel> Read(InadimplentesViewModel viewModel)
        {
            try
            {
                var retorno = new List<InadimplentesTabelaViewModel>();
                var model = inadimplentesBLL.LoadView();
                retorno = model;
                retorno = string.IsNullOrEmpty(viewModel.NomeInteressado)   ? retorno : model.Where(x => x.NomeInteressado.Equals(viewModel.NomeInteressado)).ToList();
                retorno = string.IsNullOrEmpty(viewModel.CpfCnpj)           ? retorno : model.Where(x => x.CpfCnjp.Equals(viewModel.CpfCnpj)).ToList();
                retorno = string.IsNullOrEmpty(viewModel.Protocolo)         ? retorno : model.Where(x => x.Protocolo.Equals(viewModel.Protocolo)).ToList();
                retorno = string.IsNullOrEmpty(viewModel.Processo)          ? retorno : model.Where(x => x.Processo.Equals(viewModel.Processo)).ToList();
                retorno = string.IsNullOrEmpty(viewModel.FiltroDias)        ? retorno : viewModel.FiltroDias.Equals("Todos") ? retorno : model.Where(x => x.Dias.Equals(Convert.ToInt32(viewModel.FiltroDias.Remove(2)))).ToList();
                retorno = viewModel.DataVenciemntoPrimeiro  == null         ? retorno : model.Where(x => x.DataVenciemntoPrimeiro.Equals(viewModel.DataVenciemntoPrimeiro)).ToList();
                retorno = viewModel.DataVenciemntoSegundo   == null         ? retorno : model.Where(x => x.DataVenciemntoSegundo.Equals(viewModel.DataVenciemntoSegundo)).ToList();
                retorno = viewModel.Periodo                 == null         ? retorno : model.Where(x => x.Periodo.Equals(viewModel.Periodo)).ToList();
                retorno = viewModel.Valor.Equals(0)                         ? retorno : model.Where(x => x.ValorTotal.Equals(viewModel.Valor)).ToList();
                retorno = string.IsNullOrEmpty(viewModel.FiltroValor)       ? retorno : viewModel.FiltroValor.Equals("Todos")  ? retorno : model.Where(x => viewModel.FiltroValor.Contains("Acima") ? x.ValorTotal > 600 : x.ValorTotal < 600).ToList();

                return retorno;
            }
            catch (Exception e)
            {
                return new List<InadimplentesTabelaViewModel>();
            }
        }

        private bool ValidarCampos(InadimplentesTabelaViewModel model)
        {
            try
            {
                return string.IsNullOrEmpty(model.NomeInteressado) ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private List<InadimplentesTabelaViewModel> PrepararViewModel(List<FaturamentoPorOcupacaoViewModel> model)
        {
            try
            {
                var lretorno = new List<InadimplentesTabelaViewModel>();
                model.ForEach(x =>
                {
                    var retorno = new InadimplentesTabelaViewModel();
                    retorno.NomeInteressado = x.Interessado;
                    retorno.CpfCnjp         = gestaoInteressadoBLL.ObtemId(Convert.ToInt32(x.InteressadoId)).Documento;
                    retorno.Processo        = x.Processo;
                    retorno.Protocolo       = x.Protocolo;
                    retorno.StatusBoleto    = x.Status;
                    retorno.TipoFaturamento = x.TipoFaturamento;
                    retorno.TipoOcupacao    = x.TipoOcupacao;
                    retorno.ValorPrevisto   = Convert.ToDecimal(x.ValorPrevisto);
                    retorno.ValorTotal      = Convert.ToDecimal(x.ValorTotal);
                    retorno.Dias            = (DateTime.Now - x.PeriodoInt).Value.Days.ToString();
                    retorno.Periodo         = x.PeriodoInt;
                    retorno.DataVenciemntoPrimeiro  = x.PeriodoInt;
                    retorno.DataVenciemntoSegundo   = x.PeriodoInt;

                    lretorno.Add(retorno);
                });

                return lretorno;
            }
            catch (Exception e)
            {
                return new List<InadimplentesTabelaViewModel>();
            }
        }
    }
}