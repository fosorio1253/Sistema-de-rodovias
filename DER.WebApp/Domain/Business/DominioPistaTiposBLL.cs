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
    public class DominioPistaTiposBLL
    {
        private DerContext context;
        private DominioPistaTiposDAO dominiopistatiposDAO;

        public DominioPistaTiposBLL()
        {
            context = new DerContext();
            dominiopistatiposDAO = new DominioPistaTiposDAO(context);
        }

        public bool Save(DominioPistaTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.ptp_id) ?
                    dominiopistatiposDAO.Update(model) :
                    dominiopistatiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioPistaTipos model)
        {
            try
            {
                return ExistsById(model.ptp_id) ?
                    dominiopistatiposDAO.Update(model) :
                    dominiopistatiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public List<DominioPistaTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioPistaTiposViewModel>();
            }
        }

        public List<DominioPistaTipos> Load()
        {
            try
            {
                return dominiopistatiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioPistaTipos>();
            }
        }

        public bool Remove(DominioPistaTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.ptp_id) ?
                    dominiopistatiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.ptp_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioPistaTiposViewModel> ToList(DominioPistaTiposViewModel model, List<DominioPistaTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioPistaTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioPistaTiposViewModel>();
            }
        }

        private DominioPistaTipos ViewModelToModel(DominioPistaTiposViewModel model)
        {
            try
            {
                var retorno = new DominioPistaTipos();
                retorno.ptp_id = model.ptp_id;
                retorno.ptp_descricao = model.ptp_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioPistaTipos();
            }
        }

        private DominioPistaTiposViewModel ModelToViewModel(DominioPistaTipos model)
        {
            try
            {
                var retorno = new DominioPistaTiposViewModel();
                retorno.ptp_id = model.ptp_id;
                retorno.ptp_descricao = model.ptp_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioPistaTiposViewModel();
            }
        }
    }

}