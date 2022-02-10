using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class DadoMestreBLL
    {
        private DerContext context;
        private DadoMestreDAO dadoMestreDAO;

        public DadoMestreBLL()
        {
            context = new DerContext();
            dadoMestreDAO = new DadoMestreDAO(context);
        }

        public bool Save(DadoMestreViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.dado_mestre_id) ?
                    dadoMestreDAO.Update(model) :
                    dadoMestreDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DadoMestreViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DadoMestreViewModel>();
            }
        }

        public List<DadoMestre> Load()
        {
            try
            {
                return dadoMestreDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DadoMestre>();
            }
        }

        public bool Remove(DadoMestreViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.dado_mestre_id) ?
                    dadoMestreDAO.Delete(model) : false;
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
                return Load().Any(x => x.dado_mestre_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DadoMestreViewModel> ToList(DadoMestreViewModel model, List<DadoMestreViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DadoMestreViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DadoMestreViewModel>();
            }
        }

        private DadoMestre ConvertModel(DadoMestreViewModel model)
        {
            try
            {
                var retorno = new DadoMestre();
                retorno.dado_mestre_id = (int)model.dado_mestre_id;
                retorno.nome = model.nome;
                retorno.sigla = model.sigla;

                return retorno;
            }
            catch (Exception e)
            {
                return new DadoMestre();
            }
        }

        private DadoMestreViewModel ConvertModel(DadoMestre model)
        {
            try
            {
                var retorno = new DadoMestreViewModel();
                retorno.dado_mestre_id = (int)model.dado_mestre_id;
                retorno.nome = model.nome;
                retorno.sigla = model.sigla;

                return retorno;
            }
            catch (Exception e)
            {
                return new DadoMestreViewModel();
            }
        }
    }
}