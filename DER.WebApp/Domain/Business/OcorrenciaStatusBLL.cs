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
    public class OcorrenciaStatusBLL
    {
        private DerContext context;
        private OcorrenciaStatusDAO ocorrenciaStatusDAO;

        public OcorrenciaStatusBLL()
        {
            context = new DerContext();
            ocorrenciaStatusDAO = new OcorrenciaStatusDAO(context);
        }

        public bool Save(OcorrenciaStatusViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);

                return ExistsById(model.ocorrencia_status_id) ?
                    ocorrenciaStatusDAO.Update(model) :
                    ocorrenciaStatusDAO.Inserir(model);
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

                return ExistsById(model.ocorrencia_status_id) ?
                    ocorrenciaStatusDAO.Update(model) :
                    ocorrenciaStatusDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<OcorrenciaStatusViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ConvertModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<OcorrenciaStatusViewModel>();
            }
        }

        public List<OcorrenciaStatus> Load()
        {
            try
            {
                return ocorrenciaStatusDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<OcorrenciaStatus>();
            }
        }

        public bool Remove(OcorrenciaStatusViewModel viewModel)
        {
            try
            {
                var model = ConvertModel(viewModel);
                return ExistsById(model.ocorrencia_status_id) ?
                    ocorrenciaStatusDAO.Delete(model) : false;
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
                return Load().Any(x => x.ocorrencia_status_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<OcorrenciaStatusViewModel> ToList(OcorrenciaStatusViewModel model, List<OcorrenciaStatusViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<OcorrenciaStatusViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<OcorrenciaStatusViewModel>();
            }
        }

        private OcorrenciaStatus ConvertModel(OcorrenciaStatusViewModel model)
        {
            try
            {
                var retorno = new OcorrenciaStatus();
                retorno.ocorrencia_status_id = (int)model.ocorrencia_status_id;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new OcorrenciaStatus();
            }
        }

        private OcorrenciaStatusViewModel ConvertModel(OcorrenciaStatus model)
        {
            try
            {
                var retorno = new OcorrenciaStatusViewModel();
                retorno.ocorrencia_status_id = model.ocorrencia_status_id;
                retorno.nome = model.nome;

                return retorno;
            }
            catch (Exception e)
            {
                return new OcorrenciaStatusViewModel();
            }
        }

        private OcorrenciaStatusViewModel ConvertModel(List<DadoMestreTabelaValoresViewModel> lmodel)
        {
            try
            {
                return new OcorrenciaStatusViewModel()
                {
                    ocorrencia_status_id = Convert.ToInt32(lmodel.Where(y => y.nome_coluna.Equals("ocorrencia_status_id")).Select(y => y.valor).FirstOrDefault()),
                    nome = lmodel.Where(y => y.nome_coluna.Equals("nome")).Select(y => y.valor).FirstOrDefault()
                };
            }
            catch (Exception e)
            {
                return new OcorrenciaStatusViewModel();
            }
        }
    }
}