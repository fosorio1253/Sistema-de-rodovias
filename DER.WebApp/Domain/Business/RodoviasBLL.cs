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
    public class RodoviasBLL
    {
        private DerContext context;
        private RodoviasDAO rodoviaDAO;

        public RodoviasBLL()
        {
            context = new DerContext();
            rodoviaDAO = new RodoviasDAO(context);
        }

        public bool Save(RodoviaViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rodovia_id) ?
                    rodoviaDAO.Update(model) :
                    rodoviaDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<RodoviaViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<RodoviaViewModel>();
            }
        }

        public List<Rodovia> Load()
        {
            try
            {
                return rodoviaDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Rodovia>();
            }
        }

        public bool Remove(RodoviaViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rodovia_id) ?
                    rodoviaDAO.Delete(model) : false;
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
                return Load().Any(x => x.rodovia_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<RodoviaViewModel> ToList(RodoviaViewModel model, List<RodoviaViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<RodoviaViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<RodoviaViewModel>();
            }
        }

        private Rodovia ViewModelToModel(RodoviaViewModel model)
        {
            try
            {
                var retorno = new Rodovia();
                retorno.rodovia_id = model.rodovia_id;
                retorno.rod_codigo = model.rod_codigo;
                retorno.Nome = model.Nome;
                retorno.rod_id = model.rod_id;
                retorno.jur_id_origem = model.jur_id_origem;
                retorno.rte_id = model.rte_id;
                retorno.ror_id = model.ror_id;
                retorno.rod_km_inicial = model.rod_km_inicial;
                retorno.rod_km_final = model.rod_km_final;
                retorno.rod_km_extensao = model.rod_km_extensao;

                return retorno;
            }
            catch (Exception e)
            {
                return new Rodovia();
            }
        }

        private RodoviaViewModel ModelToViewModel(Rodovia model)
        {
            try
            {
                var retorno = new RodoviaViewModel();
                retorno.rodovia_id = model.rodovia_id;
                retorno.rod_codigo = model.rod_codigo;
                retorno.Nome = model.Nome;
                retorno.rod_id = model.rod_id;
                retorno.jur_id_origem = model.jur_id_origem;
                retorno.rte_id = model.rte_id;
                retorno.ror_id = model.ror_id;
                retorno.rod_km_inicial = model.rod_km_inicial;
                retorno.rod_km_final = model.rod_km_final;
                retorno.rod_km_extensao = model.rod_km_extensao;

                return retorno;
            }
            catch (Exception e)
            {
                return new RodoviaViewModel();
            }
        }
    }

}