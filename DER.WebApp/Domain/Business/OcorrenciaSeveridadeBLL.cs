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
    public class OcorrenciaSeveridadeBLL
    {
        private DerContext context;
        private OcorrenciaSeveridadeDAO ocorrenciaSeveridadeDAO;

        public OcorrenciaSeveridadeBLL()
        {
            context = new DerContext();
            ocorrenciaSeveridadeDAO = new OcorrenciaSeveridadeDAO(context);
        }

        public bool Save(OcorrenciaSeveridadeViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.ocorrencia_severidade_id) ?
                    ocorrenciaSeveridadeDAO.Update(model) :
                    ocorrenciaSeveridadeDAO.Inserir(model);
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

                return ExistsById(model.ocorrencia_severidade_id) ?
                    ocorrenciaSeveridadeDAO.Update(model) :
                    ocorrenciaSeveridadeDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<OcorrenciaSeveridadeViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<OcorrenciaSeveridadeViewModel>();
            }
        }

        public List<OcorrenciaSeveridade> Load()
        {
            try
            {
                return ocorrenciaSeveridadeDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<OcorrenciaSeveridade>();
            }
        }

        public bool Remove(OcorrenciaSeveridadeViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.ocorrencia_severidade_id) ?
                    ocorrenciaSeveridadeDAO.Delete(model) : false;
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
                return Load().Any(x => x.ocorrencia_severidade_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<OcorrenciaSeveridadeViewModel> ToList(OcorrenciaSeveridadeViewModel model, List<OcorrenciaSeveridadeViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<OcorrenciaSeveridadeViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<OcorrenciaSeveridadeViewModel>();
            }
        }

        private OcorrenciaSeveridade ConvertModel(OcorrenciaSeveridadeViewModel model)
        {
            try
            {
                var retorno = new OcorrenciaSeveridade();
                retorno.ocorrencia_severidade_id = (int)model.ocorrencia_severidade_id;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new OcorrenciaSeveridade();
            }
        }

        private OcorrenciaSeveridadeViewModel ConvertModel(OcorrenciaSeveridade model)
        {
            try
            {
                var retorno = new OcorrenciaSeveridadeViewModel();
                retorno.ocorrencia_severidade_id = model.ocorrencia_severidade_id;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new OcorrenciaSeveridadeViewModel();
            }
        }

        private OcorrenciaSeveridadeViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new OcorrenciaSeveridadeViewModel()
                {
                    ocorrencia_severidade_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("ocorrencia_severidade_id")).Select(y => y.valor).FirstOrDefault()),
                    nome = lmodel.Where(y => y.nome_coluna.Equals("nome")).Select(y => y.valor).FirstOrDefault()
                };
            }
            catch (Exception e)
            {
                return new OcorrenciaSeveridadeViewModel();
            }
        }
    }
}