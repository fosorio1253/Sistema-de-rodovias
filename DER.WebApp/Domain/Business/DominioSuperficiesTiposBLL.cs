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
    public class DominioSuperficiesTiposBLL
    {
        private DerContext context;
        private DominioSuperficiesTiposDAO dominiosuperficiestiposDAO;

        public DominioSuperficiesTiposBLL()
        {
            context = new DerContext();
            dominiosuperficiestiposDAO = new DominioSuperficiesTiposDAO(context);
        }

        public bool Save(DominioSuperficiesTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.stp_id) ?
                    dominiosuperficiestiposDAO.Update(model) :
                    dominiosuperficiestiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioSuperficiesTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioSuperficiesTiposViewModel>();
            }
        }

        public List<DominioSuperficiesTipos> Load()
        {
            try
            {
                return dominiosuperficiestiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioSuperficiesTipos>();
            }
        }

        public bool Remove(DominioSuperficiesTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.stp_id) ?
                    dominiosuperficiestiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.stp_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioSuperficiesTiposViewModel> ToList(DominioSuperficiesTiposViewModel model, List<DominioSuperficiesTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioSuperficiesTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioSuperficiesTiposViewModel>();
            }
        }

        private DominioSuperficiesTipos ViewModelToModel(DominioSuperficiesTiposViewModel model)
        {
            try
            {
                var retorno = new DominioSuperficiesTipos();
                retorno.stp_id = model.stp_id;
                retorno.stp_descricao = model.stp_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioSuperficiesTipos();
            }
        }

        private DominioSuperficiesTiposViewModel ModelToViewModel(DominioSuperficiesTipos model)
        {
            try
            {
                var retorno = new DominioSuperficiesTiposViewModel();
                retorno.stp_id = model.stp_id;
                retorno.stp_descricao = model.stp_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioSuperficiesTiposViewModel();
            }
        }
    }

}