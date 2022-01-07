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
    public class FaixasRolamentoLevantamentoBLL
    {
        private DerContext context;
        private FaixasRolamentoLevantamentoDAO faixasrolamentolevantamentoDAO;

        public FaixasRolamentoLevantamentoBLL()
        {
            context = new DerContext();
            faixasrolamentolevantamentoDAO = new FaixasRolamentoLevantamentoDAO(context);
        }

        public bool Save(FaixasRolamentoLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    faixasrolamentolevantamentoDAO.Update(model) :
                    faixasrolamentolevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<FaixasRolamentoLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<FaixasRolamentoLevantamentoViewModel>();
            }
        }

        public List<FaixasRolamentoLevantamento> Load()
        {
            try
            {
                return faixasrolamentolevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<FaixasRolamentoLevantamento>();
            }
        }

        public bool Remove(FaixasRolamentoLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    faixasrolamentolevantamentoDAO.Delete(model) : false;
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

        public List<FaixasRolamentoLevantamentoViewModel> ToList(FaixasRolamentoLevantamentoViewModel model, List<FaixasRolamentoLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<FaixasRolamentoLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<FaixasRolamentoLevantamentoViewModel>();
            }
        }

        private FaixasRolamentoLevantamento ViewModelToModel(FaixasRolamentoLevantamentoViewModel model)
        {
            try
            {
                var retorno = new FaixasRolamentoLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.frl_km_inicial = model.frl_km_inicial;
                retorno.frl_km_final = model.frl_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.frl_data_levantamento = model.frl_data_levantamento;
                retorno.frl_extensao = model.frl_extensao;
                retorno.frl_num_faixas = Convert.ToInt32(model.frl_num_faixas);
                retorno.frl_data_criacao = model.frl_data_criacao;
                retorno.frl_id_segmento = model.frl_id_segmento;
                retorno.frl_dispositivo = Convert.ToBoolean(model.frl_dispositivo);
                retorno.frl_ext_geometria = model.frl_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new FaixasRolamentoLevantamento();
            }
        }

        private FaixasRolamentoLevantamentoViewModel ModelToViewModel(FaixasRolamentoLevantamento model)
        {
            try
            {
                var retorno = new FaixasRolamentoLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.frl_km_inicial = model.frl_km_inicial;
                retorno.frl_km_final = model.frl_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.frl_data_levantamento = model.frl_data_levantamento;
                retorno.frl_extensao = model.frl_extensao;
                retorno.frl_num_faixas = model.frl_num_faixas;
                retorno.frl_data_criacao = model.frl_data_criacao;
                retorno.frl_id_segmento = model.frl_id_segmento;
                retorno.frl_dispositivo = model.frl_dispositivo.ToString();
                retorno.frl_ext_geometria = model.frl_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new FaixasRolamentoLevantamentoViewModel();
            }
        }
    }

}