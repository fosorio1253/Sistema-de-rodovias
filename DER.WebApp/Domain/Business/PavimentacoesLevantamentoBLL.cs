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
    public class PavimentacoesLevantamentoBLL
    {
        private DerContext context;
        private PavimentacoesLevantamentoDAO pavimentacoeslevantamentoDAO;

        public PavimentacoesLevantamentoBLL()
        {
            context = new DerContext();
            pavimentacoeslevantamentoDAO = new PavimentacoesLevantamentoDAO(context);
        }

        public bool Save(PavimentacoesLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    pavimentacoeslevantamentoDAO.Update(model) :
                    pavimentacoeslevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<PavimentacoesLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<PavimentacoesLevantamentoViewModel>();
            }
        }

        public List<PavimentacoesLevantamento> Load()
        {
            try
            {
                return pavimentacoeslevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<PavimentacoesLevantamento>();
            }
        }

        public bool Remove(PavimentacoesLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    pavimentacoeslevantamentoDAO.Delete(model) : false;
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

        public List<PavimentacoesLevantamentoViewModel> ToList(PavimentacoesLevantamentoViewModel model, List<PavimentacoesLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<PavimentacoesLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<PavimentacoesLevantamentoViewModel>();
            }
        }

        private PavimentacoesLevantamento ViewModelToModel(PavimentacoesLevantamentoViewModel model)
        {
            try
            {
                var retorno = new PavimentacoesLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.rpv_km_inicial = model.rpv_km_inicial;
                retorno.rpv_km_final = model.rpv_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.rpv_data_levantamento = model.rpv_data_levantamento;
                retorno.rev_id = model.rev_id;
                retorno.rpv_extensao = model.rpv_extensao;
                retorno.rpv_data_criacao = model.rpv_data_criacao;
                retorno.rpv_id_segmento = model.rpv_id_segmento;
                retorno.rpv_dispositivo = Convert.ToBoolean(model.rpv_dispositivo);
                retorno.rpv_ext_geometria = model.rpv_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new PavimentacoesLevantamento();
            }
        }

        private PavimentacoesLevantamentoViewModel ModelToViewModel(PavimentacoesLevantamento model)
        {
            try
            {
                var retorno = new PavimentacoesLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.rpv_km_inicial = model.rpv_km_inicial;
                retorno.rpv_km_final = model.rpv_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.rpv_data_levantamento = model.rpv_data_levantamento;
                retorno.rev_id = model.rev_id;
                retorno.rpv_extensao = model.rpv_extensao;
                retorno.rpv_data_criacao = model.rpv_data_criacao;
                retorno.rpv_id_segmento = model.rpv_id_segmento;
                retorno.rpv_dispositivo = model.rpv_dispositivo.ToString();
                retorno.rpv_ext_geometria = model.rpv_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new PavimentacoesLevantamentoViewModel();
            }
        }
    }

}