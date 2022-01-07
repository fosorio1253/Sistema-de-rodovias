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
    public class ApiDrenagemBLL
    {
        private DerContext context;
        private ApiDrenagemDAO apidrenagemDAO;

        public ApiDrenagemBLL()
        {
            context = new DerContext();
            apidrenagemDAO = new ApiDrenagemDAO(context);
        }

        public bool Save(ApiDrenagemViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    apidrenagemDAO.Update(model) :
                    apidrenagemDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ApiDrenagemViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<ApiDrenagemViewModel>();
            }
        }

        public List<ApiDrenagem> Load()
        {
            try
            {
                return apidrenagemDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<ApiDrenagem>();
            }
        }

        public bool Remove(ApiDrenagemViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    apidrenagemDAO.Delete(model) : false;
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

        public List<ApiDrenagemViewModel> ToList(ApiDrenagemViewModel model, List<ApiDrenagemViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<ApiDrenagemViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<ApiDrenagemViewModel>();
            }
        }

        private ApiDrenagem ViewModelToModel(ApiDrenagemViewModel model)
        {
            try
            {
                var retorno = new ApiDrenagem();
                retorno.rod_id = model.rod_id;
                retorno.dis_id = model.dis_id;
                retorno.rtr_id = model.rtr_id;
                retorno.drp_km = model.drp_km;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.drp_latitude = model.drp_latitude;
                retorno.drp_longitude = model.drp_longitude;
                retorno.drp_foto = model.drp_foto;
                retorno.drp_data_levantamento = model.drp_data_levantamento;
                retorno.drt_id = model.drt_id;
                retorno.drp_data_criacao = model.drp_data_criacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new ApiDrenagem();
            }
        }

        private ApiDrenagemViewModel ModelToViewModel(ApiDrenagem model)
        {
            try
            {
                var retorno = new ApiDrenagemViewModel();
                retorno.rod_id = model.rod_id;
                retorno.dis_id = model.dis_id;
                retorno.rtr_id = model.rtr_id;
                retorno.drp_km = model.drp_km;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.drp_latitude = model.drp_latitude;
                retorno.drp_longitude = model.drp_longitude;
                retorno.drp_foto = model.drp_foto;
                retorno.drp_data_levantamento = model.drp_data_levantamento;
                retorno.drt_id = model.drt_id;
                retorno.drp_data_criacao = model.drp_data_criacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new ApiDrenagemViewModel();
            }
        }
    }

}