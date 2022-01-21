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
    public class AcostamentosLevantamentoBLL
    {
        private DerContext context;
        private AcostamentosLevantamentoDAO acostamentoslevantamentoDAO;

        public AcostamentosLevantamentoBLL()
        {
            context = new DerContext();
            acostamentoslevantamentoDAO = new AcostamentosLevantamentoDAO(context);
        }

        public bool Save(AcostamentosLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    acostamentoslevantamentoDAO.Update(model) :
                    acostamentoslevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(AcostamentosLevantamento model)
        {
            try
            {
                return ExistsById(model.rod_id) ?
                    acostamentoslevantamentoDAO.Update(model) :
                    acostamentoslevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<AcostamentosLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<AcostamentosLevantamentoViewModel>();
            }
        }

        public List<AcostamentosLevantamento> Load()
        {
            try
            {
                return acostamentoslevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<AcostamentosLevantamento>();
            }
        }

        public bool Remove(AcostamentosLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    acostamentoslevantamentoDAO.Delete(model) : false;
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

        public List<AcostamentosLevantamentoViewModel> ToList(AcostamentosLevantamentoViewModel model, List<AcostamentosLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<AcostamentosLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<AcostamentosLevantamentoViewModel>();
            }
        }

        private AcostamentosLevantamento ViewModelToModel(AcostamentosLevantamentoViewModel model)
        {
            try
            {
                var retorno = new AcostamentosLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.aco_km_inicial = model.aco_km_inicial;
                retorno.aco_km_final = model.aco_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.aco_data_levantamento = model.aco_data_levantamento;
                retorno.aco_extensao = model.aco_extensao;
                retorno.rev_id = model.rev_id;
                retorno.aco_largura = model.aco_largura;
                retorno.aco_data_criacao = model.aco_data_criacao;
                retorno.aco_id_segmento = model.aco_id_segmento;
                retorno.aco_dispositivo = Convert.ToBoolean(model.aco_dispositivo);
                retorno.aco_ext_geometria = model.aco_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new AcostamentosLevantamento();
            }
        }

        private AcostamentosLevantamentoViewModel ModelToViewModel(AcostamentosLevantamento model)
        {
            try
            {
                var retorno = new AcostamentosLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.aco_km_inicial = model.aco_km_inicial;
                retorno.aco_km_final = model.aco_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.aco_data_levantamento = model.aco_data_levantamento;
                retorno.aco_extensao = model.aco_extensao;
                retorno.rev_id = model.rev_id;
                retorno.aco_largura = model.aco_largura;
                retorno.aco_data_criacao = model.aco_data_criacao;
                retorno.aco_id_segmento = model.aco_id_segmento;
                retorno.aco_dispositivo = model.aco_dispositivo.ToString();
                retorno.aco_ext_geometria = model.aco_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new AcostamentosLevantamentoViewModel();
            }
        }
    }

}