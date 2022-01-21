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
    public class DominioEletricosTelefoniaTiposBLL
    {
        private DerContext context;
        private DominioEletricosTelefoniaTiposDAO dominioeletricostelefoniatiposDAO;

        public DominioEletricosTelefoniaTiposBLL()
        {
            context = new DerContext();
            dominioeletricostelefoniatiposDAO = new DominioEletricosTelefoniaTiposDAO(context);
        }

        public bool Save(DominioEletricosTelefoniaTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.ett_id) ?
                    dominioeletricostelefoniatiposDAO.Update(model) :
                    dominioeletricostelefoniatiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioEletricosTelefoniaTipos model)
        {
            try
            {
                return ExistsById(model.ett_id) ?
                    dominioeletricostelefoniatiposDAO.Update(model) :
                    dominioeletricostelefoniatiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioEletricosTelefoniaTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioEletricosTelefoniaTiposViewModel>();
            }
        }

        public List<DominioEletricosTelefoniaTipos> Load()
        {
            try
            {
                return dominioeletricostelefoniatiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioEletricosTelefoniaTipos>();
            }
        }

        public bool Remove(DominioEletricosTelefoniaTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.ett_id) ?
                    dominioeletricostelefoniatiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.ett_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioEletricosTelefoniaTiposViewModel> ToList(DominioEletricosTelefoniaTiposViewModel model, List<DominioEletricosTelefoniaTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioEletricosTelefoniaTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioEletricosTelefoniaTiposViewModel>();
            }
        }

        private DominioEletricosTelefoniaTipos ViewModelToModel(DominioEletricosTelefoniaTiposViewModel model)
        {
            try
            {
                var retorno = new DominioEletricosTelefoniaTipos();
                retorno.ett_id = model.ett_id;
                retorno.ett_descricao = model.ett_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioEletricosTelefoniaTipos();
            }
        }

        private DominioEletricosTelefoniaTiposViewModel ModelToViewModel(DominioEletricosTelefoniaTipos model)
        {
            try
            {
                var retorno = new DominioEletricosTelefoniaTiposViewModel();
                retorno.ett_id = model.ett_id;
                retorno.ett_descricao = model.ett_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioEletricosTelefoniaTiposViewModel();
            }
        }
    }

}