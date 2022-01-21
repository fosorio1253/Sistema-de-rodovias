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
    public class DominioTravessiasTiposBLL
    {
        private DerContext context;
        private DominioTravessiasTiposDAO dominiotravessiastiposDAO;

        public DominioTravessiasTiposBLL()
        {
            context = new DerContext();
            dominiotravessiastiposDAO = new DominioTravessiasTiposDAO(context);
        }

        public bool Save(DominioTravessiasTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.trt_id) ?
                    dominiotravessiastiposDAO.Update(model) :
                    dominiotravessiastiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioTravessiasTipos model)
        {
            try
            {
                return ExistsById(model.trt_id) ?
                    dominiotravessiastiposDAO.Update(model) :
                    dominiotravessiastiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioTravessiasTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioTravessiasTiposViewModel>();
            }
        }

        public List<DominioTravessiasTipos> Load()
        {
            try
            {
                return dominiotravessiastiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioTravessiasTipos>();
            }
        }

        public bool Remove(DominioTravessiasTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.trt_id) ?
                    dominiotravessiastiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.trt_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioTravessiasTiposViewModel> ToList(DominioTravessiasTiposViewModel model, List<DominioTravessiasTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioTravessiasTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioTravessiasTiposViewModel>();
            }
        }

        private DominioTravessiasTipos ViewModelToModel(DominioTravessiasTiposViewModel model)
        {
            try
            {
                var retorno = new DominioTravessiasTipos();
                retorno.trt_id = model.trt_id;
                retorno.trt_descricao = model.trt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioTravessiasTipos();
            }
        }

        private DominioTravessiasTiposViewModel ModelToViewModel(DominioTravessiasTipos model)
        {
            try
            {
                var retorno = new DominioTravessiasTiposViewModel();
                retorno.trt_id = model.trt_id;
                retorno.trt_descricao = model.trt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioTravessiasTiposViewModel();
            }
        }
    }

}