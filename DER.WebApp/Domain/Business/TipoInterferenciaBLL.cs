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
    public class TipoInterferenciaBLL
    {
        private DerContext context;
        private TipoInterferenciaDAO tipoInterferenciaDAO;

        public TipoInterferenciaBLL()
        {
            context = new DerContext();
            tipoInterferenciaDAO = new TipoInterferenciaDAO(context);
        }

        public bool Save(TipoInterferenciaViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.tipo_interferencia_id) ?
                    tipoInterferenciaDAO.Update(model) :
                    tipoInterferenciaDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoInterferenciaViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TipoInterferenciaViewModel>();
            }
        }

        public List<TipoInterferencia> Load()
        {
            try
            {
                return tipoInterferenciaDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TipoInterferencia>();
            }
        }

        public bool Remove(TipoInterferenciaViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.tipo_interferencia_id) ?
                    tipoInterferenciaDAO.Delete(model) : false;
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
                return Load().Any(x => x.tipo_interferencia_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoInterferenciaViewModel> ToList(TipoInterferenciaViewModel model, List<TipoInterferenciaViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TipoInterferenciaViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TipoInterferenciaViewModel>();
            }
        }

        private TipoInterferencia ConvertModel(TipoInterferenciaViewModel model)
        {
            try
            {
                var retorno = new TipoInterferencia();
                retorno.tipo_interferencia_id = (int)model.TipoInterferenciaId;
                retorno.nome = model.Nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoInterferencia();
            }
        }

        private TipoInterferenciaViewModel ConvertModel(TipoInterferencia model)
        {
            try
            {
                var retorno = new TipoInterferenciaViewModel();
                retorno.TipoInterferenciaId = model.tipo_interferencia_id;
                retorno.Nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoInterferenciaViewModel();
            }
        }
    }
}