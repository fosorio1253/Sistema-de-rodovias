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
    public class TipoEmpresasBLL
    {
        private DerContext context;
        private TipoEmpresaDAO tipoEmpresaDAO;

        public TipoEmpresasBLL()
        {
            context = new DerContext();
            tipoEmpresaDAO = new TipoEmpresaDAO(context);
        }

        public bool Save(TipoEmpresaViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.tipo_empresa_id) ?
                    tipoEmpresaDAO.Update(model) :
                    tipoEmpresaDAO.Inserir(model);
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

                return ExistsById(model.tipo_empresa_id) ?
                    tipoEmpresaDAO.Update(model) :
                    tipoEmpresaDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoEmpresaViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TipoEmpresaViewModel>();
            }
        }

        public List<TipoEmpresa> Load()
        {
            try
            {
                return tipoEmpresaDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TipoEmpresa>();
            }
        }

        public bool Remove(TipoEmpresaViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.tipo_empresa_id) ?
                    tipoEmpresaDAO.Delete(model) : false;
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
                return Load().Any(x => x.tipo_empresa_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoEmpresaViewModel> ToList(TipoEmpresaViewModel model, List<TipoEmpresaViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TipoEmpresaViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TipoEmpresaViewModel>();
            }
        }

        private TipoEmpresa ConvertModel(TipoEmpresaViewModel model)
        {
            try
            {
                var retorno = new TipoEmpresa();
                retorno.tipo_empresa_id = (int)model.TipoEmpresaId;
                retorno.descricao = model.Nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoEmpresa();
            }
        }

        private TipoEmpresaViewModel ConvertModel(TipoEmpresa model)
        {
            try
            {
                var retorno = new TipoEmpresaViewModel();
                retorno.TipoEmpresaId = model.tipo_empresa_id;
                retorno.Nome = model.descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoEmpresaViewModel();
            }
        }

        private TipoEmpresaViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new TipoEmpresaViewModel()
                {
                    TipoEmpresaId = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("TipoEmpresaId")).Select(y => y.valor).FirstOrDefault()),
                    Nome = lmodel.Where(y => y.nome_coluna.Equals("Nome")).Select(y => y.valor).FirstOrDefault()
                };
            }
            catch (Exception e)
            {
                return new TipoEmpresaViewModel();
            }
        }
    }
}