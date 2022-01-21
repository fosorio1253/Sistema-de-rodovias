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
    public class RegionalsBLL
    {
        private DerContext context;
        private RegionalDAO regionalDAO;

        public RegionalsBLL()
        {
            context = new DerContext();
            regionalDAO = new RegionalDAO(context);
        }

        public bool Save(RegionalViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.regional_id) ?
                    regionalDAO.Update(model) :
                    regionalDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<RegionalViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<RegionalViewModel>();
            }
        }

        public List<Regional> Load()
        {
            try
            {
                return regionalDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Regional>();
            }
        }

        public bool Remove(RegionalViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.regional_id) ?
                    regionalDAO.Delete(model) : false;
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
                return Load().Any(x => x.regional_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<RegionalViewModel> ToList(RegionalViewModel model, List<RegionalViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<RegionalViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<RegionalViewModel>();
            }
        }

        private Regional ConvertModel(RegionalViewModel model)
        {
            try
            {
                var retorno = new Regional();
                retorno.regional_id = (int)model.RegionalId;
                retorno.nome = model.Nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new Regional();
            }
        }

        private RegionalViewModel ConvertModel(Regional model)
        {
            try
            {
                var retorno = new RegionalViewModel();
                retorno.RegionalId = model.regional_id;
                retorno.Nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new RegionalViewModel();
            }
        }
    }
}