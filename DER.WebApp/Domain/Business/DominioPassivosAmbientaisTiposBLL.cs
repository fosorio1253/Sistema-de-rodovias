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
    public class DominioPassivosAmbientaisTiposBLL
    {
        private DerContext context;
        private DominioPassivosAmbientaisTiposDAO dominiopassivosambientaistiposDAO;

        public DominioPassivosAmbientaisTiposBLL()
        {
            context = new DerContext();
            dominiopassivosambientaistiposDAO = new DominioPassivosAmbientaisTiposDAO(context);
        }

        public bool Save(DominioPassivosAmbientaisTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.pat_id) ?
                    dominiopassivosambientaistiposDAO.Update(model) :
                    dominiopassivosambientaistiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioPassivosAmbientaisTipos model)
        {
            try
            {
                return ExistsById(model.pat_id) ?
                    dominiopassivosambientaistiposDAO.Update(model) :
                    dominiopassivosambientaistiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioPassivosAmbientaisTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioPassivosAmbientaisTiposViewModel>();
            }
        }

        public List<DominioPassivosAmbientaisTipos> Load()
        {
            try
            {
                return dominiopassivosambientaistiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioPassivosAmbientaisTipos>();
            }
        }

        public bool Remove(DominioPassivosAmbientaisTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.pat_id) ?
                    dominiopassivosambientaistiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.pat_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioPassivosAmbientaisTiposViewModel> ToList(DominioPassivosAmbientaisTiposViewModel model, List<DominioPassivosAmbientaisTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioPassivosAmbientaisTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioPassivosAmbientaisTiposViewModel>();
            }
        }

        private DominioPassivosAmbientaisTipos ViewModelToModel(DominioPassivosAmbientaisTiposViewModel model)
        {
            try
            {
                var retorno = new DominioPassivosAmbientaisTipos();
                retorno.pat_id = model.pat_id;
                retorno.pat_descricao = model.pat_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioPassivosAmbientaisTipos();
            }
        }

        private DominioPassivosAmbientaisTiposViewModel ModelToViewModel(DominioPassivosAmbientaisTipos model)
        {
            try
            {
                var retorno = new DominioPassivosAmbientaisTiposViewModel();
                retorno.pat_id = model.pat_id;
                retorno.pat_descricao = model.pat_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioPassivosAmbientaisTiposViewModel();
            }
        }
    }

}