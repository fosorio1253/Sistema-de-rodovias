using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class PEPBLL
    {
        private DerContext _context;
        private DadosMestresDAO dadosMestresDAO;
        private GestaoOcupacoesPEPDAO gestaoOcupacoesPEPDAO;

        #region Calculos
        //Longitudinal
        private Func<decimal, decimal> calcLC = (F) => F * (decimal)0.5; //até 100m
        private Func<decimal, decimal, decimal> calcLM = (F, E) => (decimal)0.45 * F + ((decimal)0.55 * E); //até 1000m
        private Func<decimal, decimal, decimal> calcLX = (F, E) => F * (decimal)Math.Pow((double)E, 0.55); //até 10000m
        private Func<decimal, decimal, decimal> calcLS = (F, E) => (decimal)0.55 * F * (decimal)Math.Pow((double)E, 0.80); //acima de 10000m
        //Transversal
        private Func<decimal, decimal> calcTC = (F) => F * (decimal)0.5;//até 100m
        private Func<decimal, decimal, decimal> calcTS = (F, E) => (decimal)0.45 * F + ((decimal)0.55 * E); //acima de 100m
        //Pontual
        private Func<decimal, decimal> calcPC = (F) => F * (decimal)0.5;//até 100m
        private Func<decimal, decimal, decimal> calcPS = (F, E) => (decimal)0.45 * F + ((decimal)0.55 * F * E / 1000); //acima de 100m
        #endregion

        public PEPBLL()
        {
            _context = new DerContext();
            dadosMestresDAO = new DadosMestresDAO(_context);
            gestaoOcupacoesPEPDAO = new GestaoOcupacoesPEPDAO(_context);
        }

        public decimal CalcularPEP(decimal extensaoLongitudinal, decimal extensaoTransversal, decimal extensaoPontual)
        {
            try
            {
                return CalcularLongitudinal(extensaoLongitudinal) + CalcularTransversal(extensaoTransversal) + CalcularPontual(extensaoPontual);
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        public decimal CalcularLongitudinal(decimal extensaoLongitudinal)
        {
            try
            {
                var fatorRemuneracao = FatorRemuneracao();
                return extensaoLongitudinal > 0 ? extensaoLongitudinal <= 100 ?
                    calcLC(fatorRemuneracao) : extensaoLongitudinal <= 1000 ?
                    calcLM(fatorRemuneracao, extensaoLongitudinal) : extensaoLongitudinal <= 10000 ?
                    calcLX(fatorRemuneracao, extensaoLongitudinal) : calcLS(fatorRemuneracao, extensaoLongitudinal) : 0;
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        public decimal CalcularTransversal(decimal extensaoTransversal)
        {
            try
            {
                var fatorRemuneracao = FatorRemuneracao();
                return extensaoTransversal > 0 ? extensaoTransversal <= 100 ?
                calcTC(fatorRemuneracao) : calcTS(fatorRemuneracao, extensaoTransversal) : 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public decimal CalcularPontual(decimal extensaoPontual)
        {
            try
            {
                var fatorRemuneracao = FatorRemuneracao();
                return extensaoPontual > 0 ? extensaoPontual <= 100 ?
                calcPC(fatorRemuneracao) : calcPS(fatorRemuneracao, extensaoPontual) : 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public bool Save(GestaoOcupacoesPEPViewModel viewModel)
        {
            try
            {
                return ExistsById(viewModel.Id_PEP) ?
                    gestaoOcupacoesPEPDAO.Update(ViewModelToModel(viewModel)) :
                    gestaoOcupacoesPEPDAO.Inserir(ViewModelToModel(viewModel));
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        public List<GestaoOcupacoesPEPViewModel> Load()
        {
            try
            {
                return gestaoOcupacoesPEPDAO.ObtemTodos().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesPEPViewModel>();
            }
        }

        public GestaoOcupacoesPEPViewModel LoadById(int id)
        {
            try
            {
                return Load().Where(x => x.Id_PEP.Equals(id)).FirstOrDefault();
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesPEPViewModel();
            }
        }

        public GestaoOcupacoesPEPViewModel LoadByOcupacao(int id)
        {
            try
            {
                return Load().Where(x => x.Id_Interessado.Equals(id)).FirstOrDefault();
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesPEPViewModel();
            }
        }

        public GestaoOcupacoesPEPViewModel LoadByInteressado(int id)
        {
            try
            {
                return Load().Where(x => x.Id_Interessado.Equals(id)).FirstOrDefault();
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesPEPViewModel();
            }
        }

        public GestaoOcupacoesPEPViewModel LoadPadrao()
        {
            try
            {
                var model = new GestaoOcupacoesPEPViewModel();

                return model;
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesPEPViewModel();
            }
        }

        public bool ExistsById(int id)
        {
            try
            {
                return Load().Any(x => x.Id_PEP.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExistsByOcupacao(int id)
        {
            try
            {
                return Load().Any(x => x.Id_Ocupacao.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExistsByInteressado(int id)
        {
            try
            {
                return Load().Any(x => x.Id_Interessado.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<GestaoOcupacoesPEPViewModel> ToList(GestaoOcupacoesPEPViewModel model, List<GestaoOcupacoesPEPViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<GestaoOcupacoesPEPViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesPEPViewModel>();
            }
        }

        public decimal FatorRemuneracao()
        {
            try
            {
                return dadosMestresDAO.ObterUFESP(true);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public decimal UFESP()
        {
            try
            {
                return dadosMestresDAO.ObterUFESP();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private GestaoOcupacoesPEP ViewModelToModel(GestaoOcupacoesPEPViewModel model)
        {
            try
            {
                var retorno = new GestaoOcupacoesPEP();
                retorno.Id_PEP                          = model.Id_PEP;
                retorno.Id_Interessado                  = model.Id_Interessado;
                retorno.Id_Ocupacao                     = model.Id_Ocupacao;
                retorno.DataEmissãoPEP                  = model.DataEmissãoPEP;
                retorno.DataPagamento                   = model.DataPagamento;
                retorno.Datavencimento                  = model.Datavencimento;
                retorno.Valor                           = model.Valor;
                retorno.Comprovante                     = model.Comprovante;
                retorno.Tipo_Ocupacao                   = model.Tipo_Ocupacao;
                retorno.Status                          = model.Status;
                retorno.dataBaseCalculo                 = model.dataBaseCalculo;
                retorno.UFESP                           = model.UFESP;
                retorno.extensaoOcupacaoLongitudinal    = model.extensaoOcupacaoLongitudinal;
                retorno.extensaoOcupacaoTransversal     = model.extensaoOcupacaoTransversal;
                retorno.extensaoOcupacaoPontual         = model.extensaoOcupacaoPontual;
                retorno.fatorRemuneracao                = model.fatorRemuneracao;
                retorno.OcupacaoLongitudinal            = model.OcupacaoLongitudinal;
                retorno.OcupacaoTransversal             = model.OcupacaoTransversal;
                retorno.OcupacaoPontual                 = model.OcupacaoPontual;
                retorno.totalCalculado                  = model.totalCalculado;

                return retorno;
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesPEP();
            }
        }

        private GestaoOcupacoesPEPViewModel ModelToViewModel(GestaoOcupacoesPEP model)
        {
            try
            {
                var retorno = new GestaoOcupacoesPEPViewModel();
                retorno.Id_PEP                          = model.Id_PEP;
                retorno.Id_Interessado                  = model.Id_Interessado;
                retorno.Id_Ocupacao                     = model.Id_Ocupacao;
                retorno.DataEmissãoPEP                  = model.DataEmissãoPEP;
                retorno.DataPagamento                   = model.DataPagamento;
                retorno.Datavencimento                  = model.Datavencimento;
                retorno.Valor                           = model.Valor;
                retorno.Comprovante                     = model.Comprovante;
                retorno.Tipo_Ocupacao                   = model.Tipo_Ocupacao;
                retorno.Status                          = model.Status;
                retorno.dataBaseCalculo                 = model.dataBaseCalculo;
                retorno.UFESP                           = model.UFESP;
                retorno.extensaoOcupacaoLongitudinal    = model.extensaoOcupacaoLongitudinal;
                retorno.extensaoOcupacaoTransversal     = model.extensaoOcupacaoTransversal;
                retorno.extensaoOcupacaoPontual         = model.extensaoOcupacaoPontual;
                retorno.fatorRemuneracao                = model.fatorRemuneracao;
                retorno.OcupacaoLongitudinal            = model.OcupacaoLongitudinal;
                retorno.OcupacaoTransversal             = model.OcupacaoTransversal;
                retorno.OcupacaoPontual                 = model.OcupacaoPontual;
                retorno.totalCalculado                  = model.totalCalculado;

                return retorno;
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesPEPViewModel();
            }
        }
    }
}