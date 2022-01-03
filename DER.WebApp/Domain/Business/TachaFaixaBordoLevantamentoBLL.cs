using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class TachaFaixaBordoLevantamentoBLL
    {
        private DerContext context;
        private TachaFaixaBordoLevantamentoDAO tachafaixabordolevantamentoDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            tachafaixabordolevantamentoDAO = new TachaFaixaBordoLevantamentoDAO(context);
        }

        public bool Save(TachaFaixaBordoLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    tachafaixabordolevantamentoDAO.Update(model) :
                    tachafaixabordolevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TachaFaixaBordoLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TachaFaixaBordoLevantamentoViewModel>();
            }
        }

        public List<TachaFaixaBordoLevantamento> Load()
        {
            try
            {
                return tachafaixabordolevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TachaFaixaBordoLevantamento>();
            }
        }

        public bool Remove(TachaFaixaBordoLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    tachafaixabordolevantamentoDAO.Delete(model) : false;
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

        public List<TachaFaixaBordoLevantamentoViewModel> ToList(TachaFaixaBordoLevantamentoViewModel model, List<TachaFaixaBordoLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TachaFaixaBordoLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TachaFaixaBordoLevantamentoViewModel>();
            }
        }

        private TachaFaixaBordoLevantamento ViewModelToModel(TachaFaixaBordoLevantamentoViewModel model)
        {
            try
            {
                var retorno = new TachaFaixaBordoLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.tfb_km_inicial = model.tfb_km_inicial;
                retorno.tfb_km_final = model.tfb_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.tfb_data_levantamento = model.tfb_data_levantamento;
                retorno.tfb_extensao = model.tfb_extensao;
                retorno.sht_id = model.sht_id;
                retorno.tfb_quantidade = model.tfb_quantidade;
                retorno.tfb_data_criacao = model.tfb_data_criacao;
                retorno.tfb_id_segmento = model.tfb_id_segmento;
                retorno.tfb_dispositivo = model.tfb_dispositivo;
                retorno.tfb_ext_geometria = model.tfb_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new TachaFaixaBordoLevantamento();
            }
        }

        private TachaFaixaBordoLevantamentoViewModel ViewModelToModel(TachaFaixaBordoLevantamento model)
        {
            try
            {
                var retorno = new TachaFaixaBordoLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.tfb_km_inicial = model.tfb_km_inicial;
                retorno.tfb_km_final = model.tfb_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.tfb_data_levantamento = model.tfb_data_levantamento;
                retorno.tfb_extensao = model.tfb_extensao;
                retorno.sht_id = model.sht_id;
                retorno.tfb_quantidade = model.tfb_quantidade;
                retorno.tfb_data_criacao = model.tfb_data_criacao;
                retorno.tfb_id_segmento = model.tfb_id_segmento;
                retorno.tfb_dispositivo = model.tfb_dispositivo;
                retorno.tfb_ext_geometria = model.tfb_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new TachaFaixaBordoLevantamento();
            }
        }
    }

}