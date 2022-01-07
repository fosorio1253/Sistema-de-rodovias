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
    public class IgpBLL
    {
        private DerContext context;
        private IgpDAO igpDAO;

        public IgpBLL()
        {
            context = new DerContext();
            igpDAO = new IgpDAO(context);
        }

        public bool Save(IgpViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.IGP_id) ?
                    igpDAO.Update(model) :
                    igpDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<IgpViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<IgpViewModel>();
            }
        }

        public List<Igp> Load()
        {
            try
            {
                return igpDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Igp>();
            }
        }

        public bool Remove(IgpViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.IGP_id) ?
                    igpDAO.Delete(model) : false;
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
                return Load().Any(x => x.IGP_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<IgpViewModel> ToList(IgpViewModel model, List<IgpViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<IgpViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<IgpViewModel>();
            }
        }

        private Igp ViewModelToModel(IgpViewModel model)
        {
            try
            {
                var retorno = new Igp();
                retorno.IGP_id = model.IGP_id;
                retorno.mes_ano = model.mes_ano;
                retorno.valor = model.valor;

                return retorno;
            }
            catch (Exception e)
            {
                return new Igp();
            }
        }

        private IgpViewModel ModelToViewModel(Igp model)
        {
            try
            {
                var retorno = new IgpViewModel();
                retorno.IGP_id = model.IGP_id;
                retorno.mes_ano = model.mes_ano;
                retorno.valor = model.valor;

                return retorno;
            }
            catch (Exception e)
            {
                return new IgpViewModel();
            }
        }
    }

}