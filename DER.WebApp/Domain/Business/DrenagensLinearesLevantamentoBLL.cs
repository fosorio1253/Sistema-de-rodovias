using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DrenagensLinearesLevantamentoBLL
    {
        private DerContext context;
        private DrenagensLinearesLevantamentoDAO drenagenslineareslevantamentoDAO;

        public DrenagensLinearesLevantamentoBLL()
        {
            context = new DerContext();
            drenagenslineareslevantamentoDAO = new DrenagensLinearesLevantamentoDAO(context);
        }

        public bool Save(DrenagensLinearesLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    drenagenslineareslevantamentoDAO.Update(model) :
                    drenagenslineareslevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(DrenagensLinearesLevantamento model)
        {
            try
            {
                return ExistsById(model.rod_id) ?
                    drenagenslineareslevantamentoDAO.Update(model) :
                    drenagenslineareslevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DrenagensLinearesLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DrenagensLinearesLevantamentoViewModel>();
            }
        }

        public List<DrenagensLinearesLevantamento> Load()
        {
            try
            {
                return drenagenslineareslevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DrenagensLinearesLevantamento>();
            }
        }

        public bool Remove(DrenagensLinearesLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    drenagenslineareslevantamentoDAO.Delete(model) : false;
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
                return Load().Any(x => x.rod_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DrenagensLinearesLevantamentoViewModel> ToList(DrenagensLinearesLevantamentoViewModel model, List<DrenagensLinearesLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DrenagensLinearesLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DrenagensLinearesLevantamentoViewModel>();
            }
        }

        private DrenagensLinearesLevantamento ViewModelToModel(DrenagensLinearesLevantamentoViewModel model)
        {
            try
            {
                var retorno = new DrenagensLinearesLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.drl_km_inicial = model.drl_km_inicial;
                retorno.drl_km_final = model.drl_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.drl_data_levantamento = model.drl_data_levantamento;
                retorno.drl_extensao = model.drl_extensao;
                retorno.drt_id = model.drt_id;
                retorno.drl_data_criacao = model.drl_data_criacao;
                retorno.drl_id_segmento = Convert.ToInt32(model.drl_id_segmento);
                retorno.drl_dispositivo = Convert.ToBoolean(model.drl_dispositivo);
                retorno.drl_ext_geometria = model.drl_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new DrenagensLinearesLevantamento();
            }
        }

        private DrenagensLinearesLevantamentoViewModel ModelToViewModel(DrenagensLinearesLevantamento model)
        {
            try
            {
                var retorno = new DrenagensLinearesLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.drl_km_inicial = model.drl_km_inicial;
                retorno.drl_km_final = model.drl_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.drl_data_levantamento = model.drl_data_levantamento;
                retorno.drl_extensao = model.drl_extensao;
                retorno.drt_id = model.drt_id;
                retorno.drl_data_criacao = model.drl_data_criacao;
                retorno.drl_id_segmento = model.drl_id_segmento;
                retorno.drl_dispositivo = model.drl_dispositivo.ToString();
                retorno.drl_ext_geometria = model.drl_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new DrenagensLinearesLevantamentoViewModel();
            }
        }
    }

}