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
    public class PiBLL
    {
        private DerContext context;
        private PiDAO piDAO;

        public PiBLL()
        {
            context = new DerContext();
            piDAO = new PiDAO(context);
        }

        public bool Save(PiViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.pi_id) ?
                    piDAO.Update(model) :
                    piDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<PiViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<PiViewModel>();
            }
        }

        public List<Pi> Load()
        {
            try
            {
                return piDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Pi>();
            }
        }

        public bool Remove(PiViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.pi_id) ?
                    piDAO.Delete(model) : false;
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
                return Load().Any(x => x.pi_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<PiViewModel> ToList(PiViewModel model, List<PiViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<PiViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<PiViewModel>();
            }
        }

        private Pi ViewModelToModel(PiViewModel model)
        {
            try
            {
                var retorno = new Pi();
                retorno.pi_id = model.pi_id;
                retorno.Mes_Ano = model.Mes_Ano;
                retorno.Valor_PI = model.Valor_PI;

                return retorno;
            }
            catch (Exception e)
            {
                return new Pi();
            }
        }

        private PiViewModel ModelToViewModel(Pi model)
        {
            try
            {
                var retorno = new PiViewModel();
                retorno.pi_id = model.pi_id;
                retorno.Mes_Ano = model.Mes_Ano;
                retorno.Valor_PI = model.Valor_PI;

                return retorno;
            }
            catch (Exception e)
            {
                return new PiViewModel();
            }
        }
    }

}