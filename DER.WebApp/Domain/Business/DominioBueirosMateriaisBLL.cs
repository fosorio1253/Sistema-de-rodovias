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
    public class DominioBueirosMateriaisBLL
    {
        private DerContext context;
        private DominioBueirosMateriaisDAO dominiobueirosmateriaisDAO;

        public DominioBueirosMateriaisBLL()
        {
            context = new DerContext();
            dominiobueirosmateriaisDAO = new DominioBueirosMateriaisDAO(context);
        }

        public bool Save(DominioBueirosMateriaisViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.bmt_id) ?
                    dominiobueirosmateriaisDAO.Update(model) :
                    dominiobueirosmateriaisDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioBueirosMateriaisViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioBueirosMateriaisViewModel>();
            }
        }

        public List<DominioBueirosMateriais> Load()
        {
            try
            {
                return dominiobueirosmateriaisDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioBueirosMateriais>();
            }
        }

        public bool Remove(DominioBueirosMateriaisViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.bmt_id) ?
                    dominiobueirosmateriaisDAO.Delete(model) : false;
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
                return Load().Any(x => x.bmt_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioBueirosMateriaisViewModel> ToList(DominioBueirosMateriaisViewModel model, List<DominioBueirosMateriaisViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioBueirosMateriaisViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioBueirosMateriaisViewModel>();
            }
        }

        private DominioBueirosMateriais ViewModelToModel(DominioBueirosMateriaisViewModel model)
        {
            try
            {
                var retorno = new DominioBueirosMateriais();
                retorno.bmt_id = model.bmt_id;
                retorno.bmt_descricao = model.bmt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioBueirosMateriais();
            }
        }

        private DominioBueirosMateriaisViewModel ModelToViewModel(DominioBueirosMateriais model)
        {
            try
            {
                var retorno = new DominioBueirosMateriaisViewModel();
                retorno.bmt_id = model.bmt_id;
                retorno.bmt_descricao = model.bmt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioBueirosMateriaisViewModel();
            }
        }
    }

}