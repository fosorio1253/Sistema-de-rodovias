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
    public class TipoDocumentoBLL
    {
        private DerContext context;
        private TipoDocumentoDAO tipoDocumentoDAO;

        public TipoDocumentoBLL()
        {
            context = new DerContext();
            tipoDocumentoDAO = new TipoDocumentoDAO(context);
        }

        public bool Save(TipoDocumentoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.tipo_documento_id) ?
                    tipoDocumentoDAO.Update(model) :
                    tipoDocumentoDAO.Inserir(model);
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

                return ExistsById(model.tipo_documento_id) ?
                    tipoDocumentoDAO.Update(model) :
                    tipoDocumentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoDocumentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TipoDocumentoViewModel>();
            }
        }

        public List<TipoDocumentos> Load()
        {
            try
            {
                return tipoDocumentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TipoDocumentos>();
            }
        }

        public bool Remove(TipoDocumentoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.tipo_documento_id) ?
                    tipoDocumentoDAO.Delete(model) : false;
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
                return Load().Any(x => x.tipo_documento_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoDocumentoViewModel> ToList(TipoDocumentoViewModel model, List<TipoDocumentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TipoDocumentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TipoDocumentoViewModel>();
            }
        }

        private TipoDocumentos ConvertModel(TipoDocumentoViewModel model)
        {
            try
            {
                var retorno = new TipoDocumentos();
                retorno.tipo_documento_id = (int)model.tipo_documento_id;
                retorno.descricao = model.descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoDocumentos();
            }
        }

        private TipoDocumentoViewModel ConvertModel(TipoDocumentos model)
        {
            try
            {
                var retorno = new TipoDocumentoViewModel();
                retorno.tipo_documento_id = model.tipo_documento_id;
                retorno.descricao = model.descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoDocumentoViewModel();
            }
        }

        private TipoDocumentoViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new TipoDocumentoViewModel()
                {
                    tipo_documento_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("tipo_documento_id")).Select(y => y.valor).FirstOrDefault()),
                    descricao = lmodel.Where(y => y.nome_coluna.Equals("descricao")).Select(y => y.valor).FirstOrDefault()
                };
            }
            catch (Exception e)
            {
                return new TipoDocumentoViewModel();
            }
        }
    }
}