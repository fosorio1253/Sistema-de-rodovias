﻿using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class OaeLevantamentoBLL
    {
        private DerContext context;
        private OaeLevantamentoDAO oaelevantamentoDAO;

        public OaeLevantamentoBLL()
        {
            context = new DerContext();
            oaelevantamentoDAO = new OaeLevantamentoDAO(context);
        }

        public bool Save(OaeLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    oaelevantamentoDAO.Update(model) :
                    oaelevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(OaeLevantamento model)
        {
            try
            {
                return ExistsById(model.rod_id) ?
                    oaelevantamentoDAO.Update(model) :
                    oaelevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<OaeLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<OaeLevantamentoViewModel>();
            }
        }

        public List<OaeLevantamento> Load()
        {
            try
            {
                return oaelevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<OaeLevantamento>();
            }
        }

        public bool Remove(OaeLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    oaelevantamentoDAO.Delete(model) : false;
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

        public List<OaeLevantamentoViewModel> ToList(OaeLevantamentoViewModel model, List<OaeLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<OaeLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<OaeLevantamentoViewModel>();
            }
        }

        private OaeLevantamento ViewModelToModel(OaeLevantamentoViewModel model)
        {
            try
            {
                var retorno = new OaeLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.oae_km_inicial = model.oae_km_inicial;
                retorno.oae_km_final = model.oae_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.oae_data_levantamento = model.oae_data_levantamento;
                retorno.oae_extensao = model.oae_extensao;
                retorno.oat_id = model.oat_id;
                retorno.oae_data_criacao = model.oae_data_criacao;
                retorno.oae_id_segmento = model.oae_id_segmento;
                retorno.oae_ext_geometria = model.oae_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new OaeLevantamento();
            }
        }

        private OaeLevantamentoViewModel ModelToViewModel(OaeLevantamento model)
        {
            try
            {
                var retorno = new OaeLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.oae_km_inicial = model.oae_km_inicial;
                retorno.oae_km_final = model.oae_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.oae_data_levantamento = model.oae_data_levantamento;
                retorno.oae_extensao = model.oae_extensao;
                retorno.oat_id = model.oat_id;
                retorno.oae_data_criacao = model.oae_data_criacao;
                retorno.oae_id_segmento = model.oae_id_segmento;
                retorno.oae_ext_geometria = model.oae_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new OaeLevantamentoViewModel();
            }
        }
    }

}