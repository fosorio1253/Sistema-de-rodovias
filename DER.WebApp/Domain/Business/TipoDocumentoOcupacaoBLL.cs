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
    public class TipoDocumentoOcupacaoBLL
    {
        private DerContext context;
        private TipoDocumentoOcupacaoDAO tipoDocumentoOcupacaoDAO;

        public TipoDocumentoOcupacaoBLL()
        {
            context = new DerContext();
            tipoDocumentoOcupacaoDAO = new TipoDocumentoOcupacaoDAO(context);
        }

        public bool Save(TipoDeDocumentoOcupacaoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.tipo_documento_ocupao_id) ?
                    tipoDocumentoOcupacaoDAO.Update(model) :
                    tipoDocumentoOcupacaoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoDeDocumentoOcupacaoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TipoDeDocumentoOcupacaoViewModel>();
            }
        }

        public List<TipoDocumentoOcupacao> Load()
        {
            try
            {
                return tipoDocumentoOcupacaoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TipoDocumentoOcupacao>();
            }
        }

        public bool Remove(TipoDeDocumentoOcupacaoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.tipo_documento_ocupao_id) ?
                    tipoDocumentoOcupacaoDAO.Delete(model) : false;
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
                return Load().Any(x => x.tipo_documento_ocupao_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoDeDocumentoOcupacaoViewModel> ToList(TipoDeDocumentoOcupacaoViewModel model, List<TipoDeDocumentoOcupacaoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TipoDeDocumentoOcupacaoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TipoDeDocumentoOcupacaoViewModel>();
            }
        }

        private TipoDocumentoOcupacao ConvertModel(TipoDeDocumentoOcupacaoViewModel model)
        {
            try
            {
                var retorno = new TipoDocumentoOcupacao();
                retorno.tipo_documento_ocupao_id = (int)model.TipoDeDocumentoOcupacaoId;
                retorno.descricao = model.Nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoDocumentoOcupacao();
            }
        }

        private TipoDeDocumentoOcupacaoViewModel ConvertModel(TipoDocumentoOcupacao model)
        {
            try
            {
                var retorno = new TipoDeDocumentoOcupacaoViewModel();
                retorno.TipoDeDocumentoOcupacaoId = model.tipo_documento_ocupao_id;
                retorno.Nome = model.descricao;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoDeDocumentoOcupacaoViewModel();
            }
        }
    }
}