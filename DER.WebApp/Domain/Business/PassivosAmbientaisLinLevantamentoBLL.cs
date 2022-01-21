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
    public class PassivosAmbientaisLinLevantamentoBLL
    {
        private DerContext context;
        private PassivosAmbientaisLinLevantamentoDAO passivosambientaislinlevantamentoDAO;

        public PassivosAmbientaisLinLevantamentoBLL()
        {
            context = new DerContext();
            passivosambientaislinlevantamentoDAO = new PassivosAmbientaisLinLevantamentoDAO(context);
        }

        public bool Save(PassivosAmbientaisLinLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    passivosambientaislinlevantamentoDAO.Update(model) :
                    passivosambientaislinlevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(PassivosAmbientaisLinLevantamento model)
        {
            try
            {
                return ExistsById(model.rod_id) ?
                    passivosambientaislinlevantamentoDAO.Update(model) :
                    passivosambientaislinlevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<PassivosAmbientaisLinLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<PassivosAmbientaisLinLevantamentoViewModel>();
            }
        }

        public List<PassivosAmbientaisLinLevantamento> Load()
        {
            try
            {
                return passivosambientaislinlevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<PassivosAmbientaisLinLevantamento>();
            }
        }

        public bool Remove(PassivosAmbientaisLinLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    passivosambientaislinlevantamentoDAO.Delete(model) : false;
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

        public List<PassivosAmbientaisLinLevantamentoViewModel> ToList(PassivosAmbientaisLinLevantamentoViewModel model, List<PassivosAmbientaisLinLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<PassivosAmbientaisLinLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<PassivosAmbientaisLinLevantamentoViewModel>();
            }
        }

        private PassivosAmbientaisLinLevantamento ViewModelToModel(PassivosAmbientaisLinLevantamentoViewModel model)
        {
            try
            {
                var retorno = new PassivosAmbientaisLinLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.pal_km_inicial = model.pal_km_inicial;
                retorno.pal_km_final = model.pal_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.pal_data_levantamento = model.pal_data_levantamento;
                retorno.pal_extensao = model.pal_extensao;
                retorno.pat_id = model.pat_id;
                retorno.pal_data_criacao = model.pal_data_criacao;
                retorno.pal_id_segmento = model.pal_id_segmento;
                retorno.pal_dispositivo = Convert.ToBoolean(model.pal_dispositivo);
                retorno.pal_ext_geometria = model.pal_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new PassivosAmbientaisLinLevantamento();
            }
        }

        private PassivosAmbientaisLinLevantamentoViewModel ModelToViewModel(PassivosAmbientaisLinLevantamento model)
        {
            try
            {
                var retorno = new PassivosAmbientaisLinLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.pal_km_inicial = model.pal_km_inicial;
                retorno.pal_km_final = model.pal_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.pal_data_levantamento = model.pal_data_levantamento;
                retorno.pal_extensao = model.pal_extensao;
                retorno.pat_id = model.pat_id;
                retorno.pal_data_criacao = model.pal_data_criacao;
                retorno.pal_id_segmento = model.pal_id_segmento;
                retorno.pal_dispositivo = model.pal_dispositivo.ToString();
                retorno.pal_ext_geometria = model.pal_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new PassivosAmbientaisLinLevantamentoViewModel();
            }
        }
    }

}