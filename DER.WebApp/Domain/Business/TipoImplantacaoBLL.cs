using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using DER.WebApp.ViewModels.GestaoOcupacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class TipoImplantacaoBLL
    {
        private DerContext context;
        private TipoImplantacaoDAO tipoImplantacaoDAO;

        public TipoImplantacaoBLL()
        {
            context = new DerContext();
            tipoImplantacaoDAO = new TipoImplantacaoDAO(context);
        }

        public bool Save(TipoImplantacaoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.tipo_implantacao_id) ?
                    tipoImplantacaoDAO.Update(model) :
                    tipoImplantacaoDAO.Inserir(model);
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

                return ExistsById(model.tipo_implantacao_id) ?
                    tipoImplantacaoDAO.Update(model) :
                    tipoImplantacaoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoImplantacaoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TipoImplantacaoViewModel>();
            }
        }

        public List<TipoImplantacao> Load()
        {
            try
            {
                return tipoImplantacaoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TipoImplantacao>();
            }
        }

        public bool Remove(TipoImplantacaoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.tipo_implantacao_id) ?
                    tipoImplantacaoDAO.Delete(model) : false;
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
                return Load().Any(x => x.tipo_implantacao_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TipoImplantacaoViewModel> ToList(TipoImplantacaoViewModel model, List<TipoImplantacaoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TipoImplantacaoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TipoImplantacaoViewModel>();
            }
        }

        private TipoImplantacao ConvertModel(TipoImplantacaoViewModel model)
        {
            try
            {
                var retorno = new TipoImplantacao();
                retorno.tipo_implantacao_id = (int)model.TipoImplantacaoId;
                retorno.nome = model.Nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoImplantacao();
            }
        }

        private TipoImplantacaoViewModel ConvertModel(TipoImplantacao model)
        {
            try
            {
                var retorno = new TipoImplantacaoViewModel();
                retorno.TipoImplantacaoId = model.tipo_implantacao_id;
                retorno.Nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new TipoImplantacaoViewModel();
            }
        }

        private TipoImplantacaoViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new TipoImplantacaoViewModel()
                {
                    TipoImplantacaoId = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("TipoImplantacaoId")).Select(y => y.valor).FirstOrDefault()),
                    Nome = lmodel.Where(y => y.nome_coluna.Equals("Nome")).Select(y => y.valor).FirstOrDefault()
                };
            }
            catch (Exception e)
            {
                return new TipoImplantacaoViewModel();
            }
        }
    }
}