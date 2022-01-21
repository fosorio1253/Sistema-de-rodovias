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
    public class DominioAdministradoresBLL
    {
        private DerContext context;
        private DominioAdministradoresDAO dominioadministradoresDAO;

        public DominioAdministradoresBLL()
        {
            context = new DerContext();
            dominioadministradoresDAO = new DominioAdministradoresDAO(context);
        }

        public bool Save(DominioAdministradoresViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.adm_id) ?
                    dominioadministradoresDAO.Update(model) :
                    dominioadministradoresDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioAdministradores model)
        {
            try
            {
                return ExistsById(model.adm_id) ?
                    dominioadministradoresDAO.Update(model) :
                    dominioadministradoresDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioAdministradoresViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioAdministradoresViewModel>();
            }
        }

        public List<DominioAdministradores> Load()
        {
            try
            {
                return dominioadministradoresDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioAdministradores>();
            }
        }

        public bool Remove(DominioAdministradoresViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.adm_id) ?
                    dominioadministradoresDAO.Delete(model) : false;
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
                return Load().Any(x => x.adm_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioAdministradoresViewModel> ToList(DominioAdministradoresViewModel model, List<DominioAdministradoresViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioAdministradoresViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioAdministradoresViewModel>();
            }
        }

        private DominioAdministradores ViewModelToModel(DominioAdministradoresViewModel model)
        {
            try
            {
                var retorno = new DominioAdministradores();
                retorno.adm_id = model.adm_id;
                retorno.adm_descricao = model.adm_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioAdministradores();
            }
        }

        private DominioAdministradoresViewModel ModelToViewModel(DominioAdministradores model)
        {
            try
            {
                var retorno = new DominioAdministradoresViewModel();
                retorno.adm_id = model.adm_id;
                retorno.adm_descricao = model.adm_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioAdministradoresViewModel();
            }
        }
    }

}