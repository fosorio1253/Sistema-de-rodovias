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
    public class TipoOcupacaoBLL
    {
        private DerContext context;
        private TipoOcupacaoDAO tipoocupacaoDAO;

        public TipoOcupacaoBLL()
        {
            context = new DerContext();
            tipoocupacaoDAO = new TipoOcupacaoDAO(context);
        }

        public bool Save(TipoOcupacaoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.tipo_ocupacao_id) ?
                    tipoocupacaoDAO.Update(model) :
                    tipoocupacaoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoOcupacaoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TipoOcupacaoViewModel>();
            }
        }

        public List<TipoOcupacao> Load()
        {
            try
            {
                return tipoocupacaoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TipoOcupacao>();
            }
        }

        public bool Remove(TipoOcupacaoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.tipo_ocupacao_id) ?
                    tipoocupacaoDAO.Delete(model) : false;
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
                return Load().Any(x => x.tipo_ocupacao_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoOcupacaoViewModel> ToList(TipoOcupacaoViewModel model, List<TipoOcupacaoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TipoOcupacaoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TipoOcupacaoViewModel>();
            }
        }

        private TipoOcupacao ViewModelToModel(TipoOcupacaoViewModel model)
        {
            try
            {
                var retorno = new TipoOcupacao();
                retorno.tipo_ocupacao_id = model.tipo_ocupacao_id;
                retorno.nome = model.nome;
                retorno.altura_minima = model.altura_minima;
                retorno.profundidade_minima = model.profundidade_minima;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoOcupacao();
            }
        }

        private TipoOcupacaoViewModel ModelToViewModel(TipoOcupacao model)
        {
            try
            {
                var retorno = new TipoOcupacaoViewModel();
                retorno.tipo_ocupacao_id = model.tipo_ocupacao_id;
                retorno.nome = model.nome;
                retorno.altura_minima = model.altura_minima;
                retorno.profundidade_minima = model.profundidade_minima;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoOcupacaoViewModel();
            }
        }
    }

}