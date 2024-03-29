﻿using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class TipoDocumentoInteressadoBLL
    {
        private DerContext context;
        private TipoDocumentoInteressadoDAO tipodocumentointeressadoDAO;

        public TipoDocumentoInteressadoBLL()
        {
            context = new DerContext();
            tipodocumentointeressadoDAO = new TipoDocumentoInteressadoDAO(context);
        }

        public bool Save(TipoDocumentoInteressadoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.tipo_documento_interessado_id) ?
                    tipodocumentointeressadoDAO.Update(model) :
                    tipodocumentointeressadoDAO.Inserir(model);
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

                return ExistsById(model.tipo_documento_interessado_id) ?
                    tipodocumentointeressadoDAO.Update(model) :
                    tipodocumentointeressadoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoDocumentoInteressadoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TipoDocumentoInteressadoViewModel>();
            }
        }

        public List<TipoDocumentoInteressado> Load()
        {
            try
            {
                return tipodocumentointeressadoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TipoDocumentoInteressado>();
            }
        }

        public bool Remove(TipoDocumentoInteressadoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.tipo_documento_interessado_id) ?
                    tipodocumentointeressadoDAO.Delete(model) : false;
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
                return Load().Any(x => x.tipo_documento_interessado_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoDocumentoInteressadoViewModel> ToList(TipoDocumentoInteressadoViewModel model, List<TipoDocumentoInteressadoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TipoDocumentoInteressadoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TipoDocumentoInteressadoViewModel>();
            }
        }

        private TipoDocumentoInteressado ConvertModel(TipoDocumentoInteressadoViewModel model)
        {
            try
            {
                var retorno = new TipoDocumentoInteressado();
                retorno.tipo_documento_interessado_id = model.tipo_documento_interessado_id;
                retorno.descricao = model.descricao;
                retorno.tipo_interessado = model.tipo_interessado;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoDocumentoInteressado();
            }
        }

        private TipoDocumentoInteressadoViewModel ConvertModel(TipoDocumentoInteressado model)
        {
            try
            {
                var retorno = new TipoDocumentoInteressadoViewModel();
                retorno.tipo_documento_interessado_id = model.tipo_documento_interessado_id;
                retorno.descricao = model.descricao;
                retorno.tipo_interessado = model.tipo_interessado;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoDocumentoInteressadoViewModel();
            }
        }

        private TipoDocumentoInteressadoViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new TipoDocumentoInteressadoViewModel()
                {
                    tipo_documento_interessado_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("tipo_documento_interessado_id")).Select(y => y.valor).FirstOrDefault()),
                    descricao = lmodel.Where(y => y.nome_coluna.Equals("descricao")).Select(y => y.valor).FirstOrDefault(),
                    tipo_interessado = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("tipo_interessado")).Select(y => y.valor).FirstOrDefault())
                };
            }
            catch (Exception e)
            {
                return new TipoDocumentoInteressadoViewModel();
            }
        }
    }

}