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
    public class TipoInteressadosBLL
    {
        private DerContext context;
        private TipoInteressadoDAO tipointeressadoDAO;

        public TipoInteressadosBLL()
        {
            context = new DerContext();
            tipointeressadoDAO = new TipoInteressadoDAO(context);
        }

        public bool Save(TipoInteressadoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.tipo_interessado_id) ?
                    tipointeressadoDAO.Update(model) :
                    tipointeressadoDAO.Inserir(model);
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

                return ExistsById(model.tipo_interessado_id) ?
                    tipointeressadoDAO.Update(model) :
                    tipointeressadoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoInteressadoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TipoInteressadoViewModel>();
            }
        }

        public List<TipoInteressado> Load()
        {
            try
            {
                return tipointeressadoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TipoInteressado>();
            }
        }

        public bool Remove(TipoInteressadoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.tipo_interessado_id) ?
                    tipointeressadoDAO.Delete(model) : false;
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
                return Load().Any(x => x.tipo_interessado_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoInteressadoViewModel> ToList(TipoInteressadoViewModel model, List<TipoInteressadoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TipoInteressadoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TipoInteressadoViewModel>();
            }
        }

        private TipoInteressado ConvertModel(TipoInteressadoViewModel model)
        {
            try
            {
                var retorno = new TipoInteressado();
                retorno.tipo_interessado_id = model.tipo_interessado_id;
                retorno.descricao = model.descricao;
                retorno.fator_interessado = model.fator_interessado;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoInteressado();
            }
        }

        private TipoInteressadoViewModel ConvertModel(TipoInteressado model)
        {
            try
            {
                var retorno = new TipoInteressadoViewModel();
                retorno.tipo_interessado_id = model.tipo_interessado_id;
                retorno.descricao = model.descricao;
                retorno.fator_interessado = model.fator_interessado;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoInteressadoViewModel();
            }
        }

        private TipoInteressadoViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new TipoInteressadoViewModel()
                {
                    tipo_interessado_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("tipo_interessado_id")).Select(y => y.valor).FirstOrDefault()),
                    descricao = lmodel.Where(y => y.nome_coluna.Equals("descricao")).Select(y => y.valor).FirstOrDefault(),
                    fator_interessado = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("fator_interessado")).Select(y => y.valor).FirstOrDefault())
                };
            }
            catch (Exception e)
            {
                return new TipoInteressadoViewModel();
            }
        }
    }

}