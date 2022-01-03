using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class ApiDispositivoBLL
    {
        private DerContext context;
        private ApiDispositivoDAO apidispositivoDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            apidispositivoDAO = new ApiDispositivoDAO(context);
        }

        public bool Save(ApiDispositivoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    apidispositivoDAO.Update(model) :
                    apidispositivoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ApiDispositivoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<ApiDispositivoViewModel>();
            }
        }

        public List<ApiDispositivo> Load()
        {
            try
            {
                return apidispositivoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<ApiDispositivo>();
            }
        }

        public bool Remove(ApiDispositivoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    apidispositivoDAO.Delete(model) : false;
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

        public List<ApiDispositivoViewModel> ToList(ApiDispositivoViewModel model, List<ApiDispositivoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<ApiDispositivoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<ApiDispositivoViewModel>();
            }
        }

        private ApiDispositivo ViewModelToModel(ApiDispositivoViewModel model)
        {
            try
            {
                var retorno = new ApiDispositivo();
                retorno.rod_id = model.rod_id;
                retorno.dis_id = model.dis_id;
                retorno.rtr_id = model.rtr_id;
                retorno.dis_km = model.dis_km;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.dis_latitude = model.dis_latitude;
                retorno.dis_longitude = model.dis_longitude;
                retorno.dis_foto = model.dis_foto;
                retorno.dis_data_levantamento = model.dis_data_levantamento;
                retorno.dit_id = model.dit_id;
                retorno.dis_data_criacao = model.dis_data_criacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new ApiDispositivo();
            }
        }

        private ApiDispositivoViewModel ViewModelToModel(ApiDispositivo model)
        {
            try
            {
                var retorno = new ApiDispositivoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.dis_id = model.dis_id;
                retorno.rtr_id = model.rtr_id;
                retorno.dis_km = model.dis_km;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.dis_latitude = model.dis_latitude;
                retorno.dis_longitude = model.dis_longitude;
                retorno.dis_foto = model.dis_foto;
                retorno.dis_data_levantamento = model.dis_data_levantamento;
                retorno.dit_id = model.dit_id;
                retorno.dis_data_criacao = model.dis_data_criacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new ApiDispositivo();
            }
        }
    }

}