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
    public class UaBLL
    {
        private DerContext context;
        private UaDAO uaDAO;

        public UaBLL()
        {
            context = new DerContext();
            uaDAO = new UaDAO(context);
        }

        public bool Save(UaViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.ua_id) ?
                    uaDAO.Update(model) :
                    uaDAO.Inserir(model);
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

                return ExistsById(model.ua_id) ?
                    uaDAO.Update(model) :
                    uaDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<UaViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<UaViewModel>();
            }
        }

        public List<Ua> Load()
        {
            try
            {
                return uaDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Ua>();
            }
        }

        public bool Remove(UaViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.ua_id) ?
                    uaDAO.Delete(model) : false;
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
                return Load().Any(x => x.ua_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<UaViewModel> ToList(UaViewModel model, List<UaViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<UaViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<UaViewModel>();
            }
        }

        private Ua ConvertModel(UaViewModel model)
        {
            try
            {
                var retorno = new Ua();
                retorno.ua_id = model.ua_id;
                retorno.sigla = model.sigla;
                retorno.nome_ua = model.nome_ua;
                retorno.unidade = model.unidade;
                retorno.regional = model.regional;

                return retorno;
            }
            catch (Exception e)
            {
                return new Ua();
            }
        }

        private UaViewModel ConvertModel(Ua model)
        {
            try
            {
                var retorno = new UaViewModel();
                retorno.ua_id = model.ua_id;
                retorno.sigla = model.sigla;
                retorno.nome_ua = model.nome_ua;
                retorno.unidade = model.unidade;
                retorno.regional = model.regional;

                return retorno;
            }
            catch (Exception e)
            {
                return new UaViewModel();
            }
        }

        private UaViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new UaViewModel()
                {
                    ua_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("ua_id")).Select(y => y.valor).FirstOrDefault()),
                    nome_ua = lmodel.Where(y => y.nome_coluna.Equals("nome_ua")).Select(y => y.valor).FirstOrDefault(),
                    regional = lmodel.Where(y => y.nome_coluna.Equals("regional")).Select(y => y.valor).FirstOrDefault(),
                    sigla = lmodel.Where(y => y.nome_coluna.Equals("sigla")).Select(y => y.valor).FirstOrDefault(),
                    unidade = lmodel.Where(y => y.nome_coluna.Equals("unidade")).Select(y => y.valor).FirstOrDefault()
                };
            }
            catch (Exception e)
            {
                return new UaViewModel();
            }
        }
    }

}