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
    public class SegurancaGuardaCorpoLevantamentoBLL
    {
        private DerContext context;
        private SegurancaGuardaCorpoLevantamentoDAO SegurancaGuardaCorpoLevantamentoDAO;

        public SegurancaGuardaCorpoLevantamentoBLL()
        {
            context = new DerContext();
            SegurancaGuardaCorpoLevantamentoDAO = new SegurancaGuardaCorpoLevantamentoDAO(context);
        }

        public bool Save(SegurancaGuardaCorpoLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    SegurancaGuardaCorpoLevantamentoDAO.Update(model) :
                    SegurancaGuardaCorpoLevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Save(SegurancaGuardaCorpoLevantamento model)
        {
            try
            {
                return ExistsById(model.rod_id) ?
                    SegurancaGuardaCorpoLevantamentoDAO.Update(model) :
                    SegurancaGuardaCorpoLevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<SegurancaGuardaCorpoLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<SegurancaGuardaCorpoLevantamentoViewModel>();
            }
        }

        public List<SegurancaGuardaCorpoLevantamento> Load()
        {
            try
            {
                return SegurancaGuardaCorpoLevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<SegurancaGuardaCorpoLevantamento>();
            }
        }

        public bool Remove(SegurancaGuardaCorpoLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    SegurancaGuardaCorpoLevantamentoDAO.Delete(model) : false;
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

        public List<SegurancaGuardaCorpoLevantamentoViewModel> ToList(SegurancaGuardaCorpoLevantamentoViewModel model, List<SegurancaGuardaCorpoLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<SegurancaGuardaCorpoLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<SegurancaGuardaCorpoLevantamentoViewModel>();
            }
        }

        private SegurancaGuardaCorpoLevantamento ViewModelToModel(SegurancaGuardaCorpoLevantamentoViewModel model)
        {
            try
            {
                var retorno = new SegurancaGuardaCorpoLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.sgc_km_inicial = model.sgc_km_inicial;
                retorno.sgc_km_final = model.sgc_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.sgc_data_levantamento = model.sgc_data_levantamento;
                retorno.sgc_extensao = model.sgc_extensao;
                retorno.mat_id = model.mat_id;
                retorno.sgc_data_criacao = model.sgc_data_criacao;
                retorno.sgc_id_segmento = model.sgc_id_segmento;
                retorno.sgc_dispositivo = Convert.ToBoolean(model.sgc_dispositivo);
                retorno.sgc_ext_geometria = model.sgc_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new SegurancaGuardaCorpoLevantamento();
            }
        }

        private SegurancaGuardaCorpoLevantamentoViewModel ModelToViewModel(SegurancaGuardaCorpoLevantamento model)
        {
            try
            {
                var retorno = new SegurancaGuardaCorpoLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.sgc_km_inicial = model.sgc_km_inicial;
                retorno.sgc_km_final = model.sgc_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.sgc_data_levantamento = model.sgc_data_levantamento;
                retorno.sgc_extensao = model.sgc_extensao;
                retorno.mat_id = model.mat_id;
                retorno.sgc_data_criacao = model.sgc_data_criacao;
                retorno.sgc_id_segmento = model.sgc_id_segmento;
                retorno.sgc_dispositivo = model.sgc_dispositivo.ToString();
                retorno.sgc_ext_geometria = model.sgc_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new SegurancaGuardaCorpoLevantamentoViewModel();
            }
        }
    }

}