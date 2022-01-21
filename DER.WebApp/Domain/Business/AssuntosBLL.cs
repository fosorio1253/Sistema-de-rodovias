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
    public class AssuntosBLL
    {
        private DerContext context;
        private AssuntoDAO assuntoDAO;

        public AssuntosBLL()
        {
            context = new DerContext();
            assuntoDAO = new AssuntoDAO(context);
        }

        public bool Save(AssuntoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.assunto_id) ?
                    assuntoDAO.Update(model) :
                    assuntoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<AssuntoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<AssuntoViewModel>();
            }
        }

        public List<Assunto> Load()
        {
            try
            {
                return assuntoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Assunto>();
            }
        }

        public bool Remove(AssuntoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.assunto_id) ?
                    assuntoDAO.Delete(model) : false;
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
                return Load().Any(x => x.assunto_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<AssuntoViewModel> ToList(AssuntoViewModel model, List<AssuntoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<AssuntoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<AssuntoViewModel>();
            }
        }

        private Assunto ConvertModel(AssuntoViewModel model)
        {
            try
            {
                var retorno = new Assunto();
                retorno.assunto_id = (int)model.assunto_id;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new Assunto();
            }
        }

        private AssuntoViewModel ConvertModel(Assunto model)
        {
            try
            {
                var retorno = new AssuntoViewModel();
                retorno.assunto_id = (int)model.assunto_id;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new AssuntoViewModel();
            }
        }
    }
}