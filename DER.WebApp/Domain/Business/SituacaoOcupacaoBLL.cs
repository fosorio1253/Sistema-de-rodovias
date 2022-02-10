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
    public class SituacaoOcupacaoBLL
    {
        private DerContext context;
        private SituacaoOcupacaoDAO situacaoOcupacaoDAO;

        public SituacaoOcupacaoBLL()
        {
            context = new DerContext();
            situacaoOcupacaoDAO = new SituacaoOcupacaoDAO(context);
        }

        public bool Save(GestaoOcupacoesSituacaoOcupacaoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.situacao_ocupacao_id) ?
                    situacaoOcupacaoDAO.Update(model) :
                    situacaoOcupacaoDAO.Inserir(model);
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

                return ExistsById(model.situacao_ocupacao_id) ?
                    situacaoOcupacaoDAO.Update(model) :
                    situacaoOcupacaoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<GestaoOcupacoesSituacaoOcupacaoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesSituacaoOcupacaoViewModel>();
            }
        }

        public List<SituacaoOcupacao> Load()
        {
            try
            {
                return situacaoOcupacaoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<SituacaoOcupacao>();
            }
        }

        public bool Remove(GestaoOcupacoesSituacaoOcupacaoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.situacao_ocupacao_id) ?
                    situacaoOcupacaoDAO.Delete(model) : false;
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
                return Load().Any(x => x.situacao_ocupacao_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<GestaoOcupacoesSituacaoOcupacaoViewModel> ToList(GestaoOcupacoesSituacaoOcupacaoViewModel model, List<GestaoOcupacoesSituacaoOcupacaoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<GestaoOcupacoesSituacaoOcupacaoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<GestaoOcupacoesSituacaoOcupacaoViewModel>();
            }
        }

        private SituacaoOcupacao ConvertModel(GestaoOcupacoesSituacaoOcupacaoViewModel model)
        {
            try
            {
                var retorno = new SituacaoOcupacao();
                retorno.situacao_ocupacao_id = (int)model.SituacaoOcupacaoId;
                retorno.nome = model.Nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new SituacaoOcupacao();
            }
        }

        private GestaoOcupacoesSituacaoOcupacaoViewModel ConvertModel(SituacaoOcupacao model)
        {
            try
            {
                var retorno = new GestaoOcupacoesSituacaoOcupacaoViewModel();
                retorno.SituacaoOcupacaoId = model.situacao_ocupacao_id;
                retorno.Nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesSituacaoOcupacaoViewModel();
            }
        }

        private GestaoOcupacoesSituacaoOcupacaoViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new GestaoOcupacoesSituacaoOcupacaoViewModel()
                {
                    SituacaoOcupacaoId = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("SituacaoOcupacaoId")).Select(y => y.valor).FirstOrDefault()),
                    Nome = lmodel.Where(y => y.nome_coluna.Equals("Nome")).Select(y => y.valor).FirstOrDefault(),
                    Sigla = lmodel.Where(y => y.nome_coluna.Equals("Sigla")).Select(y => y.valor).FirstOrDefault()
                };
            }
            catch (Exception e)
            {
                return new GestaoOcupacoesSituacaoOcupacaoViewModel();
            }
        }
    }
}