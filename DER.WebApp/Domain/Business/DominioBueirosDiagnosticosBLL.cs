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
    public class DominioBueirosDiagnosticosBLL
    {
        private DerContext context;
        private DominioBueirosDiagnosticosDAO dominiobueirosdiagnosticosDAO;

        public DominioBueirosDiagnosticosBLL()
        {
            context = new DerContext();
            dominiobueirosdiagnosticosDAO = new DominioBueirosDiagnosticosDAO(context);
        }

        public bool Save(DominioBueirosDiagnosticosViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.bdg_id) ?
                    dominiobueirosdiagnosticosDAO.Update(model) :
                    dominiobueirosdiagnosticosDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DominioBueirosDiagnosticos model)
        {
            try
            {
                return ExistsById(model.bdg_id) ?
                    dominiobueirosdiagnosticosDAO.Update(model) :
                    dominiobueirosdiagnosticosDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioBueirosDiagnosticosViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioBueirosDiagnosticosViewModel>();
            }
        }

        public List<DominioBueirosDiagnosticos> Load()
        {
            try
            {
                return dominiobueirosdiagnosticosDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioBueirosDiagnosticos>();
            }
        }

        public bool Remove(DominioBueirosDiagnosticosViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.bdg_id) ?
                    dominiobueirosdiagnosticosDAO.Delete(model) : false;
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
                return Load().Any(x => x.bdg_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioBueirosDiagnosticosViewModel> ToList(DominioBueirosDiagnosticosViewModel model, List<DominioBueirosDiagnosticosViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioBueirosDiagnosticosViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioBueirosDiagnosticosViewModel>();
            }
        }

        private DominioBueirosDiagnosticos ViewModelToModel(DominioBueirosDiagnosticosViewModel model)
        {
            try
            {
                var retorno = new DominioBueirosDiagnosticos();
                retorno.bdg_id = model.bdg_id;
                retorno.bdg_descricao = model.bdg_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioBueirosDiagnosticos();
            }
        }

        private DominioBueirosDiagnosticosViewModel ModelToViewModel(DominioBueirosDiagnosticos model)
        {
            try
            {
                var retorno = new DominioBueirosDiagnosticosViewModel();
                retorno.bdg_id = model.bdg_id;
                retorno.bdg_descricao = model.bdg_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioBueirosDiagnosticosViewModel();
            }
        }
    }

}