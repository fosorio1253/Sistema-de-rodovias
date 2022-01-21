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
    public class DominioOaeTiposBLL
    {
        private DerContext context;
        private DominioOaeTiposDAO dominiooaetiposDAO;

        public DominioOaeTiposBLL()
        {
            context = new DerContext();
            dominiooaetiposDAO = new DominioOaeTiposDAO(context);
        }

        public bool Save(DominioOaeTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.oat_id) ?
                    dominiooaetiposDAO.Update(model) :
                    dominiooaetiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioOaeTipos model)
        {
            try
            {
                return ExistsById(model.oat_id) ?
                    dominiooaetiposDAO.Update(model) :
                    dominiooaetiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioOaeTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioOaeTiposViewModel>();
            }
        }

        public List<DominioOaeTipos> Load()
        {
            try
            {
                return dominiooaetiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioOaeTipos>();
            }
        }

        public bool Remove(DominioOaeTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.oat_id) ?
                    dominiooaetiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.oat_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioOaeTiposViewModel> ToList(DominioOaeTiposViewModel model, List<DominioOaeTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioOaeTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioOaeTiposViewModel>();
            }
        }

        private DominioOaeTipos ViewModelToModel(DominioOaeTiposViewModel model)
        {
            try
            {
                var retorno = new DominioOaeTipos();
                retorno.oat_id = model.oat_id;
                retorno.oat_descricao = model.oat_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioOaeTipos();
            }
        }

        private DominioOaeTiposViewModel ModelToViewModel(DominioOaeTipos model)
        {
            try
            {
                var retorno = new DominioOaeTiposViewModel();
                retorno.oat_id = model.oat_id;
                retorno.oat_descricao = model.oat_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioOaeTiposViewModel();
            }
        }
    }

}