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
    public class AreasBLL
    {
        private DerContext context;
        private AreaDAO areaDAO;

        public AreasBLL()
        {
            context = new DerContext();
            areaDAO = new AreaDAO(context);
        }

        public bool Save(AreaViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.area_id) ?
                    areaDAO.Update(model) :
                    areaDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<AreaViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<AreaViewModel>();
            }
        }

        public List<Area> Load()
        {
            try
            {
                return areaDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Area>();
            }
        }

        public bool Remove(AreaViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.area_id) ?
                    areaDAO.Delete(model) : false;
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
                return Load().Any(x => x.area_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<AreaViewModel> ToList(AreaViewModel model, List<AreaViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<AreaViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<AreaViewModel>();
            }
        }

        private Area ConvertModel(AreaViewModel model)
        {
            try
            {
                var retorno = new Area();
                retorno.area_id = (int)model.AreaId;
                retorno.nome = model.Nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new Area();
            }
        }

        private AreaViewModel ConvertModel(Area model)
        {
            try
            {
                var retorno = new AreaViewModel();
                retorno.AreaId = model.area_id;
                retorno.Nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new AreaViewModel();
            }
        }
    }
}