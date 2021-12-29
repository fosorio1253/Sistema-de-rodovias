using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;

namespace DER.WebApp.Domain.Business
{
    public class GestaoOcupacaoAcoesJudiciaisBLL
    {
        private AcoesJudiciaisBLL acoesJudiciaisBLL;

        public GestaoOcupacaoAcoesJudiciaisBLL()
        {
            acoesJudiciaisBLL = new AcoesJudiciaisBLL();
        }

        public bool Write(GestaoOcupacoesAcoesJudiciaisViewModel viewModel)
        {
            try
            {
                return ValidarCampos(viewModel) ? acoesJudiciaisBLL.Save(viewModel) : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<GestaoOcupacoesAcoesJudiciaisViewModel> Read(int id = 0, bool ocupacao = false, bool interessado = false)
        {
            try
            {
                return ocupacao ?
                    acoesJudiciaisBLL.ExistsByOcupacao((int)id) ?
                        acoesJudiciaisBLL.ToList(acoesJudiciaisBLL.LoadByOcupacao((int)id)) :
                        acoesJudiciaisBLL.ToList(acoesJudiciaisBLL.LoadPadrao()) :
                    interessado ?
                        acoesJudiciaisBLL.ExistsByInteressado((int)id) ?
                            acoesJudiciaisBLL.ToList(acoesJudiciaisBLL.LoadByInteressado((int)id)) :
                            acoesJudiciaisBLL.ToList(acoesJudiciaisBLL.LoadPadrao()) :
                        acoesJudiciaisBLL.ExistsById(id) ?
                            acoesJudiciaisBLL.ToList(acoesJudiciaisBLL.LoadById(id)) :
                            acoesJudiciaisBLL.Load();
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesAcoesJudiciaisViewModel>();
            }
        }

        private bool ValidarCampos(GestaoOcupacoesAcoesJudiciaisViewModel model)
        {
            try
            {
                return
                    model.IdInteressado.Equals(0)   ||
                    model.IdOcupacao.Equals(0)      ||
                    model.IdRodovia.Equals(0)       ||
                    model.IdTipoOcupacao.Equals(0)
                    ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}