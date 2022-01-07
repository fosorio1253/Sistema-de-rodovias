using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using DER.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DER.WebApp.Domain.Business
{
    public class ApiEdificacoesBLL
    {
        private DerContext context;
        private ApiEdificacoesDAO apiedificacoesDAO;

        public ApiEdificacoesBLL()
        {
            context = new DerContext();
            apiedificacoesDAO = new ApiEdificacoesDAO(context);
        }

        public bool Save(ApiEdificacoesViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    apiedificacoesDAO.Update(model) :
                    apiedificacoesDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ApiEdificacoesViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<ApiEdificacoesViewModel>();
            }
        }

        public List<ApiEdificacoes> Load()
        {
            try
            {
                return apiedificacoesDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<ApiEdificacoes>();
            }
        }

        public bool Remove(ApiEdificacoesViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    apiedificacoesDAO.Delete(model) : false;
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

        public List<ApiEdificacoesViewModel> ToList(ApiEdificacoesViewModel model, List<ApiEdificacoesViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<ApiEdificacoesViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<ApiEdificacoesViewModel>();
            }
        }

        private ApiEdificacoes ViewModelToModel(ApiEdificacoesViewModel model)
        {
            try
            {
                var retorno = new ApiEdificacoes();
                retorno.rod_id = model.rod_id;
                retorno.dis_id = model.dis_id;
                retorno.rtr_id = model.rtr_id;
                retorno.edi_km = model.edi_km;
                retorno.sen_id = model.sen_id;
                retorno.edi_latitude = model.edi_latitude;
                retorno.edi_longitude = model.edi_longitude;
                retorno.edi_foto = model.edi_foto;
                retorno.edi_data_levantamento = model.edi_data_levantamento;
                retorno.edt_id = model.edt_id;
                retorno.edi_data_criacao = model.edi_data_criacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new ApiEdificacoes();
            }
        }

        private ApiEdificacoesViewModel ModelToViewModel(ApiEdificacoes model)
        {
            try
            {
                var retorno = new ApiEdificacoesViewModel();
                retorno.rod_id = model.rod_id;
                retorno.dis_id = model.dis_id;
                retorno.rtr_id = model.rtr_id;
                retorno.edi_km = model.edi_km;
                retorno.sen_id = model.sen_id;
                retorno.edi_latitude = model.edi_latitude;
                retorno.edi_longitude = model.edi_longitude;
                retorno.edi_foto = model.edi_foto;
                retorno.edi_data_levantamento = model.edi_data_levantamento;
                retorno.edt_id = model.edt_id;
                retorno.edi_data_criacao = model.edi_data_criacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new ApiEdificacoesViewModel();
            }
        }
    }

}