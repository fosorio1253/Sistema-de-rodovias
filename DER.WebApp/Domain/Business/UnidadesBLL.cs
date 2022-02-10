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
    public class UnidadesBLL
    {
        private DerContext context;
        private UnidadeDAO unidadeDAO;

        public UnidadesBLL()
        {
            context = new DerContext();
            unidadeDAO = new UnidadeDAO(context);
        }

        public bool Save(UnidadeViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.unidade_id) ?
                    unidadeDAO.Update(model) :
                    unidadeDAO.Inserir(model);
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

                return ExistsById(model.unidade_id) ?
                    unidadeDAO.Update(model) :
                    unidadeDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<UnidadeViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<UnidadeViewModel>();
            }
        }

        public List<Unidade> Load()
        {
            try
            {
                return unidadeDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Unidade>();
            }
        }

        public bool Remove(UnidadeViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.unidade_id) ?
                    unidadeDAO.Delete(model) : false;
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
                return Load().Any(x => x.unidade_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<UnidadeViewModel> ToList(UnidadeViewModel model, List<UnidadeViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<UnidadeViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<UnidadeViewModel>();
            }
        }

        private Unidade ConvertModel(UnidadeViewModel model)
        {
            try
            {
                var retorno = new Unidade();
                retorno.unidade_id = model.unidade_id;
                retorno.sigla = model.sigla;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new Unidade();
            }
        }

        private UnidadeViewModel ConvertModel(Unidade model)
        {
            try
            {
                var retorno = new UnidadeViewModel();
                retorno.unidade_id = model.unidade_id;
                retorno.sigla = model.sigla;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new UnidadeViewModel();
            }
        }

        private UnidadeViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new UnidadeViewModel()
                {
                    unidade_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("unidade_id")).Select(y => y.valor).FirstOrDefault()),
                    nome = lmodel.Where(y => y.nome_coluna.Equals("nome")).Select(y => y.valor).FirstOrDefault()
                };
            }
            catch (Exception e)
            {
                return new UnidadeViewModel();
            }
        }
    }

}