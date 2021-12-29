using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class GestaoOcupacaoRemuneracaoBLL
    {
        private RemuneracaoBLL remuneracaoBLL;
        private AcoesJudiciaisBLL acoesJudiciaisBLL;

        public GestaoOcupacaoRemuneracaoBLL()
        {
            remuneracaoBLL = new RemuneracaoBLL();
            acoesJudiciaisBLL = new AcoesJudiciaisBLL();
        }


        public bool Write(GestaoOcupacoesViewModel viewModel, int idremuneracao = 0)
        {
            try
            {
             

                var r = remuneracaoBLL.Load().Count.Equals(0) ?
                    ValidarCampos(GenerateModel(viewModel)) ?
                        remuneracaoBLL.Save(GenerateModel(viewModel)) :
                        false :
                    remuneracaoBLL.ExistsById(idremuneracao) ?
                        remuneracaoBLL.LoadById(idremuneracao).Liberado ?
                            remuneracaoBLL.Save(GenerateModel(viewModel, idremuneracao)) :
                            false :
                    idremuneracao.Equals(0) ?
                        remuneracaoBLL.Save(GenerateModel(viewModel)) :
                        false;
                return r;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<GestaoOcupacoesRemuneracaoViewModel> Read(int? id = 0, bool ocupacao = false)
        {
            try
            {
                return ocupacao ?
                    remuneracaoBLL.ExistsByOcupacao((int)id) ?
                        remuneracaoBLL.LoadByOcupacao((int)id) :
                        remuneracaoBLL.ToList(remuneracaoBLL.LoadPadrao()) :
                    id == null ?
                        new List<GestaoOcupacoesRemuneracaoViewModel>() :
                    remuneracaoBLL.ExistsById((int)id) ?
                        remuneracaoBLL.ToList(remuneracaoBLL.LoadById((int)id)) :
                        remuneracaoBLL.Load();
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesRemuneracaoViewModel>();
            }
        }

        private GestaoOcupacoesRemuneracaoViewModel GenerateModel(GestaoOcupacoesViewModel viewModel, int idremuneracao = 0)
        {
            try
            {
                var retorno = new GestaoOcupacoesRemuneracaoViewModel();

                retorno.IdGestaoOcupacoesRemuneracao = idremuneracao;
                retorno.ValorRemuneracao = remuneracaoBLL.CalcularRemuneracao(viewModel);
                retorno.DataRemuneracao = DateTime.Now;
                retorno.Descricao = viewModel.Observacao ?? "";
                retorno.Status = "Pendente";
                retorno.IdOcupacao = viewModel.Id;
                retorno.Liberado = idremuneracao > 0 ? true : false;

                return retorno;
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesRemuneracaoViewModel();
            }
        }

        private bool ValidarCampos(GestaoOcupacoesRemuneracaoViewModel model)
        {
            try
            {
                return
                    model.IdOcupacao.Equals(0) ||
                    acoesJudiciaisBLL.ValidarAcaoJudicialAnuidade(model.IdOcupacao)
                    ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool LiberarBoletoRemuneracao(int idocupacao, int idremuneracao)
        {
            try
            {
                var remuneracao = remuneracaoBLL.LoadByOcupacao(idocupacao).Where(x => x.IdGestaoOcupacoesRemuneracao.Equals(idremuneracao)).FirstOrDefault();
                remuneracao.Liberado = true;
                remuneracaoBLL.Save(remuneracao);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}