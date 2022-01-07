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
    public class DominioRelevosBLL
    {
        private DerContext context;
        private DominioRelevosDAO dominiorelevosDAO;

        public DominioRelevosBLL()
        {
            context = new DerContext();
            dominiorelevosDAO = new DominioRelevosDAO(context);
        }

        public bool Save(DominioRelevosViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rel_id) ?
                    dominiorelevosDAO.Update(model) :
                    dominiorelevosDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioRelevosViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioRelevosViewModel>();
            }
        }

        public List<DominioRelevos> Load()
        {
            try
            {
                return dominiorelevosDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioRelevos>();
            }
        }

        public bool Remove(DominioRelevosViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rel_id) ?
                    dominiorelevosDAO.Delete(model) : false;
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
                return Load().Any(x => x.rel_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioRelevosViewModel> ToList(DominioRelevosViewModel model, List<DominioRelevosViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioRelevosViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioRelevosViewModel>();
            }
        }

        private DominioRelevos ViewModelToModel(DominioRelevosViewModel model)
        {
            try
            {
                var retorno = new DominioRelevos();
                retorno.rel_id = model.rel_id;
                retorno.rel_descricao = model.rel_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioRelevos();
            }
        }

        private DominioRelevosViewModel ModelToViewModel(DominioRelevos model)
        {
            try
            {
                var retorno = new DominioRelevosViewModel();
                retorno.rel_id = model.rel_id;
                retorno.rel_descricao = model.rel_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioRelevosViewModel();
            }
        }
    }

}