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
    public class DominioSinalizacoesVerticaisTiposBLL
    {
        private DerContext context;
        private DominioSinalizacoesVerticaisTiposDAO dominiosinalizacoesverticaistiposDAO;

        public DominioSinalizacoesVerticaisTiposBLL()
        {
            context = new DerContext();
            dominiosinalizacoesverticaistiposDAO = new DominioSinalizacoesVerticaisTiposDAO(context);
        }

        public bool Save(DominioSinalizacoesVerticaisTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.svt_id) ?
                    dominiosinalizacoesverticaistiposDAO.Update(model) :
                    dominiosinalizacoesverticaistiposDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioSinalizacoesVerticaisTiposViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioSinalizacoesVerticaisTiposViewModel>();
            }
        }

        public List<DominioSinalizacoesVerticaisTipos> Load()
        {
            try
            {
                return dominiosinalizacoesverticaistiposDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioSinalizacoesVerticaisTipos>();
            }
        }

        public bool Remove(DominioSinalizacoesVerticaisTiposViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.svt_id) ?
                    dominiosinalizacoesverticaistiposDAO.Delete(model) : false;
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
                return Load().Any(x => x.svt_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioSinalizacoesVerticaisTiposViewModel> ToList(DominioSinalizacoesVerticaisTiposViewModel model, List<DominioSinalizacoesVerticaisTiposViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioSinalizacoesVerticaisTiposViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioSinalizacoesVerticaisTiposViewModel>();
            }
        }

        private DominioSinalizacoesVerticaisTipos ViewModelToModel(DominioSinalizacoesVerticaisTiposViewModel model)
        {
            try
            {
                var retorno = new DominioSinalizacoesVerticaisTipos();
                retorno.svt_id = model.svt_id;
                retorno.svt_descricao = model.svt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioSinalizacoesVerticaisTipos();
            }
        }

        private DominioSinalizacoesVerticaisTiposViewModel ModelToViewModel(DominioSinalizacoesVerticaisTipos model)
        {
            try
            {
                var retorno = new DominioSinalizacoesVerticaisTiposViewModel();
                retorno.svt_id = model.svt_id;
                retorno.svt_descricao = model.svt_descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioSinalizacoesVerticaisTiposViewModel();
            }
        }
    }

}