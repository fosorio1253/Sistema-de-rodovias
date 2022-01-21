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
    public class SinalFaixaBordoLevantamentoBLL
    {
        private DerContext context;
        private SinalFaixaBordoLevantamentoDAO sinalfaixabordolevantamentoDAO;

        public SinalFaixaBordoLevantamentoBLL()
        {
            context = new DerContext();
            sinalfaixabordolevantamentoDAO = new SinalFaixaBordoLevantamentoDAO(context);
        }

        public bool Save(SinalFaixaBordoLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    sinalfaixabordolevantamentoDAO.Update(model) :
                    sinalfaixabordolevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(SinalFaixaBordoLevantamento model)
        {
            try
            {
                return ExistsById(model.rod_id) ?
                    sinalfaixabordolevantamentoDAO.Update(model) :
                    sinalfaixabordolevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<SinalFaixaBordoLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<SinalFaixaBordoLevantamentoViewModel>();
            }
        }

        public List<SinalFaixaBordoLevantamento> Load()
        {
            try
            {
                return sinalfaixabordolevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<SinalFaixaBordoLevantamento>();
            }
        }

        public bool Remove(SinalFaixaBordoLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    sinalfaixabordolevantamentoDAO.Delete(model) : false;
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

        public List<SinalFaixaBordoLevantamentoViewModel> ToList(SinalFaixaBordoLevantamentoViewModel model, List<SinalFaixaBordoLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<SinalFaixaBordoLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<SinalFaixaBordoLevantamentoViewModel>();
            }
        }

        private SinalFaixaBordoLevantamento ViewModelToModel(SinalFaixaBordoLevantamentoViewModel model)
        {
            try
            {
                var retorno = new SinalFaixaBordoLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.sfb_km_inicial = model.sfb_km_inicial;
                retorno.sfb_km_final = model.sfb_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.sfb_data_levantamento = model.sfb_data_levantamento;
                retorno.sfb_extensao = model.sfb_extensao;
                retorno.sht_id = model.sht_id;
                retorno.sfb_largura_faixa = model.sfb_largura_faixa;
                retorno.sfb_data_criacao = model.sfb_data_criacao;
                retorno.sfb_id_segmento = model.sfb_id_segmento;
                retorno.sfb_dispositivo = Convert.ToBoolean(model.sfb_dispositivo);
                retorno.sfb_ext_geometria = model.sfb_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new SinalFaixaBordoLevantamento();
            }
        }

        private SinalFaixaBordoLevantamentoViewModel ModelToViewModel(SinalFaixaBordoLevantamento model)
        {
            try
            {
                var retorno = new SinalFaixaBordoLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.sfb_km_inicial = model.sfb_km_inicial;
                retorno.sfb_km_final = model.sfb_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.sfb_data_levantamento = model.sfb_data_levantamento;
                retorno.sfb_extensao = (int)model.sfb_extensao;
                retorno.sht_id = model.sht_id;
                retorno.sfb_largura_faixa = (int)model.sfb_largura_faixa;
                retorno.sfb_data_criacao = model.sfb_data_criacao;
                retorno.sfb_id_segmento = model.sfb_id_segmento;
                retorno.sfb_dispositivo = model.sfb_dispositivo.ToString();
                retorno.sfb_ext_geometria = model.sfb_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new SinalFaixaBordoLevantamentoViewModel();
            }
        }
    }

}