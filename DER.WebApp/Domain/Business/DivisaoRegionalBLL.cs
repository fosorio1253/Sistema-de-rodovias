using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
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

        public InadimplentesBLL()
        {
            context = new DerContext();
            divisaoregionalDAO = new DivisaoRegionalDAO(context);
        }

        public bool Save(DivisaoRegionalViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

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
                return Load().Select(x => ModelToViewModel(x)).ToList();
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
                var model = ViewModelToModel(viewModel);
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

        private DivisaoRegional ViewModelToModel(DivisaoRegionalViewModel model)
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

        private DivisaoRegionalViewModel ViewModelToModel(DivisaoRegional model)
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
                return new DivisaoRegional();
            }
        }
    }

}