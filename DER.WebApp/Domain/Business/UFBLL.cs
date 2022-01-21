using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoInteressados;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class UFBLL
    {
        private DerContext context;
        private UFDAO uFDAO;

        public UFBLL()
        {
            context = new DerContext();
            uFDAO = new UFDAO(context);
        }

        public bool Save(UFViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.uf_id) ?
                    uFDAO.Update(model) :
                    uFDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<UFViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<UFViewModel>();
            }
        }

        public List<UF> Load()
        {
            try
            {
                return uFDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<UF>();
            }
        }

        public bool Remove(UFViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.uf_id) ?
                    uFDAO.Delete(model) : false;
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
                return Load().Any(x => x.uf_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<UFViewModel> ToList(UFViewModel model, List<UFViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<UFViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<UFViewModel>();
            }
        }

        private UF ConvertModel(UFViewModel model)
        {
            try
            {
                var retorno = new UF();
                retorno.uf_id = (int)model.uf_id;
                retorno.estado = model.estado;
                retorno.sigla = model.sigla;

                return retorno;
            }
            catch (Exception e)
            {
                return new UF();
            }
        }

        private UFViewModel ConvertModel(UF model)
        {
            try
            {
                var retorno = new UFViewModel();
                retorno.uf_id = (int)model.uf_id;
                retorno.estado = model.estado;
                retorno.sigla = model.sigla;

                return retorno;
            }
            catch (Exception e)
            {
                return new UFViewModel();
            }
        }
    }
}