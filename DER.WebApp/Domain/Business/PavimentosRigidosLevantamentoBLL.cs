using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class PavimentosRigidosLevantamentoBLL
    {
        private DerContext context;
        private PavimentosRigidosLevantamentoDAO pavimentosrigidoslevantamentoDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            pavimentosrigidoslevantamentoDAO = new PavimentosRigidosLevantamentoDAO(context);
        }

        public bool Save(PavimentosRigidosLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    pavimentosrigidoslevantamentoDAO.Update(model) :
                    pavimentosrigidoslevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<PavimentosRigidosLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<PavimentosRigidosLevantamentoViewModel>();
            }
        }

        public List<PavimentosRigidosLevantamento> Load()
        {
            try
            {
                return pavimentosrigidoslevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<PavimentosRigidosLevantamento>();
            }
        }

        public bool Remove(PavimentosRigidosLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    pavimentosrigidoslevantamentoDAO.Delete(model) : false;
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

        public List<PavimentosRigidosLevantamentoViewModel> ToList(PavimentosRigidosLevantamentoViewModel model, List<PavimentosRigidosLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<PavimentosRigidosLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<PavimentosRigidosLevantamentoViewModel>();
            }
        }

        private PavimentosRigidosLevantamento ViewModelToModel(PavimentosRigidosLevantamentoViewModel model)
        {
            try
            {
                var retorno = new PavimentosRigidosLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.pvr_km_inicial = model.pvr_km_inicial;
                retorno.pvr_km_final = model.pvr_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.pvr_data_levantamento = model.pvr_data_levantamento;
                retorno.pvr_extensao = model.pvr_extensao;
                retorno.rev_id = model.rev_id;
                retorno.pvr_data_criacao = model.pvr_data_criacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new PavimentosRigidosLevantamento();
            }
        }

        private PavimentosRigidosLevantamentoViewModel ViewModelToModel(PavimentosRigidosLevantamento model)
        {
            try
            {
                var retorno = new PavimentosRigidosLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.pvr_km_inicial = model.pvr_km_inicial;
                retorno.pvr_km_final = model.pvr_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.pvr_data_levantamento = model.pvr_data_levantamento;
                retorno.pvr_extensao = model.pvr_extensao;
                retorno.rev_id = model.rev_id;
                retorno.pvr_data_criacao = model.pvr_data_criacao;

                return retorno;
            }
            catch (Exception e)
            {
                return new PavimentosRigidosLevantamento();
            }
        }
    }

}