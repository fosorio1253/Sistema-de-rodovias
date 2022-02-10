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
    public class OrigemSolicitacaoBLL
    {
        private DerContext context;
        private OrigemSolicitacaoDAO origemSolicitacaoDAO;

        public OrigemSolicitacaoBLL()
        {
            context = new DerContext();
            origemSolicitacaoDAO = new OrigemSolicitacaoDAO(context);
        }

        public bool Save(OrigemSolicitacaoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.origem_da_solicitacao_id) ?
                    origemSolicitacaoDAO.Update(model) :
                    origemSolicitacaoDAO.Inserir(model);
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

                return ExistsById(model.origem_da_solicitacao_id) ?
                    origemSolicitacaoDAO.Update(model) :
                    origemSolicitacaoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<OrigemSolicitacaoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<OrigemSolicitacaoViewModel>();
            }
        }

        public List<OrigemSolicitacao> Load()
        {
            try
            {
                return origemSolicitacaoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<OrigemSolicitacao>();
            }
        }

        public bool Remove(OrigemSolicitacaoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.origem_da_solicitacao_id) ?
                    origemSolicitacaoDAO.Delete(model) : false;
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
                return Load().Any(x => x.origem_da_solicitacao_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<OrigemSolicitacaoViewModel> ToList(OrigemSolicitacaoViewModel model, List<OrigemSolicitacaoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<OrigemSolicitacaoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<OrigemSolicitacaoViewModel>();
            }
        }

        private OrigemSolicitacao ConvertModel(OrigemSolicitacaoViewModel model)
        {
            try
            {
                var retorno = new OrigemSolicitacao();
                retorno.origem_da_solicitacao_id = model.origem_da_solicitacao_id;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new OrigemSolicitacao();
            }
        }

        private OrigemSolicitacaoViewModel ConvertModel(OrigemSolicitacao model)
        {
            try
            {
                var retorno = new OrigemSolicitacaoViewModel();
                retorno.origem_da_solicitacao_id = model.origem_da_solicitacao_id;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new OrigemSolicitacaoViewModel();
            }
        }

        private OrigemSolicitacaoViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new OrigemSolicitacaoViewModel()
                {
                    origem_da_solicitacao_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("origem_da_solicitacao_id")).Select(y => y.valor).FirstOrDefault()),
                    nome = lmodel.Where(y => y.nome_coluna.Equals("nome")).Select(y => y.valor).FirstOrDefault()
                };
            }
            catch (Exception e)
            {
                return new OrigemSolicitacaoViewModel();
            }
        }
    }
}