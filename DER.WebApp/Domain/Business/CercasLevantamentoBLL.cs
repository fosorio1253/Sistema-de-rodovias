using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class CercasLevantamentoBLL
    {
        private DerContext context;
        private CercasLevantamentoDAO cercaslevantamentoDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            cercaslevantamentoDAO = new CercasLevantamentoDAO(context);
        }

        public bool Save(CercasLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    cercaslevantamentoDAO.Update(model) :
                    cercaslevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CercasLevantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<CercasLevantamentoViewModel>();
            }
        }

        public List<CercasLevantamento> Load()
        {
            try
            {
                return cercaslevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<CercasLevantamento>();
            }
        }

        public bool Remove(CercasLevantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    cercaslevantamentoDAO.Delete(model) : false;
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

        public List<CercasLevantamentoViewModel> ToList(CercasLevantamentoViewModel model, List<CercasLevantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<CercasLevantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<CercasLevantamentoViewModel>();
            }
        }

        private CercasLevantamento ViewModelToModel(CercasLevantamentoViewModel model)
        {
            try
            {
                var retorno = new CercasLevantamento();
                retorno.rod_id = model.rod_id;
                retorno.cer_km_inicial = model.cer_km_inicial;
                retorno.cer_km_final = model.cer_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.cer_data_levantamento = model.cer_data_levantamento;
                retorno.cer_extensao = model.cer_extensao;
                retorno.cer_distancia_eixo = model.cer_distancia_eixo;
                retorno.cer_data_criacao = model.cer_data_criacao;
                retorno.cer_id_segmento = model.cer_id_segmento;
                retorno.cer_dispositivo = model.cer_dispositivo;
                retorno.cer_ext_geometria = model.cer_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new CercasLevantamento();
            }
        }

        private CercasLevantamentoViewModel ViewModelToModel(CercasLevantamento model)
        {
            try
            {
                var retorno = new CercasLevantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.cer_km_inicial = model.cer_km_inicial;
                retorno.cer_km_final = model.cer_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.cer_data_levantamento = model.cer_data_levantamento;
                retorno.cer_extensao = model.cer_extensao;
                retorno.cer_distancia_eixo = model.cer_distancia_eixo;
                retorno.cer_data_criacao = model.cer_data_criacao;
                retorno.cer_id_segmento = model.cer_id_segmento;
                retorno.cer_dispositivo = model.cer_dispositivo;
                retorno.cer_ext_geometria = model.cer_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new CercasLevantamento();
            }
        }
    }

}