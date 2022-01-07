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
    public class TachaFaixaCentralLevantamentoBLL
    {
        private DerContext context;
        private TachaFaixaCentralLevantamentoDAO tachafaixacentrallevantamentoDAO;

        public TachaFaixaCentralLevantamentoBLL()
        {
            context = new DerContext();
            tachafaixacentrallevantamentoDAO = new TachaFaixaCentralLevantamentoDAO(context);
        }

        public bool Save(TachaFaixaCentralLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    tachafaixacentrallevantamentoDAO.Update(model) :
                    tachafaixacentrallevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TachaFaixaCentralLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TachaFaixaCentralLevantamentoViewModel>();
            }
        }

        public List<TachaFaixaCentralLevantamento> Load()
        {
            try
            {
                return tachafaixacentrallevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TachaFaixaCentralLevantamento>();
            }
        }

        public bool Remove(TachaFaixaCentralLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    tachafaixacentrallevantamentoDAO.Delete(model) : false;
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

        public List<TachaFaixaCentralLevantamentoViewModel> ToList(TachaFaixaCentralLevantamentoViewModel model, List<TachaFaixaCentralLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TachaFaixaCentralLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TachaFaixaCentralLevantamentoViewModel>();
            }
        }

        private TachaFaixaCentralLevantamento ViewModelToModel(TachaFaixaCentralLevantamentoViewModel model)
        {
            try
            {
                var retorno = new TachaFaixaCentralLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.tfc_km_inicial = model.tfc_km_inicial;
                retorno.tfc_km_final = model.tfc_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.tfc_data_levantamento = model.tfc_data_levantamento;
                retorno.tfc_extensao = model.tfc_extensao;
                retorno.sht_id = model.sht_id;
                retorno.tfc_quantidade = (int)model.tfc_quantidade;
                retorno.tfc_data_criacao = model.tfc_data_criacao;
                retorno.tfc_id_segmento = (int)model.tfc_id_segmento;
                retorno.tfc_dispositivo = Convert.ToBoolean(model.tfc_dispositivo);
                retorno.tfc_ext_geometria = model.tfc_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new TachaFaixaCentralLevantamento();
            }
        }

        private TachaFaixaCentralLevantamentoViewModel ModelToViewModel(TachaFaixaCentralLevantamento model)
        {
            try
            {
                var retorno = new TachaFaixaCentralLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.tfc_km_inicial = model.tfc_km_inicial;
                retorno.tfc_km_final = model.tfc_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.tfc_data_levantamento = model.tfc_data_levantamento;
                retorno.tfc_extensao = model.tfc_extensao;
                retorno.sht_id = model.sht_id;
                retorno.tfc_quantidade = model.tfc_quantidade;
                retorno.tfc_data_criacao = model.tfc_data_criacao;
                retorno.tfc_id_segmento = model.tfc_id_segmento;
                retorno.tfc_dispositivo = model.tfc_dispositivo.ToString();
                retorno.tfc_ext_geometria = model.tfc_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new TachaFaixaCentralLevantamentoViewModel();
            }
        }
    }

}