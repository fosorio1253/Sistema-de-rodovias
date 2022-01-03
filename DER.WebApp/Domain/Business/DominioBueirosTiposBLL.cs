using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioBueirosTiposBLL
    {
        private DerContext context;
        private DominioBueirosTiposDAO dominiobueirostiposDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            dominiobueirostiposDAO = new DominioBueirosTiposDAO(context);
        }

        public bool Save(DominioBueirosTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.btp_id) ?
                    dominiobueirostiposDAO.Update(model) :
                    dominiobueirostiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioBueirosTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioBueirosTiposViewModel>();
            }
        }

        public List<DominioBueirosTipos> Load()
        {
            try
            {
                return dominiobueirostiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioBueirosTipos>();
            }
        }

        public bool Remove(DominioBueirosTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.btp_id) ?
                    dominiobueirostiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.btp_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioBueirosTiposViewModel> ToList(DominioBueirosTiposViewModel model, List<DominioBueirosTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioBueirosTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioBueirosTiposViewModel>();
            }
        }

        private DominioBueirosTipos ViewModelToModel(DominioBueirosTiposViewModel model)
        {
            try
            {
                var retorno = new DominioBueirosTipos();
                retorno.btp_id = model.btp_id;
                retorno.btp_descricao = model.btp_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioBueirosTipos();
            }
        }

        private DominioBueirosTiposViewModel ViewModelToModel(DominioBueirosTipos model)
        {
            try
            {
                var retorno = new DominioBueirosTiposViewModel();
                retorno.btp_id = model.btp_id;
                retorno.btp_descricao = model.btp_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioBueirosTipos();
            }
        }
    }

}