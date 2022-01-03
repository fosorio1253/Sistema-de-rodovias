using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class SegurancaBordoLevantamentoBLL
    {
        private DerContext context;
        private SegurancaBordoLevantamentoDAO segurancabordolevantamentoDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            segurancabordolevantamentoDAO = new SegurancaBordoLevantamentoDAO(context);
        }

        public bool Save(SegurancaBordoLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    segurancabordolevantamentoDAO.Update(model) :
                    segurancabordolevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<SegurancaBordoLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<SegurancaBordoLevantamentoViewModel>();
            }
        }

        public List<SegurancaBordoLevantamento> Load()
        {
            try
            {
                return segurancabordolevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<SegurancaBordoLevantamento>();
            }
        }

        public bool Remove(SegurancaBordoLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    segurancabordolevantamentoDAO.Delete(model) : false;
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

        public List<SegurancaBordoLevantamentoViewModel> ToList(SegurancaBordoLevantamentoViewModel model, List<SegurancaBordoLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<SegurancaBordoLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<SegurancaBordoLevantamentoViewModel>();
            }
        }

        private SegurancaBordoLevantamento ViewModelToModel(SegurancaBordoLevantamentoViewModel model)
        {
            try
            {
                var retorno = new SegurancaBordoLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.sbd_km_inicial = model.sbd_km_inicial;
                retorno.sbd_km_final = model.sbd_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.sbd_data_levantamento = model.sbd_data_levantamento;
                retorno.sbd_extensao = model.sbd_extensao;
                retorno.est_id = model.est_id;
                retorno.sbd_data_criacao = model.sbd_data_criacao;
                retorno.sbd_id_segmento = model.sbd_id_segmento;
                retorno.sbd_dispositivo = model.sbd_dispositivo;
                retorno.sbd_ext_geometria = model.sbd_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new SegurancaBordoLevantamento();
            }
        }

        private SegurancaBordoLevantamentoViewModel ViewModelToModel(SegurancaBordoLevantamento model)
        {
            try
            {
                var retorno = new SegurancaBordoLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.sbd_km_inicial = model.sbd_km_inicial;
                retorno.sbd_km_final = model.sbd_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.sbd_data_levantamento = model.sbd_data_levantamento;
                retorno.sbd_extensao = model.sbd_extensao;
                retorno.est_id = model.est_id;
                retorno.sbd_data_criacao = model.sbd_data_criacao;
                retorno.sbd_id_segmento = model.sbd_id_segmento;
                retorno.sbd_dispositivo = model.sbd_dispositivo;
                retorno.sbd_ext_geometria = model.sbd_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new SegurancaBordoLevantamento();
            }
        }
    }

}