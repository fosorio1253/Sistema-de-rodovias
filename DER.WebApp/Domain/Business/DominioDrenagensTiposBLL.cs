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
    public class DominioDrenagensTiposBLL
    {
        private DerContext context;
        private DominioDrenagensTiposDAO dominiodrenagenstiposDAO;

        public DominioDrenagensTiposBLL()
        {
            context = new DerContext();
            dominiodrenagenstiposDAO = new DominioDrenagensTiposDAO(context);
        }

        public bool Save(DominioDrenagensTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.drt_id) ?
                    dominiodrenagenstiposDAO.Update(model) :
                    dominiodrenagenstiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioDrenagensTipos model)
        {
            try
            {
                return ExistsById(model.drt_id) ?
                    dominiodrenagenstiposDAO.Update(model) :
                    dominiodrenagenstiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioDrenagensTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioDrenagensTiposViewModel>();
            }
        }

        public List<DominioDrenagensTipos> Load()
        {
            try
            {
                return dominiodrenagenstiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioDrenagensTipos>();
            }
        }

        public bool Remove(DominioDrenagensTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.drt_id) ?
                    dominiodrenagenstiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.drt_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioDrenagensTiposViewModel> ToList(DominioDrenagensTiposViewModel model, List<DominioDrenagensTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioDrenagensTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioDrenagensTiposViewModel>();
            }
        }

        private DominioDrenagensTipos ViewModelToModel(DominioDrenagensTiposViewModel model)
        {
            try
            {
                var retorno = new DominioDrenagensTipos();
                retorno.drt_id = model.drt_id;
                retorno.drt_descricao = model.drt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioDrenagensTipos();
            }
        }

        private DominioDrenagensTiposViewModel ModelToViewModel(DominioDrenagensTipos model)
        {
            try
            {
                var retorno = new DominioDrenagensTiposViewModel();
                retorno.drt_id = model.drt_id;
                retorno.drt_descricao = model.drt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioDrenagensTiposViewModel();
            }
        }
    }

}