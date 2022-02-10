using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DivisaoRegionalBLL
    {
        private DerContext context;
        private DivisaoRegionalDAO divisaoregionalDAO;

        public DivisaoRegionalBLL()
        {
            context = new DerContext();
            divisaoregionalDAO = new DivisaoRegionalDAO(context);
        }

        public bool Save(DivisaoRegionalViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.divisao_regional_id) ?
                    divisaoregionalDAO.Update(model) :
                    divisaoregionalDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(List<DadoMestreTabelaValoresViewModel> viewModel)
        {
            try
            {
                var model = ConvertModel(ConvertModel(viewModel));

                return ExistsById(model.divisao_regional_id) ?
                    divisaoregionalDAO.Update(model) :
                    divisaoregionalDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DivisaoRegionalViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DivisaoRegionalViewModel>();
            }
        }

        public List<DivisaoRegional> Load()
        {
            try
            {
                return divisaoregionalDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DivisaoRegional>();
            }
        }

        public bool Remove(DivisaoRegionalViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.divisao_regional_id) ?
                    divisaoregionalDAO.Delete(model) : false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ExistsById(int id)
        {
            try
            {
                return Load().Any(x => x.divisao_regional_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DivisaoRegionalViewModel> ToList(DivisaoRegionalViewModel model, List<DivisaoRegionalViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DivisaoRegionalViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DivisaoRegionalViewModel>();
            }
        }

        private DivisaoRegional ConvertModel(DivisaoRegionalViewModel model)
        {
            try
            {
                var retorno = new DivisaoRegional();
                retorno.divisao_regional_id = model.divisao_regional_id;
                retorno.sigla = model.sigla;
                retorno.descricao = model.descricao;
                retorno.fator_regional = model.fator_regional;

                return retorno;
            }
            catch (Exception e)
            {
                return new DivisaoRegional();
            }
        }

        private DivisaoRegionalViewModel ConvertModel(DivisaoRegional model)
        {
            try
            {
                var retorno = new DivisaoRegionalViewModel();
                retorno.divisao_regional_id = model.divisao_regional_id;
                retorno.sigla = model.sigla;
                retorno.descricao = model.descricao;
                retorno.fator_regional = model.fator_regional;

                return retorno;
            }
            catch (Exception e)
            {
                return new DivisaoRegionalViewModel();
            }
        }

        private DivisaoRegionalViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new DivisaoRegionalViewModel()
                {
                    divisao_regional_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("divisao_regional_id")).Select(y => y.valor).FirstOrDefault()),
                    descricao = lmodel.Where(y => y.nome_coluna.Equals("descricao")).Select(y => y.valor).FirstOrDefault(),
                    sigla = lmodel.Where(y => y.nome_coluna.Equals("sigla")).Select(y => y.valor).FirstOrDefault(),
                    fator_regional = Convert.ToDouble(lmodel.Where(y => y.nome_coluna.Equals("fator_regional")).Select(y => y.valor).FirstOrDefault())
                };
            }
            catch (Exception e)
            {
                return new DivisaoRegionalViewModel();
            }
        }
    }

}