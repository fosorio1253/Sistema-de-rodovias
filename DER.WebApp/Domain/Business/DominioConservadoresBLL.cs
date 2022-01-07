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
    public class DominioConservadoresBLL
    {
        private DerContext context;
        private DominioConservadoresDAO dominioconservadoresDAO;

        public DominioConservadoresBLL()
        {
            context = new DerContext();
            dominioconservadoresDAO = new DominioConservadoresDAO(context);
        }

        public bool Save(DominioConservadoresViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.res_id) ?
                    dominioconservadoresDAO.Update(model) :
                    dominioconservadoresDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioConservadoresViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioConservadoresViewModel>();
            }
        }

        public List<DominioConservadores> Load()
        {
            try
            {
                return dominioconservadoresDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioConservadores>();
            }
        }

        public bool Remove(DominioConservadoresViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.res_id) ?
                    dominioconservadoresDAO.Delete(model) : false;
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
                return Load().Any(x => x.res_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioConservadoresViewModel> ToList(DominioConservadoresViewModel model, List<DominioConservadoresViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioConservadoresViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioConservadoresViewModel>();
            }
        }

        private DominioConservadores ViewModelToModel(DominioConservadoresViewModel model)
        {
            try
            {
                var retorno = new DominioConservadores();
                retorno.res_id = model.res_id;
                retorno.res_codigo = model.res_codigo;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioConservadores();
            }
        }

        private DominioConservadoresViewModel ModelToViewModel(DominioConservadores model)
        {
            try
            {
                var retorno = new DominioConservadoresViewModel();
                retorno.res_id = model.res_id;
                retorno.res_codigo = model.res_codigo;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioConservadoresViewModel();
            }
        }
    }

}