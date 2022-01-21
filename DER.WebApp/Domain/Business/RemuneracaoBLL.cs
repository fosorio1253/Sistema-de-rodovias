using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class RemuneracaoBLL
    {
        private DerContext _context;
        private GestaoOcupacoesRemuneracaoDAO gestaoOcupacoesRemuneracaoDAO;
        private IgpBLL igpBLL;

        #region Calculos
        private Func<decimal, decimal, decimal, decimal> calcRemuneracao = (E, PI, F) => E * PI * F;
        #endregion

        public RemuneracaoBLL()
        {
            _context = new DerContext();
            gestaoOcupacoesRemuneracaoDAO = new GestaoOcupacoesRemuneracaoDAO(_context);
            igpBLL = new IgpBLL();
        }

        public decimal CalcularRemuneracao(GestaoOcupacoesViewModel viewModel)
        {
            return calcRemuneracao(
                viewModel.ListaTrecho.Where(x =>    x.NomeTipoImplantacao.Equals("Longitudinal")    ||
                                                    x.NomeTipoImplantacao.Equals("Transversal")     ||
                                                    x.NomeTipoImplantacao.Equals("Pontual"))
                .Select(x => x.Extensao).Sum(),
                viewModel.TipoInteressadoId != null ?
                    viewModel.TipoInteressadoId.Any(x => x.Value.Equals("30")) ?
                        0 :
                    viewModel.TipoInteressadoId.Any(x => x.Value.Equals("28")) ?
                        (decimal)0.5 : 1 : 
                1,
                (decimal)igpBLL.LoadView().Select(x => x.valor).FirstOrDefault());
        }

        public bool Save(GestaoOcupacoesRemuneracaoViewModel viewModel)
        {
            try
            {
                return ExistsById(viewModel.IdGestaoOcupacoesRemuneracao) ?
                    gestaoOcupacoesRemuneracaoDAO.Update(ViewModelToModel(viewModel)) :
                    gestaoOcupacoesRemuneracaoDAO.Inserir(ViewModelToModel(viewModel));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<GestaoOcupacoesRemuneracaoViewModel> Load()
        {
            try
            {
                return gestaoOcupacoesRemuneracaoDAO.ObtemTodos().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesRemuneracaoViewModel>();
            }
        }

        public GestaoOcupacoesRemuneracaoViewModel LoadById(int id)
        {
            try
            {
                return Load().Where(x => x.IdGestaoOcupacoesRemuneracao.Equals(id)).FirstOrDefault();
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesRemuneracaoViewModel();
            }
        }

        public List<GestaoOcupacoesRemuneracaoViewModel> LoadByOcupacao(int id)
        {
            try
            {
                return Load().Where(x => x.IdOcupacao.Equals(id)).ToList();
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesRemuneracaoViewModel>();
            }
        }

        public GestaoOcupacoesRemuneracaoViewModel LoadPadrao()
        {
            try
            {
                var model = new GestaoOcupacoesRemuneracaoViewModel();

                return model;
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesRemuneracaoViewModel();
            }
        }

        public bool ExistsById(int id)
        {
            try
            {
                return Load().Any(x => x.IdGestaoOcupacoesRemuneracao.Equals(id));
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
                return Load().Any(x => x.IdOcupacao.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<GestaoOcupacoesRemuneracaoViewModel> ToList(GestaoOcupacoesRemuneracaoViewModel model, List<GestaoOcupacoesRemuneracaoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<GestaoOcupacoesRemuneracaoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesRemuneracaoViewModel>();
            }
        }
        
        private GestaoOcupacoesRemuneracao ViewModelToModel(GestaoOcupacoesRemuneracaoViewModel model)
        {
            try
            {
                var retorno = new GestaoOcupacoesRemuneracao();
                retorno.IdGestaoOcupacoesRemuneracao    = model.IdGestaoOcupacoesRemuneracao;
                retorno.IdOcupacao                      = model.IdOcupacao;
                retorno.DataRemuneracao                 = model.DataRemuneracao;
                retorno.Descricao                       = model.Descricao;
                retorno.Liberado                        = model.Liberado;
                retorno.Status                          = model.Status;
                retorno.ValorRemuneracao                = model.ValorRemuneracao;

                return retorno;
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesRemuneracao();
            }
        }

        private GestaoOcupacoesRemuneracaoViewModel ModelToViewModel(GestaoOcupacoesRemuneracao model)
        {
            try
            {
                var retorno = new GestaoOcupacoesRemuneracaoViewModel();
                retorno.IdGestaoOcupacoesRemuneracao    = model.IdGestaoOcupacoesRemuneracao;
                retorno.IdOcupacao                      = model.IdOcupacao;
                retorno.DataRemuneracao                 = model.DataRemuneracao;
                retorno.Descricao                       = model.Descricao;
                retorno.Liberado                        = model.Liberado;
                retorno.Status                          = model.Status;
                retorno.ValorRemuneracao                = model.ValorRemuneracao;

                return retorno;
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesRemuneracaoViewModel();
            }
        }
    }
}