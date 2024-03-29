﻿using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class UfespBLL
    {
        private DerContext context;
        private UfespDAO ufespDAO;

        public UfespBLL()
        {
            context = new DerContext();
            ufespDAO = new UfespDAO(context);
        }

        public bool Save(UfespViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.ufesp_id) ?
                    ufespDAO.Update(model) :
                    ufespDAO.Inserir(model);
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

                return ExistsById(model.ufesp_id) ?
                    ufespDAO.Update(model) :
                    ufespDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<UfespViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<UfespViewModel>();
            }
        }

        public List<Ufesp> Load()
        {
            try
            {
                return ufespDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<Ufesp>();
            }
        }

        public bool Remove(UfespViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.ufesp_id) ?
                    ufespDAO.Delete(model) : false;
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
                return Load().Any(x => x.ufesp_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<UfespViewModel> ToList(UfespViewModel model, List<UfespViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<UfespViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<UfespViewModel>();
            }
        }

        private Ufesp ConvertModel(UfespViewModel model)
        {
            try
            {
                var retorno = new Ufesp();
                retorno.ufesp_id = model.ufesp_id;
                retorno.mes_ano = model.mes_ano;
                retorno.valor = model.valor;
                retorno.p_calculado = model.p_calculado;

                return retorno;
            }
            catch (Exception e)
            {
                return new Ufesp();
            }
        }

        private UfespViewModel ConvertModel(Ufesp model)
        {
            try
            {
                var retorno = new UfespViewModel();
                retorno.ufesp_id = model.ufesp_id;
                retorno.mes_ano = model.mes_ano;
                retorno.valor = model.valor;
                retorno.p_calculado = model.p_calculado;

                return retorno;
            }
            catch (Exception e)
            {
                return new UfespViewModel();
            }
        }

        private UfespViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new UfespViewModel()
                {
                    ufesp_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("ufesp_id")).Select(y => y.valor).FirstOrDefault()),
                    mes_ano = Convert.ToDateTime(lmodel.Where(y => y.nome_coluna.Equals("mes_ano")).Select(y => y.valor).FirstOrDefault()),
                    p_calculado = Convert.ToDouble(lmodel.Where(y => y.nome_coluna.Equals("p_calculado")).Select(y => y.valor).FirstOrDefault()),
                    valor = Convert.ToDouble(lmodel.Where(y => y.nome_coluna.Equals("valor")).Select(y => y.valor).FirstOrDefault())
                };
            }
            catch (Exception e)
            {
                return new UfespViewModel();
            }
        }
    }

}