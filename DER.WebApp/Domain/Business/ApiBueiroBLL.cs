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
    public class ApiBueiroBLL
    {
        private DerContext context;
        private ApiBueiroDAO apibueiroDAO;

        public ApiBueiroBLL()
        {
            context = new DerContext();
            apibueiroDAO = new ApiBueiroDAO(context);
        }

        public bool Save(ApiBueiroViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    apibueiroDAO.Update(model) :
                    apibueiroDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<ApiBueiroViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<ApiBueiroViewModel>();
            }
        }

        public List<ApiBueiro> Load()
        {
            try
            {
                return apibueiroDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<ApiBueiro>();
            }
        }

        public bool Remove(ApiBueiroViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    apibueiroDAO.Delete(model) : false;
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

        public List<ApiBueiroViewModel> ToList(ApiBueiroViewModel model, List<ApiBueiroViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<ApiBueiroViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<ApiBueiroViewModel>();
            }
        }

        private ApiBueiro ViewModelToModel(ApiBueiroViewModel model)
        {
            try
            {
                var retorno = new ApiBueiro();
                retorno.rod_id = model.rod_id;
                retorno.dis_id = model.dis_id;
                retorno.rtr_id = model.rtr_id;
                retorno.ace_km = model.ace_km;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.ace_latitude = model.ace_latitude;
                retorno.ace_longitude = model.ace_longitude;
                retorno.ace_foto = model.ace_foto;
                retorno.ace_data_levantamento = model.ace_data_levantamento;
                retorno.stp_id = model.stp_id;
                retorno.ace_largura = model.ace_largura;
                retorno.ace_data_criacao = model.ace_data_criacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new ApiBueiro();
            }
        }

        private ApiBueiroViewModel ModelToViewModel(ApiBueiro model)
        {
            try
            {
                var retorno = new ApiBueiroViewModel();
                retorno.rod_id = model.rod_id;
                retorno.dis_id = model.dis_id;
                retorno.rtr_id = model.rtr_id;
                retorno.ace_km = model.ace_km;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.ace_latitude = model.ace_latitude;
                retorno.ace_longitude = model.ace_longitude;
                retorno.ace_foto = model.ace_foto;
                retorno.ace_data_levantamento = model.ace_data_levantamento;
                retorno.stp_id = model.stp_id;
                retorno.ace_largura = model.ace_largura;
                retorno.ace_data_criacao = model.ace_data_criacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new ApiBueiroViewModel();
            }
        }
    }

}