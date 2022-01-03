using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class TerceiraFaixaLevantamentoBLL
    {
        private DerContext context;
        private TerceiraFaixaLevantamentoDAO terceirafaixalevantamentoDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            terceirafaixalevantamentoDAO = new TerceiraFaixaLevantamentoDAO(context);
        }

        public bool Save(TerceiraFaixaLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.terceira_faixa_levantamento_id) ?
                    terceirafaixalevantamentoDAO.Update(model) :
                    terceirafaixalevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TerceiraFaixaLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<TerceiraFaixaLevantamentoViewModel>();
            }
        }

        public List<TerceiraFaixaLevantamento> Load()
        {
            try
            {
                return terceirafaixalevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<TerceiraFaixaLevantamento>();
            }
        }

        public bool Remove(TerceiraFaixaLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.terceira_faixa_levantamento_id) ?
                    terceirafaixalevantamentoDAO.Delete(model) : false;
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
                return Load().Any(x => x.terceira_faixa_levantamento_id.Equals(id));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<TerceiraFaixaLevantamentoViewModel> ToList(TerceiraFaixaLevantamentoViewModel model, List<TerceiraFaixaLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<TerceiraFaixaLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<TerceiraFaixaLevantamentoViewModel>();
            }
        }

        private TerceiraFaixaLevantamento ViewModelToModel(TerceiraFaixaLevantamentoViewModel model)
        {
            try
            {
                var retorno = new TerceiraFaixaLevantamento();
                retorno.terceira_faixa_levantamento_id = model.terceira_faixa_levantamento_id;
                retorno.1 = model.1;
                retorno.tfx_km_inicial = model.tfx_km_inicial;
                retorno.tfx_km_final = model.tfx_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.tfx_data_levantamento = model.tfx_data_levantamento;
                retorno.tfx_extensao = model.tfx_extensao;
                retorno.tfx_data_criacao = model.tfx_data_criacao;
                retorno.tfx_id_segmento = model.tfx_id_segmento;
                retorno.tfx_dispositivo = model.tfx_dispositivo;
                retorno.tfx_ext_geometria = model.tfx_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new TerceiraFaixaLevantamento();
            }
        }

        private TerceiraFaixaLevantamentoViewModel ViewModelToModel(TerceiraFaixaLevantamento model)
        {
            try
            {
                var retorno = new TerceiraFaixaLevantamentoViewModel();
                retorno.terceira_faixa_levantamento_id = model.terceira_faixa_levantamento_id;
                retorno.1 = model.1;
                retorno.tfx_km_inicial = model.tfx_km_inicial;
                retorno.tfx_km_final = model.tfx_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.tfx_data_levantamento = model.tfx_data_levantamento;
                retorno.tfx_extensao = model.tfx_extensao;
                retorno.tfx_data_criacao = model.tfx_data_criacao;
                retorno.tfx_id_segmento = model.tfx_id_segmento;
                retorno.tfx_dispositivo = model.tfx_dispositivo;
                retorno.tfx_ext_geometria = model.tfx_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new TerceiraFaixaLevantamento();
            }
        }
    }

}