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
    public class DominioPorticosPmvsTiposBLL
    {
        private DerContext context;
        private DominioPorticosPmvsTiposDAO dominioporticospmvstiposDAO;

        public DominioPorticosPmvsTiposBLL()
        {
            context = new DerContext();
            dominioporticospmvstiposDAO = new DominioPorticosPmvsTiposDAO(context);
        }

        public bool Save(DominioPorticosPmvsTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.ppt_id) ?
                    dominioporticospmvstiposDAO.Update(model) :
                    dominioporticospmvstiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioPorticosPmvsTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioPorticosPmvsTiposViewModel>();
            }
        }

        public List<DominioPorticosPmvsTipos> Load()
        {
            try
            {
                return dominioporticospmvstiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioPorticosPmvsTipos>();
            }
        }

        public bool Remove(DominioPorticosPmvsTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.ppt_id) ?
                    dominioporticospmvstiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.ppt_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioPorticosPmvsTiposViewModel> ToList(DominioPorticosPmvsTiposViewModel model, List<DominioPorticosPmvsTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioPorticosPmvsTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioPorticosPmvsTiposViewModel>();
            }
        }

        private DominioPorticosPmvsTipos ViewModelToModel(DominioPorticosPmvsTiposViewModel model)
        {
            try
            {
                var retorno = new DominioPorticosPmvsTipos();
                retorno.ppt_id = model.ppt_id;
                retorno.ppt_descricao = model.ppt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioPorticosPmvsTipos();
            }
        }

        private DominioPorticosPmvsTiposViewModel ModelToViewModel(DominioPorticosPmvsTipos model)
        {
            try
            {
                var retorno = new DominioPorticosPmvsTiposViewModel();
                retorno.ppt_id = model.ppt_id;
                retorno.ppt_descricao = model.ppt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioPorticosPmvsTiposViewModel();
            }
        }
    }

}