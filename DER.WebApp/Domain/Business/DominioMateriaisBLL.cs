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
    public class DominioMateriaisBLL
    {
        private DerContext context;
        private DominioMateriaisDAO dominiomateriaisDAO;

        public DominioMateriaisBLL()
        {
            context = new DerContext();
            dominiomateriaisDAO = new DominioMateriaisDAO(context);
        }

        public bool Save(DominioMateriaisViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.mat_id) ?
                    dominiomateriaisDAO.Update(model) :
                    dominiomateriaisDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioMateriais model)
        {
            try
            {
                return ExistsById(model.mat_id) ?
                    dominiomateriaisDAO.Update(model) :
                    dominiomateriaisDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioMateriaisViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioMateriaisViewModel>();
            }
        }

        public List<DominioMateriais> Load()
        {
            try
            {
                return dominiomateriaisDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioMateriais>();
            }
        }

        public bool Remove(DominioMateriaisViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.mat_id) ?
                    dominiomateriaisDAO.Delete(model) : false;
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
                return Load().Any(x => x.mat_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioMateriaisViewModel> ToList(DominioMateriaisViewModel model, List<DominioMateriaisViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioMateriaisViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioMateriaisViewModel>();
            }
        }

        private DominioMateriais ViewModelToModel(DominioMateriaisViewModel model)
        {
            try
            {
                var retorno = new DominioMateriais();
                retorno.mat_id = model.mat_id;
                retorno.mat_descricao = model.mat_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioMateriais();
            }
        }

        private DominioMateriaisViewModel ModelToViewModel(DominioMateriais model)
        {
            try
            {
                var retorno = new DominioMateriaisViewModel();
                retorno.mat_id = model.mat_id;
                retorno.mat_descricao = model.mat_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioMateriaisViewModel();
            }
        }
    }

}