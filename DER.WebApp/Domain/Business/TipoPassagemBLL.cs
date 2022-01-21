using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class TipoPassagemBLL
    {
        private DerContext context;
        private TipoPassagemDAO tipoPassagemDAO;

        public TipoPassagemBLL()
        {
            context = new DerContext();
            tipoPassagemDAO = new TipoPassagemDAO(context);
        }

        public bool Save(TipoPassagemViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.tipo_passagem_id) ?
                    tipoPassagemDAO.Update(model) :
                    tipoPassagemDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoPassagemViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TipoPassagemViewModel>();
            }
        }

        public List<TipoPassagem> Load()
        {
            try
            {
                return tipoPassagemDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TipoPassagem>();
            }
        }

        public bool Remove(TipoPassagemViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.tipo_passagem_id) ?
                    tipoPassagemDAO.Delete(model) : false;
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
                return Load().Any(x => x.tipo_passagem_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoPassagemViewModel> ToList(TipoPassagemViewModel model, List<TipoPassagemViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TipoPassagemViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TipoPassagemViewModel>();
            }
        }

        private TipoPassagem ConvertModel(TipoPassagemViewModel model)
        {
            try
            {
                var retorno = new TipoPassagem();
                retorno.tipo_passagem_id = (int)model.TipoPassagemId;
                retorno.nome = model.Nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoPassagem();
            }
        }

        private TipoPassagemViewModel ConvertModel(TipoPassagem model)
        {
            try
            {
                var retorno = new TipoPassagemViewModel();
                retorno.TipoPassagemId = model.tipo_passagem_id;
                retorno.Nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoPassagemViewModel();
            }
        }
    }
}