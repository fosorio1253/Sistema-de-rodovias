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
    public class AreasGramadasLevantamentoBLL
    {
        private DerContext context;
        private AreasGramadasLevantamentoDAO areasgramadaslevantamentoDAO;

        public AreasGramadasLevantamentoBLL()
        {
            context = new DerContext();
            areasgramadaslevantamentoDAO = new AreasGramadasLevantamentoDAO(context);
        }

        public bool Save(AreasGramadasLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    areasgramadaslevantamentoDAO.Update(model) :
                    areasgramadaslevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<AreasGramadasLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<AreasGramadasLevantamentoViewModel>();
            }
        }

        public List<AreasGramadasLevantamento> Load()
        {
            try
            {
                return areasgramadaslevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<AreasGramadasLevantamento>();
            }
        }

        public bool Remove(AreasGramadasLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    areasgramadaslevantamentoDAO.Delete(model) : false;
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

        public List<AreasGramadasLevantamentoViewModel> ToList(AreasGramadasLevantamentoViewModel model, List<AreasGramadasLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<AreasGramadasLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<AreasGramadasLevantamentoViewModel>();
            }
        }

        private AreasGramadasLevantamento ViewModelToModel(AreasGramadasLevantamentoViewModel model)
        {
            try
            {
                var retorno = new AreasGramadasLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.agr_km_inicial = model.agr_km_inicial;
                retorno.agr_km_final = model.agr_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.agr_data_levantamento = model.agr_data_levantamento;
                retorno.agr_extensao = model.agr_extensao;
                retorno.agr_largura = model.agr_largura;
                retorno.agr_id_segmento = model.agr_id_segmento;
                retorno.agr_dispositivo = Convert.ToBoolean(model.agr_dispositivo);
                retorno.agr_ext_geometria = model.agr_ext_geometria;
                retorno.agr_data_criacao = model.agr_data_criacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new AreasGramadasLevantamento();
            }
        }

        private AreasGramadasLevantamentoViewModel ModelToViewModel(AreasGramadasLevantamento model)
        {
            try
            {
                var retorno = new AreasGramadasLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.agr_km_inicial = model.agr_km_inicial;
                retorno.agr_km_final = model.agr_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.agr_data_levantamento = model.agr_data_levantamento;
                retorno.agr_extensao = model.agr_extensao;
                retorno.agr_largura = model.agr_largura;
                retorno.agr_id_segmento = model.agr_id_segmento;
                retorno.agr_dispositivo = model.agr_dispositivo.ToString();
                retorno.agr_ext_geometria = model.agr_ext_geometria;
                retorno.agr_data_criacao = model.agr_data_criacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new AreasGramadasLevantamentoViewModel();
            }
        }
    }

}