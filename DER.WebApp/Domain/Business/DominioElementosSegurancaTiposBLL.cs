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
    public class DominioElementosSegurancaTiposBLL
    {
        private DerContext context;
        private DominioElementosSegurancaTiposDAO dominioelementossegurancatiposDAO;

        public DominioElementosSegurancaTiposBLL()
        {
            context = new DerContext();
            dominioelementossegurancatiposDAO = new DominioElementosSegurancaTiposDAO(context);
        }

        public bool Save(DominioElementosSegurancaTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.est_id) ?
                    dominioelementossegurancatiposDAO.Update(model) :
                    dominioelementossegurancatiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioElementosSegurancaTipos model)
        {
            try
            {
                return ExistsById(model.est_id) ?
                    dominioelementossegurancatiposDAO.Update(model) :
                    dominioelementossegurancatiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioElementosSegurancaTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioElementosSegurancaTiposViewModel>();
            }
        }

        public List<DominioElementosSegurancaTipos> Load()
        {
            try
            {
                return dominioelementossegurancatiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioElementosSegurancaTipos>();
            }
        }

        public bool Remove(DominioElementosSegurancaTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.est_id) ?
                    dominioelementossegurancatiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.est_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioElementosSegurancaTiposViewModel> ToList(DominioElementosSegurancaTiposViewModel model, List<DominioElementosSegurancaTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioElementosSegurancaTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioElementosSegurancaTiposViewModel>();
            }
        }

        private DominioElementosSegurancaTipos ViewModelToModel(DominioElementosSegurancaTiposViewModel model)
        {
            try
            {
                var retorno = new DominioElementosSegurancaTipos();
                retorno.est_id = model.est_id;
                retorno.est_descricao = model.est_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioElementosSegurancaTipos();
            }
        }

        private DominioElementosSegurancaTiposViewModel ModelToViewModel(DominioElementosSegurancaTipos model)
        {
            try
            {
                var retorno = new DominioElementosSegurancaTiposViewModel();
                retorno.est_id = model.est_id;
                retorno.est_descricao = model.est_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioElementosSegurancaTiposViewModel();
            }
        }
    }

}