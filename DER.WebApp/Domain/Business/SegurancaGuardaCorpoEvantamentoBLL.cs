using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class SegurancaGuardaCorpoEvantamentoBLL
    {
        private DerContext context;
        private SegurancaGuardaCorpoEvantamentoDAO segurancaguardacorpoevantamentoDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            segurancaguardacorpoevantamentoDAO = new SegurancaGuardaCorpoEvantamentoDAO(context);
        }

        public bool Save(SegurancaGuardaCorpoEvantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    segurancaguardacorpoevantamentoDAO.Update(model) :
                    segurancaguardacorpoevantamentoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<SegurancaGuardaCorpoEvantamentoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<SegurancaGuardaCorpoEvantamentoViewModel>();
            }
        }

        public List<SegurancaGuardaCorpoEvantamento> Load()
        {
            try
            {
                return segurancaguardacorpoevantamentoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<SegurancaGuardaCorpoEvantamento>();
            }
        }

        public bool Remove(SegurancaGuardaCorpoEvantamentoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    segurancaguardacorpoevantamentoDAO.Delete(model) : false;
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

        public List<SegurancaGuardaCorpoEvantamentoViewModel> ToList(SegurancaGuardaCorpoEvantamentoViewModel model, List<SegurancaGuardaCorpoEvantamentoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<SegurancaGuardaCorpoEvantamentoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<SegurancaGuardaCorpoEvantamentoViewModel>();
            }
        }

        private SegurancaGuardaCorpoEvantamento ViewModelToModel(SegurancaGuardaCorpoEvantamentoViewModel model)
        {
            try
            {
                var retorno = new SegurancaGuardaCorpoEvantamento();
                retorno.rod_id = model.rod_id;
                retorno.sgc_km_inicial = model.sgc_km_inicial;
                retorno.sgc_km_final = model.sgc_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.sgc_data_levantamento = model.sgc_data_levantamento;
                retorno.sgc_extensao = model.sgc_extensao;
                retorno.mat_id = model.mat_id;
                retorno.sgc_data_criacao = model.sgc_data_criacao;
                retorno.sgc_id_segmento = model.sgc_id_segmento;
                retorno.sgc_dispositivo = model.sgc_dispositivo;
                retorno.sgc_ext_geometria = model.sgc_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new SegurancaGuardaCorpoEvantamento();
            }
        }

        private SegurancaGuardaCorpoEvantamentoViewModel ViewModelToModel(SegurancaGuardaCorpoEvantamento model)
        {
            try
            {
                var retorno = new SegurancaGuardaCorpoEvantamentoViewModel();
                retorno.rod_id = model.rod_id;
                retorno.sgc_km_inicial = model.sgc_km_inicial;
                retorno.sgc_km_final = model.sgc_km_final;
                retorno.sen_id = model.sen_id;
                retorno.reg_id = model.reg_id;
                retorno.sgc_data_levantamento = model.sgc_data_levantamento;
                retorno.sgc_extensao = model.sgc_extensao;
                retorno.mat_id = model.mat_id;
                retorno.sgc_data_criacao = model.sgc_data_criacao;
                retorno.sgc_id_segmento = model.sgc_id_segmento;
                retorno.sgc_dispositivo = model.sgc_dispositivo;
                retorno.sgc_ext_geometria = model.sgc_ext_geometria;

                return retorno;
            }
            catch (Exception e)
            {
                return new SegurancaGuardaCorpoEvantamento();
            }
        }
    }

}