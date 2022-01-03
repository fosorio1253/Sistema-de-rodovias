using DER.WebApp.Domain.Models;
using DER.WebApp.Infra.DAL;
using DER.WebApp.Infra.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DER.WebApp.Domain.Business
{
    public class DominioCircunscricaoBLL
    {
        private DerContext context;
        private DominioCircunscricaoDAO dominiocircunscricaoDAO;

        public InadimplentesBLL()
        {
            context = new DerContext();
            dominiocircunscricaoDAO = new DominioCircunscricaoDAO(context);
        }

        public bool Save(DominioCircunscricaoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);

                return ExistsById(model.rod_id) ?
                    dominiocircunscricaoDAO.Update(model) :
                    dominiocircunscricaoDAO.Inserir(model);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<DominioCircunscricaoViewModel> LoadView()
        {
            try
            {
                return Load().Select(x => ModelToViewModel(x)).ToList();
            }
            catch (Exception e)
            {
                return new List<DominioCircunscricaoViewModel>();
            }
        }

        public List<DominioCircunscricao> Load()
        {
            try
            {
                return dominiocircunscricaoDAO.ObtemTodos().ToList();
            }
            catch (Exception e)
            {
                return new List<DominioCircunscricao>();
            }
        }

        public bool Remove(DominioCircunscricaoViewModel viewModel)
        {
            try
            {
                var model = ViewModelToModel(viewModel);
                return ExistsById(model.rod_id) ?
                    dominiocircunscricaoDAO.Delete(model) : false;
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

        public List<DominioCircunscricaoViewModel> ToList(DominioCircunscricaoViewModel model, List<DominioCircunscricaoViewModel> lmodel = null)
        {
            try
            {
                if (lmodel == null) lmodel = new List<DominioCircunscricaoViewModel>();
                lmodel.Add(model);
                return lmodel;
            }
            catch (Exception e)
            {
                return new List<DominioCircunscricaoViewModel>();
            }
        }

        private DominioCircunscricao ViewModelToModel(DominioCircunscricaoViewModel model)
        {
            try
            {
                var retorno = new DominioCircunscricao();
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

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioCircunscricao();
            }
        }

        private DominioCircunscricaoViewModel ViewModelToModel(DominioCircunscricao model)
        {
            try
            {
                var retorno = new DominioCircunscricaoViewModel();
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

                return retorno;
            }
            catch (Exception e)
            {
                return new DominioCircunscricao();
            }
        }
    }

}