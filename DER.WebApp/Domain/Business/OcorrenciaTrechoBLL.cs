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
    public class OcorrenciaTrechoBLL
    {
        private DerContext context;
        private OcorrenciaTrechoDAO ocorrenciaTrechoDAO;

        public OcorrenciaTrechoBLL()
        {
            context = new DerContext();
            ocorrenciaTrechoDAO = new OcorrenciaTrechoDAO(context);
        }

        public bool Save(OcorrenciaTrechoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.ocorrencia_trecho_id) ?
                    ocorrenciaTrechoDAO.Update(model) :
                    ocorrenciaTrechoDAO.Inserir(model);
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

                return ExistsById(model.ocorrencia_trecho_id) ?
                    ocorrenciaTrechoDAO.Update(model) :
                    ocorrenciaTrechoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<OcorrenciaTrechoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<OcorrenciaTrechoViewModel>();
            }
        }

        public List<OcorrenciaTrecho> Load()
        {
            try
            {
                return ocorrenciaTrechoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<OcorrenciaTrecho>();
            }
        }

        public bool Remove(OcorrenciaTrechoViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.ocorrencia_trecho_id) ?
                    ocorrenciaTrechoDAO.Delete(model) : false;
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
                return Load().Any(x => x.ocorrencia_trecho_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<OcorrenciaTrechoViewModel> ToList(OcorrenciaTrechoViewModel model, List<OcorrenciaTrechoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<OcorrenciaTrechoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<OcorrenciaTrechoViewModel>();
            }
        }

        private OcorrenciaTrecho ConvertModel(OcorrenciaTrechoViewModel model)
        {
            try
            {
                var retorno = new OcorrenciaTrecho();
                retorno.ocorrencia_trecho_id = (int)model.ocorrencia_trecho_id;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new OcorrenciaTrecho();
            }
        }

        private OcorrenciaTrechoViewModel ConvertModel(OcorrenciaTrecho model)
        {
            try
            {
                var retorno = new OcorrenciaTrechoViewModel();
                retorno.ocorrencia_trecho_id = model.ocorrencia_trecho_id;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new OcorrenciaTrechoViewModel();
            }
        }

        private OcorrenciaTrechoViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new OcorrenciaTrechoViewModel()
                {
                    ocorrencia_trecho_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("ocorrencia_trecho_id")).Select(y => y.valor).FirstOrDefault()),
                    nome = lmodel.Where(y => y.nome_coluna.Equals("nome")).Select(y => y.valor).FirstOrDefault()
                };
            }
            catch (Exception e)
            {
                return new OcorrenciaTrechoViewModel();
            }
        }
    }
}