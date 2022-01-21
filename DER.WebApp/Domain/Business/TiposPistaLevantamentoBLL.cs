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
    public class TiposPistaLevantamentoBLL
    {
        private DerContext context;
        private TiposPistaLevantamentoDAO tipospistalevantamentoDAO;

        public TiposPistaLevantamentoBLL()
        {
            context = new DerContext();
            tipospistalevantamentoDAO = new TiposPistaLevantamentoDAO(context);
        }

        public bool Save(TiposPistaLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    tipospistalevantamentoDAO.Update(model) :
                    tipospistalevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(TiposPistaLevantamento model)
        {
            try
            {
                return ExistsById(model.rod_id) ?
                    tipospistalevantamentoDAO.Update(model) :
                    tipospistalevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TiposPistaLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TiposPistaLevantamentoViewModel>();
            }
        }

        public List<TiposPistaLevantamento> Load()
        {
            try
            {
                return tipospistalevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TiposPistaLevantamento>();
            }
        }

        public bool Remove(TiposPistaLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    tipospistalevantamentoDAO.Delete(model) : false;
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

        public List<TiposPistaLevantamentoViewModel> ToList(TiposPistaLevantamentoViewModel model, List<TiposPistaLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TiposPistaLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TiposPistaLevantamentoViewModel>();
            }
        }

        private TiposPistaLevantamento ViewModelToModel(TiposPistaLevantamentoViewModel model)
        {
            try
            {
                var retorno = new TiposPistaLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.rpt_km_inicial = model.rpt_km_inicial;
                retorno.rpt_km_final = model.rpt_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.rpt_data_levantamento = model.rpt_data_levantamento;
                retorno.rpt_extensao = model.rpt_extensao;
                retorno.ptp_id = model.ptp_id;
                retorno.rpt_data_criacao = model.rpt_data_criacao;
                retorno.rpt_id_segmento = model.rpt_id_segmento;
                retorno.rpt_dispositivo = Convert.ToBoolean(model.rpt_dispositivo);
                retorno.rpt_ext_geometria = model.rpt_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new TiposPistaLevantamento();
            }
        }

        private TiposPistaLevantamentoViewModel ModelToViewModel(TiposPistaLevantamento model)
        {
            try
            {
                var retorno = new TiposPistaLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.rpt_km_inicial = model.rpt_km_inicial;
                retorno.rpt_km_final = model.rpt_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.rpt_data_levantamento = model.rpt_data_levantamento;
                retorno.rpt_extensao = model.rpt_extensao;
                retorno.ptp_id = model.ptp_id;
                retorno.rpt_data_criacao = model.rpt_data_criacao;
                retorno.rpt_id_segmento = model.rpt_id_segmento;
                retorno.rpt_dispositivo = model.rpt_dispositivo.ToString();
                retorno.rpt_ext_geometria = model.rpt_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new TiposPistaLevantamentoViewModel();
            }
        }
    }

}