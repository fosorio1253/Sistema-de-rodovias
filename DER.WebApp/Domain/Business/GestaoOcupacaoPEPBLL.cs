using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class GestaoOcupacaoPEPBLL
    {
        private PEPBLL PEPBLL;
        private AcoesJudiciaisBLL acoesJudiciaisBLL;

        public GestaoOcupacaoPEPBLL()
        {
            PEPBLL = new PEPBLL();
            acoesJudiciaisBLL = new AcoesJudiciaisBLL();
        }

        public bool Write(GestaoOcupacoesViewModel model)
        {
            try
            {
                var pep = GeneratePEP(model);
                return ValidarCampos(pep) ? PEPBLL.Save(pep) : false;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public List<GestaoOcupacoesPEPViewModel> Read(int? id = 0, bool ocupacao = false, bool interessado = false)
        {
            try
            {
                return ocupacao ?
                    PEPBLL.ExistsByOcupacao((int)id) ?
                        PEPBLL.ToList(PEPBLL.LoadByOcupacao((int)id)) :
                        PEPBLL.ToList(PEPBLL.LoadPadrao()) :
                    interessado ?
                        PEPBLL.ExistsByInteressado((int)id) ?
                            PEPBLL.ToList(PEPBLL.LoadByInteressado((int)id)) :
                            PEPBLL.ToList(PEPBLL.LoadPadrao()) :
                        id == null ?
                            new List<GestaoOcupacoesPEPViewModel>() :
                        PEPBLL.ExistsById((int)id) ?
                            PEPBLL.ToList(PEPBLL.LoadById((int)id)) :
                            PEPBLL.Load();
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesPEPViewModel>();
            }
        }

        private bool ValidarCampos(GestaoOcupacoesPEPViewModel model)
        {
            try
            {
                return 
                    model.Id_Interessado.Equals(0)  ||
                    model.Id_Ocupacao.Equals(0)     ||
                    model.Tipo_Ocupacao.Equals(0)   ||
                    acoesJudiciaisBLL.ValidarAcaoJudicialPEP(model.Id_Ocupacao)
                    ? true : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private GestaoOcupacoesPEPViewModel GeneratePEP(GestaoOcupacoesViewModel model)
        {
            try
            {
                var retorno = new GestaoOcupacoesPEPViewModel();
                retorno.Id_PEP                          = model.PEP.Id_PEP;
                retorno.Id_Interessado                  = model.PEP.Id_Interessado.Equals(0) ? model.InteressadoId : model.PEP.Id_Interessado;
                retorno.Id_Ocupacao                     = model.PEP.Id_Ocupacao.Equals(0) ? model.Id : model.PEP.Id_Ocupacao;
                retorno.Tipo_Ocupacao                   = model.PEP.Tipo_Ocupacao.Equals(0) ? model.TipoOcupacaoId : model.PEP.Tipo_Ocupacao;
                retorno.Comprovante                     = model.PEP.Comprovante ?? string.Empty;
                retorno.dataBaseCalculo                 = model.PEP.dataBaseCalculo ?? DateTime.Now.ToString();
                retorno.DataEmissãoPEP                  = model.PEP.DataEmissãoPEP ?? DateTime.Now;
                retorno.DataPagamento                   = model.PEP.DataPagamento ?? DateTime.Now.AddDays(30);
                retorno.Datavencimento                  = model.PEP.Datavencimento ?? DateTime.Now.AddDays(30);
                retorno.extensaoOcupacaoLongitudinal    = model.ListaTrecho.Where(x => x.NomeTipoImplantacao.Equals("Longitudinal")).Select(x => x.Extensao).Sum();
                retorno.extensaoOcupacaoPontual         = model.ListaTrecho.Where(x => x.NomeTipoImplantacao.Equals("Pontual")).Select(x => x.Extensao).Sum();
                retorno.extensaoOcupacaoTransversal     = model.ListaTrecho.Where(x => x.NomeTipoImplantacao.Equals("Transversal")).Select(x => x.Extensao).Sum();
                retorno.fatorRemuneracao                = PEPBLL.FatorRemuneracao();
                retorno.OcupacaoLongitudinal            = PEPBLL.CalcularLongitudinal(retorno.extensaoOcupacaoLongitudinal);
                retorno.OcupacaoPontual                 = PEPBLL.CalcularPontual(retorno.extensaoOcupacaoPontual);
                retorno.OcupacaoTransversal             = PEPBLL.CalcularTransversal(retorno.extensaoOcupacaoTransversal);
                retorno.Status                          = model.PEP.Status ?? "Pendente";
                retorno.totalCalculado                  = PEPBLL.CalcularPEP(retorno.OcupacaoLongitudinal, retorno.extensaoOcupacaoTransversal, retorno.extensaoOcupacaoPontual);
                retorno.UFESP                           = PEPBLL.UFESP();
                retorno.Valor                           = retorno.totalCalculado;

                return retorno;
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesPEPViewModel();
            }
        }
    }
}