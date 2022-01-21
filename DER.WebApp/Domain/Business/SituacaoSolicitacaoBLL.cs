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
    public class SituacaoSolicitacaoBLL
    {
        private DerContext context;
        private SituacaoSolicitacaoDAO situacaoSolicitacaoDAO;

        public SituacaoSolicitacaoBLL()
        {
            context = new DerContext();
            situacaoSolicitacaoDAO = new SituacaoSolicitacaoDAO(context);
        }

        public bool Save(GestaoOcupacoesSituacaoSolicitacaoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.situacao_solicitacao_id) ?
                    situacaoSolicitacaoDAO.Update(model) :
                    situacaoSolicitacaoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<GestaoOcupacoesSituacaoSolicitacaoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesSituacaoSolicitacaoViewModel>();
            }
        }

        public List<SituacaoSolicitacao> Load()
        {
            try
            {
                return situacaoSolicitacaoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<SituacaoSolicitacao>();
            }
        }

        public bool Remove(GestaoOcupacoesSituacaoSolicitacaoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.situacao_solicitacao_id) ?
                    situacaoSolicitacaoDAO.Delete(model) : false;
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
                return Load().Any(x => x.situacao_solicitacao_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<GestaoOcupacoesSituacaoSolicitacaoViewModel> ToList(GestaoOcupacoesSituacaoSolicitacaoViewModel model, List<GestaoOcupacoesSituacaoSolicitacaoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<GestaoOcupacoesSituacaoSolicitacaoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesSituacaoSolicitacaoViewModel>();
            }
        }

        private SituacaoSolicitacao ConvertModel(GestaoOcupacoesSituacaoSolicitacaoViewModel model)
        {
            try
            {
                var retorno = new SituacaoSolicitacao();
                retorno.situacao_solicitacao_id = (int)model.SituacaoSolicitacaoId;
                retorno.nome = model.Nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new SituacaoSolicitacao();
            }
        }

        private GestaoOcupacoesSituacaoSolicitacaoViewModel ConvertModel(SituacaoSolicitacao model)
        {
            try
            {
                var retorno = new GestaoOcupacoesSituacaoSolicitacaoViewModel();
                retorno.SituacaoSolicitacaoId = model.situacao_solicitacao_id;
                retorno.Nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesSituacaoSolicitacaoViewModel();
            }
        }
    }
}