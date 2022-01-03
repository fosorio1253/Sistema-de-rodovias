using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class ConcessionariaBLL
    {
        private DerContext context;
        private ConcessionariaDAO concessionariaDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            concessionariaDAO = new ConcessionariaDAO(context);
        }

        public bool Save(ConcessionariaViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.concessionaria_id) ?
                    concessionariaDAO.Update(model) :
                    concessionariaDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ConcessionariaViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<ConcessionariaViewModel>();
            }
        }

        public List<Concessionaria> Load()
        {
            try
            {
                return concessionariaDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Concessionaria>();
            }
        }

        public bool Remove(ConcessionariaViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.concessionaria_id) ?
                    concessionariaDAO.Delete(model) : false;
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
                return Load().Any(x => x.concessionaria_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ConcessionariaViewModel> ToList(ConcessionariaViewModel model, List<ConcessionariaViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<ConcessionariaViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<ConcessionariaViewModel>();
            }
        }

        private Concessionaria ViewModelToModel(ConcessionariaViewModel model)
        {
            try
            {
                var retorno = new Concessionaria();
                retorno.concessionaria_id = model.concessionaria_id;
                retorno.sigla = model.sigla;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new Concessionaria();
            }
        }

        private ConcessionariaViewModel ViewModelToModel(Concessionaria model)
        {
            try
            {
                var retorno = new ConcessionariaViewModel();
                retorno.concessionaria_id = model.concessionaria_id;
                retorno.sigla = model.sigla;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new Concessionaria();
            }
        }
    }

}