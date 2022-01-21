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
    public class LadosBLL
    {
        private DerContext context;
        private LadoDAO ladoDAO;

        public LadosBLL()
        {
            context = new DerContext();
            ladoDAO = new LadoDAO(context);
        }

        public bool Save(LadoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.lado_id) ?
                    ladoDAO.Update(model) :
                    ladoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<LadoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<LadoViewModel>();
            }
        }

        public List<Lado> Load()
        {
            try
            {
                return ladoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Lado>();
            }
        }

        public bool Remove(LadoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.lado_id) ?
                    ladoDAO.Delete(model) : false;
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
                return Load().Any(x => x.lado_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<LadoViewModel> ToList(LadoViewModel model, List<LadoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<LadoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<LadoViewModel>();
            }
        }

        private Lado ConvertModel(LadoViewModel model)
        {
            try
            {
                var retorno = new Lado();
                retorno.lado_id = (int)model.LadoId;
                retorno.nome = model.Nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new Lado();
            }
        }

        private LadoViewModel ConvertModel(Lado model)
        {
            try
            {
                var retorno = new LadoViewModel();
                retorno.LadoId = model.lado_id;
                retorno.Nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new LadoViewModel();
            }
        }
    }
}