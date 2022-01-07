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
    public class SinalFaixaCentralLevantamentoBLL
    {
        private DerContext context;
        private SinalFaixaCentralLevantamentoDAO sinalfaixacentrallevantamentoDAO;

        public SinalFaixaCentralLevantamentoBLL()
        {
            context = new DerContext();
            sinalfaixacentrallevantamentoDAO = new SinalFaixaCentralLevantamentoDAO(context);
        }

        public bool Save(SinalFaixaCentralLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    sinalfaixacentrallevantamentoDAO.Update(model) :
                    sinalfaixacentrallevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<SinalFaixaCentralLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<SinalFaixaCentralLevantamentoViewModel>();
            }
        }

        public List<SinalFaixaCentralLevantamento> Load()
        {
            try
            {
                return sinalfaixacentrallevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<SinalFaixaCentralLevantamento>();
            }
        }

        public bool Remove(SinalFaixaCentralLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    sinalfaixacentrallevantamentoDAO.Delete(model) : false;
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

        public List<SinalFaixaCentralLevantamentoViewModel> ToList(SinalFaixaCentralLevantamentoViewModel model, List<SinalFaixaCentralLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<SinalFaixaCentralLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<SinalFaixaCentralLevantamentoViewModel>();
            }
        }

        private SinalFaixaCentralLevantamento ViewModelToModel(SinalFaixaCentralLevantamentoViewModel model)
        {
            try
            {
                var retorno = new SinalFaixaCentralLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.sfc_km_inicial = model.sfc_km_inicial;
                retorno.sfc_km_final = model.sfc_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.sfc_data_levantamento = model.sfc_data_levantamento;
                retorno.sfc_extensao = model.sfc_extensao;
                retorno.sht_id = model.sht_id;
                retorno.sfc_largura_faixa = model.sfc_largura_faixa;
                retorno.sfc_data_criacao = model.sfc_data_criacao;
                retorno.sfc_id_segmento = model.sfc_id_segmento;
                retorno.sfc_dispositivo = Convert.ToBoolean(model.sfc_dispositivo);
                retorno.sfc_ext_geometria = model.sfc_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new SinalFaixaCentralLevantamento();
            }
        }

        private SinalFaixaCentralLevantamentoViewModel ModelToViewModel(SinalFaixaCentralLevantamento model)
        {
            try
            {
                var retorno = new SinalFaixaCentralLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.sfc_km_inicial = model.sfc_km_inicial;
                retorno.sfc_km_final = model.sfc_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.sfc_data_levantamento = model.sfc_data_levantamento;
                retorno.sfc_extensao = model.sfc_extensao;
                retorno.sht_id = model.sht_id;
                retorno.sfc_largura_faixa = model.sfc_largura_faixa;
                retorno.sfc_data_criacao = model.sfc_data_criacao;
                retorno.sfc_id_segmento = model.sfc_id_segmento;
                retorno.sfc_dispositivo = model.sfc_dispositivo.ToString();
                retorno.sfc_ext_geometria = model.sfc_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new SinalFaixaCentralLevantamentoViewModel();
            }
        }
    }

}