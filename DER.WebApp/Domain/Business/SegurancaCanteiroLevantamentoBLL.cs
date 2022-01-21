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
    public class SegurancaCanteiroLevantamentoBLL
    {
        private DerContext context;
        private SegurancaCanteiroLevantamentoDAO segurancacanteirolevantamentoDAO;

        public SegurancaCanteiroLevantamentoBLL()
        {
            context = new DerContext();
            segurancacanteirolevantamentoDAO = new SegurancaCanteiroLevantamentoDAO(context);
        }

        public bool Save(SegurancaCanteiroLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    segurancacanteirolevantamentoDAO.Update(model) :
                    segurancacanteirolevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(SegurancaCanteiroLevantamento model)
        {
            try
            {
                return ExistsById(model.rod_id) ?
                    segurancacanteirolevantamentoDAO.Update(model) :
                    segurancacanteirolevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<SegurancaCanteiroLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<SegurancaCanteiroLevantamentoViewModel>();
            }
        }

        public List<SegurancaCanteiroLevantamento> Load()
        {
            try
            {
                return segurancacanteirolevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<SegurancaCanteiroLevantamento>();
            }
        }

        public bool Remove(SegurancaCanteiroLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    segurancacanteirolevantamentoDAO.Delete(model) : false;
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

        public List<SegurancaCanteiroLevantamentoViewModel> ToList(SegurancaCanteiroLevantamentoViewModel model, List<SegurancaCanteiroLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<SegurancaCanteiroLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<SegurancaCanteiroLevantamentoViewModel>();
            }
        }

        private SegurancaCanteiroLevantamento ViewModelToModel(SegurancaCanteiroLevantamentoViewModel model)
        {
            try
            {
                var retorno = new SegurancaCanteiroLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.scc_km_inicial = model.scc_km_inicial;
                retorno.scc_km_final = model.scc_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.scc_data_levantamento = model.scc_data_levantamento;
                retorno.scc_extensao = model.scc_extensao;
                retorno.est_id = model.est_id;
                retorno.scc_data_criacao = model.scc_data_criacao;
                retorno.scc_id_segmento = model.scc_id_segmento;
                retorno.scc_dispositivo = Convert.ToBoolean(model.scc_dispositivo);
                retorno.scc_ext_geometria = model.scc_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new SegurancaCanteiroLevantamento();
            }
        }

        private SegurancaCanteiroLevantamentoViewModel ModelToViewModel(SegurancaCanteiroLevantamento model)
        {
            try
            {
                var retorno = new SegurancaCanteiroLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.scc_km_inicial = model.scc_km_inicial;
                retorno.scc_km_final = model.scc_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.scc_data_levantamento = model.scc_data_levantamento;
                retorno.scc_extensao = model.scc_extensao;
                retorno.est_id = model.est_id;
                retorno.scc_data_criacao = model.scc_data_criacao;
                retorno.scc_id_segmento = model.scc_id_segmento;
                retorno.scc_dispositivo = model.scc_dispositivo.ToString();
                retorno.scc_ext_geometria = model.scc_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new SegurancaCanteiroLevantamentoViewModel();
            }
        }
    }

}