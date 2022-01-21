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
    public class RocadasLevantamentoBLL
    {
        private DerContext context;
        private RocadasLevantamentoDAO rocadaslevantamentoDAO;

        public RocadasLevantamentoBLL()
        {
            context = new DerContext();
            rocadaslevantamentoDAO = new RocadasLevantamentoDAO(context);
        }

        public bool Save(RocadasLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    rocadaslevantamentoDAO.Update(model) :
                    rocadaslevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(RocadasLevantamento model)
        {
            try
            {
                return ExistsById(model.rod_id) ?
                    rocadaslevantamentoDAO.Update(model) :
                    rocadaslevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<RocadasLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<RocadasLevantamentoViewModel>();
            }
        }

        public List<RocadasLevantamento> Load()
        {
            try
            {
                return rocadaslevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<RocadasLevantamento>();
            }
        }

        public bool Remove(RocadasLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    rocadaslevantamentoDAO.Delete(model) : false;
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

        public List<RocadasLevantamentoViewModel> ToList(RocadasLevantamentoViewModel model, List<RocadasLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<RocadasLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<RocadasLevantamentoViewModel>();
            }
        }

        private RocadasLevantamento ViewModelToModel(RocadasLevantamentoViewModel model)
        {
            try
            {
                var retorno = new RocadasLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.rcd_km_inicial = model.rcd_km_inicial;
                retorno.rcd_km_final = model.rcd_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.rcd_data_levantamento = model.rcd_data_levantamento;
                retorno.rcd_extensao = model.rcd_extensao;
                retorno.rcd_data_criacao = model.rcd_data_criacao;
                retorno.rcd_id_segmento = model.rcd_id_segmento;
                retorno.rcd_dispositivo = Convert.ToBoolean(model.rcd_dispositivo);
                retorno.rcd_ext_geometria = model.rcd_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new RocadasLevantamento();
            }
        }

        private RocadasLevantamentoViewModel ModelToViewModel(RocadasLevantamento model)
        {
            try
            {
                var retorno = new RocadasLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.rcd_km_inicial = model.rcd_km_inicial;
                retorno.rcd_km_final = model.rcd_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.rcd_data_levantamento = model.rcd_data_levantamento;
                retorno.rcd_extensao = model.rcd_extensao;
                retorno.rcd_data_criacao = model.rcd_data_criacao;
                retorno.rcd_id_segmento = model.rcd_id_segmento;
                retorno.rcd_dispositivo = model.rcd_dispositivo.ToString();
                retorno.rcd_ext_geometria = model.rcd_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new RocadasLevantamentoViewModel();
            }
        }
    }

}