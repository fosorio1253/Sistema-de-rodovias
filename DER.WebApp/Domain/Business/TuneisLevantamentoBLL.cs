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
    public class TuneisLevantamentoBLL
    {
        private DerContext context;
        private TuneisLevantamentoDAO tuneislevantamentoDAO;

        public TuneisLevantamentoBLL()
        {
            context = new DerContext();
            tuneislevantamentoDAO = new TuneisLevantamentoDAO(context);
        }

        public bool Save(TuneisLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    tuneislevantamentoDAO.Update(model) :
                    tuneislevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(TuneisLevantamento model)
        {
            try
            {
                return ExistsById(model.rod_id) ?
                    tuneislevantamentoDAO.Update(model) :
                    tuneislevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TuneisLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TuneisLevantamentoViewModel>();
            }
        }

        public List<TuneisLevantamento> Load()
        {
            try
            {
                return tuneislevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TuneisLevantamento>();
            }
        }

        public bool Remove(TuneisLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    tuneislevantamentoDAO.Delete(model) : false;
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

        public List<TuneisLevantamentoViewModel> ToList(TuneisLevantamentoViewModel model, List<TuneisLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TuneisLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TuneisLevantamentoViewModel>();
            }
        }

        private TuneisLevantamento ViewModelToModel(TuneisLevantamentoViewModel model)
        {
            try
            {
                var retorno = new TuneisLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.tun_km_inicial = model.tun_km_inicial;
                retorno.tun_km_final = model.tun_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.tun_data_levantamento = model.tun_data_levantamento;
                retorno.tun_extensao = model.tun_extensao;
                retorno.tun_data_criacao = model.tun_data_criacao;
                retorno.tun_id_segmento = model.tun_id_segmento;
                retorno.tun_dispositivo = Convert.ToBoolean(model.tun_dispositivo);
                retorno.tun_ext_geometria = model.tun_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new TuneisLevantamento();
            }
        }

        private TuneisLevantamentoViewModel ModelToViewModel(TuneisLevantamento model)
        {
            try
            {
                var retorno = new TuneisLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.tun_km_inicial = model.tun_km_inicial;
                retorno.tun_km_final = model.tun_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.tun_data_levantamento = model.tun_data_levantamento;
                retorno.tun_extensao = model.tun_extensao;
                retorno.tun_data_criacao = model.tun_data_criacao;
                retorno.tun_id_segmento = model.tun_id_segmento;
                retorno.tun_dispositivo = model.tun_dispositivo.ToString();
                retorno.tun_ext_geometria = model.tun_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new TuneisLevantamentoViewModel();
            }
        }
    }

}