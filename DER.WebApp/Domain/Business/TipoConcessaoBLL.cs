using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class TipoConcessaoBLL
    {
        private DerContext context;
        private TipoConcessaoDAO tipoconcessaoDAO;

        public TipoConcessaoBLL()
        {
            context = new DerContext();
            tipoconcessaoDAO = new TipoConcessaoDAO(context);
        }

        public bool Save(TipoConcessaoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.tipo_concessao_id) ?
                    tipoconcessaoDAO.Update(model) :
                    tipoconcessaoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(List<DadoMestreTabelaValoresViewModel> viewModel)
        {
            try
            {
                var model = ConvertModel(ConvertModel(viewModel));

                return ExistsById(model.tipo_concessao_id) ?
                    tipoconcessaoDAO.Update(model) :
                    tipoconcessaoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoConcessaoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TipoConcessaoViewModel>();
            }
        }

        public List<TipoConcessao> Load()
        {
            try
            {
                return tipoconcessaoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TipoConcessao>();
            }
        }

        public bool Remove(TipoConcessaoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.tipo_concessao_id) ?
                    tipoconcessaoDAO.Delete(model) : false;
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
                return Load().Any(x => x.tipo_concessao_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoConcessaoViewModel> ToList(TipoConcessaoViewModel model, List<TipoConcessaoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TipoConcessaoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TipoConcessaoViewModel>();
            }
        }

        private TipoConcessao ConvertModel(TipoConcessaoViewModel model)
        {
            try
            {
                var retorno = new TipoConcessao();
                retorno.tipo_concessao_id = model.tipo_concessao_id;
                retorno.Descricao = model.Descricao;
                retorno.Documentos = model.Documentos;
                retorno.profundidade_minima = model.profundidade_minima;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoConcessao();
            }
        }

        private TipoConcessaoViewModel ConvertModel(TipoConcessao model)
        {
            try
            {
                var retorno = new TipoConcessaoViewModel();
                retorno.tipo_concessao_id = model.tipo_concessao_id;
                retorno.Descricao = model.Descricao;
                retorno.Documentos = model.Documentos;
                retorno.profundidade_minima = model.profundidade_minima;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoConcessaoViewModel();
            }
        }

        private TipoConcessaoViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new TipoConcessaoViewModel()
                {
                    tipo_concessao_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("tipo_concessao_id")).Select(y => y.valor).FirstOrDefault()),
                    Descricao = lmodel.Where(y => y.nome_coluna.Equals("Descricao")).Select(y => y.valor).FirstOrDefault(),
                    Documentos = lmodel.Where(y => y.nome_coluna.Equals("Documentos")).Select(y => y.valor).FirstOrDefault(),
                    profundidade_minima = Convert.ToDouble(lmodel.Where(y => y.nome_coluna.Equals("profundidade_minima")).Select(y => y.valor).FirstOrDefault())
                };
            }
            catch (Exception e)
            {
                return new TipoConcessaoViewModel();
            }
        }
    }

}