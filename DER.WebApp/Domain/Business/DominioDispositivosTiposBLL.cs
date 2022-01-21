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
    public class DominioDispositivosTiposBLL
    {
        private DerContext context;
        private DominioDispositivosTiposDAO dominiodispositivostiposDAO;

        public DominioDispositivosTiposBLL()
        {
            context = new DerContext();
            dominiodispositivostiposDAO = new DominioDispositivosTiposDAO(context);
        }

        public bool Save(DominioDispositivosTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.dit_id) ?
                    dominiodispositivostiposDAO.Update(model) :
                    dominiodispositivostiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioDispositivosTipos model)
        {
            try
            {
                return ExistsById(model.dit_id) ?
                    dominiodispositivostiposDAO.Update(model) :
                    dominiodispositivostiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioDispositivosTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioDispositivosTiposViewModel>();
            }
        }

        public List<DominioDispositivosTipos> Load()
        {
            try
            {
                return dominiodispositivostiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioDispositivosTipos>();
            }
        }

        public bool Remove(DominioDispositivosTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.dit_id) ?
                    dominiodispositivostiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.dit_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioDispositivosTiposViewModel> ToList(DominioDispositivosTiposViewModel model, List<DominioDispositivosTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioDispositivosTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioDispositivosTiposViewModel>();
            }
        }

        private DominioDispositivosTipos ViewModelToModel(DominioDispositivosTiposViewModel model)
        {
            try
            {
                var retorno = new DominioDispositivosTipos();
                retorno.dit_id = model.dit_id;
                retorno.dit_descricao = model.dit_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioDispositivosTipos();
            }
        }

        private DominioDispositivosTiposViewModel ModelToViewModel(DominioDispositivosTipos model)
        {
            try
            {
                var retorno = new DominioDispositivosTiposViewModel();
                retorno.dit_id = model.dit_id;
                retorno.dit_descricao = model.dit_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioDispositivosTiposViewModel();
            }
        }
    }

}