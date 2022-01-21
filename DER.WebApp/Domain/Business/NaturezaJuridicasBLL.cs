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
    public class NaturezaJuridicasBLL
    {
        private DerContext context;
        private NaturezaJuridicaDAO naturezaJuridicaDAO;

        public NaturezaJuridicasBLL()
        {
            context = new DerContext();
            naturezaJuridicaDAO = new NaturezaJuridicaDAO(context);
        }

        public bool Save(NaturezaJuridicaViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.natureza_juridica_id) ?
                    naturezaJuridicaDAO.Update(model) :
                    naturezaJuridicaDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<NaturezaJuridicaViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<NaturezaJuridicaViewModel>();
            }
        }

        public List<NaturezaJuridica> Load()
        {
            try
            {
                return naturezaJuridicaDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<NaturezaJuridica>();
            }
        }

        public bool Remove(NaturezaJuridicaViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.natureza_juridica_id) ?
                    naturezaJuridicaDAO.Delete(model) : false;
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
                return Load().Any(x => x.natureza_juridica_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<NaturezaJuridicaViewModel> ToList(NaturezaJuridicaViewModel model, List<NaturezaJuridicaViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<NaturezaJuridicaViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<NaturezaJuridicaViewModel>();
            }
        }

        private NaturezaJuridica ConvertModel(NaturezaJuridicaViewModel model)
        {
            try
            {
                var retorno = new NaturezaJuridica();
                retorno.natureza_juridica_id = (int)model.NaturezaJuridicaId;
                retorno.nome = model.Nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new NaturezaJuridica();
            }
        }

        private NaturezaJuridicaViewModel ConvertModel(NaturezaJuridica model)
        {
            try
            {
                var retorno = new NaturezaJuridicaViewModel();
                retorno.NaturezaJuridicaId = model.natureza_juridica_id;
                retorno.Nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new NaturezaJuridicaViewModel();
            }
        }
    }
}