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
    public class DominioRegionaisCodeBLL
    {
        private DerContext context;
        private DominioRegionaisCodeDAO dominioregionaiscodeDAO;

        public DominioRegionaisCodeBLL()
        {
            context = new DerContext();
            dominioregionaiscodeDAO = new DominioRegionaisCodeDAO(context);
        }

        public bool Save(DominioRegionaisCodeViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.reg_id) ?
                    dominioregionaiscodeDAO.Update(model) :
                    dominioregionaiscodeDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioRegionaisCode model)
        {
            try
            {
                return ExistsById(model.reg_id) ?
                    dominioregionaiscodeDAO.Update(model) :
                    dominioregionaiscodeDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioRegionaisCodeViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioRegionaisCodeViewModel>();
            }
        }

        public List<DominioRegionaisCode> Load()
        {
            try
            {
                return dominioregionaiscodeDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioRegionaisCode>();
            }
        }

        public bool Remove(DominioRegionaisCodeViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.reg_id) ?
                    dominioregionaiscodeDAO.Delete(model) : false;
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
                return Load().Any(x => x.reg_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioRegionaisCodeViewModel> ToList(DominioRegionaisCodeViewModel model, List<DominioRegionaisCodeViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioRegionaisCodeViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioRegionaisCodeViewModel>();
            }
        }

        private DominioRegionaisCode ViewModelToModel(DominioRegionaisCodeViewModel model)
        {
            try
            {
                var retorno = new DominioRegionaisCode();
                retorno.reg_id = model.reg_id;
                retorno.reg_codigo = model.reg_codigo;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioRegionaisCode();
            }
        }

        private DominioRegionaisCodeViewModel ModelToViewModel(DominioRegionaisCode model)
        {
            try
            {
                var retorno = new DominioRegionaisCodeViewModel();
                retorno.reg_id = model.reg_id;
                retorno.reg_codigo = model.reg_codigo;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioRegionaisCodeViewModel();
            }
        }
    }

}